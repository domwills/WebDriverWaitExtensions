﻿using Moq;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using WebDriverWaitExtensions.Tests.Support;

namespace WebDriverWaitExtensions.Tests.Steps.UntilNetwork;

[Binding]
public sealed class NetworkRequestSentSteps
{
    private readonly ScenarioContext _scenarioContext;

    public NetworkRequestSentSteps(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [Given(@"the request that is sent will be '(.*)'")]
    public void GivenTheRequestThatIsSentWillBe(string url)
    {
        var mockDriver = new Mock<IWebDriver>();
        var mockNetwork = new Mock<INetwork>();

        mockDriver.Setup(d => d.Manage().Network).Returns(mockNetwork.Object);

        var httpRequestData = new HttpRequestData
        {
            Url = url,
            Headers = new Dictionary<string, string>
            {
                { "Accept", "text/html" }
            }
        };

        mockNetwork.Setup(n => n.StartMonitoring()).Callback(() =>
        {
            mockNetwork.Raise(n => n.NetworkRequestSent += null, new NetworkRequestSentEventArgs(httpRequestData));
        });

        _scenarioContext.Add(ScenarioContextKeys.MockDriver, mockDriver);
    }

    [When(@"I use Wait\.UntilNetwork\(\)\.RequestSent\('(.*)', action\)")]
    public void WhenIUseWaitUntilNetworkRequestSentAction(string url)
    {
        var wait = MockUtils.GetWebDriverWait(_scenarioContext);

        try
        {
            wait.UntilNetwork().RequestSent(url, () => { });
            _scenarioContext.Add(ScenarioContextKeys.Exception, null);
        }
        catch (Exception ex)
        {
            _scenarioContext.Add(ScenarioContextKeys.Exception, ex);
        }
    }

    [When(@"I use Wait\.UntilNetwork\(\)\.RequestSent\('(.*)', action, timeout\)")]
    public void WhenIUseWaitUntilNetworkRequestSentActionTimeout(string url)
    {
        var wait = MockUtils.GetWebDriverWait(_scenarioContext);

        try
        {
            wait.UntilNetwork().RequestSent(url, () => { }, TimeSpan.FromSeconds(1));
            _scenarioContext.Add(ScenarioContextKeys.Exception, null);
        }
        catch (Exception ex)
        {
            _scenarioContext.Add(ScenarioContextKeys.Exception, ex);
        }
    }

    [When(@"I use Wait\.UntilNetwork\(\)\.RequestSent\('(.*)', action, out var condition\)")]
    public void WhenIUseWaitUntilNetworkRequestSentActionOutVarCondition(string url)
    {
        var wait = MockUtils.GetWebDriverWait(_scenarioContext);

        try
        {
            wait.UntilNetwork().RequestSent(url, () => { }, out var condition);
            _scenarioContext.Add(ScenarioContextKeys.Condition, condition);
        }
        catch (Exception ex)
        {
            _scenarioContext.Add(ScenarioContextKeys.Exception, ex);
        }
    }

    [When(@"I use Wait\.UntilNetwork\(\)\.RequestSent\('(.*)', action, timeout, out var condition\)")]
    public void WhenIUseWaitUntilNetworkRequestSentActionTimeoutOutVarCondition(string url)
    {
        var wait = MockUtils.GetWebDriverWait(_scenarioContext);

        try
        {
            wait.UntilNetwork().RequestSent(url, () => { }, TimeSpan.FromSeconds(1), out var condition);
            _scenarioContext.Add(ScenarioContextKeys.Condition, condition);
        }
        catch (Exception ex)
        {
            _scenarioContext.Add(ScenarioContextKeys.Exception, ex);
        }
    }
}