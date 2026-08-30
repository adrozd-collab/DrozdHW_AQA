using Dapper;
using DrozdHW_AQA.DTO.DapperTestsDTO;
using DrozdHW_AQA.Interface.DapperTestsInterfaces;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Text;


namespace DrozdHW_AQA.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly string connection;
        public AddressRepository(string connection)
        {
            this.connection = connection;
        }

        public async Task<AddressDTO> GetAddressByUserId(int userId)
        {
            using var db = new SqliteConnection(connection);
            var address = await db.QueryFirstOrDefaultAsync<AddressDTO>("SELECT * from Addresses " +
                "WHERE UserId = @userId", new { userId });
            return address;
        }
    }
}
