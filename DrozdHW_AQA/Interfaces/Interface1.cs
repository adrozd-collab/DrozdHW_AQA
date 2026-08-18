using System;
using System.Collections.Generic;
using System.Text;
using Refit;

namespace DrozdHW_AQA.Interfaces
{
    [Headers("x-api-key: free_user_3I2DtUwiSzKQ4zy8x37TOPvgHRa")]
    public interface IUserApi
    {
        [Get("/users/2")]
        Task<UserResponseDTO> GetUserAsync(int id);
    }

}
