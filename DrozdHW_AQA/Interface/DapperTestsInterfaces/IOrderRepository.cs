using DrozdHW_AQA.DTO.DapperTestsDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DrozdHW_AQA.Interface.DapperTestsInterfaces
{
    public interface IOrderRepository
    {
        Task<OrderDTO> GetOrderByIdAsync(long id);
        Task<IEnumerable<OrderItemsDTO>> GetOrderItemsByOrderIdAsync(long orderId);
    }
}
