using System;
using System.Collections.Generic;
using System.Text;

namespace DrozdHW_AQA.DTO.BookStoreDTO
{
    public record GenerateTokenResponseDTO(
        string Token,
        string Expires,
        string Status,
        string Result
    );
}
