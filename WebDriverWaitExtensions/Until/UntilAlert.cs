using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using WebDriverWaitExtensions.ExpectedConditions;

namespace WebDriverWaitExtensions.Until;

/// <summary>
/// Contains methods for handling alert conditions.
/// </summary>
public class UntilAlert
{
    private readonly WebDriverWait _wait;

    /// <summary>
    /// Initializes a new instance of the <see cref="UntilAlert"/> class.
    /// </summary>
    /// <param name="wait">The WebDriverWait instance to be used for waiting for conditions.</param>
    public UntilAlert(WebDriverWait wait)
    {
        _wait = wait;
    }

    private IAlert IsSwitchedTo(TimeSpan? timeout, out Condition condition, bool throwOnException)
    {
        Utilities.SetTimeout(_wait, timeout, out var originalTimeout);
        condition = new Condition();

        try
        {
            var alert = _wait.Until(AlertConditions.IsSwitchedTo());

            condition.Result = true;
            condition.Error = null;

            return alert;
        }
        catch (WebDriverTimeoutException ex)
        {
            Utilities.HandleException(AlertConditions.ErrorMessage.Value, ex, throwOnException, out condition);
        }
        finally
        {
            Utilities.ResetTimeout(_wait, timeout, originalTimeout);
        }

        return null;
    }

    /// <summary>
    /// An expectation for checking whether the given alert is available to switch to.
    ///  If the alert is available it switches the given driver to the specified alert.
    /// </summary>
    /// <returns>An <see cref="IAlert"/> object if the alert is available and switched to.</returns>
    public IAlert IsSwitchedTo()
    {
        return IsSwitchedTo(null, out _, true);
    }

    /// <summary>
    /// An expectation for checking whether the given alert is available to switch to.
    ///  If the alert is available it switches the given driver to the specified alert.
    /// </summary>
    /// <param name="timeout">The time to wait for the condition to be successful.</param>
    /// <returns>An <see cref="IAlert"/> object if the alert is available and switched to.</returns>
    public IAlert IsSwitchedTo(TimeSpan timeout)
    {
        return IsSwitchedTo(timeout, out _, true);
    }

    /// <summary>
    /// An expectation for checking whether the given alert is available to switch to.
    ///  If the alert is available it switches the given driver to the specified alert.
    /// </summary>
    /// <param name="condition">Out parameter that returns a <see cref="Condition"/> object indicating the result of the condition.</param>
    /// <returns>An <see cref="IAlert"/> object if the alert is available and switched to within the specified time, null otherwise.</returns>
    public IAlert IsSwitchedTo(out Condition condition)
    {
        return IsSwitchedTo(null, out condition, false);
    }

    /// <summary>
    /// An expectation for checking whether the given alert is available to switch to.
    ///  If the alert is available, it switches the given driver to the specified alert.
    /// </summary>
    /// <param name="timeout">The time to wait for the condition to be successful.</param>
    /// <param name="condition">Out parameter that returns a <see cref="Condition"/> object indicating the result of the condition.</param>
    /// <returns>An <see cref="IAlert"/> object if the alert is available and switched to within the specified time, null otherwise.</returns>
    public IAlert IsSwitchedTo(TimeSpan timeout, out Condition condition)
    {
        return IsSwitchedTo(timeout, out condition, false);
    }
}