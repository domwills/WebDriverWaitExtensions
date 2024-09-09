using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using WebDriverWaitExtensions.Tests.Support;
using NotSupportedException = System.NotSupportedException;

namespace WebDriverWaitExtensions.Tests.Steps;

[Binding]
public sealed class CommonSteps
{
    private readonly ScenarioContext _scenarioContext;

    public CommonSteps(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [Given(@"an unhandled exception occurs")]
    public void GivenAnUnhandledExceptionOccurs()
    {
        var mockDriver = MockSetup.GetDriver(_scenarioContext);

        mockDriver.Setup(d => d.FindElement(By.Id("id")))
            .Throws(new NotSupportedException());

        mockDriver.Setup(d => d.SwitchTo().Alert())
            .Throws(new NotSupportedException());

        mockDriver.Setup(d => d.SwitchTo().Frame("id"))
            .Throws(new NotSupportedException());

        mockDriver.Setup(d => d.Title)
            .Throws(new NotSupportedException());

        mockDriver.Setup(d => d.Url)
            .Throws(new NotSupportedException());

        _scenarioContext.AddOrUpdate(ScenarioContextKeys.MockDriver, mockDriver);
    }

    [Then(@"the method will not throw an exception")]
    public void ThenTheMethodWillNotThrowAnException()
    {
        var exception = _scenarioContext.Get<Exception>(ScenarioContextKeys.Exception);
        Assert.That(exception, Is.Null);
    }

    [Then(@"the method will throw a WebDriverTimeoutException")]
    public void ThenTheMethodWillThrowAWebDriverTimeoutException(string expectedMessage)
    {
        var exception = _scenarioContext.Get<Exception>(ScenarioContextKeys.Exception);

        Assert.That(exception.GetType(), Is.EqualTo(typeof(WebDriverTimeoutException)));
        Assert.That(exception.Message, Is.EqualTo(expectedMessage));
    }

    [Then(@"the Condition\.Result is true and Condition\.Error is null")]
    public void ThenTheConditionResultIsTrueAndConditionErrorIsNull()
    {
        var condition = _scenarioContext.Get<Condition>(ScenarioContextKeys.Condition);

        Assert.Multiple(() =>
        {
            Assert.That(condition.Result, Is.EqualTo(true));
            Assert.That(condition.Error, Is.Null);
        });
    }

    [Then(@"the Condition\.Result is false and Condition\.Error contains the following:")]
    public void ThenTheConditionResultIsFalseAndConditionErrorContainsTheFollowing(string errorMessage)
    {
        var condition = _scenarioContext.Get<Condition>(ScenarioContextKeys.Condition);

        Assert.Multiple(() =>
        {
            Assert.That(condition.Result, Is.EqualTo(false));
            Assert.That(condition.Error, Does.Contain(errorMessage));
        });
    }

    [Then(@"the method will return the WebDriver")]
    public void ThenTheMethodWillReturnTheWebDriver()
    {
        var returnedDriver = _scenarioContext.Get<IWebDriver>(ScenarioContextKeys.ReturnedDriver);
        Assert.That(returnedDriver, Is.Not.Null);
    }

    [Then(@"the unhandled exception will be thrown")]
    public void ThenTheUnhandledExceptionWillBeThrown()
    {
        var exception = _scenarioContext.Get<Exception>(ScenarioContextKeys.Exception);
        Assert.That(exception.GetType(), Is.EqualTo(typeof(NotSupportedException)));
    }
}