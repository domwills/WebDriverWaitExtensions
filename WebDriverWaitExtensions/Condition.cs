namespace WebDriverWaitExtensions;

/// <summary>
/// Represents a condition that can be evaluated to a boolean result.
/// </summary>
public class Condition
{
    /// <value>
    /// A boolean value representing the result of the condition.
    /// </value>
    public bool Result { get; set; }

    /// <value>
    /// A string representing the error message.
    /// </value>
    public string Error { get; set; }
}