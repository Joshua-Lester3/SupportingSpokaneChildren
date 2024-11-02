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
    public DateTime DateTime { get; set; }
    [Required]
    public required string Location { get; set; }
    public string? Link { get; set; }
    [Hidden(HiddenAttribute.Areas.All)]
    public string? ImageUri { get; set; }
    [InternalUse]
    public string? BlobId { get; set; }
}
