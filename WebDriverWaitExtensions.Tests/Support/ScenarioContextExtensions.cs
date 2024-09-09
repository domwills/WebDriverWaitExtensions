using TechTalk.SpecFlow;

namespace WebDriverWaitExtensions.Tests.Support;

public static class ScenarioContextExtensions
{
    /// <summary>
    /// Will add a new context items if it doesn't already exists; otherwise, it will update the context item.
    /// </summary>
    /// <param name="scenarioContext">The ScenarioContext object.</param>
    /// <param name="key">The key of the element to update.</param>
    /// <param name="value">The value of the element to update.</param>
    public static void AddOrUpdate(this ScenarioContext scenarioContext, string key, object value)
    {
        try
        {
            scenarioContext.Add(key, value);
        }
        catch (ArgumentException)
        {
            scenarioContext.Remove(key);
            scenarioContext.Add(key, value);
        }
    }
}