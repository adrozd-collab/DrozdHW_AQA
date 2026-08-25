using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using FluentAssertions.Execution;
using DrozdHW_AQA.DTO;
using DrozdHW_AQA.Utils;


namespace DrozdHW_AQA.AutoTests
{
    public class OrderJsonTests
    {
        private OrderDTO order;

        [OneTimeSetUp]
        public void Setup()
        {
            order = JsonFileReader.ReadAndDeserialize<OrderDTO>("OrderData.json");
        }

        [Test]
        public void Test1_CheckItemsIsNotNull()
        {
            foreach (var item in order.Items)
            {
                TestContext.WriteLine($"Result\n{item.ProductId} | {item.Quantity.ToString()} | {item.Price.ToString()}");
            }
            order.Items.Should().NotBeNull();
            order.Items.Should().HaveCount(3); // 3 элемента
        }

        [Test]
        public void Test2_CheckSumOfItems() // проверяем, что сумма стоимости позиций = ItemsTotal из json
        {
            var sum = order.Items.Select(item => item.Quantity * item.Price).Sum();
            sum.Should().Be(order.Summary.ItemsTotal);
        }

        [Test]
        public void Test3_CheckElectronicsQuantity()
        {
            var hasElectonicsCategory = order.Items.Where(item => item.Category == "Electronics").ToList();

            using (new AssertionScope())
            {
                hasElectonicsCategory.Should().OnlyContain(item => item.Category == "Electronics");
                hasElectonicsCategory.Should().HaveCount(3);
            }
        }
    }
}
