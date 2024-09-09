using System;
using System.Text;
using System.Threading;
using OpenQA.Selenium;

namespace WebDriverWaitExtensions.ExpectedConditions;

internal static class FrameConditions
{
    internal static ThreadLocal<string> ErrorMessage { get; } = new();

    internal static Func<IWebDriver, IWebDriver> IsSwitchedTo(string frameLocator)
    {
        return driver =>
        {
            try
            {
                return driver.SwitchTo().Frame(frameLocator);
            }
            catch (NoSuchFrameException)
            {
                var sb = new StringBuilder();
                sb.AppendLine("No frame is available to switch to.");
                sb.AppendLine($"Frame locator: '{frameLocator}'");
                ErrorMessage.Value = sb.ToString();
                return null;
            }
        };
    }

    internal static Func<IWebDriver, IWebDriver> IsSwitchedTo(By locator, string name)
    {
        return driver =>
        {
            try
            {
                var frameElement = driver.FindElement(locator);
                return driver.SwitchTo().Frame(frameElement);
            }
            catch (NoSuchFrameException)
            {
                var sb = new StringBuilder();
                sb.AppendLine("No frame is available to switch to.");
                sb.AppendLine($"Locator Name: '{name}'");
                sb.AppendLine($"Locator: '{locator}'");
                ErrorMessage.Value = sb.ToString();
                return null;
            }
            catch (StaleElementReferenceException)
            {
                ErrorMessage.Value = Utilities.GetStaleElementReferenceExceptionMessage(locator, name);
                return null;
            }
            catch (NoSuchElementException)
            {
                ErrorMessage.Value = Utilities.GetNoSuchElementExceptionMessage(locator, name);
                return null;
            }
        };
    }
}