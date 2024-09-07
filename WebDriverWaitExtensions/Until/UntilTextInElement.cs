using System;
using System.Runtime.CompilerServices;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using WebDriverWaitExtensions.ExpectedConditions;

namespace WebDriverWaitExtensions.Until;

/// <summary>
/// Contains methods for handling text conditions.
/// </summary>
public class UntilTextInElement
{
    private readonly WebDriverWait _wait;

    /// <summary>
    /// Initializes a new instance of the <see cref="UntilTextInElement"/> class.
    /// </summary>
    /// <param name="wait">The WebDriverWait instance to be used for waiting for conditions.</param>
    public UntilTextInElement(WebDriverWait wait)
    {
        _wait = wait;
    }

    private IWebElement DoesNotContain(By locator, string text, TimeSpan? timeout, out Condition condition, bool throwOnException, string name)
    {
        Utilities.SetTimeout(_wait, timeout, out var originalTimeout);
        condition = new Condition();

        try
        {
            var element = _wait.Until(TextInElementConditions.DoesNotContain(locator, text, name));

            condition.Result = true;
            condition.Error = null;

            return element;
        }
        catch (WebDriverTimeoutException ex)
        {
            Utilities.HandleException(TextInElementConditions.ErrorMessage.Value, ex, throwOnException, out condition);
        }
        finally
        {
            Utilities.ResetTimeout(_wait, timeout, originalTimeout);
        }

        return null;
    }

    /// <summary>
    /// An expectation for checking if the given text is not present in the element that matches the given locator.
    /// </summary>
    /// <param name="locator">The locator used to find the element.</param>
    /// <param name="text">The text not to be present in the element.</param>
    /// <param name="name">The name of the locator, used for better error messages. Shouldn't be provided as it's generated automatically.</param>
    /// <returns>The <see cref="IWebElement"/> once the element does not contain the given text.</returns>
    public IWebElement DoesNotContain(By locator, string text, [CallerArgumentExpression("locator")] string name = null)
    {
        return DoesNotContain(locator, text, null, out _, true, name);
    }

    /// <summary>
    /// An expectation for checking if the given text is not present in the element that matches the given locator.
    /// </summary>
    /// <param name="locator">The locator used to find the element.</param>
    /// <param name="text">The text not to be present in the element.</param>
    /// <param name="condition">Out parameter that returns a <see cref="Condition"/> object indicating the result of the condition.</param>
    /// <param name="name">The name of the locator, used for better error messages. Shouldn't be provided as it's generated automatically.</param>
    /// <returns>The <see cref="IWebElement"/> once the element does not contain the given text, otherwise null.</returns>
    public IWebElement DoesNotContain(By locator, string text, out Condition condition, [CallerArgumentExpression("locator")] string name = null)
    {
        return DoesNotContain(locator, text, null, out condition, false, name);
    }

    /// <summary>
    /// An expectation for checking if the given text is not present in the element that matches the given locator.
    /// </summary>
    /// <param name="locator">The locator used to find the element.</param>
    /// <param name="text">The text not to be present in the element.</param>
    /// <param name="timeout">The time to wait for the condition to be successful.</param>
    /// <param name="name">The name of the locator, used for better error messages. Shouldn't be provided as it's generated automatically.</param>
    /// <returns>The <see cref="IWebElement"/> once the element does not contain the given text.</returns>
    public IWebElement DoesNotContain(By locator, string text, TimeSpan timeout, [CallerArgumentExpression("locator")] string name = null)
    {
        return DoesNotContain(locator, text, timeout, out _, true, name);
    }

    /// <summary>
    /// An expectation for checking if the given text is not present in the element that matches the given locator.
    /// </summary>
    /// <param name="locator">The locator used to find the element.</param>
    /// <param name="text">The text not to be present in the element.</param>
    /// <param name="timeout">The time to wait for the condition to be successful.</param>
    /// <param name="condition">Out parameter that returns a <see cref="Condition"/> object indicating the result of the condition.</param>
    /// <param name="name">The name of the locator, used for better error messages. Shouldn't be provided as it's generated automatically.</param>
    /// <returns>The <see cref="IWebElement"/> once the element does not contain the given text, otherwise null.</returns>
    public IWebElement DoesNotContain(By locator, string text, TimeSpan timeout, out Condition condition, [CallerArgumentExpression("locator")] string name = null)
    {
        return DoesNotContain(locator, text, timeout, out condition, false, name);
    }

    private IWebElement AttributeDoesNotContain(By locator, string attribute, string text, TimeSpan? timeout, out Condition condition, bool throwOnException, string name)
    {
        Utilities.SetTimeout(_wait, timeout, out var originalTimeout);
        condition = new Condition();

        try
        {
            var element = _wait.Until(TextInElementConditions.AttributeDoesNotContain(locator, attribute, text, name));

            condition.Result = true;
            condition.Error = null;

            return element;
        }
        catch (WebDriverTimeoutException ex)
        {
            Utilities.HandleException(TextInElementConditions.ErrorMessage.Value, ex, throwOnException, out condition);
        }
        finally
        {
            Utilities.ResetTimeout(_wait, timeout, originalTimeout);
        }

        return null;
    }

    /// <summary>
    /// An expectation for checking if the given text is not present in the given elements attribute.
    /// </summary>
    /// <param name="locator">The locator used to find the element.</param>
    /// <param name="attribute">The attribute which will be compared.</param>
    /// <param name="text">The text not to be present in the element attribute.</param>
    /// <param name="name">The name of the locator, used for better error messages. Shouldn't be provided as it's generated automatically.</param>
    /// <returns>The <see cref="IWebElement"/> once the element attribute does not contain the given text.</returns>
    public IWebElement AttributeDoesNotContain(By locator, string attribute, string text, [CallerArgumentExpression("locator")] string name = null)
    {
        return AttributeDoesNotContain(locator, attribute, text, null, out _, true, name);
    }

