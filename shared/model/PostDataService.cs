using System.Net.Http.Json;
using shared.model;
using Microsoft.Extensions.Configuration;

namespace PostdataBlazor.Data;

public class PostDataService
{
    private readonly HttpClient http;
    private readonly IConfiguration configuration;
    private readonly string baseAPI = "";

    public event Action RefreshRequired;

    public PostDataService(HttpClient http, IConfiguration configuration)
    {
        this.http = http;
        this.configuration = configuration;
        this.baseAPI = configuration["base_api"];
    }

    public void CallRequestRefresh()
    {
        RefreshRequired?.Invoke();
    }

    // Hent alle poster fra API'en
    public async Task<PostData[]> GetPosts()
    {
        string url = $"{baseAPI}post/";
        return await http.GetFromJsonAsync<PostData[]>(url);
    }

    // Hent en specifik post fra API'en
    public async Task<PostData> GetPostById(long id)
    {
        string url = $"{baseAPI}post/{id}";
        return await http.GetFromJsonAsync<PostData>(url);
    }

    // Opdater en post (PUT)
    public async Task UpdatePost(PostData post)
    {
        string url = $"{baseAPI}post/{post.PostId}";
        var res = await http.PutAsJsonAsync(url, post);
        CallRequestRefresh();
    }

    // Tilføj en ny post (POST)
    public async Task AddPost(PostData post)
    {
        string url = $"{baseAPI}posts/";
        var res = await http.PostAsJsonAsync(url, post);
        CallRequestRefresh();
    }

    // Tilføj en kommentar til en post (POST)
    public async Task AddComment(long postId, Comment comment)
    {
        string url = $"{baseAPI}posts/{postId}/comments";
        var res = await http.PostAsJsonAsync(url, comment);
        CallRequestRefresh();
    }

    // Upvote en post (PUT)
    public async Task UpvotePost(long id)
    {
        string url = $"{baseAPI}post/{id}/upvote";
        var res = await http.PutAsJsonAsync(url, new { });  
        CallRequestRefresh();
    }

    // Downvote en post (PUT)
    public async Task DownvotePost(long id)
    {
        string url = $"{baseAPI}post/{id}/downvote";
        var res = await http.PutAsJsonAsync(url, new { });  
        CallRequestRefresh();
    }

    // Upvote en kommentar (PUT)
    public async Task UpvoteComment(long postId, long commentId)
    {
        string url = $"{baseAPI}post/{postId}/comment/{commentId}/upvote";
        var res = await http.PutAsJsonAsync(url, new { }); 
        CallRequestRefresh();
    }

    // Downvote en kommentar (PUT)
    public async Task DownvoteComment(long postId, long commentId)
    {
        string url = $"{baseAPI}post/{postId}/comment/{commentId}/downvote";
        var res = await http.PutAsJsonAsync(url, new { });  
        CallRequestRefresh();
    }
}
