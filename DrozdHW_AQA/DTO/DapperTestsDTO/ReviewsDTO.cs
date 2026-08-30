using System;
using System.Collections.Generic;
using System.Text;

namespace DrozdHW_AQA.DTO.DapperTestsDTO
{
    public record ReviewsDTO
        (
        long id,

        string userId,

        string productId,

        long rating,

        long comment,

        long createdAt
        );
}