    /// <summary>
    /// An expectation for checking if the given text is not present in the given elements attribute.
    /// </summary>
    /// <param name="locator">The locator used to find the element.</param>
    /// <param name="attribute">The attribute which will be compared.</param>
    /// <param name="text">The text not to be present in the element attribute.</param>
    /// <param name="condition">Out parameter that returns a <see cref="Condition"/> object indicating the result of the condition.</param>
    /// <param name="name">The name of the locator, used for better error messages. Shouldn't be provided as it's generated automatically.</param>
    /// <returns>The <see cref="IWebElement"/> once the element attribute does not contain the given text, otherwise null.</returns>
    public IWebElement AttributeDoesNotContain(By locator, string attribute, string text, out Condition condition, [CallerArgumentExpression("locator")] string name = null)
    {
        return AttributeDoesNotContain(locator, attribute, text, null, out condition, false, name);
    }

    /// <summary>
    /// An expectation for checking if the given text is not present in the given elements attribute.
    /// </summary>
    /// <param name="locator">The locator used to find the element.</param>
    /// <param name="attribute">The attribute which will be compared.</param>
    /// <param name="text">The text not to be present in the element attribute.</param>
    /// <param name="timeout">The time to wait for the condition to be successful.</param>
    /// <param name="name">The name of the locator, used for better error messages. Shouldn't be provided as it's generated automatically.</param>
    /// <returns>The <see cref="IWebElement"/> once the element attribute does not contain the given text.</returns>
    public IWebElement AttributeDoesNotContain(By locator, string attribute, string text, TimeSpan timeout, [CallerArgumentExpression("locator")] string name = null)
    {
        return AttributeDoesNotContain(locator, attribute, text, timeout, out _, true, name);
    }

    /// <summary>
    /// An expectation for checking if the given text is not present in the given elements attribute.
    /// </summary>
    /// <param name="locator">The locator used to find the element.</param>
    /// <param name="attribute">The attribute which will be compared.</param>
    /// <param name="text">The text not to be present in the element attribute.</param>
    /// <param name="timeout">The time to wait for the condition to be successful.</param>
    /// <param name="condition">Out parameter that returns a <see cref="Condition"/> object indicating the result of the condition.</param>
    /// <param name="name">The name of the locator, used for better error messages. Shouldn't be provided as it's generated automatically.</param>
    /// <returns>The <see cref="IWebElement"/> once the element attribute does not contain the given text, otherwise null.</returns>
    public IWebElement AttributeDoesNotContain(By locator, string attribute, string text, TimeSpan timeout, out Condition condition, [CallerArgumentExpression("locator")] string name = null)
    {
        return AttributeDoesNotContain(locator, attribute, text, timeout, out condition, false, name);
    }

    private IWebElement CssValueDoesNotContain(By locator, string cssValue, string text, TimeSpan? timeout, out Condition condition, bool throwOnException, string name)
    {
        Utilities.SetTimeout(_wait, timeout, out var originalTimeout);
        condition = new Condition();

        try
        {
            var element = _wait.Until(TextInElementConditions.CssValueDoesNotContain(locator, cssValue, text, name));

            condition.Result = true;
            condition.Error = null;

            return element;
        }
        catch (WebDriverTimeoutException ex)
        {
            Utilities.HandleException(TextInElementConditions.ErrorMessage.Value, ex, throwOnException, out condition);
        }
        finally
        {
            Utilities.ResetTimeout(_wait, timeout, originalTimeout);
        }

        return null;
    }

    /// <summary>
    /// An expectation for checking if the given text is not present in the given elements CSS value.
    /// </summary>
    /// <param name="locator">The locator used to find the element.</param>
    /// <param name="cssValue">The CSS value which will be compared.</param>
    /// <param name="text">The text not to be present in the element CSS value.</param>
    /// <param name="name">The name of the locator, used for better error messages. Shouldn't be provided as it's generated automatically.</param>
    /// <returns>The <see cref="IWebElement"/> once the element CSS value does not contain the given text.</returns>
    public IWebElement CssValueDoesNotContain(By locator, string cssValue, string text, [CallerArgumentExpression("locator")] string name = null)
    {
        return CssValueDoesNotContain(locator, cssValue, text, null, out _, true, name);
    }

    /// <summary>
    /// An expectation for checking if the given text is not present in the given elements CSS value.
    /// </summary>
    /// <param name="locator">The locator used to find the element.</param>
    /// <param name="cssValue">The CSS value which will be compared.</param>
    /// <param name="text">The text not to be present in the element CSS value.</param>
    /// <param name="condition">Out parameter that returns a <see cref="Condition"/> object indicating the result of the condition.</param>
    /// <param name="name">The name of the locator, used for better error messages. Shouldn't be provided as it's generated automatically.</param>
    /// <returns>The <see cref="IWebElement"/> once the element CSS value does not contain the given text, otherwise null.</returns>
    public IWebElement CssValueDoesNotContain(By locator, string cssValue, string text, out Condition condition, [CallerArgumentExpression("locator")] string name = null)
    {
        return CssValueDoesNotContain(locator, cssValue, text, null, out condition, false, name);
    }

    /// <summary>
    /// An expectation for checking if the given text is not present in the given elements CSS value.
    /// </summary>
    /// <param name="locator">The locator used to find the element.</param>
    /// <param name="cssValue">The CSS value which will be compared.</param>
    /// <param name="text">The text not to be present in the element CSS value.</param>
    /// <param name="timeout">The time to wait for the condition to be successful.</param>
    /// <param name="name">The name of the locator, used for better error messages. Shouldn't be provided as it's generated automatically.</param>
    /// <returns>The <see cref="IWebElement"/> once the element CSS value does not contain the given text.</returns>
    public IWebElement CssValueDoesNotContain(By locator, string cssValue, string text, TimeSpan timeout, [CallerArgumentExpression("locator")] string name = null)
    {
        return CssValueDoesNotContain(locator, cssValue, text, timeout, out _, true, name);
    }

