Feature: URL Is
    Wait.UntilUrl.Is(string url)

    Scenario: UrlIs(url) will wait until URL is the expected URL
        Given the current URL changes to be 'www.github.com'
        When I use Wait.UntilUrl.Is('www.github.com')
        Then the method will not throw an exception

    Scenario: UrlIs(url) will throw a WebDriverTimeoutException if the URL is not the expected URL
        Given the current URL is 'www.github.com/invalid'
        When I use Wait.UntilUrl.Is('www.github.com')
        Then the method will throw a WebDriverTimeoutException
            """
            The URL doesn't match 'www.github.com'.
            Actual URL: 'www.github.com/invalid'
            Expected URL: 'www.github.com'

            """

    Scenario: UrlIs(url) throws the unhandled exception if an unhandled exception occurs
        Given an unhandled exception occurs
        When I use Wait.UntilUrl.Is('www.github.com')
        Then the unhandled exception will be thrown