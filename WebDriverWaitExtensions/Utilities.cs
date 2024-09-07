using System;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace WebDriverWaitExtensions;

internal static class Utilities
{
    internal static void SetWebDriverTimeout(IWebDriver driver, TimeSpan timeout)
    {
        driver.Manage().Timeouts().ImplicitWait = timeout;
    }

    internal static TimeSpan GetWebDriverTimeout(IWebDriver driver)
    {
        return driver.Manage().Timeouts().ImplicitWait;
    }

    internal static void SetTimeout(WebDriverWait wait, TimeSpan? timeout, out TimeSpan? originalTimeout)
    {
        originalTimeout = null;

        if (!timeout.HasValue)
        {
            return;
        }

        originalTimeout = wait.Timeout;
        wait.Timeout = timeout.Value;
    }

    internal static void ResetTimeout(WebDriverWait wait, TimeSpan? timeout, TimeSpan? originalTimeout)
    {
        if (timeout.HasValue)
        {
            wait.Timeout = originalTimeout.Value;
        }
    }

    internal static void HandleException(string errorMessage, WebDriverTimeoutException ex, bool throwOnException, out Condition condition)
    {
        var exception = new WebDriverTimeoutException(errorMessage, ex);

        if (throwOnException)
        {
            throw exception;
        }

        condition = new Condition
        {
            Result = false,
            Error = exception.ToString()
        };
    }

    internal static void AppendWebElementInformation(StringBuilder sb, IWebElement element)
    {
        sb.AppendLine($"Displayed: {element.Displayed}");
        sb.AppendLine($"Enabled: {element.Enabled}");
        sb.AppendLine($"Location: {element.Location}");
        sb.AppendLine($"Selected: {element.Selected}");
        sb.AppendLine($"Size: {element.Size}");
        sb.AppendLine($"TagName: {element.TagName}");
        sb.AppendLine($"Text: '{element.Text}'");
    }

    internal static string GetNoSuchElementExceptionMessage(By locator, string name)
    {
        var sb = new StringBuilder();
        sb.AppendLine("The element does not exist, 'NoSuchElementException' has been thrown internally.");
        sb.AppendLine($"Locator Name: '{name}'");
        sb.AppendLine($"Locator: '{locator}'");
        return sb.ToString();
    }

    internal static string GetStaleElementReferenceExceptionMessage(By locator, string name)
    {
        var sb = new StringBuilder();
        sb.AppendLine("The element reference is no longer valid, 'StaleElementReferenceException' has been thrown internally.");
        sb.AppendLine($"Locator Name: '{name}'");
        sb.AppendLine($"Locator: '{locator}'");
        return sb.ToString();
    }

    internal static string GetErrorMessage(By locator, string name, IWebElement element, string errorMessage)
    {
        var sb = new StringBuilder();
        sb.AppendLine(errorMessage);
        sb.AppendLine($"Locator Name: '{name}'");
        sb.AppendLine($"Locator: '{locator}'");
        AppendWebElementInformation(sb, element);
        return sb.ToString();
    }
}