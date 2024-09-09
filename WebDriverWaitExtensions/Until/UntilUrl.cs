using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using WebDriverWaitExtensions.ExpectedConditions;

namespace WebDriverWaitExtensions.Until;

/// <summary>
/// Contains methods for handling URL conditions.
/// </summary>
public class UntilUrl
{
    private readonly WebDriverWait _wait;

    /// <summary>
    /// Initializes a new instance of the <see cref="UntilUrl"/> class.
    /// </summary>
    /// <param name="wait">The WebDriverWait instance to be used for waiting for conditions.</param>
    public UntilUrl(WebDriverWait wait)
    {
        _wait = wait;
    }

    private void Is(string url, TimeSpan? timeout, out Condition condition, bool throwOnException)
    {
        Utilities.SetTimeout(_wait, timeout, out var originalTimeout);
        condition = new Condition();

        try
        {
            _wait.Until(UrlConditions.Is(url));

            condition.Result = true;
            condition.Error = null;
        }
        catch (WebDriverTimeoutException ex)
        {
            Utilities.HandleException(UrlConditions.ErrorMessage.Value, ex, throwOnException, out condition);
        }
        finally
        {
            Utilities.ResetTimeout(_wait, timeout, originalTimeout);
        }
    }

    /// <summary>
    /// An expectation for the URL of the current page to be a specific URL.
    /// </summary>
    /// <param name="url">The URL that the page should be on</param>
    public void Is(string url)
    {
        Is(url, null, out _, true);
    }

    /// <summary>
    /// An expectation for the URL of the current page to be a specific URL.
    /// </summary>
    /// <param name="url">The URL that the page should be on</param>
    /// <param name="condition">Out parameter that returns a <see cref="Condition"/> object indicating the result of the condition.</param>
    public void Is(string url, out Condition condition)
    {
        Is(url, null, out condition, false);
    }

    /// <summary>
    /// An expectation for the URL of the current page to be a specific URL.
    /// </summary>
    /// <param name="url">The URL that the page should be on</param>
    /// <param name="timeout">The time to wait for the condition to be successful.</param>
    public void Is(string url, TimeSpan timeout)
    {
        Is(url, timeout, out _, true);
    }

    /// <summary>
    /// An expectation for the URL of the current page to be a specific URL.
    /// </summary>
    /// <param name="url">The URL that the page should be on</param>
    /// <param name="timeout">The time to wait for the condition to be successful.</param>
    /// <param name="condition">Out parameter that returns a <see cref="Condition"/> object indicating the result of the condition.</param>
    public void Is(string url, TimeSpan timeout, out Condition condition)
    {
        Is(url, timeout, out condition, false);
    }

    private void Contains(string fraction, TimeSpan? timeout, out Condition condition, bool throwOnException)
    {
        Utilities.SetTimeout(_wait, timeout, out var originalTimeout);
        condition = new Condition();

        try
        {
            _wait.Until(UrlConditions.Contains(fraction));

            condition.Result = true;
            condition.Error = null;
        }
        catch (WebDriverTimeoutException ex)
        {
            Utilities.HandleException(UrlConditions.ErrorMessage.Value, ex, throwOnException, out condition);
        }
        finally
        {
            Utilities.ResetTimeout(_wait, timeout, originalTimeout);
        }
    }

    /// <summary>
    /// An expectation for the URL of the current page to be a specific URL.
    /// </summary>
    /// <param name="fraction">The fraction of the url that the page should be on</param>
    public void Contains(string fraction)
    {
        Contains(fraction, null, out _, true);
    }

    /// <summary>
    /// An expectation for the URL of the current page to be a specific URL.
    /// </summary>
    /// <param name="fraction">The fraction of the url that the page should be on</param>
    /// <param name="condition">Out parameter that returns a <see cref="Condition"/> object indicating the result of the condition.</param>
    public void Contains(string fraction, out Condition condition)
    {
        Contains(fraction, null, out condition, false);
    }

    /// <summary>
    /// An expectation for the URL of the current page to be a specific URL.
    /// </summary>
    /// <param name="fraction">The fraction of the url that the page should be on</param>
    /// <param name="timeout">The time to wait for the condition to be successful.</param>
    public void Contains(string fraction, TimeSpan timeout)
    {
        Contains(fraction, timeout, out _, true);
    }

    /// <summary>
    /// An expectation for the URL of the current page to be a specific URL.
    /// </summary>
    /// <param name="fraction">The fraction of the url that the page should be on</param>
    /// <param name="timeout">The time to wait for the condition to be successful.</param>
    /// <param name="condition">Out parameter that returns a <see cref="Condition"/> object indicating the result of the condition.</param>
    public void Contains(string fraction, TimeSpan timeout, out Condition condition)
    {
        Contains(fraction, timeout, out condition, false);
    }
}