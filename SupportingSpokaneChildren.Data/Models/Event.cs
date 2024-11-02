using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportingSpokaneChildren.Data.Models;

[Create(Roles = Roles.Moderator)]
[Read(PermissionLevel = SecurityPermissionLevels.AllowAll)]
[Edit(Roles = Roles.Moderator)]
[Delete(Roles = Roles.Moderator)]
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
