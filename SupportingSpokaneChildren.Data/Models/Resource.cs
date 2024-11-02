namespace SupportingSpokaneChildren.Data.Models;

[Create(Roles = Roles.Moderator)]
[Read(PermissionLevel = SecurityPermissionLevels.AllowAll)]
[Edit(Roles = Roles.Moderator)]
[Delete(Roles = Roles.Moderator)]
public class Resource
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string ResourceId { get; init; } = null!;
    [Required]
    [ListText]
    public required string Name { get; set; }
    public string? Website {  get; set; }
    public string? Phone {  get; set; }
    public string? Address { get; set; }
    public string? Email { get; set; }
    [Required]
    public string ResourceCategoryId { get; set; } = null!;
    public ResourceCategory? ResourceCategory { get; set; }
}
