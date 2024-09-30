using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium;

namespace WebDriverWaitExtensions.ExpectedConditions;

internal static class NetworkConditions
{
    internal static ThreadLocal<string> ErrorMessage { get; } = new();

    internal static Func<IWebDriver, bool> RequestSent(string url, List<string> requests)
    {
        return _ =>
        {
            if (requests.Any(request => request == url))
            {
                return true;
            }

            var sb = new StringBuilder();
            sb.AppendLine("No URL has been found in the list of requests.");
            sb.AppendLine($"URL: '{url}'");
            ErrorMessage.Value = sb.ToString();

            return false;
        };
    }
}