Feature: URL Is Condition
    Wait.UntilUrl.Is(string url, out Condition condition)
    Wait.UntilUrl.Is(string url, int waitTimeInSeconds, out Condition condition)

    Scenario: UrlIs(url, out var condition) will return a Condition when URL is the expected URL
        Given the current URL changes to be 'www.github.com'
        When I use Wait.UntilUrl.Is('www.github.com', out var condition)
        Then the Condition.Result is true and Condition.Error is null

    Scenario: UrlIs(url, out var condition) will return a Condition when URL is not the expected URL
        Given the current URL is 'www.github.com/invalid'
        When I use Wait.UntilUrl.Is('www.github.com', out var condition)
        Then the Condition.Result is false and Condition.Error contains the following:
            """
            The URL doesn't match 'www.github.com'.
            Actual URL: 'www.github.com/invalid'
            Expected URL: 'www.github.com'
            """

    Scenario: UrlIs(url, out var condition) throws the unhandled exception if an unhandled exception occurs
        Given an unhandled exception occurs
        When I use Wait.UntilUrl.Is('www.github.com', out var condition)
        Then the unhandled exception will be thrown