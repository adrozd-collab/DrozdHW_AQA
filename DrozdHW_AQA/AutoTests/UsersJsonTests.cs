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
    }
}
