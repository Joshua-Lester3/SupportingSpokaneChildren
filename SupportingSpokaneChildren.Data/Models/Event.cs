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

    public class EventLoader : StandardDataSource<Event, AppDbContext>
    {
        public EventLoader(CrudContext<AppDbContext> context) : base(context) { }

        public override IQueryable<Event> GetQuery(IDataSourceParameters parameters)
        {
            return base.GetQuery(parameters);
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
