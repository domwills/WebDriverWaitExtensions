using System;
using System.Threading;
using OpenQA.Selenium;

namespace WebDriverWaitExtensions.ExpectedConditions;

internal static class AlertConditions
{
    internal static ThreadLocal<string> ErrorMessage { get; } = new();

    internal static Func<IWebDriver, IAlert> IsSwitchedTo()
    {
        return driver =>
        {
            try
            {
                return driver.SwitchTo().Alert();
            }
            catch (NoAlertPresentException)
            {
                ErrorMessage.Value = "No alert is available to switch to.";
                return null;
            }
        };
    }
}