using System;
using System.Collections.Generic;
using System.Text;

namespace DrozdHW_AQA.DTO.BookStoreDTO
{
    public record UserCreateResponseDTO(
        string UserId,
        string UserName,
        List<UserCreateResponseBookDTO> Books
    );
}
