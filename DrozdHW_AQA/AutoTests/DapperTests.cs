using DrozdHW_AQA.Interface.DapperTestsInterfaces;
using DrozdHW_AQA.Preconditions;
using DrozdHW_AQA.Utils;
using FluentAssertions;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DrozdHW_AQA.AutoTests
{
    public class DapperTests
    {
        private readonly DataBasePreconditions p = new DataBasePreconditions();

        [Test]
        public async Task Test001CheckAllUsersCount()
        {
            var repo = p.Provider.GetService<IUserRepository>();
            var users = await repo.GetUsersAsync();
            users.Should().HaveCount(15);
        }

        [Test]
        public async Task Test002GetUserById()
        {
            var repo = p.Provider.GetService<IUserRepository>();
            var users = await repo.GetUserByIdAsync(15);
            users.Should().NotBeNull();
        }

        [Test]
        public async Task Test003GetUserByNameAndSurname()
        {
            var repo = p.Provider.GetService<IUserRepository>();
            var users = await repo.GetUserByNameAndSurname("Мария", "Павлова");
            users.Should().NotBeNull();
            users.firstName.Should().Be("Мария");
            users.lastName.Should().Be("Павлова");
        }

        [Test]
        public async Task Test004GetAddressByUserId()
        {
            var repo = p.Provider.GetService<IAddressRepository>();
            var address = await repo.GetAddressByUserId(1);
            address.Should().NotBeNull();
        }

        [Test]
        public async Task Test005CheckAllCategoriesCount()
        {
            var repo = p.Provider.GetService<ICategoryRepository>();
            var categories = await repo.GetCategoriesAsync();
            categories.Should().HaveCount(6);
            categories.Select(c => c.name).Should().BeEquivalentTo(
                "Смартфоны", "Ноутбуки", "Наушники", "Телевизоры", "Бытовая техника", "Аксессуары");
        }

        [Test]
        public async Task Test006GetProductById()
        {
            var repo = p.Provider.GetService<IProductRepository>();
            var product = await repo.GetProductByIdAsync(7);
            product.Should().NotBeNull();
            product.name.Should().Be("AirPods Pro 2");
            product.description.Should().Be("Беспроводные наушники Apple");
            product.price.Should().Be(24990);
            product.stock.Should().Be(30);
            product.categoryId.Should().Be(3);
        }

        [Test]
        public async Task Test007GetOrderItemsForUserOrder()
        {
            var orderRepo = p.Provider.GetService<IOrderRepository>();
            var productRepo = p.Provider.GetService<IProductRepository>();

            var order = await orderRepo.GetOrderByIdAsync(1);
            order.Should().NotBeNull();
            order.userId.Should().Be(1);

            var items = await orderRepo.GetOrderItemsByOrderIdAsync(order.id);
            items.Should().HaveCount(2);
            items.Should().ContainSingle(i => i.productId == 1 && i.quantity == 1 && i.unitPrice == 79990);
            items.Should().ContainSingle(i => i.productId == 15 && i.quantity == 1 && i.unitPrice == 4990);

            var expectedProductNames = new Dictionary<long, string>
            {
                [1] = "iPhone 15",
                [15] = "Anker PowerBank"
            };

            foreach (var item in items)
            {
                var product = await productRepo.GetProductByIdAsync(item.productId);
                product.Should().NotBeNull();
                product.name.Should().Be(expectedProductNames[item.productId]);
            }
        }

        [Test]
        public async Task Test008AccessoriesBoughtByUsersFromDifferentCities()
        {
            var repo = p.Provider.GetService<ICategoryRepository>();
            var cities = await repo.GetDistinctBuyerCitiesByCategoryNameAsync("Аксессуары");

            cities.Should().NotBeNullOrEmpty();
            cities.Should().HaveCountGreaterThan(1, "товары категории 'Аксессуары' должны покупать пользователи из разных городов");
        }

        [Test]
        public async Task Test009TvBuyersAlsoBuyAccessories() // тест фейлится - ожидаемо (единственный покупатель телевизора, userId=15, аксессуары не покупал)
        {
            var repo = p.Provider.GetService<ICategoryRepository>();

            var tvBuyers = await repo.GetDistinctBuyerUserIdsByCategoryNameAsync("Телевизоры");
            var accessoryBuyers = await repo.GetDistinctBuyerUserIdsByCategoryNameAsync("Аксессуары");

            tvBuyers.Should().NotBeEmpty();
            tvBuyers.Should().BeSubsetOf(accessoryBuyers, "покупатели телевизоров должны покупать также и аксессуары");
        }


        //[Test] //генерация базы - раскомментить, а потом запустить тест разово
        //public async Task InitialiseTest()
        //{
        //    var connectionString = "Data Source=marketplace.db";
        //    await using var connection = new SqliteConnection(connectionString);
        //    await connection.OpenAsync();
        //    await DatabaseInitializer.InitializeAsync(connection);
        //}
    }
}