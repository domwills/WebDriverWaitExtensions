using System.Drawing;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using WebDriverWaitExtensions.Tests.Support;

namespace WebDriverWaitExtensions.Tests.Steps.UntilElement;

[Binding]
public sealed class ElementSteps
{
    private readonly ScenarioContext _scenarioContext;

    public ElementSteps(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [Given(@"the WebElement exists")]
    [Given(@"the WebElement is visible")]
    [Given(@"the WebElement is enabled")]
    [Given(@"the WebElement is selected")]
    [Given(@"the WebElement has stopped moving")]
    public void GivenTheWebElementExists()
    {
        var mockDriver = MockSetup.GetDriver(_scenarioContext);
        var mockElement = MockSetup.GetWebElement(_scenarioContext);

        mockDriver.Setup(d => d.FindElement(By.Id("id")))
            .Returns(mockElement.Object);

        _scenarioContext.AddOrUpdate(ScenarioContextKeys.MockDriver, mockDriver);
    }

    [Given(@"the WebElement does not exist")]
    public void GivenTheWebElementDoesNotExist()
    {
        var mockDriver = MockSetup.GetDriver(_scenarioContext);

        mockDriver.Setup(d => d.FindElement(By.Id("id")))
            .Throws(new NoSuchElementException());

        _scenarioContext.AddOrUpdate(ScenarioContextKeys.MockDriver, mockDriver);
    }

    [Given(@"the WebElement is not visible")]
    public void GivenTheWebElementIsNotVisible()
    {
        var mockDriver = MockSetup.GetDriver(_scenarioContext);
        var mockElement = MockSetup.GetWebElement(_scenarioContext);

        mockElement.Setup(e => e.Displayed)
            .Returns(false);

        mockDriver.Setup(d => d.FindElement(By.Id("id")))
            .Returns(mockElement.Object);

        _scenarioContext.AddOrUpdate(ScenarioContextKeys.MockDriver, mockDriver);
    }

    [Given(@"the WebElement is not enabled")]
    public void GivenTheWebElementIsEnabled()
    {
        var mockDriver = MockSetup.GetDriver(_scenarioContext);
        var mockElement = MockSetup.GetWebElement(_scenarioContext);

        mockElement.Setup(e => e.Enabled)
            .Returns(false);

        mockDriver.Setup(d => d.FindElement(By.Id("id")))
            .Returns(mockElement.Object);

        _scenarioContext.AddOrUpdate(ScenarioContextKeys.MockDriver, mockDriver);
    }

    [Given(@"the WebElement is not selected")]
    public void GivenTheWebElementIsNotSelected()
    {
        var mockDriver = MockSetup.GetDriver(_scenarioContext);
        var mockElement = MockSetup.GetWebElement(_scenarioContext);

        mockElement.Setup(e => e.Selected)
            .Returns(false);

        mockDriver.Setup(d => d.FindElement(By.Id("id")))
            .Returns(mockElement.Object);

        _scenarioContext.AddOrUpdate(ScenarioContextKeys.MockDriver, mockDriver);
    }

    [Given(@"the WebElement keeps moving")]
    public void GivenTheWebElementKeepsMoving()
    {
        var mockDriver = MockSetup.GetDriver(_scenarioContext);
        var mockElement = MockSetup.GetWebElement(_scenarioContext);

        mockElement.SetupSequence(e => e.Location)
            .Returns(new Point(1, 2))
            .Returns(new Point(3, 4))
            .Returns(new Point(5, 6))
            .Returns(new Point(7, 8))
            .Returns(new Point(9, 10))
            .Returns(new Point(11, 12));

        mockDriver.Setup(d => d.FindElement(By.Id("id")))
            .Returns(mockElement.Object);

        _scenarioContext.AddOrUpdate(ScenarioContextKeys.MockDriver, mockDriver);
    }

    [Given(@"the WebElement is focused")]
    public void GivenTheWebElementIsFocused()
    {
        var mockDriver = MockSetup.GetDriver(_scenarioContext);
        var mockElement = MockSetup.GetWebElement(_scenarioContext);

        mockElement.Setup(e => e.ToString())
            .Returns("ID-1");

        mockDriver.Setup(d => d.SwitchTo().ActiveElement())
            .Returns(mockElement.Object);

        mockDriver.Setup(d => d.FindElement(By.Id("id")))
            .Returns(mockElement.Object);

        _scenarioContext.AddOrUpdate(ScenarioContextKeys.MockDriver, mockDriver);
    }

    [Given(@"the WebElement is not focused")]
    public void GivenTheWebElementIsNotFocused()
    {
        var mockDriver = MockSetup.GetDriver(_scenarioContext);
        var mockElement = MockSetup.GetWebElement(_scenarioContext);
        var differentElement = MockSetup.ConfigureWebElement();

        mockElement.Setup(e => e.ToString())
            .Returns("ID-1");

        differentElement.Setup(e => e.ToString())
            .Returns("ID-2");

        mockDriver.Setup(d => d.SwitchTo().ActiveElement())
            .Returns(differentElement.Object);

        mockDriver.Setup(d => d.FindElement(By.Id("id")))
            .Returns(mockElement.Object);

        _scenarioContext.AddOrUpdate(ScenarioContextKeys.MockDriver, mockDriver);
    }

    [Given(@"the WebElement reference is invalid")]
    public void GivenTheWebElementReferenceIsInvalid()
    {
        var mockDriver = MockSetup.GetDriver(_scenarioContext);

        mockDriver.Setup(d => d.FindElement(By.Id("id")))
            .Throws(new StaleElementReferenceException());

        _scenarioContext.AddOrUpdate(ScenarioContextKeys.MockDriver, mockDriver);
    }

    [Given(@"the WebElement has attribute '(.*)'")]
    public void GivenTheWebElementHasAttribute(string attribute)
    {
        var mockDriver = MockSetup.GetDriver(_scenarioContext);
        var mockElement = MockSetup.GetWebElement(_scenarioContext);

        mockElement.Setup(e => e.GetAttribute(attribute))
            .Returns(string.Empty);

        mockDriver.Setup(d => d.FindElement(By.Id("id")))
            .Returns(mockElement.Object);

        _scenarioContext.AddOrUpdate(ScenarioContextKeys.MockDriver, mockDriver);
    }

    [Given(@"the WebElement does not have attribute '(.*)'")]
    public void GivenTheWebElementDoesNotHaveAttribute(string attribute)
    {
        var mockDriver = MockSetup.GetDriver(_scenarioContext);
        var mockElement = MockSetup.GetWebElement(_scenarioContext);

        mockElement.Setup(e => e.GetAttribute(attribute))
            .Returns((string)null);

        mockDriver.Setup(d => d.FindElement(By.Id("id")))
            .Returns(mockElement.Object);

        _scenarioContext.AddOrUpdate(ScenarioContextKeys.MockDriver, mockDriver);
    }

    [Then(@"the method will return the WebElement")]
    public void ThenTheMethodWillReturnTheWebElement()
    {
        var returnedElement = _scenarioContext.Get<IWebElement>(ScenarioContextKeys.ReturnedElement);
        Assert.That(returnedElement, Is.Not.Null);
    }

    [Then(@"the method will throw a WebDriverTimeoutException")]
    public void ThenTheMethodWillThrowAWebDriverTimeoutException()
    {
        var exception = _scenarioContext.Get<Exception>(ScenarioContextKeys.Exception);
        Assert.That(exception.GetType(), Is.EqualTo(typeof(WebDriverTimeoutException)));
    }
}