using System;
using System.Collections.Generic;
using System.Text;

namespace DrozdHW_AQA.DTO.DapperTestsDTO
{
    public record ProductDTO
        (
        long id,

        string name,

        string description,

        double price,

        long stock,

        long categoryId
        );
}