    /// <summary>
    /// An expectation for checking if the given text is not present in the given elements CSS value.
    /// </summary>
    /// <param name="locator">The locator used to find the element.</param>
    /// <param name="cssValue">The CSS value which will be compared.</param>
    /// <param name="text">The text not to be present in the element CSS value.</param>
    /// <param name="timeout">The time to wait for the condition to be successful.</param>
    /// <param name="condition">Out parameter that returns a <see cref="Condition"/> object indicating the result of the condition.</param>
    /// <param name="name">The name of the locator, used for better error messages. Shouldn't be provided as it's generated automatically.</param>
    /// <returns>The <see cref="IWebElement"/> once the element CSS value does not contain the given text, otherwise null.</returns>
    public IWebElement CssValueDoesNotContain(By locator, string cssValue, string text, TimeSpan timeout, out Condition condition, [CallerArgumentExpression("locator")] string name = null)
    {
        return CssValueDoesNotContain(locator, cssValue, text, timeout, out condition, false, name);
    }

    private IWebElement ValueDoesNotContain(By locator, string text, TimeSpan? timeout, out Condition condition, bool throwOnException, string name)
    {
        Utilities.SetTimeout(_wait, timeout, out var originalTimeout);
        condition = new Condition();

        try
        {
            var element = _wait.Until(TextInElementConditions.AttributeDoesNotContain(locator, "value", text, name));

            condition.Result = true;
            condition.Error = null;

            return element;
        }
        catch (WebDriverTimeoutException ex)
        {
            Utilities.HandleException(TextInElementConditions.ErrorMessage.Value, ex, throwOnException, out condition);
        }
        finally
        {
            Utilities.ResetTimeout(_wait, timeout, originalTimeout);
        }

        return null;
    }

    /// <summary>
    /// An expectation for checking if the given text is not present in the specified elements value attribute.
    /// </summary>
    /// <param name="locator">The locator used to find the element.</param>
    /// <param name="text">The text not to be present in the element value.</param>
    /// <param name="name">The name of the locator, used for better error messages. Shouldn't be provided as it's generated automatically.</param>
    /// <returns>The <see cref="IWebElement"/> once the element does not contain the given text.</returns>
    public IWebElement ValueDoesNotContain(By locator, string text, [CallerArgumentExpression("locator")] string name = null)
    {
        return ValueDoesNotContain(locator, text, null, out _, true, name);
    }

    /// <summary>
    /// An expectation for checking if the given text is not present in the specified elements value attribute.
    /// </summary>
    /// <param name="locator">The locator used to find the element.</param>
    /// <param name="text">The text not to be present in the element value.</param>
    /// <param name="condition">Out parameter that returns a <see cref="Condition"/> object indicating the result of the condition.</param>
    /// <param name="name">The name of the locator, used for better error messages. Shouldn't be provided as it's generated automatically.</param>
    /// <returns>The <see cref="IWebElement"/> once the element does not contain the given text, otherwise null.</returns>
    public IWebElement ValueDoesNotContain(By locator, string text, out Condition condition, [CallerArgumentExpression("locator")] string name = null)
    {
        return ValueDoesNotContain(locator, text, null, out condition, false, name);
    }

    /// <summary>
    /// An expectation for checking if the given text is not present in the specified elements value attribute.
    /// </summary>
    /// <param name="locator">The locator used to find the element.</param>
    /// <param name="text">The text not to be present in the element value.</param>
    /// <param name="timeout">The time to wait for the condition to be successful.</param>
    /// <param name="name">The name of the locator, used for better error messages. Shouldn't be provided as it's generated automatically.</param>
    /// <returns>The <see cref="IWebElement"/> once the element does not contain the given text.</returns>
    public IWebElement ValueDoesNotContain(By locator, string text, TimeSpan timeout, [CallerArgumentExpression("locator")] string name = null)
    {
        return ValueDoesNotContain(locator, text, timeout, out _, true, name);
    }

    /// <summary>
    /// An expectation for checking if the given text is not present in the specified elements value attribute.
    /// </summary>
    /// <param name="locator">The locator used to find the element.</param>
    /// <param name="text">The text not to be present in the element value.</param>
    /// <param name="condition">Out parameter that returns a <see cref="Condition"/> object indicating the result of the condition.</param>
    /// <param name="timeout">The time to wait for the condition to be successful.</param>
    /// <param name="name">The name of the locator, used for better error messages. Shouldn't be provided as it's generated automatically.</param>
    /// <returns>The <see cref="IWebElement"/> once the element does not contain the given text, otherwise null.</returns>
    public IWebElement ValueDoesNotContain(By locator, string text, TimeSpan timeout, out Condition condition, [CallerArgumentExpression("locator")] string name = null)
    {
        return ValueDoesNotContain(locator, text, timeout, out condition, false, name);
    }

    private IWebElement Contains(By locator, string text, TimeSpan? timeout, out Condition condition, bool throwOnException, string name)
    {
        Utilities.SetTimeout(_wait, timeout, out var originalTimeout);
        condition = new Condition();

        try
        {
            var element = _wait.Until(TextInElementConditions.Contains(locator, text, name));

            condition.Result = true;
            condition.Error = null;

            return element;
        }
        catch (WebDriverTimeoutException ex)
        {
            Utilities.HandleException(TextInElementConditions.ErrorMessage.Value, ex, throwOnException, out condition);
        }
        finally
        {
            Utilities.ResetTimeout(_wait, timeout, originalTimeout);
        }

        return null;
    }

