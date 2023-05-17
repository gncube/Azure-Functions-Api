using GSN.Domain;

namespace Client.Services;

public class MockDataService : IBlogDataService
{
    private List<Blog> blogs;

    public MockDataService()
    {
        blogs = new List<Blog>
        {
            new Blog { Id = Guid.NewGuid().ToString(), BlogName = "Tech Trends 2023", Published = true, CreatedOnDate = DateTime.UtcNow.AddDays(-60) },
            new Blog { Id = Guid.NewGuid().ToString(), BlogName = "Healthy Living & Recipes", Published = false, CreatedOnDate = DateTime.UtcNow.AddDays(-30) },
            new Blog { Id = Guid.NewGuid().ToString(), BlogName = "Adventures in Travel", Published = true, CreatedOnDate = DateTime.UtcNow.AddDays(-10) }
        };
    }

    public Task<IEnumerable<Blog>> GetAllBlogsAsync(bool refreshRequired = false)
    {
        return Task.FromResult(blogs.AsEnumerable());
    }

    public Task<IEnumerable<Blog>> GetBlogsAsync()
    {
        return Task.FromResult(blogs.Where(b => b.Published).AsEnumerable());
    }

    public Task<Blog> GetBlogByIdAsync(string id)
    {
        return Task.FromResult(blogs.FirstOrDefault(b => b.Id == id));
    }

    public Task<Blog> CreateBlogAsync(Blog blog)
    {
        blogs.Add(blog);
        return Task.FromResult(blog);
    }

    public Task UpdateBlogAsync(Blog blog)
    {
        var index = blogs.FindIndex(b => b.Id == blog.Id);
        if (index != -1)
        {
            blogs[index] = blog;
        }
        return Task.CompletedTask;
    }

    public Task DeleteBlogAsync(string id)
    {
        var blog = blogs.FirstOrDefault(b => b.Id == id);
        if (blog != null)
        {
            blogs.Remove(blog);
        }
        return Task.CompletedTask;
    }
}
