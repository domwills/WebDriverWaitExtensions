using System.Drawing;
using Moq;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace WebDriverWaitExtensions.Tests.Support;

public static class MockSetup
{
    public static Mock<IWebDriver> GetDriver(ScenarioContext scenarioContext)
    {
        scenarioContext.TryGetValue(ScenarioContextKeys.MockDriver, out Mock<IWebDriver> mockDriver);
        mockDriver ??= new Mock<IWebDriver>();

        mockDriver.Setup(d => d.Manage().Timeouts().ImplicitWait)
            .Returns(new TimeSpan());

        scenarioContext.AddOrUpdate(ScenarioContextKeys.MockDriver, mockDriver);
        return mockDriver;
    }

    public static Mock<IWebElement> GetWebElement(ScenarioContext scenarioContext)
    {
        scenarioContext.TryGetValue(ScenarioContextKeys.MockWebElement, out Mock<IWebElement> mockWebElement);
        mockWebElement ??= ConfigureWebElement();

        scenarioContext.AddOrUpdate(ScenarioContextKeys.MockWebElement, mockWebElement);
        return mockWebElement;
    }

    public static Mock<IWebElement> ConfigureWebElement()
    {
        var mockWebElement = new Mock<IWebElement>();

        mockWebElement.Setup(e => e.Displayed)
            .Returns(true);

        mockWebElement.Setup(e => e.Enabled)
            .Returns(true);

        mockWebElement.Setup(e => e.Location)
            .Returns(new Point(2, 3));

        mockWebElement.Setup(e => e.Selected)
            .Returns(true);

        mockWebElement.Setup(e => e.Size)
            .Returns(new Size(4, 5));

        mockWebElement.Setup(e => e.TagName)
            .Returns("div");

        mockWebElement.Setup(e => e.Text)
            .Returns("example text");

        return mockWebElement;
    }
}