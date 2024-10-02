using System;
using System.Collections.Generic;
using System.Linq;
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
    private readonly List<NetworkRequestSentEventArgs> _requests = new();
    private readonly List<NetworkResponseReceivedEventArgs> _responses = new();

    /// <summary>
    /// Initializes a new instance of the <see cref="UntilNetwork"/> class.
    /// </summary>
    /// <param name="wait">The WebDriverWait instance to be used for waiting for conditions.</param>
    public UntilNetwork(WebDriverWait wait)
    {
        _wait = wait;
    }

    private NetworkEvent RequestSent(string url, Action action, TimeSpan? timeout, out Condition condition, bool throwOnException)
    {
        Utilities.SetTimeout(_wait, timeout, out var originalTimeout);
        condition = new Condition();

        try
        {
            var field = typeof(WebDriverWait).BaseType.GetField("input", BindingFlags.NonPublic | BindingFlags.Instance);
            var driver = (IWebDriver)field.GetValue(_wait);

            var interceptor = driver.Manage().Network;
            interceptor.NetworkRequestSent += OnNetworkRequestSent;
            interceptor.NetworkResponseReceived += OnNetworkResponseReceived;
            interceptor.StartMonitoring();

            action();

            var request = _wait.Until(NetworkConditions.RequestSent(url, _requests));

            interceptor.StopMonitoring();

            condition.Result = true;
            condition.Error = null;

            var response = _responses.First(response => response.RequestId == request.RequestId);
            var networkEvent = new NetworkEvent
            {
                Request = request,
                Response = response
            };

            return networkEvent;
        }
        catch (WebDriverTimeoutException ex)
        {
            Utilities.HandleException(NetworkConditions.ErrorMessage.Value, ex, throwOnException, out condition);
        }
        finally
        {
            Utilities.ResetTimeout(_wait, timeout, originalTimeout);
        }

        return null;
    }

    /// <summary>
    /// An expectation for checking whether a network request with the given URL has been sent.
    /// </summary>
    /// <param name="url">The URL of the network request to check for.</param>
    /// <param name="action">The action that triggers the network request.</param>
    /// <returns>A <see cref="NetworkEvent"/> object containing the request and response details if the request is sent.</returns>
    public NetworkEvent RequestSent(string url, Action action)
    {
        return RequestSent(url, action, null, out _, true);
    }

    /// <summary>
    /// An expectation for checking whether a network request with the given URL has been sent.
    /// </summary>
    /// <param name="url">The URL of the network request to check for.</param>
    /// <param name="action">The action that triggers the network request.</param>
    /// <param name="timeout">The time to wait for the condition to be successful.</param>
    /// <returns>A <see cref="NetworkEvent"/> object containing the request and response details if the request is sent.</returns>
    public NetworkEvent RequestSent(string url, Action action, TimeSpan timeout)
    {
        return RequestSent(url, action, timeout, out _, true);
    }

    /// <summary>
    /// An expectation for checking whether a network request with the given URL has been sent.
    /// </summary>
    /// <param name="url">The URL of the network request to check for.</param>
    /// <param name="action">The action that triggers the network request.</param>
    /// <param name="condition">Out parameter that returns a <see cref="Condition"/> object indicating the result of the condition.</param>
    /// <returns>A <see cref="NetworkEvent"/> object containing the request and response details if the request is sent; otherwise, null.</returns>
    public NetworkEvent RequestSent(string url, Action action, out Condition condition)
    {
        return RequestSent(url, action, null, out condition, false);
    }

    /// <summary>
    /// An expectation for checking whether a network request with the given URL has been sent.
    /// </summary>
    /// <param name="url">The URL of the network request to check for.</param>
    /// <param name="action">The action that triggers the network request.</param>
    /// <param name="timeout">The time to wait for the condition to be successful.</param>
    /// <param name="condition">Out parameter that returns a <see cref="Condition"/> object indicating the result of the condition.</param>
    /// <returns>A <see cref="NetworkEvent"/> object containing the request and response details if the request is sent; otherwise, null.</returns>
    public NetworkEvent RequestSent(string url, Action action, TimeSpan timeout, out Condition condition)
    {
        return RequestSent(url, action, timeout, out condition, false);
    }

    private void OnNetworkRequestSent(object sender, NetworkRequestSentEventArgs e)
    {
        _requests.Add(e);
    }

    private void OnNetworkResponseReceived(object sender, NetworkResponseReceivedEventArgs e)
    {
        _responses.Add(e);
    }
}