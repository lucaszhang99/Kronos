
using System.Text.Json.Serialization;

namespace Kronos.Contract;

public record Commit(
[property: JsonPropertyName("id")] string Id,
[property: JsonPropertyName("message")] string Message,
[property: JsonPropertyName("title")] string Title,
[property: JsonPropertyName("timestamp")] DateTime Timestamp,
[property: JsonPropertyName("url")] string Url,
[property: JsonPropertyName("author")] Author Author,
[property: JsonPropertyName("added")] IReadOnlyList<string?> Added,
[property: JsonPropertyName("modified")] IReadOnlyList<string?> Modified,
[property: JsonPropertyName("removed")] IReadOnlyList<object?> Removed);

