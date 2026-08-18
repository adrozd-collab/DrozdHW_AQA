using System.Net.Http.Json;
using System.Text.Json;
using TestAQA1;

namespace DrozdHW_AQA.Tests
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
        
        [Test]
        public async Task Test3()
        {
            CreateUserRequestDTO request = new CreateUserRequestDTO
            {
                Name = "Test User",
                Job = "Test Job"
            };
            
            using HttpResponseMessage response = await client.PostAsJsonAsync("users", request);
            string jsonPost = await response.Content.ReadAsStringAsync();
            CreateUserResponseDTO userResponse = JsonSerializer.Deserialize<CreateUserResponseDTO>(jsonPost);
        }

        [Test]
        public async Task Test4()
        {
            CreateUserRequestDTO request = new CreateUserRequestDTO
            {
                Name = "Test User",
                Job = "QA Job"
            };

            using HttpResponseMessage response = await client.PutAsJsonAsync("users/2", request);
            response.EnsureSuccessStatusCode();
        }

        [Test]
        public async Task Test5()
        {
            using HttpResponseMessage response = await client.DeleteAsync("users/2");
            response.EnsureSuccessStatusCode();
        }
        
        [OneTimeTearDown]
        public void TearDown()
        {
            client.Dispose();
        }
    }
}
