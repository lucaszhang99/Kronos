using System.Text.Json.Serialization;

namespace Kronos.Contract
{
    public record Repository(
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("url")] string Url,
    [property: JsonPropertyName("description")] string? Description,
    [property: JsonPropertyName("homepage")] string Homepage,
    [property: JsonPropertyName("git_http_url")] string GitHttpUrl,
    [property: JsonPropertyName("git_ssh_url")] string GitSshUrl,
    [property: JsonPropertyName("visibility_level")] int VisibilityLevel
);

}
