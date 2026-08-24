using System;
using System.Collections.Generic;
using System.Text;

namespace DrozdHW_AQA.DTO;
using System.Text.Json.Serialization;

public record SummaryDTO(
    [property: JsonPropertyName("itemsTotal")]
    decimal ItemsTotal,
    [property: JsonPropertyName("deliveryFee")]
    decimal DeliveryFee,
    [property: JsonPropertyName("discount")]
    decimal Discount,
    [property: JsonPropertyName("finalTotal")]
    decimal FinalTotal
);
