using System.Text.Json;
using System.Text.Json.Serialization;

namespace Kronos.Contract;

public record Project(
    [property: JsonPropertyName("id")] int Id,
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("description")] string? Description,
    [property: JsonPropertyName("web_url")] string WebUrl,
    [property: JsonPropertyName("avatar_url")] object? AvatarUrl,
    [property: JsonPropertyName("git_ssh_url")] string GitSshUrl,
    [property: JsonPropertyName("git_http_url")] string GitHttpUrl,
    [property: JsonPropertyName("namespace")] string Namespace,
    [property: JsonPropertyName("visibility_level")] int VisibilityLevel,
    [property: JsonPropertyName("path_with_namespace")] string PathWithNamespace,
    [property: JsonPropertyName("default_branch")] string DefaultBranch,
    [property: JsonPropertyName("homepage")] string Homepage,
    [property: JsonPropertyName("url")] string Url,
    [property: JsonPropertyName("ssh_url")] string SshUrl,
    [property: JsonPropertyName("http_url")] string HttpUrl,
    Dictionary<string, JsonElement>? ExtraFields
);

