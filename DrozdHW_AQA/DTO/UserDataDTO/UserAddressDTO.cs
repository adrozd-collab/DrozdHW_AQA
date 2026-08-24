using System.Text.Json.Serialization;

namespace DrozdHW_AQA.DTO;

public record UserAddressDTO(
    [property: JsonPropertyName("street")]
    string Street,
    [property: JsonPropertyName("city")]
    string City,
    [property: JsonPropertyName("geo")]
    GeoDTO Geo
);
