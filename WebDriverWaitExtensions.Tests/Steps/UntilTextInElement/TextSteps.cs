using OpenQA.Selenium;
using TechTalk.SpecFlow;
using WebDriverWaitExtensions.Tests.Support;

namespace WebDriverWaitExtensions.Tests.Steps.UntilTextInElement;

[Binding]
public sealed class TextSteps
{
    private readonly ScenarioContext _scenarioContext;

    public TextSteps(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [Given(@"the WebElement text value is '(.*)'")]
    public void GivenTheWebElementTextValueIs(string text)
    {
        var mockDriver = MockSetup.GetDriver(_scenarioContext);
        var mockElement = MockSetup.GetWebElement(_scenarioContext);

        mockElement.Setup(e => e.Text)
            .Returns(text);

        mockDriver.Setup(d => d.FindElement(By.Id("id")))
            .Returns(mockElement.Object);

        _scenarioContext.AddOrUpdate(ScenarioContextKeys.MockDriver, mockDriver);
    }

    [Given(@"the WebElement attribute '(.*)' has value '(.*)'")]
    public void GivenTheWebElementAttributeHasValue(string attribute, string text)
    {
        var mockDriver = MockSetup.GetDriver(_scenarioContext);
        var mockElement = MockSetup.GetWebElement(_scenarioContext);

        mockElement.Setup(e => e.GetAttribute(attribute))
            .Returns(text);

        mockDriver.Setup(d => d.FindElement(By.Id("id")))
            .Returns(mockElement.Object);

        _scenarioContext.AddOrUpdate(ScenarioContextKeys.MockDriver, mockDriver);
    }

    [Given(@"the WebElement cssValue '(.*)' has value '(.*)'")]
    public void GivenTheWebElementCssValueHasValue(string cssValue, string text)
    {
        var mockDriver = MockSetup.GetDriver(_scenarioContext);
        var mockElement = MockSetup.GetWebElement(_scenarioContext);

        mockElement.Setup(e => e.GetCssValue(cssValue))
            .Returns(text);

        mockDriver.Setup(d => d.FindElement(By.Id("id")))
            .Returns(mockElement.Object);

        _scenarioContext.AddOrUpdate(ScenarioContextKeys.MockDriver, mockDriver);
    }
}