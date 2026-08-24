using System;
using System.Collections.Generic;
using System.Text;

namespace DrozdHW_AQA.DTO;
using System.Text.Json.Serialization;

public record DeliveryDTO(
    [property: JsonPropertyName("type")]
    string Type,
    [property: JsonPropertyName("status")]
    string Status,
    [property: JsonPropertyName("estimatedDate")]
    string EstimatedDate,
    [property: JsonPropertyName("trackingNumber")]
    string TrackingNumber
);
