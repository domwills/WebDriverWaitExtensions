using Moq;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using WebDriverWaitExtensions.Tests.Support;

namespace WebDriverWaitExtensions.Tests.Steps.UntilAlert;

[Binding]
public sealed class AlertSteps
{
    private readonly ScenarioContext _scenarioContext;

    public AlertSteps(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [Given(@"the alert is available")]
    public void GivenTheAlertIsAvailable()
    {
        var mockDriver = new Mock<IWebDriver>();
        var mockAlert = new Mock<IAlert>();

        mockDriver.SetupSequence(d => d.SwitchTo().Alert())
            .Throws(new NoAlertPresentException())
            .Returns(mockAlert.Object);

        _scenarioContext.Add(ScenarioContextKeys.MockDriver, mockDriver);
    }

    [Given(@"the alert is not available")]
    public void GivenTheAlertIsNotAvailable()
    {
        var mockDriver = new Mock<IWebDriver>();

        mockDriver.Setup(d => d.SwitchTo().Alert())
            .Throws(new NoAlertPresentException());

        _scenarioContext.Add(ScenarioContextKeys.MockDriver, mockDriver);
    }

    [Then(@"the method will return the Alert")]
    public void ThenTheMethodWillReturnTheAlert()
    {
        var returnedAlert = _scenarioContext.Get<IAlert>(ScenarioContextKeys.ReturnedAlert);
        Assert.That(returnedAlert, Is.Not.Null);
    }

    [Then(@"the returned Alert will be null")]
    public void ThenTheReturnedAlertWillBeNull()
    {
        var returnedAlert = _scenarioContext.Get<IAlert>(ScenarioContextKeys.ReturnedAlert);
        Assert.That(returnedAlert, Is.Null);
    }
}