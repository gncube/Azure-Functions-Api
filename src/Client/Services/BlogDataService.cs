using GSN.Domain;
using System.Text.Json;

namespace Client.Services;

public class BlogDataService : IBlogDataService
{
    private readonly HttpClient _httpClient;

    public BlogDataService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<IEnumerable<Blog>> GetAllBlogsAsync(bool refreshRequired = false)
    {
        using var responseStream = await _httpClient.GetStreamAsync($"api/blogs");
        using var jsonDoc = await JsonDocument.ParseAsync(responseStream);

        var blogsArray = jsonDoc.RootElement.GetProperty("Value");

        var blogs = JsonSerializer.Deserialize<IEnumerable<Blog>>(blogsArray.GetRawText(), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

        return blogs;
    }

    public Task<IEnumerable<Blog>> GetBlogsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Blog> GetBlogByIdAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task<Blog> CreateBlogAsync(Blog blog)
    {
        throw new NotImplementedException();
    }

    public Task UpdateBlogAsync(Blog blog)
    {
        throw new NotImplementedException();
    }

    public Task DeleteBlogAsync(string id)
    {
        throw new NotImplementedException();
    }
}
