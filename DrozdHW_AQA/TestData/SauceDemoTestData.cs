using DrozdHW_AQA.DTO.SauceDemoDTO;
using DrozdHW_AQA.Utils;

namespace DrozdHW_AQA.TestData
{
    public static class SauceDemoTestData
    {
        public static IEnumerable<TestCaseData> ValidUsers()
        {
            var users = JsonFileReader.ReadAndDeserialize<List<SauceDemoUserDTO>>("SauceDemoUsers.json");

            foreach (var user in users)
            {
                yield return new TestCaseData(user).SetName($"SuccessfulLogin_{user.Username}");
            }
        }
    }
}