    /// <summary>
    /// An expectation for checking if the given text is present in the element that matches the given locator.
    /// </summary>
    /// <param name="locator">The locator used to find the element.</param>
    /// <param name="text">Text to be present in the element</param>
    /// <param name="name">The name of the locator, used for better error messages. Shouldn't be provided as it's generated automatically.</param>
    /// <returns>The <see cref="IWebElement"/> once the element contains the given text.</returns>
    public IWebElement Contains(By locator, string text, [CallerArgumentExpression("locator")] string name = null)
    {
        return Contains(locator, text, null, out _, true, name);
    }

    /// <summary>
    /// An expectation for checking if the given text is present in the element that matches the given locator.
    /// </summary>
    /// <param name="locator">The locator used to find the element.</param>
    /// <param name="text">Text to be present in the element</param>
    /// <param name="condition">Out parameter that returns a <see cref="Condition"/> object indicating the result of the condition.</param>
    /// <param name="name">The name of the locator, used for better error messages. Shouldn't be provided as it's generated automatically.</param>
    /// <returns>The <see cref="IWebElement"/> once the element contains the given text, otherwise null.</returns>
    public IWebElement Contains(By locator, string text, out Condition condition, [CallerArgumentExpression("locator")] string name = null)
    {
        return Contains(locator, text, null, out condition, false, name);
    }

    /// <summary>
    /// An expectation for checking if the given text is present in the element that matches the given locator.
    /// </summary>
    /// <param name="locator">The locator used to find the element.</param>
    /// <param name="text">Text to be present in the element</param>
    /// <param name="timeout">The time to wait for the condition to be successful.</param>
    /// <param name="name">The name of the locator, used for better error messages. Shouldn't be provided as it's generated automatically.</param>
    /// <returns>The <see cref="IWebElement"/> once the element contains the given text.</returns>
    public IWebElement Contains(By locator, string text, TimeSpan timeout, [CallerArgumentExpression("locator")] string name = null)
    {
        return Contains(locator, text, timeout, out _, true, name);
    }

    /// <summary>
    /// An expectation for checking if the given text is present in the element that matches the given locator.
    /// </summary>
    /// <param name="locator">The locator used to find the element.</param>
    /// <param name="text">Text to be present in the element</param>
    /// <param name="timeout">The time to wait for the condition to be successful.</param>
    /// <param name="condition">Out parameter that returns a <see cref="Condition"/> object indicating the result of the condition.</param>
    /// <param name="name">The name of the locator, used for better error messages. Shouldn't be provided as it's generated automatically.</param>
    /// <returns>The <see cref="IWebElement"/> once the element contains the given text, otherwise null.</returns>
    public IWebElement Contains(By locator, string text, TimeSpan timeout, out Condition condition, [CallerArgumentExpression("locator")] string name = null)
    {
        return Contains(locator, text, timeout, out condition, false, name);
    }

    private IWebElement AttributeContains(By locator, string attribute, string text, TimeSpan? timeout, out Condition condition, bool throwOnException, string name)
    {
        Utilities.SetTimeout(_wait, timeout, out var originalTimeout);
        condition = new Condition();

        try
        {
            var element = _wait.Until(TextInElementConditions.AttributeContains(locator, attribute, text, name));

            condition.Result = true;
            condition.Error = null;

            return element;
        }
        catch (WebDriverTimeoutException ex)
        {
            Utilities.HandleException(TextInElementConditions.ErrorMessage.Value, ex, throwOnException, out condition);
        }
        finally
        {
            Utilities.ResetTimeout(_wait, timeout, originalTimeout);
        }

        return null;
    }

    /// <summary>
    /// An expectation for checking if the given text is present in the given elements attribute.
    /// </summary>
    /// <param name="locator">The locator used to find the element.</param>
    /// <param name="attribute">The attribute which will be compared.</param>
    /// <param name="text">The text to be present in the element attribute.</param>
    /// <param name="name">The name of the locator, used for better error messages. Shouldn't be provided as it's generated automatically.</param>
    /// <returns>The <see cref="IWebElement"/> once the element attribute contains the given text.</returns>
    public IWebElement AttributeContains(By locator, string attribute, string text, [CallerArgumentExpression("locator")] string name = null)
    {
        return AttributeContains(locator, attribute, text, null, out _, true, name);
    }

    /// <summary>
    /// An expectation for checking if the given text is present in the given elements attribute.
    /// </summary>
    /// <param name="locator">The locator used to find the element.</param>
    /// <param name="attribute">The attribute which will be compared.</param>
    /// <param name="text">The text to be present in the element attribute.</param>
    /// <param name="condition">Out parameter that returns a <see cref="Condition"/> object indicating the result of the condition.</param>
    /// <param name="name">The name of the locator, used for better error messages. Shouldn't be provided as it's generated automatically.</param>
    /// <returns>The <see cref="IWebElement"/> once the element attribute contains the given text, otherwise null.</returns>
    public IWebElement AttributeContains(By locator, string attribute, string text, out Condition condition, [CallerArgumentExpression("locator")] string name = null)
    {
        return AttributeContains(locator, attribute, text, null, out condition, false, name);
    }

    /// <summary>
    /// An expectation for checking if the given text is present in the given elements attribute.
    /// </summary>
    /// <param name="locator">The locator used to find the element.</param>
    /// <param name="attribute">The attribute which will be compared.</param>
    /// <param name="text">Text to be present in the element</param>
    /// <param name="timeout">The time to wait for the condition to be successful.</param>
    /// <param name="name">The name of the locator, used for better error messages. Shouldn't be provided as it's generated automatically.</param>
    /// <returns>The <see cref="IWebElement"/> once the element attribute contains the given text.</returns>
    public IWebElement AttributeContains(By locator, string attribute, string text, TimeSpan timeout, [CallerArgumentExpression("locator")] string name = null)
    {
        return AttributeContains(locator, attribute, text, timeout, out _, true, name);
    }

