using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DrozdHW_AQA.DTO;

public record UserDTO(
    [property: JsonPropertyName("id")]
    int Id,
    [property: JsonPropertyName("username")]
    string Username,
    [property: JsonPropertyName("profile")]
    ProfileDTO Profile,
    [property: JsonPropertyName("roles")]
    List<string> Roles
);
