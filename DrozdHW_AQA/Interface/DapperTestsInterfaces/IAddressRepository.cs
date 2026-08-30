using DrozdHW_AQA.DTO.DapperTestsDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DrozdHW_AQA.Interface.DapperTestsInterfaces
{
    public interface IAddressRepository
    {
        Task<AddressDTO> GetAddressByUserId(int userId);
    }
}
