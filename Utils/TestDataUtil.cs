using System.Collections.Generic;

namespace Playwright_NUnit_Csharp_BDD.Utils
{
    public static class TestDataUtil
    {
        public static Dictionary<string, string> GetTestUser()
        {
            return new Dictionary<string, string>
            {
                { "username", "Admin" },
                { "password", "admin123" }
            };
        }
    }
}
