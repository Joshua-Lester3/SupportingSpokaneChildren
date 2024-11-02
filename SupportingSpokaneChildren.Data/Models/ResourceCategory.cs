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
public class ResourceCategory
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string ResourceCategoryId { get; init; } = null!;
    [Required]
    [ListText]
    public required string CategoryName { get; set; }
}
