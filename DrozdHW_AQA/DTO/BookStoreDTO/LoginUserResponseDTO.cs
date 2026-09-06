using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace DrozdHW_AQA.DTO.BookStoreDTO
{
    public record LoginUserResponseDTO(
        string UserId,
        string Username,
        string Password,
        string Token,
        string Expires,
        string Created_Date,
        bool IsActive
        );
}