    /// <summary>
    /// An expectation for checking if the given text is present in the given elements attribute.
    /// </summary>
    /// <param name="locator">The locator used to find the element.</param>
    /// <param name="attribute">The attribute which will be compared.</param>
    /// <param name="text">Text to be present in the element</param>
    /// <param name="timeout">The time to wait for the condition to be successful.</param>
    /// <param name="condition">Out parameter that returns a <see cref="Condition"/> object indicating the result of the condition.</param>
    /// <param name="name">The name of the locator, used for better error messages. Shouldn't be provided as it's generated automatically.</param>
    /// <returns>The <see cref="IWebElement"/> once the element attribute contains the given text, otherwise null.</returns>
    public IWebElement AttributeContains(By locator, string attribute, string text, TimeSpan timeout, out Condition condition, [CallerArgumentExpression("locator")] string name = null)
    {
        return AttributeContains(locator, attribute, text, null, out condition, false, name);
    }

    private IWebElement CssValueContains(By locator, string cssValue, string text, TimeSpan? timeout, out Condition condition, bool throwOnException, string name)
    {
        Utilities.SetTimeout(_wait, timeout, out var originalTimeout);
        condition = new Condition();

        try
        {
            var element = _wait.Until(TextInElementConditions.CssValueContains(locator, cssValue, text, name));

            condition.Result = true;
            condition.Error = null;

            return element;
        }
        catch (WebDriverTimeoutException ex)
        {
            Utilities.HandleException(TextInElementConditions.ErrorMessage.Value, ex, throwOnException, out condition);
        }
        finally
        {
            Utilities.ResetTimeout(_wait, timeout, originalTimeout);
        }

        return null;
    }

    /// <summary>
    /// An expectation for checking if the given text is present in the given elements CSS value.
    /// </summary>
    /// <param name="locator">The locator used to find the element.</param>
    /// <param name="cssValue">The CSS value which will be compared.</param>
    /// <param name="text">The text to be present in the element CSS value.</param>
    /// <param name="name">The name of the locator, used for better error messages. Shouldn't be provided as it's generated automatically.</param>
    /// <returns>The <see cref="IWebElement"/> once the element CSS value contains the given text.</returns>
    public IWebElement CssValueContains(By locator, string cssValue, string text, [CallerArgumentExpression("locator")] string name = null)
    {
        return CssValueContains(locator, cssValue, text, null, out _, true, name);
    }

    /// <summary>
    /// An expectation for checking if the given text is present in the given elements CSS value.
    /// </summary>
    /// <param name="locator">The locator used to find the element.</param>
    /// <param name="cssValue">The CSS value which will be compared.</param>
    /// <param name="text">The text to be present in the element CSS value.</param>
    /// <param name="condition">Out parameter that returns a <see cref="Condition"/> object indicating the result of the condition.</param>
    /// <param name="name">The name of the locator, used for better error messages. Shouldn't be provided as it's generated automatically.</param>
    /// <returns>The <see cref="IWebElement"/> once the element CSS value contains the given text, otherwise null.</returns>
    public IWebElement CssValueContains(By locator, string cssValue, string text, out Condition condition, [CallerArgumentExpression("locator")] string name = null)
    {
        return CssValueContains(locator, cssValue, text, null, out condition, false, name);
    }

    /// <summary>
    /// An expectation for checking if the given text is present in the given elements CSS value.
    /// </summary>
    /// <param name="locator">The locator used to find the element.</param>
    /// <param name="cssValue">The CSS value which will be compared.</param>
    /// <param name="text">The text to be present in the element CSS value.</param>
    /// <param name="timeout">The time to wait for the condition to be successful.</param>
    /// <param name="name">The name of the locator, used for better error messages. Shouldn't be provided as it's generated automatically.</param>
    /// <returns>The <see cref="IWebElement"/> once the element CSS value contains the given text.</returns>
    public IWebElement CssValueContains(By locator, string cssValue, string text, TimeSpan timeout, [CallerArgumentExpression("locator")] string name = null)
    {
        return CssValueContains(locator, cssValue, text, timeout, out _, true, name);
    }

    /// <summary>
    /// An expectation for checking if the given text is present in the given elements CSS value.
    /// </summary>
    /// <param name="locator">The locator used to find the element.</param>
    /// <param name="cssValue">The CSS value which will be compared.</param>
    /// <param name="text">The text to be present in the element CSS value.</param>
    /// <param name="timeout">The time to wait for the condition to be successful.</param>
    /// <param name="condition">Out parameter that returns a <see cref="Condition"/> object indicating the result of the condition.</param>
    /// <param name="name">The name of the locator, used for better error messages. Shouldn't be provided as it's generated automatically.</param>
    /// <returns>The <see cref="IWebElement"/> once the element CSS value contains the given text, otherwise null.</returns>
    public IWebElement CssValueContains(By locator, string cssValue, string text, TimeSpan timeout, out Condition condition, [CallerArgumentExpression("locator")] string name = null)
    {
        return CssValueContains(locator, cssValue, text, timeout, out condition, false, name);
    }

    private IWebElement ValueContains(By locator, string text, TimeSpan? timeout, out Condition condition, bool throwOnException, string name)
    {
        Utilities.SetTimeout(_wait, timeout, out var originalTimeout);
        condition = new Condition();

        try
        {
            var element = _wait.Until(TextInElementConditions.AttributeContains(locator, "value", text, name));

            condition.Result = true;
            condition.Error = null;

            return element;
        }
        catch (WebDriverTimeoutException ex)
        {
            Utilities.HandleException(TextInElementConditions.ErrorMessage.Value, ex, throwOnException, out condition);
        }
        finally
        {
            Utilities.ResetTimeout(_wait, timeout, originalTimeout);
        }

        return null;
    }

    /// <summary>
    /// An expectation for checking if the given text is present in the specified elements value attribute.
    /// </summary>
    /// <param name="locator">The locator used to find the element.</param>
    /// <param name="text">Text to be present in the element</param>
    /// <param name="name">The name of the locator, used for better error messages. Shouldn't be provided as it's generated automatically.</param>
    /// <returns>The <see cref="IWebElement"/> once the element contains the given text.</returns>
    public IWebElement ValueContains(By locator, string text, [CallerArgumentExpression("locator")] string name = null)
    {
        return ValueContains(locator, text, null, out _, true, name);
    }

