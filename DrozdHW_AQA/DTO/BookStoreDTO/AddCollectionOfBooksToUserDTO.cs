using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace DrozdHW_AQA.DTO.BookStoreDTO
{
    public record AddCollectionOfBooksToUserDTO(
        string UserId,
        [property: JsonPropertyName("collectionOfIsbns")] List<CollectionOfIsbnsDTO> Books
    );
}
