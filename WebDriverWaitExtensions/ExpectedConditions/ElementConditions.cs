using System;
using System.Text;
using System.Threading;
using OpenQA.Selenium;

namespace WebDriverWaitExtensions.ExpectedConditions;

internal static class ElementConditions
{
    internal static ThreadLocal<string> ErrorMessage { get; } = new();

    internal static Func<IWebDriver, IWebElement> Exists(By locator, string name)
    {
        return driver =>
        {
            try
            {
                return driver.FindElement(locator);
            }
            catch (NoSuchElementException)
            {
                ErrorMessage.Value = Utilities.GetNoSuchElementExceptionMessage(locator, name);

                return null;
            }
            catch (StaleElementReferenceException)
            {
                ErrorMessage.Value = Utilities.GetStaleElementReferenceExceptionMessage(locator, name);
                return null;
            }
        };
    }

    internal static Func<IWebDriver, bool> DoesNotExist(By locator, string name)
    {
        return driver =>
        {
            var timeout = Utilities.GetWebDriverTimeout(driver);
            Utilities.SetWebDriverTimeout(driver, TimeSpan.FromSeconds(0));

            try
            {
                var element = driver.FindElement(locator);
                ErrorMessage.Value = Utilities.GetErrorMessage(locator, name, element, "The element still exists.");
                return false;
            }
            catch (StaleElementReferenceException)
            {
                ErrorMessage.Value = Utilities.GetStaleElementReferenceExceptionMessage(locator, name);
                return false;
            }
            catch (NoSuchElementException)
            {
                return true;
            }
            finally
            {
                Utilities.SetWebDriverTimeout(driver, timeout);
            }
        };
    }

