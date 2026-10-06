using System.Globalization;
using DrozdHW_AQA.DTO.PracticeFormDTO;
using Microsoft.Playwright;

namespace DrozdHW_AQA.Pages
{
    public class PracticeFormPage
    {
        private const string Url = "https://demoqa.com/automation-practice-form";

        private readonly IPage page;

        public PracticeFormPage(IPage page)
        {
            this.page = page;
        }

        private ILocator FirstNameTextBox => page.Locator("#firstName");
        private ILocator LastNameTextBox => page.Locator("#lastName");
        private ILocator EmailTextBox => page.Locator("#userEmail");
        private ILocator MobileTextBox => page.Locator("#userNumber");
        private ILocator DateOfBirthInput => page.Locator("#dateOfBirthInput");
        private ILocator MonthSelect => page.Locator(".react-datepicker__month-select");
        private ILocator YearSelect => page.Locator(".react-datepicker__year-select");
        private ILocator SubjectsInput => page.Locator("#subjectsInput");
        private ILocator UploadPictureInput => page.Locator("#uploadPicture");
        private ILocator CurrentAddressTextArea => page.Locator("#currentAddress");
        private ILocator StateInput => page.Locator("#react-select-3-input");
        private ILocator CityInput => page.Locator("#react-select-4-input");
        private ILocator SubmitButton => page.Locator("#submit");
        private ILocator ModalTitle => page.Locator("#example-modal-sizes-title-lg");

        private ILocator CheckOption(string text) =>
            page.GetByLabel(text, new() { Exact = true });

        private ILocator DayOfMonth(int day) =>
            page.Locator($".react-datepicker__day--{day:D3}:not(.react-datepicker__day--outside-month)");

        private ILocator ResultValue(string label) =>
            page.Locator($"//div[@class='modal-body']//td[text()='{label}']/following-sibling::td");

        public async Task OpenAsync()
        {
            await page.GotoAsync(Url);
        }

        public async Task FillFormAsync(StudentFormDTO student)
        {
            await FirstNameTextBox.FillAsync(student.FirstName);
            await LastNameTextBox.FillAsync(student.LastName);
            await EmailTextBox.FillAsync(student.Email);
            await CheckOption(student.Gender).CheckAsync();
            await MobileTextBox.FillAsync(student.Mobile);
            await SelectDateOfBirthAsync(student.DateOfBirth);

            foreach (var subject in student.Subjects)
            {
                await SubjectsInput.FillAsync(subject);
                await SubjectsInput.PressAsync("Enter");
            }

            foreach (var hobby in student.Hobbies)
            {
                await CheckOption(hobby).CheckAsync();
            }

            await UploadPictureInput.SetInputFilesAsync(student.PicturePath);
            await CurrentAddressTextArea.FillAsync(student.CurrentAddress);
            await StateInput.FillAsync(student.State);
            await StateInput.PressAsync("Enter");
            await CityInput.FillAsync(student.City);
            await CityInput.PressAsync("Enter");
        }

        public async Task SubmitAsync()
        {
            await SubmitButton.ClickAsync();
        }

        public async Task<string?> GetModalTitleAsync()
        {
            return await ModalTitle.TextContentAsync();
        }

        public async Task<string?> GetResultValueAsync(string label)
        {
            return await ResultValue(label).TextContentAsync();
        }

        private async Task SelectDateOfBirthAsync(DateTime date)
        {
            await DateOfBirthInput.ClickAsync();
            await MonthSelect.SelectOptionAsync(new SelectOptionValue { Label = date.ToString("MMMM", CultureInfo.InvariantCulture) });
            await YearSelect.SelectOptionAsync(date.Year.ToString());
            await DayOfMonth(date.Day).ClickAsync();
        }
    }
}
