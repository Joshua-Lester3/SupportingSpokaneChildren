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
}
