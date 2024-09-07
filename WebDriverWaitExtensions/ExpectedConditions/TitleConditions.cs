using System;
using System.Text;
using System.Threading;
using OpenQA.Selenium;

namespace WebDriverWaitExtensions.ExpectedConditions;

internal static class TitleConditions
{
    internal static ThreadLocal<string> ErrorMessage { get; } = new();

    internal static Func<IWebDriver, bool> Is(string title)
    {
        return driver =>
        {
            var currentTitle = driver.Title;
            var isMatch = title == currentTitle;

            if (isMatch)
            {
                return true;
            }

            var sb = new StringBuilder();
            sb.AppendLine($"The browser window title doesn't match '{title}'.");
            sb.AppendLine($"Actual title: '{currentTitle}'");
            sb.AppendLine($"Expected title: '{title}'");
            ErrorMessage.Value = sb.ToString();

            return false;
        };
    }

    internal static Func<IWebDriver, bool> Contains(string title)
    {
        return driver =>
        {
            var currentTitle = driver.Title;
            var isMatch = currentTitle.Contains(title);

            if (isMatch)
            {
                return true;
            }

            var sb = new StringBuilder();
            sb.AppendLine($"The browser window title doesn't contain '{title}'.");
            sb.AppendLine($"Actual title: '{currentTitle}'");
            sb.AppendLine($"Should contain: '{title}'");
            ErrorMessage.Value = sb.ToString();

            return false;
        };
    }
}