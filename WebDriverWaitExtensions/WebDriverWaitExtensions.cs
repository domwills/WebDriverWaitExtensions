using OpenQA.Selenium.Support.UI;
using WebDriverWaitExtensions.Until;

namespace WebDriverWaitExtensions;

/// <summary>
/// Provides extension methods for the WebDriverWait class.
/// </summary>
public static class WebDriverWaitExtensions
{
    /// <summary>
    /// Contains methods for handling alert conditions.
    /// </summary>
    public static UntilAlert UntilAlert(this WebDriverWait wait)
    {
        return new UntilAlert(wait);
    }

    /// <summary>
    /// Contains methods for handling element conditions.
    /// </summary>
    public static UntilElement UntilElement(this WebDriverWait wait)
    {
        return new UntilElement(wait);
    }

    /// <summary>
    /// Contains methods for handling frame conditions.
    /// </summary>
    public static UntilFrame UntilFrame(this WebDriverWait wait)
    {
        return new UntilFrame(wait);
    }

    /// <summary>
    /// Contains methods for handling element text conditions.
    /// </summary>
    public static UntilTextInElement UntilTextInElement(this WebDriverWait wait)
    {
        return new UntilTextInElement(wait);
    }

    /// <summary>
    /// Contains methods for handling title conditions.
    /// </summary>
    public static UntilTitle UntilTitle(this WebDriverWait wait)
    {
        return new UntilTitle(wait);
    }

    /// <summary>
    /// Contains methods for handling URL conditions.
    /// </summary>
    public static UntilUrl UntilUrl(this WebDriverWait wait)
    {
        return new UntilUrl(wait);
    }
}