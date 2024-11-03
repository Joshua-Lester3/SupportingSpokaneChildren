using IntelliTect.Coalesce.Api.Controllers;
using SupportingSpokaneChildren.Data.Blob;

namespace SupportingSpokaneChildren.Data.Models;

[Create(nameof(Permission.Admin))]
[Read(PermissionLevel = SecurityPermissionLevels.AllowAll)]
[Edit(nameof(Permission.Admin))]
[Delete(nameof(Permission.Admin))]
public class Announcement
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string AnnouncementId { get; init; } = null!;
    [Required]
    [ListText]
    public required string Title { get; set; }
    public string? Description { get; set; }
    [Hidden(HiddenAttribute.Areas.Edit)]
    public DateTime DatePosted { get; private set; }
    [Hidden(HiddenAttribute.Areas.All)]
    public string? ImageUri { get; set; }
    [InternalUse]
    public string? BlobId { get; set; }

    [Coalesce]
    public class AnnouncementBehaviors : StandardBehaviors<Announcement, AppDbContext>
    {
        public AnnouncementBehaviors(CrudContext<AppDbContext> context) : base(context) { }

        public override ItemResult BeforeSave(SaveKind kind, Announcement? oldItem, Announcement item)
        {
            item.DatePosted = DateTime.UtcNow.AddHours(-7);
            return base.BeforeSave(kind, oldItem, item);
        }
    }

    [Coalesce]
    public async Task<ItemResult> UploadImageAsync(AppDbContext db, [Inject] BlobStorageService service, IFile file)
    {
        ArgumentNullException.ThrowIfNull(file.Content);

        if (file.Name is null) return "File name cannot be null.";
        if (!file.Name.EndsWith(".jpg")
            && !file.Name.EndsWith(".png")) return "File must be in JPEG or PNG format.";
        var splitName = file.Name.Split(".");
        string fileFormat = splitName[splitName.Length - 1];

        using MemoryStream uploadFileStream = new MemoryStream(await file.Content.ReadAllBytesAsync());
        BlobId = await service.Upload(BlobStorageService.Container.Announcements, uploadFileStream, fileFormat);
        db.SaveChanges();

        return true;
    }
}
