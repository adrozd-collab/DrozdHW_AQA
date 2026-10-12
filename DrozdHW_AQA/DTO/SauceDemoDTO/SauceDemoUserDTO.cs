using System.Text.Json.Serialization;

namespace DrozdHW_AQA.DTO.SauceDemoDTO;

public record SauceDemoUserDTO(
    [property: JsonPropertyName("username")]
    string Username,
    [property: JsonPropertyName("password")]
    string Password
);
