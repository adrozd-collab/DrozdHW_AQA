using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace DrozdHW_AQA.DTO.PetStoreDTO
{
    public record RootDTO(
        List<PetDTO> Data,
        PaginationDTO Pagination
    );

}