    /// <summary>
    /// An expectation for checking if the given text is present in the specified elements value attribute.
    /// </summary>
    /// <param name="locator">The locator used to find the element.</param>
    /// <param name="text">Text to be present in the element</param>
    /// <param name="condition">Out parameter that returns a <see cref="Condition"/> object indicating the result of the condition.</param>
    /// <param name="name">The name of the locator, used for better error messages. Shouldn't be provided as it's generated automatically.</param>
    /// <returns>The <see cref="IWebElement"/> once the element contains the given text, otherwise null.</returns>
    public IWebElement ValueContains(By locator, string text, out Condition condition, [CallerArgumentExpression("locator")] string name = null)
    {
        return ValueContains(locator, text, null, out condition, false, name);
    }

    /// <summary>
    /// An expectation for checking if the given text is present in the specified elements value attribute.
    /// </summary>
    /// <param name="locator">The locator used to find the element.</param>
    /// <param name="text">Text to be present in the element</param>
    /// <param name="timeout">The time to wait for the condition to be successful.</param>
    /// <param name="name">The name of the locator, used for better error messages. Shouldn't be provided as it's generated automatically.</param>
    /// <returns>The <see cref="IWebElement"/> once the element contains the given text.</returns>
    public IWebElement ValueContains(By locator, string text, TimeSpan timeout, [CallerArgumentExpression("locator")] string name = null)
    {
        return ValueContains(locator, text, timeout, out _, true, name);
    }

    /// <summary>
    /// An expectation for checking if the given text is present in the specified elements value attribute.
    /// </summary>
    /// <param name="locator">The locator used to find the element.</param>
    /// <param name="text">Text to be present in the element</param>
    /// <param name="timeout">The time to wait for the condition to be successful.</param>
    /// <param name="condition">Out parameter that returns a <see cref="Condition"/> object indicating the result of the condition.</param>
    /// <param name="name">The name of the locator, used for better error messages. Shouldn't be provided as it's generated automatically.</param>
    /// <returns>The <see cref="IWebElement"/> once the element contains the given text, otherwise null.</returns>
    public IWebElement ValueContains(By locator, string text, TimeSpan timeout, out Condition condition, [CallerArgumentExpression("locator")] string name = null)
    {
        return ValueContains(locator, text, timeout, out condition, false, name);
    }

    private IWebElement Is(By locator, string text, TimeSpan? timeout, out Condition condition, bool throwOnException, string name)
    {
        Utilities.SetTimeout(_wait, timeout, out var originalTimeout);
        condition = new Condition();

        try
        {
            var element = _wait.Until(TextInElementConditions.Is(locator, text, name));

            condition.Result = true;
            condition.Error = null;

            return element;
        }
        catch (WebDriverTimeoutException ex)
        {
            Utilities.HandleException(TextInElementConditions.ErrorMessage.Value, ex, throwOnException, out condition);
        }
        finally
        {
            Utilities.ResetTimeout(_wait, timeout, originalTimeout);
        }

        return null;
    }

    /// <summary>
    /// An expectation for checking if the given text matches the element text.
    /// </summary>
    /// <param name="locator">The locator used to find the element.</param>
    /// <param name="text">The text to match the element text.</param>
    /// <param name="name">The name of the locator, used for better error messages. Shouldn't be provided as it's generated automatically.</param>
    /// <returns>The <see cref="IWebElement"/> once the element text matches the given text.</returns>
    public IWebElement Is(By locator, string text, [CallerArgumentExpression("locator")] string name = null)
    {
        return Is(locator, text, null, out _, true, name);
    }

    /// <summary>
    /// An expectation for checking if the given text matches the element text.
    /// </summary>
    /// <param name="locator">The locator used to find the element.</param>
    /// <param name="text">The text to match the element text.</param>
    /// <param name="condition">Out parameter that returns a <see cref="Condition"/> object indicating the result of the condition.</param>
    /// <param name="name">The name of the locator, used for better error messages. Shouldn't be provided as it's generated automatically.</param>
    /// <returns>The <see cref="IWebElement"/> once the element text matches the given text, otherwise null.</returns>
    public IWebElement Is(By locator, string text, out Condition condition, [CallerArgumentExpression("locator")] string name = null)
    {
        return Is(locator, text, null, out condition, false, name);
    }

    /// <summary>
    /// An expectation for checking if the given text matches the element text.
    /// </summary>
    /// <param name="locator">The locator used to find the element.</param>
    /// <param name="text">The text to match the element text.</param>
    /// <param name="timeout">The time to wait for the condition to be successful.</param>
    /// <param name="name">The name of the locator, used for better error messages. Shouldn't be provided as it's generated automatically.</param>
    /// <returns>The <see cref="IWebElement"/> once the element text matches the given text.</returns>
    public IWebElement Is(By locator, string text, TimeSpan timeout, [CallerArgumentExpression("locator")] string name = null)
    {
        return Is(locator, text, timeout, out _, true, name);
    }

    /// <summary>
    /// An expectation for checking if the given text matches the element text.
    /// </summary>
    /// <param name="locator">The locator used to find the element.</param>
    /// <param name="text">The text to match the element text.</param>
    /// <param name="timeout">The time to wait for the condition to be successful.</param>
    /// <param name="condition">Out parameter that returns a <see cref="Condition"/> object indicating the result of the condition.</param>
    /// <param name="name">The name of the locator, used for better error messages. Shouldn't be provided as it's generated automatically.</param>
    /// <returns>The <see cref="IWebElement"/> once the element text matches the given text, otherwise null.</returns>
    public IWebElement Is(By locator, string text, TimeSpan timeout, out Condition condition, [CallerArgumentExpression("locator")] string name = null)
    {
        return Is(locator, text, timeout, out condition, false, name);
    }

