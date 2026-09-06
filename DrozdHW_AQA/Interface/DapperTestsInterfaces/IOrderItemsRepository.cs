using System;
using System.Collections.Generic;
using System.Text;
using DrozdHW_AQA.DTO.DapperTestsDTO;

namespace DrozdHW_AQA.Interface.DapperTestsInterfaces
{
    public interface IOrderItemsRepository
    {
        Task<IEnumerable<OrderItemsDTO>> GetOrderItemsByOrderId(int orderId);
    }
}
