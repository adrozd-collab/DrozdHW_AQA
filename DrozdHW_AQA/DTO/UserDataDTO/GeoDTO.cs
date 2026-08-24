using System.Text.Json.Serialization;

namespace DrozdHW_AQA.DTO;

public record GeoDTO(
    [property: JsonPropertyName("lat")]
    double Lat,
    [property: JsonPropertyName("lng")]
    double Lng
);
