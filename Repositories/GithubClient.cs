using System.Text.Json;

public interface IGithubClient
{
    Task<string> GetZenAsync();
}

public class GithubClient : IGithubClient
{

    private readonly HttpClient httpClient;

    public GithubClient(IHttpClientFactory clientFactory)
    {
        httpClient = clientFactory.CreateClient("GithubClient");
    }

    public async Task<string> GetZenAsync()
    {
        var req = new HttpRequestMessage(HttpMethod.Get, "https://api.github.com/zen");
        req.Headers.Add("Accept", "application/vnd.github.v3+json");
        req.Headers.Add("User-Agent", "GithubClientTest");

        var res = await httpClient.SendAsync(req);

        if (res.IsSuccessStatusCode)
            return await res?.Content?.ReadAsStringAsync();
        
        return null;
    }
}