Feature: URL Is Timeout
    Wait.UntilUrl.Is(string url, int waitTimeInSeconds)

    Scenario: UrlIs(url, timeout) will wait until URL is the expected URL
        Given the current URL changes to be 'www.github.com'
        When I use Wait.UntilUrl.Is('www.github.com', timeout)
        Then the method will not throw an exception

    Scenario: UrlIs(url, timeout) will throw a WebDriverTimeoutException if the URL is not the expected URL
        Given the current URL is 'www.github.com/invalid'
        When I use Wait.UntilUrl.Is('www.github.com', timeout)
        Then the method will throw a WebDriverTimeoutException
            """
            The URL doesn't match 'www.github.com'.
            Actual URL: 'www.github.com/invalid'
            Expected URL: 'www.github.com'

            """

    Scenario: UrlIs(url, timeout) throws the unhandled exception if an unhandled exception occurs
        Given an unhandled exception occurs
        When I use Wait.UntilUrl.Is('www.github.com', timeout)
        Then the unhandled exception will be thrown