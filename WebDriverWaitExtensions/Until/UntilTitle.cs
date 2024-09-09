using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using WebDriverWaitExtensions.ExpectedConditions;

namespace WebDriverWaitExtensions.Until;

/// <summary>
/// Contains methods for handling title conditions.
/// </summary>
public class UntilTitle
{
    private readonly WebDriverWait _wait;

    /// <summary>
    /// Initializes a new instance of the <see cref="UntilTitle"/> class.
    /// </summary>
    /// <param name="wait">The WebDriverWait instance to be used for waiting for conditions.</param>
    public UntilTitle(WebDriverWait wait)
    {
        _wait = wait;
    }

    private void Is(string title, TimeSpan? timeout, out Condition condition, bool throwOnException)
    {
        Utilities.SetTimeout(_wait, timeout, out var originalTimeout);
        condition = new Condition();

        try
        {
            _wait.Until(TitleConditions.Is(title));

            condition.Result = true;
            condition.Error = null;
        }
        catch (WebDriverTimeoutException ex)
        {
            Utilities.HandleException(TitleConditions.ErrorMessage.Value, ex, throwOnException, out condition);
        }
        finally
        {
            Utilities.ResetTimeout(_wait, timeout, originalTimeout);
        }
    }

    /// <summary>
    /// An expectation for checking the title of a page.
    /// </summary>
    /// <param name="title">The expected title, which must be an exact match.</param>
    public void Is(string title)
    {
        Is(title, null, out _, true);
    }

    /// <summary>
    /// An expectation for checking the title of a page.
    /// </summary>
    /// <param name="title">The expected title, which must be an exact match.</param>
    /// <param name="condition">Out parameter that returns a <see cref="Condition"/> object indicating the result of the condition.</param>
    public void Is(string title, out Condition condition)
    {
        Is(title, null, out condition, false);
    }

    /// <summary>
    /// An expectation for checking the title of a page.
    /// </summary>
    /// <param name="title">The expected title, which must be an exact match.</param>
    /// <param name="timeout">The time to wait for the condition to be successful.</param>
    public void Is(string title, TimeSpan timeout)
    {
        Is(title, timeout, out _, true);
    }

    /// <summary>
    /// An expectation for checking the title of a page.
    /// </summary>
    /// <param name="title">The expected title, which must be an exact match.</param>
    /// <param name="timeout">The time to wait for the condition to be successful.</param>
    /// <param name="condition">Out parameter that returns a <see cref="Condition"/> object indicating the result of the condition.</param>
    public void Is(string title, TimeSpan timeout, out Condition condition)
    {
        Is(title, timeout, out condition, false);
    }

    private void Contains(string title, TimeSpan? timeout, out Condition condition, bool throwOnException)
    {
        Utilities.SetTimeout(_wait, timeout, out var originalTimeout);
        condition = new Condition();

        try
        {
            _wait.Until(TitleConditions.Contains(title));

            condition.Result = true;
            condition.Error = null;
        }
        catch (WebDriverTimeoutException ex)
        {
            Utilities.HandleException(TitleConditions.ErrorMessage.Value, ex, throwOnException, out condition);
        }
        finally
        {
            Utilities.ResetTimeout(_wait, timeout, originalTimeout);
        }
    }

    /// <summary>
    /// An expectation for checking that the title of a page contains a case-sensitive substring.
    /// </summary>
    /// <param name="title">The fragment of title expected.</param>
    public void Contains(string title)
    {
        Contains(title, null, out _, true);
    }

    /// <summary>
    /// An expectation for checking that the title of a page contains a case-sensitive substring.
    /// </summary>
    /// <param name="title">The fragment of title expected.</param>
    /// <param name="condition">Out parameter that returns a <see cref="Condition"/> object indicating the result of the condition.</param>
    public void Contains(string title, out Condition condition)
    {
        Contains(title, null, out condition, false);
    }

    /// <summary>
    /// An expectation for checking that the title of a page contains a case-sensitive substring.
    /// </summary>
    /// <param name="title">The fragment of title expected.</param>
    /// <param name="timeout">The time to wait for the condition to be successful.</param>
    public void Contains(string title, TimeSpan timeout)
    {
        Contains(title, timeout, out _, true);
    }

    /// <summary>
    /// An expectation for checking that the title of a page contains a case-sensitive substring.
    /// </summary>
    /// <param name="title">The fragment of title expected.</param>
    /// <param name="timeout">The time to wait for the condition to be successful.</param>
    /// <param name="condition">Out parameter that returns a <see cref="Condition"/> object indicating the result of the condition.</param>
    public void Contains(string title, TimeSpan timeout, out Condition condition)
    {
        Contains(title, timeout, out condition, false);
    }
}