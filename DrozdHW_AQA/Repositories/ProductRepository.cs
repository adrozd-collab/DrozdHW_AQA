using Dapper;
using DrozdHW_AQA.DTO.DapperTestsDTO;
using DrozdHW_AQA.Interface.DapperTestsInterfaces;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DrozdHW_AQA.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly string connection;
        public ProductRepository(string connection)
        {
            this.connection = connection;
        }

        public async Task<ProductDTO> GetProductByIdAsync(long id)
        {
            using var db = new SqliteConnection(connection);
            var product = await db.QueryFirstOrDefaultAsync<ProductDTO>("SELECT * from Products " +
                "WHERE Id = @id", new { id });
            return product;
        }
    }
}
