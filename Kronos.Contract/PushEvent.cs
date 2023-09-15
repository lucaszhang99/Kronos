// PushEvent myDeserializedClass = JsonSerializer.Deserialize<PushEvent>(myJsonResponse);
using System.Text.Json;
using System.Text.Json.Serialization;
namespace Kronos.Contract;

public record PushEvent(
    [property: JsonPropertyName("object_kind")] string ObjectKind,
    [property: JsonPropertyName("event_name")] string EventName,
    [property: JsonPropertyName("before")] string Before,
    [property: JsonPropertyName("after")] string After,
    [property: JsonPropertyName("ref")] string Ref,
    [property: JsonPropertyName("ref_protected")] bool RefProtected,
    [property: JsonPropertyName("checkout_sha")] string CheckoutSha,
    [property: JsonPropertyName("user_id")] int UserId,
    [property: JsonPropertyName("user_name")] string UserName,
    [property: JsonPropertyName("user_username")] string UserUsername,
    [property: JsonPropertyName("user_email")] string? UserEmail,
    [property: JsonPropertyName("user_avatar")] string? UserAvatar,
    [property: JsonPropertyName("project_id")] int ProjectId,
    [property: JsonPropertyName("project")] Project Project,
    [property: JsonPropertyName("repository")] Repository Repository,
    [property: JsonPropertyName("commits")] IReadOnlyList<Commit> Commits,
    [property: JsonPropertyName("total_commits_count")] int TotalCommitsCount,
    Dictionary<string, JsonElement>? ExtraFields
);

