using System;
using System.Collections.Generic;
using System.Text;

namespace DrozdHW_AQA.DTO.DapperTestsDTO
{
    public record OrderItemsDTO
        (
        long id,

        string orderId,

        string productId,

        long quantity,

        long unitPrice
        );
}