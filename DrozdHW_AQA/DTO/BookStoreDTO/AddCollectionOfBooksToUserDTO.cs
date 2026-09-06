using System;
using System.Collections.Generic;
using System.Text;

namespace DrozdHW_AQA.DTO.BookStoreDTO
{
    public record AddCollectionOfBooksToUserDTO(
        string UserId,
        List<CollectionOfIsbnsDTO> Books
    );
}
