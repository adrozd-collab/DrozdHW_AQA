using Dapper;
using DrozdHW_AQA.DTO.DapperTestsDTO;
using DrozdHW_AQA.Interface.DapperTestsInterfaces;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DrozdHW_AQA.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly string connection;
        public OrderRepository(string connection)
        {
            this.connection = connection;
        }

        public async Task<OrderDTO> GetOrderByIdAsync(long id)
        {
            using var db = new SqliteConnection(connection);
            var order = await db.QueryFirstOrDefaultAsync<OrderDTO>("SELECT * from Orders " +
                "WHERE Id = @id", new { id });
            return order;
        }

        public async Task<IEnumerable<OrderItemsDTO>> GetOrderItemsByOrderIdAsync(long orderId)
        {
            using var db = new SqliteConnection(connection);
            var items = await db.QueryAsync<OrderItemsDTO>("SELECT * from OrderItems " +
                "WHERE OrderId = @orderId", new { orderId });
            return items;
        }
    }
}
