using Dapper;
using DrozdHW_AQA.DTO.DapperTestsDTO;
using DrozdHW_AQA.Interface.DapperTestsInterfaces;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DrozdHW_AQA.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly string connection;
        public CategoryRepository(string connection)
        {
            this.connection = connection;
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategoriesAsync()
        {
            using var db = new SqliteConnection(connection);
            var categories = await db.QueryAsync<CategoryDTO>("SELECT * from Categories");
            return categories;
        }

        public async Task<IEnumerable<string>> GetDistinctBuyerCitiesByCategoryNameAsync(string categoryName)
        {
            using var db = new SqliteConnection(connection);
            var cities = await db.QueryAsync<string>("""
                SELECT DISTINCT a.City
                FROM Categories c
                JOIN Products p ON p.CategoryId = c.Id
                JOIN OrderItems oi ON oi.ProductId = p.Id
                JOIN Orders o ON o.Id = oi.OrderId
                JOIN Addresses a ON a.UserId = o.UserId
                WHERE c.Name = @categoryName
                """, new { categoryName });
            return cities;
        }
    }
}
