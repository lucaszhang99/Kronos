

using System.Text.Json.Serialization;

namespace Kronos.Contract;

public record Author(
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("email")] string Email
);


