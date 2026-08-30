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
    }
}
