using IntelliTect.Coalesce.Api.Controllers;
using SupportingSpokaneChildren.Data.Blob;

namespace SupportingSpokaneChildren.Data.Models;

[Create(nameof(Permission.Admin))]
[Read(PermissionLevel = SecurityPermissionLevels.AllowAll)]
[Edit(nameof(Permission.Admin))]
[Delete(nameof(Permission.Admin))]
public class Event
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string EventId { get; init; } = null!;
    [Required]
    [ListText]
    public required string EventName { get; set; }
    public string? Description { get; set; }
    public DateTimeOffset DateTime { get; set; }
    [Required]
    public required string Location { get; set; }
    public string? Link { get; set; }
    [Hidden(HiddenAttribute.Areas.All)]
    public string? ImageUri { get; set; }
    [InternalUse]
    public string? BlobId { get; set; }

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
        BlobId = await service.Upload(BlobStorageService.Container.Events, uploadFileStream, fileFormat);
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

    public class BlobLoader : StandardDataSource<Event, AppDbContext>
    {
        public BlobStorageService _Service { get; set; }
        public BlobLoader(CrudContext<AppDbContext> context, BlobStorageService service) : base(context) { _Service = service; }

        public override IQueryable<Event> GetQuery(IDataSourceParameters parameters)
        {
            var list = base.GetQuery(parameters).ToList();
            foreach (var item in list)
            {
                item.UpdateImageUri(Db, _Service);
            }
            return base.GetQuery(parameters).Where(e => e.DateTime > DateTimeOffset.UtcNow);
        }

        public override async Task<ItemResult<Event>> GetItemAsync(object id, IDataSourceParameters parameters)
        {
            string newId = (string)id;
            var e = await Db.Events.FirstOrDefaultAsync(e => e.EventId == newId);
            if (e is not null)
            {
                e.UpdateImageUri(Db, _Service);
            }
            return await base.GetItemAsync(id, parameters);
        }
    }

    [Coalesce]
    public class EventBehaviors : StandardBehaviors<Event, AppDbContext>
    {
        public EventBehaviors(CrudContext<AppDbContext> context) : base(context) { }

        public override ItemResult BeforeSave(SaveKind kind, Event? oldItem, Event item)
        {
            item.DateTime.AddHours(7);
            return base.BeforeSave(kind, oldItem, item);
        }
    }
}
