using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DrozdHW_AQA.DTO;

public record UsersRootDTO(
    [property: JsonPropertyName("data")]
    List<UserDTO> Data
);
