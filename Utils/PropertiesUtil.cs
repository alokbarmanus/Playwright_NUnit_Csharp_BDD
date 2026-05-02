using System;
using System.Collections.Generic;
using System.IO;

namespace Playwright_NUnit_Csharp_BDD.Utils
{
    public static class PropertiesUtil
    {
        public static Dictionary<string, string> LoadProperties(string filePath)
        {
            var dict = new Dictionary<string, string>();
            foreach (var line in File.ReadAllLines(filePath))
            {
                var trimmed = line.Trim();
                if (string.IsNullOrEmpty(trimmed) || trimmed.StartsWith("#")) continue;
                var idx = trimmed.IndexOf('=');
                if (idx > 0)
                {
                    var key = trimmed.Substring(0, idx).Trim();
                    var value = trimmed.Substring(idx + 1).Trim();
                    dict[key] = value;
                }
            }
            return dict;
        }
    }
}