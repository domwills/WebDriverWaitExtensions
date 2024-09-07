using System;
using System.Text;
using System.Threading;
using OpenQA.Selenium;

namespace WebDriverWaitExtensions.ExpectedConditions;

internal static class TextInElementConditions
{
    internal static ThreadLocal<string> ErrorMessage { get; } = new();

    internal static Func<IWebDriver, IWebElement> DoesNotContain(By locator, string text, string name)
    {
        return driver =>
        {
            try
            {
                var element = driver.FindElement(locator);
                var elementText = element.Text;

                if (!elementText.Contains(text))
                {
                    return element;
                }

                ErrorMessage.Value = Utilities.GetErrorMessage(locator, name, element, $"The element text still contains '{text}'.");
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

    internal static Func<IWebDriver, IWebElement> AttributeDoesNotContain(By locator, string attribute, string text, string name)
    {
        return driver =>
        {
            try
            {
                var element = driver.FindElement(locator);
                var elementValue = element.GetAttribute(attribute);

                if (!elementValue.Contains(text))
                {
                    return element;
                }

                var sb = new StringBuilder();
                sb.AppendLine($"The element attribute '{attribute}' still contains '{text}'.");
                sb.AppendLine($"Attribute: '{attribute}'");
                sb.Append($"Attribute text: '{elementValue}'");
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

    internal static Func<IWebDriver, IWebElement> CssValueDoesNotContain(By locator, string cssValue, string text, string name)
    {
        return driver =>
        {
            try
            {
                var element = driver.FindElement(locator);
                var elementValue = element.GetCssValue(cssValue);

                if (!elementValue.Contains(text))
                {
                    return element;
                }

                var sb = new StringBuilder();
                sb.AppendLine($"The element CSS value '{cssValue}' still contains '{text}'.");
                sb.AppendLine($"CSS value: '{cssValue}'");
                sb.Append($"CSS value text: '{elementValue}'");
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

    internal static Func<IWebDriver, IWebElement> Contains(By locator, string text, string name)
    {
        return driver =>
        {
            try
            {
                var element = driver.FindElement(locator);
                var elementText = element.Text;

                if (elementText.Contains(text))
                {
                    return element;
                }

                var sb = new StringBuilder();
                sb.AppendLine($"The element text does not contain '{text}'.");
                sb.AppendLine($"Element text: '{elementText}'");
                sb.Append($"Should contain: '{text}'");
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

    internal static Func<IWebDriver, IWebElement> AttributeContains(By locator, string attribute, string text, string name)
    {
        return driver =>
        {
            try
            {
                var element = driver.FindElement(locator);
                var elementValue = element.GetAttribute(attribute);

                if (elementValue.Contains(text))
                {
                    return element;
                }

                var sb = new StringBuilder();
                sb.AppendLine($"The element attribute '{attribute}' does not contain '{text}'.");
                sb.AppendLine($"Attribute: '{attribute}'");
                sb.AppendLine($"Attribute text: '{elementValue}'");
                sb.Append($"Should contain: '{text}'");
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

    internal static Func<IWebDriver, IWebElement> CssValueContains(By locator, string cssValue, string text, string name)
    {
        return driver =>
        {
            try
            {
                var element = driver.FindElement(locator);
                var elementValue = element.GetCssValue(cssValue);

                if (elementValue.Contains(text))
                {
                    return element;
                }

                var sb = new StringBuilder();
                sb.AppendLine($"The element CSS value '{cssValue}' does not contain '{text}'.");
                sb.AppendLine($"CSS value: '{cssValue}'");
                sb.AppendLine($"CSS value text: '{elementValue}'");
                sb.Append($"Should contain: '{text}'");
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

    internal static Func<IWebDriver, IWebElement> Is(By locator, string text, string name)
    {
        return driver =>
        {
            try
            {
                var element = driver.FindElement(locator);
                var elementText = element.Text;

                if (elementText == text)
                {
                    return element;
                }

                var sb = new StringBuilder();
                sb.AppendLine($"The element text does not match '{text}'.");
                sb.AppendLine($"Element text: '{element.Text}'");
                sb.Append($"Should be: '{text}'");
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

    internal static Func<IWebDriver, IWebElement> AttributeIs(By locator, string attribute, string text, string name)
    {
        return driver =>
        {
            try
            {
                var element = driver.FindElement(locator);
                var elementValue = element.GetAttribute(attribute);

                if (elementValue == text)
                {
                    return element;
                }

                var sb = new StringBuilder();
                sb.AppendLine($"The element attribute '{attribute}' does not match '{text}'.");
                sb.AppendLine($"Attribute: '{attribute}'");
                sb.AppendLine($"Attribute text: '{elementValue}'");
                sb.Append($"Should be: '{text}'");
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

    internal static Func<IWebDriver, IWebElement> CssValueIs(By locator, string cssValue, string text, string name)
    {
        return driver =>
        {
            try
            {
                var element = driver.FindElement(locator);
                var elementValue = element.GetCssValue(cssValue);

                if (elementValue == text)
                {
                    return element;
                }

                var sb = new StringBuilder();
                sb.AppendLine($"The element CSS value '{cssValue}' does not match '{text}'.");
                sb.AppendLine($"CSS value: '{cssValue}'");
                sb.AppendLine($"CSS value text: '{elementValue}'");
                sb.Append($"Should be: '{text}'");
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
}