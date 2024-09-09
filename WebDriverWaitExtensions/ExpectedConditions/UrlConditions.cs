using System;
using System.Text;
using System.Threading;
using OpenQA.Selenium;

namespace WebDriverWaitExtensions.ExpectedConditions;

internal static class UrlConditions
{
    internal static ThreadLocal<string> ErrorMessage { get; } = new();

    internal static Func<IWebDriver, bool> Is(string url)
    {
        return driver =>
        {
            var currentUrl = driver.Url;
            var isMatch = currentUrl.ToLowerInvariant().Equals(url.ToLowerInvariant());

            if (isMatch)
            {
                return true;
            }

            var sb = new StringBuilder();
            sb.AppendLine($"The URL doesn't match '{url}'.");
            sb.AppendLine($"Actual URL: '{currentUrl}'");
            sb.AppendLine($"Expected URL: '{url}'");
            ErrorMessage.Value = sb.ToString();

            return false;
        };
    }

    internal static Func<IWebDriver, bool> Contains(string fraction)
    {
        return driver =>
        {
            var currentUrl = driver.Url;
            var isMatch = currentUrl.ToLowerInvariant().Contains(fraction.ToLowerInvariant());

            if (isMatch)
            {
                return true;
            }

            var sb = new StringBuilder();
            sb.AppendLine($"The URL doesn't contain '{fraction}'.");
            sb.AppendLine($"Actual URL: '{currentUrl}'");
            sb.AppendLine($"Should contain: '{fraction}'");
            ErrorMessage.Value = sb.ToString();

            return false;
        };
    }
}