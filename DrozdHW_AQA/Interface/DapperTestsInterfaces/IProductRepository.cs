using DrozdHW_AQA.DTO.DapperTestsDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DrozdHW_AQA.Interface.DapperTestsInterfaces
{
    public interface IProductRepository
    {
        Task<ProductDTO> GetProductByIdAsync(long id);
    }
}
