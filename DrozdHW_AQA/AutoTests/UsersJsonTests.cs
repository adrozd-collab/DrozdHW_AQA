using System.Text.Json;
using FluentAssertions;
using DrozdHW_AQA.DTO;

namespace DrozdHW_AQA.AutoTests
{
    public class UsersJsonTests
    {
        private const double SwedenMinLat = 55.0;
        private const double SwedenMaxLat = 69.1;
        private const double SwedenMinLng = 11.0;
        private const double SwedenMaxLng = 24.2;

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

        [Test]
        public void Test2_7_CheckAllUsersAgeInRange()
        {
            users.Should().OnlyContain(user => user.Profile.Age >= 18 && user.Profile.Age <= 60);
        }

        [Test]
        public void Test2_8_CheckAtLeastOneAdminUser()
        {
            users.Should().Contain(user => user.Roles.Contains("admin"));
        }

        [Test]
        public void Test3_CheckAllUsersCoordinatesAreWithinSweden()
        {
            users.Should().OnlyContain(user =>
                user.Profile.Address.Geo.Lat >= SwedenMinLat && user.Profile.Address.Geo.Lat <= SwedenMaxLat &&
                user.Profile.Address.Geo.Lng >= SwedenMinLng && user.Profile.Address.Geo.Lng <= SwedenMaxLng);
        }
    }
}
