using System;
using System.Collections.Generic;
using System.Text;

namespace DrozdHW_AQA.DTO;
using System.Text.Json.Serialization;

public record AddressDTO
(
    [property: JsonPropertyName("country")]
    string Country,
    [property: JsonPropertyName("city")]
    string City,
    [property: JsonPropertyName("street")]
    string Street,
    [property: JsonPropertyName("zip")]
    string Zip
);