using System;
using System.Collections.Generic;
using System.Text;

namespace DrozdHW_AQA.DTO;
using System.Text.Json.Serialization;

public record CustomerDTO(
    [property: JsonPropertyName("id")]
    int Id,
    [property: JsonPropertyName("name")]
    string Name,
    [property: JsonPropertyName("email")]
    string Email,
    [property: JsonPropertyName("phone")]
    string Phone,
    [property: JsonPropertyName("address")]
    AddressDTO Address
);