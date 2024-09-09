using System;
using System.Runtime.CompilerServices;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using WebDriverWaitExtensions.ExpectedConditions;

namespace WebDriverWaitExtensions.Until;

/// <summary>
/// Contains methods for handling frame conditions.
/// </summary>
public class UntilFrame
{
    private readonly WebDriverWait _wait;

    /// <summary>
    /// Initializes a new instance of the <see cref="UntilFrame"/> class.
    /// </summary>
    /// <param name="wait">The WebDriverWait instance to be used for waiting for conditions.</param>
    public UntilFrame(WebDriverWait wait)
    {
        _wait = wait;
    }

    private IWebDriver IsSwitchedTo(string frameLocator, TimeSpan? timeout, out Condition condition, bool throwOnException)
    {
        Utilities.SetTimeout(_wait, timeout, out var originalTimeout);
        condition = new Condition();

        try
        {
            var driver = _wait.Until(FrameConditions.IsSwitchedTo(frameLocator));

            condition.Result = true;
            condition.Error = null;

            return driver;
        }
        catch (WebDriverTimeoutException ex)
        {
            Utilities.HandleException(FrameConditions.ErrorMessage.Value, ex, throwOnException, out condition);
        }
        finally
        {
            Utilities.ResetTimeout(_wait, timeout, originalTimeout);
        }

        return null;
    }

    /// <summary>
    /// An expectation for checking whether the given frame is available to switch to.
    ///  If the frame is available it switches the given driver to the specified frame.
    /// </summary>
    /// <param name="frameLocator">Used to find the frame (id or name)</param>
    /// <returns>An <see cref="IWebDriver"/> object if the frame is available and switched to within the specified time.</returns>
    public IWebDriver IsSwitchedTo(string frameLocator)
    {
        return IsSwitchedTo(frameLocator, null, out _, true);
    }

    /// <summary>
    /// An expectation for checking whether the given frame is available to switch to.
    ///  If the frame is available it switches the given driver to the specified frame.
    /// </summary>
    /// <param name="frameLocator">Used to find the frame (id or name)</param>
    /// <param name="timeout">The time to wait for the condition to be successful.</param>
    /// <returns>An <see cref="IWebDriver"/> object if the frame is available and switched to within the specified time.</returns>
    public IWebDriver IsSwitchedTo(string frameLocator, TimeSpan timeout)
    {
        return IsSwitchedTo(frameLocator, timeout, out _, true);
    }

    /// <summary>
    /// An expectation for checking whether the given frame is available to switch to.
    ///  If the frame is available it switches the given driver to the specified frame.
    /// </summary>
    /// <param name="frameLocator">Used to find the frame (id or name)</param>
    /// <param name="condition">Out parameter that returns a <see cref="Condition"/> object indicating the result of the condition.</param>
    /// <returns>An <see cref="IWebDriver"/> object if the frame is available and switched to within the specified time, null otherwise.</returns>
    public IWebDriver IsSwitchedTo(string frameLocator, out Condition condition)
    {
        return IsSwitchedTo(frameLocator, null, out condition, false);
    }

    /// <summary>
    /// An expectation for checking whether the given frame is available to switch to.
    ///  If the frame is available it switches the given driver to the specified frame.
    /// </summary>
    /// <param name="frameLocator">Used to find the frame (id or name)</param>
    /// <param name="timeout">The time to wait for the condition to be successful.</param>
    /// <param name="condition">Out parameter that returns a <see cref="Condition"/> object indicating the result of the condition.</param>
    /// <returns>An <see cref="IWebDriver"/> object if the frame is available and switched to within the specified time, null otherwise.</returns>
    public IWebDriver IsSwitchedTo(string frameLocator, TimeSpan timeout, out Condition condition)
    {
        return IsSwitchedTo(frameLocator, timeout, out condition, false);
    }

    private IWebDriver IsSwitchedTo(By locator, TimeSpan? timeout, out Condition condition, bool throwOnException, string name)
    {
        Utilities.SetTimeout(_wait, timeout, out var originalTimeout);
        condition = new Condition();

        try
        {
            var driver = _wait.Until(FrameConditions.IsSwitchedTo(locator, name));

            condition.Result = true;
            condition.Error = null;

            return driver;
        }
        catch (WebDriverTimeoutException ex)
        {
            Utilities.HandleException(FrameConditions.ErrorMessage.Value, ex, throwOnException, out condition);
        }
        finally
        {
            Utilities.ResetTimeout(_wait, timeout, originalTimeout);
        }

        return null;
    }

    /// <summary>
    /// An expectation for checking whether the given frame is available to switch to.
    ///  If the frame is available it switches the given driver to the specified frame.
    /// </summary>
    /// <param name="locator">Locator for the Frame</param>
    /// <param name="name">The name of the locator, used for better error messages. Shouldn't be provided as it's generated automatically.</param>
    /// <returns>An <see cref="IWebDriver"/> object if the frame is available and switched to within the specified time.</returns>
    public IWebDriver IsSwitchedTo(By locator, [CallerArgumentExpression("locator")] string name = null)
    {
        return IsSwitchedTo(locator, null, out _, true, name);
    }

    /// <summary>
    /// An expectation for checking whether the given frame is available to switch to.
    ///  If the frame is available it switches the given driver to the specified frame.
    /// </summary>
    /// <param name="locator">Locator for the Frame</param>
    /// <param name="timeout">The time to wait for the condition to be successful.</param>
    /// <param name="name">The name of the locator, used for better error messages. Shouldn't be provided as it's generated automatically.</param>
    /// <returns>An <see cref="IWebDriver"/> object if the frame is available and switched to within the specified time.</returns>
    public IWebDriver IsSwitchedTo(By locator, TimeSpan timeout, [CallerArgumentExpression("locator")] string name = null)
    {
        return IsSwitchedTo(locator, timeout, out _, true, name);
    }

    /// <summary>
    /// An expectation for checking whether the given frame is available to switch to.
    ///  If the frame is available it switches the given driver to the specified frame.
    /// </summary>
    /// <param name="locator">Locator for the Frame</param>
    /// <param name="condition">Out parameter that returns a <see cref="Condition"/> object indicating the result of the condition.</param>
    /// <param name="name">The name of the locator, used for better error messages. Shouldn't be provided as it's generated automatically.</param>
    /// <returns>An <see cref="IWebDriver"/> object if the frame is available and switched to within the specified time, null otherwise.</returns>
    public IWebDriver IsSwitchedTo(By locator, out Condition condition, [CallerArgumentExpression("locator")] string name = null)
    {
        return IsSwitchedTo(locator, null, out condition, false, name);
    }

    /// <summary>
    /// An expectation for checking whether the given frame is available to switch to.
    ///  If the frame is available it switches the given driver to the specified frame.
    /// </summary>
    /// <param name="locator">Locator for the Frame</param>
    /// <param name="timeout">The time to wait for the condition to be successful.</param>
    /// <param name="condition">Out parameter that returns a <see cref="Condition"/> object indicating the result of the condition.</param>
    /// <param name="name">The name of the locator, used for better error messages. Shouldn't be provided as it's generated automatically.</param>
    /// <returns>An <see cref="IWebDriver"/> object if the frame is available and switched to within the specified time, null otherwise.</returns>
    public IWebDriver IsSwitchedTo(By locator, TimeSpan timeout, out Condition condition, [CallerArgumentExpression("locator")] string name = null)
    {
        return IsSwitchedTo(locator, timeout, out condition, false, name);
    }
}