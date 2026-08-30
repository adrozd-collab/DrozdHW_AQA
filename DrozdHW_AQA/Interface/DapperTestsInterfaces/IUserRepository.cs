using System;
using System.Collections.Generic;
using System.Text;
using DrozdHW_AQA.DTO.DapperTestsDTO;

namespace DrozdHW_AQA.Interface.DapperTestsInterfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserDTO>> GetUsersAsync();
        Task<UserDTO> GetUserByIdAsync(int id);
        Task<UserDTO> GetUserByNameAndSurname(string firstName, string lastName);
    }
}
