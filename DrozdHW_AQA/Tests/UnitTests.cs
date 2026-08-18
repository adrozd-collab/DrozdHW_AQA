using System.Net.Http.Json;
using System.Text.Json;

namespace DrozdHW_AQA
{
    public class Testing
    {
        private static HttpClient client;

        [OneTimeSetUp]
        public void Setup()
        {
            client = new HttpClient
            {
                BaseAddress = new Uri("https://reqres.in/api/")
            };
            client.DefaultRequestHeaders.Add("x-api-key", "free_user_3I2DtUwiSzKQ4zy8x37TOPvgHRa");
        }

        [Test]
        public async Task Test1()
        {
            using HttpResponseMessage response = await client.GetAsync("users/2");
            response.EnsureSuccessStatusCode();
        }

        [Test]
        public async Task Test2()
        {
            using HttpResponseMessage response = await client.GetAsync("users/2");
            string jsonGet = await response.Content.ReadAsStringAsync();
            UserResponseDTO userResponse = JsonSerializer.Deserialize<UserResponseDTO>(jsonGet);
            UserDataDTO user = userResponse.Data;
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            client.Dispose();
        }
    }
}
