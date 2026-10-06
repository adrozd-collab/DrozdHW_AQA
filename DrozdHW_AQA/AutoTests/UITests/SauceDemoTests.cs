using DrozdHW_AQA.DTO.SauceDemoDTO;
using DrozdHW_AQA.Utils;
using FluentAssertions;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;

namespace DrozdHW_AQA.AutoTests.UITests
{
    public class SauceDemoTests : BaseTest
    {
        [Test]
        public async Task SuccessfulLogin()
        {
            await Page.GotoAsync("https://www.saucedemo.com");
            var userNameTextBox = Page.GetByPlaceholder("Username");
            await userNameTextBox.FillAsync("standard_user");
            var passwordTextBox = Page.GetByPlaceholder("Password");
            await passwordTextBox.FillAsync("secret_sauce");
            var loginButton = Page.GetByRole(AriaRole.Button, new() { Name = "Login" });
            await loginButton.ClickAsync();
            var productsTitle = Page.Locator(".title");
            var productsTitleText = await productsTitle.TextContentAsync();
            productsTitleText.Should().Contain("Products");
        }

        private static IEnumerable<TestCaseData> ValidUsers()
        {
            var users = JsonFileReader.ReadAndDeserialize<List<SauceDemoUserDTO>>("SauceDemoUsers.json");

            foreach (var user in users)
            {
                yield return new TestCaseData(user).SetName($"SuccessfulLogin_{user.Username}");
            }
        }

        [TestCaseSource(nameof(ValidUsers))]
        public async Task SuccessfulLoginOfValidUsers(SauceDemoUserDTO user)
        {
            await Page.GotoAsync("https://www.saucedemo.com");
            var userNameTextBox = Page.GetByPlaceholder("Username");
            await userNameTextBox.FillAsync(user.Username);
            var passwordTextBox = Page.GetByPlaceholder("Password");
            await passwordTextBox.FillAsync(user.Password);
            var loginButton = Page.GetByRole(AriaRole.Button, new() { Name = "Login" });
            await loginButton.ClickAsync();
            var productsTitle = Page.Locator(".title");
            var productsTitleText = await productsTitle.TextContentAsync();
            productsTitleText.Should().Contain("Products");
        }
    }
}
