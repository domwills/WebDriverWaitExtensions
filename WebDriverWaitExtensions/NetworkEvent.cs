using OpenQA.Selenium;

namespace WebDriverWaitExtensions;

/// <summary>
/// Represents a network event that contains both the request and response details.
/// </summary>
public class NetworkEvent
{
    /// <summary>
    /// Gets or sets the network request details.
    /// </summary>
    public NetworkRequestSentEventArgs Request { get; set; }

    /// <summary>
    /// Gets or sets the network response details.
    /// </summary>
    public NetworkResponseReceivedEventArgs Response { get; set; }
}