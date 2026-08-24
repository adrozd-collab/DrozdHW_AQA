using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using TestAQA1;

namespace Tests1.Interfaces
{
    [Headers("x-api-key: free_user_3I2DtUwiSzKQ4zy8x37TOPvgHRa")]
    public interface IUserApi
    {
        [Get("/users/{id}")]
        Task<UserResponseDTO> GetUserAsync(int id);

        [Post("/users")]
        Task<CreateUserResponseDTO> CreateUserAsync([Body] CreateUserRequestDTO request);

        [Delete("/users/{id}")]
        Task<ApiResponse<string>> DeleteUserAsync(int id);
    }
}
