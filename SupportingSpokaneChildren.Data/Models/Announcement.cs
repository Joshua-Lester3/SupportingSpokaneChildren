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
            && !file.Name.EndsWith(".png") && !file.Name.EndsWith(".jpeg")) return "File must be in JPEG or PNG format.";
        var splitName = file.Name.Split(".");
        string fileFormat = splitName[splitName.Length - 1];

        using MemoryStream uploadFileStream = new MemoryStream(await file.Content.ReadAllBytesAsync());
        BlobId = await service.Upload(BlobStorageService.Container.Announcements, uploadFileStream, fileFormat);
        db.SaveChanges();

        return true;
    }

    [Coalesce]
    public string? UpdateImageUri(AppDbContext db, [Inject] BlobStorageService service)
    {
        if (BlobId is not null)
        {
            ImageUri = service.GetImageUri(BlobId);
        }
        else
        {
            ImageUri = null;
        }
        db.SaveChanges();
        return ImageUri;
    }

    public class BlobLoader : StandardDataSource<Announcement, AppDbContext>
    {
        public BlobStorageService _Service { get; set; }
        public BlobLoader(CrudContext<AppDbContext> context, BlobStorageService service) : base(context) { _Service = service; }

        public override IQueryable<Announcement> GetQuery(IDataSourceParameters parameters)
        {
            var list = base.GetQuery(parameters).ToList();
            foreach (var item in list)
            {
                item.UpdateImageUri(Db, _Service);
            }
            return base.GetQuery(parameters);
        }

        public override async Task<ItemResult<Announcement>> GetItemAsync(object id, IDataSourceParameters parameters)
        {
            var result = await base.GetItemAsync(id, parameters);
            if (result.Object is not null)
            {
                result.Object.UpdateImageUri(Db, _Service);
            }
            return result;
        }
    }
}
