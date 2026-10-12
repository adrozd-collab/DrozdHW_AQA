using System.Globalization;
using DrozdHW_AQA.Builders;
using DrozdHW_AQA.Pages;
using FluentAssertions;

namespace DrozdHW_AQA.AutoTests.UITests
{
    public class PracticeFormTests : BaseTest
    {
        [Test]
        public async Task SubmitPracticeFormWithAllFields()
        {
            var student = new StudentFormBuilder()
                .WithFirstName("Andrei")
                .WithLastName("Drozd")
                .WithEmail("andrei.drozd@example.com")
                .WithGender("Male")
                .WithMobile("1234567890")
                .WithDateOfBirth(new DateTime(1990, 5, 15))
                .WithSubject("Maths")
                .WithSubject("English")
                .WithHobby("Sports")
                .WithHobby("Music")
                .WithPicture(Path.Combine(TestContext.CurrentContext.TestDirectory, "Resources", "Images", "avatar.png"))
                .WithCurrentAddress("Main St 12, Minsk")
                .WithStateAndCity("NCR", "Delhi")
                .Build();

            var practiceFormPage = new PracticeFormPage(Page);
            await practiceFormPage.OpenAsync();
            await practiceFormPage.FillFormAsync(student);
            await practiceFormPage.SubmitAsync();

            var modalTitle = await practiceFormPage.GetModalTitleAsync();
            modalTitle.Should().Be("Thanks for submitting the form");

            var expectedDateOfBirth = student.DateOfBirth.ToString("dd MMMM,yyyy", CultureInfo.InvariantCulture);
            var expectedResults = new Dictionary<string, string>
            {
                ["Student Name"] = $"{student.FirstName} {student.LastName}",
                ["Student Email"] = student.Email,
                ["Gender"] = student.Gender,
                ["Mobile"] = student.Mobile,
                ["Date of Birth"] = expectedDateOfBirth,
                ["Subjects"] = string.Join(", ", student.Subjects),
                ["Hobbies"] = string.Join(", ", student.Hobbies),
                ["Picture"] = Path.GetFileName(student.PicturePath),
                ["Address"] = student.CurrentAddress,
                ["State and City"] = $"{student.State} {student.City}"
            };

            foreach (var expected in expectedResults)
            {
                var actualValue = await practiceFormPage.GetResultValueAsync(expected.Key);
                actualValue.Should().Be(expected.Value, $"'{expected.Key}' should match the submitted data");
            }
        }
    }
}
