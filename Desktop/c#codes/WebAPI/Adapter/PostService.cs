using System.Text;
using System.Text.Json;
using WebAPI.Entities;

namespace WebAPI.bin
{
    public class PostService
    {
        private readonly HttpClient _httpClient;
        private const string _baseUrl= "https://jsonplaceholder.typicode.com";
        public PostService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        public async Task<IEnumerable<Post>> GetPosts()
        {
            try
            {
                
                var path = $"{_baseUrl}/posts";
                var response =await _httpClient.GetAsync(path);
                response.EnsureSuccessStatusCode();
                var responseContent = await response.Content.ReadAsStringAsync();
                var option = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var posts = JsonSerializer.Deserialize<IEnumerable<Post>>(responseContent,option);
                return posts;
            }
            catch(HttpRequestException ex)
            {
                Console.WriteLine($"An error occured while getting post : {ex.Message}");
                throw ex;
            }

        }
        
        public async Task<IEnumerable<Post>> AddPost(PostRequestModel postRequestModel)
        {
            try
            {
                
                var path = $"{_baseUrl}/posts";
                var content_Json = JsonSerializer.Serialize(postRequestModel);
                var httpContent = new StringContent(content_Json,Encoding.UTF8,"application/json");
                var response =await _httpClient.GetAsync(path);
                response.EnsureSuccessStatusCode();
                var responseContent = await response.Content.ReadAsStringAsync();
                var option = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var posts = JsonSerializer.Deserialize<IEnumerable<Post>>(responseContent,option);
                return posts;
            }
            catch(HttpRequestException ex)
            {
                Console.WriteLine($"An error occured while getting post : {ex.Message}");
                throw ex;
            }

        }
    }
}