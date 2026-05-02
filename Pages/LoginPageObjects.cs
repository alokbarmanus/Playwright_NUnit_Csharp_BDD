using Microsoft.Playwright;
using System.Threading.Tasks;

namespace Playwright_NUnit_Csharp_BDD.Pages
{
    public class LoginPage
    {
        private readonly IPage _page;
        public LoginPage(IPage page)
        {
            _page = page;
        }

        // Locators
        private ILocator UsernameInput => _page.Locator("input[name='username']");
        private ILocator PasswordInput => _page.Locator("input[name='password']");
        private ILocator LoginButton => _page.Locator("button[type='submit']");

        // Actions
        public async Task Login(string username, string password)
        {
            await UsernameInput.FillAsync(username);
            await PasswordInput.FillAsync(password);
            await LoginButton.ClickAsync();
            await _page.WaitForTimeoutAsync(6000); // Wait for navigation or response after login, adjust as needed
        }

        public string GetCurrentUrl()
        {
            return _page.Url.ToString();
        }
    }
}
