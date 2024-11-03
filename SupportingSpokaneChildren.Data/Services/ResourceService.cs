namespace SupportingSpokaneChildren.Data.Services;

public class ResourceService
{
    public AppDbContext Db { get; set; }
    public ResourceService(AppDbContext db)
    {
        Db = db;
    }

    [Coalesce]
    public List<List<Resource>> GetResources()
    {
        var list = Db.Resources.Include(r => r.ResourceCategory)
            .OrderBy(r => r.ResourceCategory!.CategoryName)
            .GroupBy(resource => resource.ResourceCategory)
            .ToList();
        List<List<Resource>> result = new List<List<Resource>>();
        foreach (var grouping in list)
        {
            var groupingList = new List<Resource>();
            foreach (var resource in grouping)
            {
                groupingList.Add(resource);
            }
            result.Add(groupingList);
        }
        return result;
    }
}