    private IWebElement AttributeIs(By locator, string attribute, string text, TimeSpan? timeout, out Condition condition, bool throwOnException, string name)
    {
        Utilities.SetTimeout(_wait, timeout, out var originalTimeout);
        condition = new Condition();

        try
        {
            var element = _wait.Until(TextInElementConditions.AttributeIs(locator, attribute, text, name));

            condition.Result = true;
            condition.Error = null;

            return element;
        }
        catch (WebDriverTimeoutException ex)
        {
            Utilities.HandleException(TextInElementConditions.ErrorMessage.Value, ex, throwOnException, out condition);
        }
        finally
        {
            Utilities.ResetTimeout(_wait, timeout, originalTimeout);
        }

        return null;
    }

    /// <summary>
    /// An expectation for checking if the given text matches the given elements attribute.
    /// </summary>
    /// <param name="locator">The locator used to find the element.</param>
    /// <param name="attribute">The attribute which will be compared.</param>
    /// <param name="text">The text to match the element attribute.</param>
    /// <param name="name">The name of the locator, used for better error messages. Shouldn't be provided as it's generated automatically.</param>
    /// <returns>The <see cref="IWebElement"/> once the element attribute matches the given text.</returns>
    public IWebElement AttributeIs(By locator, string attribute, string text, [CallerArgumentExpression("locator")] string name = null)
    {
        return AttributeIs(locator, attribute, text, null, out _, true, name);
    }

    /// <summary>
    /// An expectation for checking if the given text matches the given elements attribute.
    /// </summary>
    /// <param name="locator">The locator used to find the element.</param>
    /// <param name="attribute">The attribute which will be compared.</param>
    /// <param name="text">The text to match the element attribute.</param>
    /// <param name="condition">Out parameter that returns a <see cref="Condition"/> object indicating the result of the condition.</param>
    /// <param name="name">The name of the locator, used for better error messages. Shouldn't be provided as it's generated automatically.</param>
    /// <returns>The <see cref="IWebElement"/> once the element text matches the given text, otherwise null.</returns>
    public IWebElement AttributeIs(By locator, string attribute, string text, out Condition condition, [CallerArgumentExpression("locator")] string name = null)
    {
        return AttributeIs(locator, attribute, text, null, out condition, false, name);
    }

    /// <summary>
    /// An expectation for checking if the given text matches the element text.
    /// </summary>
    /// <param name="locator">The locator used to find the element.</param>
    /// <param name="attribute">The attribute which will be compared.</param>
    /// <param name="text">The text to match the element text.</param>
    /// <param name="timeout">The time to wait for the condition to be successful.</param>
    /// <param name="name">The name of the locator, used for better error messages. Shouldn't be provided as it's generated automatically.</param>
    /// <returns>The <see cref="IWebElement"/> once the element text matches the given text.</returns>
    public IWebElement AttributeIs(By locator, string attribute, string text, TimeSpan timeout, [CallerArgumentExpression("locator")] string name = null)
    {
        return AttributeIs(locator, attribute, text, timeout, out _, true, name);
    }

    /// <summary>
    /// An expectation for checking if the given text matches the element text.
    /// </summary>
    /// <param name="locator">The locator used to find the element.</param>
    /// <param name="attribute">The attribute which will be compared.</param>
    /// <param name="text">The text to match the element text.</param>
    /// <param name="timeout">The time to wait for the condition to be successful.</param>
    /// <param name="condition">Out parameter that returns a <see cref="Condition"/> object indicating the result of the condition.</param>
    /// <param name="name">The name of the locator, used for better error messages. Shouldn't be provided as it's generated automatically.</param>
    /// <returns>The <see cref="IWebElement"/> once the element text matches the given text, otherwise null.</returns>
    public IWebElement AttributeIs(By locator, string attribute, string text, TimeSpan timeout, out Condition condition, [CallerArgumentExpression("locator")] string name = null)
    {
        return AttributeIs(locator, attribute, text, timeout, out condition, false, name);
    }

    private IWebElement ValueIs(By locator, string text, TimeSpan? timeout, out Condition condition, bool throwOnException, string name)
    {
        Utilities.SetTimeout(_wait, timeout, out var originalTimeout);
        condition = new Condition();

        try
        {
            var element = _wait.Until(TextInElementConditions.AttributeIs(locator, "value", text, name));

            condition.Result = true;
            condition.Error = null;

            return element;
        }
        catch (WebDriverTimeoutException ex)
        {
            Utilities.HandleException(TextInElementConditions.ErrorMessage.Value, ex, throwOnException, out condition);
        }
        finally
        {
            Utilities.ResetTimeout(_wait, timeout, originalTimeout);
        }

        return null;
    }

    /// <summary>
    /// An expectation for checking if the given text matches the specified elements value attribute.
    /// </summary>
    /// <param name="locator">The locator used to find the element.</param>
    /// <param name="text">The text to match the element value.</param>
    /// <param name="name">The name of the locator, used for better error messages. Shouldn't be provided as it's generated automatically.</param>
    /// <returns>The <see cref="IWebElement"/> once the element value matches the given text.</returns>
    public IWebElement ValueIs(By locator, string text, [CallerArgumentExpression("locator")] string name = null)
    {
        return ValueIs(locator, text, null, out _, true, name);
    }

    /// <summary>
    /// An expectation for checking if the given text matches the specified elements value attribute.
    /// </summary>
    /// <param name="locator">The locator used to find the element.</param>
    /// <param name="text">The text to match the element value.</param>
    /// <param name="condition">Out parameter that returns a <see cref="Condition"/> object indicating the result of the condition.</param>
    /// <param name="name">The name of the locator, used for better error messages. Shouldn't be provided as it's generated automatically.</param>
    /// <returns>The <see cref="IWebElement"/> once the element value matches the given text, otherwise null.</returns>
    public IWebElement ValueIs(By locator, string text, out Condition condition, [CallerArgumentExpression("locator")] string name = null)
    {
        return ValueIs(locator, text, null, out condition, false, name);
    }

