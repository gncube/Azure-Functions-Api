﻿using Blazored.LocalStorage;
using Client.Helper;
using GSN.Domain;
using System.Text.Json;

namespace Client.Services;

public class BlogDataService : IBlogDataService
{
    private readonly HttpClient _httpClient;
    private readonly ILocalStorageService _localStorageService;

    public BlogDataService(HttpClient httpClient, ILocalStorageService localStorageService)
    {
        _httpClient = httpClient;
        _localStorageService = localStorageService;
    }
    public async Task<IEnumerable<Blog>> GetAllBlogsAsync(bool refreshRequired = false)
    {
        if (!refreshRequired)
        {
            bool blogExpirationKeyExists = await
                _localStorageService.ContainKeyAsync(LocalStorageConstants.BlogListExpirationKey);
            if (blogExpirationKeyExists)
            {
                DateTime blogListExpiration = await _localStorageService.GetItemAsync<DateTime>(LocalStorageConstants.BlogListExpirationKey);
                if (blogListExpiration > DateTime.Now)
                {
                    if (await _localStorageService.ContainKeyAsync(LocalStorageConstants.BlogsListKey))
                    {
                        return await _localStorageService.GetItemAsync<IEnumerable<Blog>>(LocalStorageConstants.BlogsListKey);
                    }
                }
            }
        }

        var baseUrl = _httpClient.BaseAddress;
        using var responseStream = await _httpClient.GetStreamAsync($"api/blogs");
        using var jsonDoc = await JsonDocument.ParseAsync(responseStream);

        var blogsArray = jsonDoc.RootElement.GetProperty("Value");

        var blogs = JsonSerializer.Deserialize<IEnumerable<Blog>>(blogsArray.GetRawText(), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

        await _localStorageService.SetItemAsync(LocalStorageConstants.BlogsListKey, blogs);
        await _localStorageService.SetItemAsync(LocalStorageConstants.BlogListExpirationKey, DateTime.Now.AddMinutes(5));

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
