using Moq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;

namespace WebDriverWaitExtensions.Tests.Support;

public static class MockUtils
{
    public static WebDriverWait GetWebDriverWait(ScenarioContext scenarioContext)
    {
        var mockDriver = scenarioContext.Get<Mock<IWebDriver>>(ScenarioContextKeys.MockDriver);
        return new WebDriverWait(mockDriver.Object, TimeSpan.FromMilliseconds(500));
    }
}