    /// <summary>
    /// An expectation for checking if the given text matches the specified elements value attribute.
    /// </summary>
    /// <param name="locator">The locator used to find the element.</param>
    /// <param name="text">The text to match the element value.</param>
    /// <param name="timeout">The time to wait for the condition to be successful.</param>
    /// <param name="name">The name of the locator, used for better error messages. Shouldn't be provided as it's generated automatically.</param>
    /// <returns>The <see cref="IWebElement"/> once the element value matches the given text.</returns>
    public IWebElement ValueIs(By locator, string text, TimeSpan timeout, [CallerArgumentExpression("locator")] string name = null)
    {
        return ValueIs(locator, text, timeout, out _, true, name);
    }

    /// <summary>
    /// An expectation for checking if the given text matches the specified elements value attribute.
    /// </summary>
    /// <param name="locator">The locator used to find the element.</param>
    /// <param name="text">The text to match the element value.</param>
    /// <param name="timeout">The time to wait for the condition to be successful.</param>
    /// <param name="condition">Out parameter that returns a <see cref="Condition"/> object indicating the result of the condition.</param>
    /// <param name="name">The name of the locator, used for better error messages. Shouldn't be provided as it's generated automatically.</param>
    /// <returns>The <see cref="IWebElement"/> once the element value matches the given text, otherwise null.</returns>
    public IWebElement ValueIs(By locator, string text, TimeSpan timeout, out Condition condition, [CallerArgumentExpression("locator")] string name = null)
    {
        return ValueIs(locator, text, timeout, out condition, false, name);
    }

    private IWebElement CssValueIs(By locator, string cssValue, string text, TimeSpan? timeout, out Condition condition, bool throwOnException, string name)
    {
        Utilities.SetTimeout(_wait, timeout, out var originalTimeout);
        condition = new Condition();

        try
        {
            var element = _wait.Until(TextInElementConditions.CssValueIs(locator, cssValue, text, name));

            condition.Result = true;
            condition.Error = null;

            return element;
        }
        catch (WebDriverTimeoutException ex)
        {
            Utilities.HandleException(TextInElementConditions.ErrorMessage.Value, ex, throwOnException, out condition);
        }
        finally
        {
            Utilities.ResetTimeout(_wait, timeout, originalTimeout);
        }

        return null;
    }

    /// <summary>
    /// An expectation for checking if the given text matches the given elements CSS value.
    /// </summary>
    /// <param name="locator">The locator used to find the element.</param>
    /// <param name="cssValue">The CSS value which will be compared.</param>
    /// <param name="text">The text to match the element CSS value.</param>
    /// <param name="name">The name of the locator, used for better error messages. Shouldn't be provided as it's generated automatically.</param>
    /// <returns>The <see cref="IWebElement"/> once the element CSS value matches the given text.</returns>
    public IWebElement CssValueIs(By locator, string cssValue, string text, [CallerArgumentExpression("locator")] string name = null)
    {
        return CssValueIs(locator, cssValue, text, null, out _, true, name);
    }

    /// <summary>
    /// An expectation for checking if the given text matches the given elements CSS value.
    /// </summary>
    /// <param name="locator">The locator used to find the element.</param>
    /// <param name="cssValue">The CSS value which will be compared.</param>
    /// <param name="text">The text to match the element CSS value.</param>
    /// <param name="condition">Out parameter that returns a <see cref="Condition"/> object indicating the result of the condition.</param>
    /// <param name="name">The name of the locator, used for better error messages. Shouldn't be provided as it's generated automatically.</param>
    /// <returns>The <see cref="IWebElement"/> once the element CSS value matches the given text, otherwise null.</returns>
    public IWebElement CssValueIs(By locator, string cssValue, string text, out Condition condition, [CallerArgumentExpression("locator")] string name = null)
    {
        return CssValueIs(locator, cssValue, text, null, out condition, false, name);
    }

    /// <summary>
    /// An expectation for checking if the given text matches the given elements CSS value.
    /// </summary>
    /// <param name="locator">The locator used to find the element.</param>
    /// <param name="cssValue">The CSS value which will be compared.</param>
    /// <param name="text">The text to match the element CSS value.</param>
    /// <param name="timeout">The time to wait for the condition to be successful.</param>
    /// <param name="name">The name of the locator, used for better error messages. Shouldn't be provided as it's generated automatically.</param>
    /// <returns>The <see cref="IWebElement"/> once the element CSS value matches the given text.</returns>
    public IWebElement CssValueIs(By locator, string cssValue, string text, TimeSpan timeout, [CallerArgumentExpression("locator")] string name = null)
    {
        return CssValueIs(locator, cssValue, text, timeout, out _, true, name);
    }

    /// <summary>
    /// An expectation for checking if the given text matches the given elements CSS value.
    /// </summary>
    /// <param name="locator">The locator used to find the element.</param>
    /// <param name="cssValue">The CSS value which will be compared.</param>
    /// <param name="text">The text to match the element CSS value.</param>
    /// <param name="timeout">The time to wait for the condition to be successful.</param>
    /// <param name="condition">Out parameter that returns a <see cref="Condition"/> object indicating the result of the condition.</param>
    /// <param name="name">The name of the locator, used for better error messages. Shouldn't be provided as it's generated automatically.</param>
    /// <returns>The <see cref="IWebElement"/> once the element CSS value matches the given text, otherwise null.</returns>
    public IWebElement CssValueIs(By locator, string cssValue, string text, TimeSpan timeout, out Condition condition, [CallerArgumentExpression("locator")] string name = null)
    {
        return CssValueIs(locator, cssValue, text, timeout, out condition, false, name);
    }
}