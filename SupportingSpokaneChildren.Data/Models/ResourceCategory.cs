using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportingSpokaneChildren.Data.Models;

[Create(nameof(Permission.Admin))]
[Read(PermissionLevel = SecurityPermissionLevels.AllowAll)]
[Edit(nameof(Permission.Admin))]
[Delete(nameof(Permission.Admin))]
public class ResourceCategory
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string ResourceCategoryId { get; init; } = null!;
    [Required]
    [ListText]
    public required string CategoryName { get; set; }
}
