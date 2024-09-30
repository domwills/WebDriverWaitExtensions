using System;
using System.Collections.Generic;
using System.Reflection;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using WebDriverWaitExtensions.ExpectedConditions;

namespace WebDriverWaitExtensions.Until;

/// <summary>
/// Contains methods for handling network conditions.
/// </summary>
public class UntilNetwork
{
    private readonly WebDriverWait _wait;
    private readonly List<string> _requests = new();

    /// <summary>
    /// Initializes a new instance of the <see cref="UntilNetwork"/> class.
    /// </summary>
    /// <param name="wait">The WebDriverWait instance to be used for waiting for conditions.</param>
    public UntilNetwork(WebDriverWait wait)
    {
        _wait = wait;
    }

    private void RequestSent(string url, Action action, TimeSpan? timeout, out Condition condition, bool throwOnException)
    {
        Utilities.SetTimeout(_wait, timeout, out var originalTimeout);
        condition = new Condition();

        try
        {
            var field = typeof(WebDriverWait).BaseType.GetField("input", BindingFlags.NonPublic | BindingFlags.Instance);
            var driver = (IWebDriver)field.GetValue(_wait);

            var interceptor = driver.Manage().Network;
            interceptor.NetworkRequestSent += OnNetworkRequestSent;
            interceptor.StartMonitoring();

            action();

            _wait.Until(NetworkConditions.RequestSent(url, _requests));

            interceptor.StopMonitoring();

            condition.Result = true;
            condition.Error = null;
        }
        catch (WebDriverTimeoutException ex)
        {
            Utilities.HandleException(NetworkConditions.ErrorMessage.Value, ex, throwOnException, out condition);
        }
        finally
        {
            Utilities.ResetTimeout(_wait, timeout, originalTimeout);
        }
    }

    /// <summary>
    /// An expectation for checking whether a network request with the given URL has been sent.
    /// </summary>
    /// <param name="url">The URL of the network request to check for.</param>
    /// <param name="action">The action that triggers the network request.</param>
    public void RequestSent(string url, Action action)
    {
        RequestSent(url, action, null, out _, true);
    }

    /// <summary>
    /// An expectation for checking whether a network request with the given URL has been sent.
    /// </summary>
    /// <param name="url">The URL of the network request to check for.</param>
    /// <param name="action">The action that triggers the network request.</param>
    /// <param name="timeout">The time to wait for the condition to be successful.</param>
    public void RequestSent(string url, Action action, TimeSpan timeout)
    {
        RequestSent(url, action, timeout, out _, true);
    }

    /// <summary>
    /// An expectation for checking whether a network request with the given URL has been sent.
    /// </summary>
    /// <param name="url">The URL of the network request to check for.</param>
    /// <param name="action">The action that triggers the network request.</param>
    /// <param name="condition">Out parameter that returns a <see cref="Condition"/> object indicating the result of the condition.</param>
    public void RequestSent(string url, Action action, out Condition condition)
    {
        RequestSent(url, action, null, out condition, false);
    }

    /// <summary>
    /// An expectation for checking whether a network request with the given URL has been sent.
    /// </summary>
    /// <param name="url">The URL of the network request to check for.</param>
    /// <param name="action">The action that triggers the network request.</param>
    /// <param name="timeout">The time to wait for the condition to be successful.</param>
    /// <param name="condition">Out parameter that returns a <see cref="Condition"/> object indicating the result of the condition.</param>
    public void RequestSent(string url, Action action, TimeSpan timeout, out Condition condition)
    {
        RequestSent(url, action, timeout, out condition, false);
    }

    private void OnNetworkRequestSent(object sender, NetworkRequestSentEventArgs e)
    {
        _requests.Add(e.RequestUrl);
    }
}