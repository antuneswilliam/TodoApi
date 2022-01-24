using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class GithubController : ControllerBase {

    private readonly IGithubClient githubClient;

    public GithubController(IGithubClient githubClient)
    {
        this.githubClient = githubClient;
    }

    [HttpGet]
    public async Task<IActionResult> Zen() {

        var zen = await githubClient.GetZenAsync();
        return Ok(zen);
    }
}