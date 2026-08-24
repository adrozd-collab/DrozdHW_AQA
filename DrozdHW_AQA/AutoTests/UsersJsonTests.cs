using System.Text.Json;
using FluentAssertions;
using DrozdHW_AQA.DTO;

namespace DrozdHW_AQA.AutoTests
{
    public class UsersJsonTests
    {
        private List<UserDTO> users;

        [OneTimeSetUp]
        public void Setup()
        {
            var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "Resources", "UsersData.json");
            string json = File.ReadAllText(path);

            users = JsonSerializer.Deserialize<UsersRootDTO>(json).Data;
        }

        [Test]
        public void Test2_1_CheckUsersCount()
        {
            users.Should().HaveCount(10);
        }

        [Test]
        public void Test2_2_CheckFirstUserIsAliceJohnson()
        {
            users.First().Profile.FullName.Should().Be("Alice Johnson");
        }

        [Test]
        public void Test2_3_CheckAllIdsAreUnique()
        {
            var ids = users.Select(user => user.Id).ToList();

            ids.Should().OnlyHaveUniqueItems();
        }

        [Test]
        public void Test2_4_CheckAtLeastOnePremiumUser()
        {
            users.Should().Contain(user => user.Profile.Tags.Contains("premium"));
        }

        [Test]
        public void Test2_5_CheckAllUsersHaveNonEmptyCity()
        {
            users.Should().OnlyContain(user => !string.IsNullOrWhiteSpace(user.Profile.Address.City));
        }

        [Test]
        public void Test2_6_CheckAtLeastOneUserFromStockholm()
        {
            users.Should().Contain(user => user.Profile.Address.City == "Stockholm");
        }
    }
}