    internal static Func<IWebDriver, IWebElement> IsVisible(By locator, string name)
    {
        return driver =>
        {
            try
            {
                var element = driver.FindElement(locator);
                if (element.Displayed)
                {
                    return element;
                }

                ErrorMessage.Value = Utilities.GetErrorMessage(locator, name, element, "The element is not visible.");
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

    internal static Func<IWebDriver, IWebElement> IsNotVisible(By locator, string name)
    {
        return driver =>
        {
            var timeout = Utilities.GetWebDriverTimeout(driver);
            Utilities.SetWebDriverTimeout(driver, TimeSpan.FromSeconds(0));

            try
            {
                var element = driver.FindElement(locator);

                if (!element.Displayed)
                {
                    return element;
                }

                ErrorMessage.Value = Utilities.GetErrorMessage(locator, name, element, "The element is still visible.");
                return null;
            }
            catch (NoSuchElementException)
            {
                ErrorMessage.Value = Utilities.GetNoSuchElementExceptionMessage(locator, name);
                return null;
            }
            catch (StaleElementReferenceException)
            {
                ErrorMessage.Value = Utilities.GetStaleElementReferenceExceptionMessage(locator, name);
                return null;
            }
            finally
            {
                Utilities.SetWebDriverTimeout(driver, timeout);
            }
        };
    }

    internal static Func<IWebDriver, IWebElement> IsClickable(By locator, string name)
    {
        return driver =>
        {
            try
            {
                var element = driver.FindElement(locator);

                if (!element.Displayed && !element.Enabled)
                {
                    ErrorMessage.Value = Utilities.GetErrorMessage(locator, name, element, "The element is not clickable as it's not visible and not enabled.");
                    return null;
                }

                if (!element.Displayed)
                {
                    ErrorMessage.Value = Utilities.GetErrorMessage(locator, name, element, "The element is not clickable as it's not visible.");
                    return null;
                }

                if (!element.Enabled)
                {
                    ErrorMessage.Value = Utilities.GetErrorMessage(locator, name, element, "The element is not clickable as it's not enabled.");
                    return null;
                }

                return element;
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

    internal static Func<IWebDriver, IWebElement> IsSelected(By locator, string name)
    {
        return SelectedStateIs(locator, true, name);
    }

    internal static Func<IWebDriver, IWebElement> SelectedStateIs(By locator, bool isSelected, string name)
    {
        return driver =>
        {
            try
            {
                var element = driver.FindElement(locator);

                if (element.Selected != isSelected)
                {
                    ErrorMessage.Value = Utilities.GetErrorMessage(locator, name, element, $"The element selected state is not set to '{isSelected}'.");

                    return null;
                }

                return element;
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

    internal static Func<IWebDriver, IWebElement> StopsMoving(By locator, string name)
    {
        return driver =>
        {
            try
            {
                var element = driver.FindElement(locator);
                var firstLocation = element.Location;
                // Sleep for 500 milliseconds to give the element time to initially move.
                Thread.Sleep(TimeSpan.FromMilliseconds(500));
                var secondLocation = element.Location;

                if (firstLocation.Equals(secondLocation))
                {
                    return driver.FindElement(locator);
                }

                var sb = new StringBuilder();
                sb.AppendLine("The element has not stopped moving.");
                sb.AppendLine($"First location: {firstLocation}");
                sb.Append($"Second location: {secondLocation}");
                ErrorMessage.Value = Utilities.GetErrorMessage(locator, name, element, sb.ToString());

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

    internal static Func<IWebDriver, IWebElement> IsFocused(By locator, string name)
    {
        return driver =>
        {
            try
            {
                var element = driver.FindElement(locator);
                var focusedElement = driver.SwitchTo().ActiveElement();

                if (focusedElement.ToString() == element.ToString())
                    return element;

                var errorMessage = Utilities.GetErrorMessage(locator, name, element, "The element is not focused.");
                var sb = new StringBuilder();
                sb.AppendLine(errorMessage);
                sb.AppendLine("Focused element:");
                Utilities.AppendWebElementInformation(sb, focusedElement);
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

    internal static Func<IWebDriver, IWebElement> AttributeExists(By locator, string attribute, string name)
    {
        return driver =>
        {
            try
            {
                var element = driver.FindElement(locator);

                if (element.GetAttribute(attribute) != null)
                {
                    return element;
                }

                ErrorMessage.Value = Utilities.GetErrorMessage(locator, name, element, $"The attribute '{attribute}' does not exist for the element.");
                return null;
            }
            catch (NoSuchElementException)
            {
                ErrorMessage.Value = Utilities.GetNoSuchElementExceptionMessage(locator, name);

                return null;
            }
            catch (StaleElementReferenceException)
            {
                ErrorMessage.Value = Utilities.GetStaleElementReferenceExceptionMessage(locator, name);
                return null;
            }
        };
    }

    internal static Func<IWebDriver, IWebElement> AttributeDoesNotExists(By locator, string attribute, string name)
    {
        return driver =>
        {
            try
            {
                var element = driver.FindElement(locator);

                if (element.GetAttribute(attribute) == null)
                {
                    return element;
                }

                ErrorMessage.Value = Utilities.GetErrorMessage(locator, name, element, $"The attribute '{attribute}' still exists for the element.");
                return null;
            }
            catch (NoSuchElementException)
            {
                ErrorMessage.Value = Utilities.GetNoSuchElementExceptionMessage(locator, name);

                return null;
            }
            catch (StaleElementReferenceException)
            {
                ErrorMessage.Value = Utilities.GetStaleElementReferenceExceptionMessage(locator, name);
                return null;
            }
        };
    }

    internal static Func<IWebDriver, bool> IsClicked(By locator, string name)
    {
        return driver =>
        {
            try
            {
                driver.FindElement(locator).Click();
                return true;
            }
            catch (NoSuchElementException)
            {
                ErrorMessage.Value = Utilities.GetNoSuchElementExceptionMessage(locator, name);
                return false;
            }
            catch (StaleElementReferenceException)
            {
                ErrorMessage.Value = Utilities.GetStaleElementReferenceExceptionMessage(locator, name);
                return false;
            }
            catch (ElementClickInterceptedException)
            {
                var sb = new StringBuilder();
                sb.AppendLine("Element has not been clicked, 'ElementClickInterceptedException' has been thrown internally.");
                sb.AppendLine($"Locator Name: '{name}'");
                sb.AppendLine($"Locator: '{locator}'");
                ErrorMessage.Value = sb.ToString();
                return false;
            }
        };
    }
}