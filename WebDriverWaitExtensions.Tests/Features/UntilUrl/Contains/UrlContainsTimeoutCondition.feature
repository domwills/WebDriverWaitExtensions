Feature: URL Contains Timeout Condition
    Wait.UntilUrl.Contains(string fraction, int waitTimeInSeconds, out Condition condition)

    Scenario: UrlContains(fraction, timeout, out var condition) will return a Condition when URL contains the expected fraction
        Given the current URL changes to be 'www.github.com'
        When I use Wait.UntilUrl.Contains('git', timeout, out var condition)
        Then the Condition.Result is true and Condition.Error is null

    Scenario: UrlContains(fraction, timeout, out var condition) will return a Condition when URL does not contain the expected fraction
        Given the current URL is 'www.github.com'
        When I use Wait.UntilUrl.Contains('invalid', timeout, out var condition)
        Then the Condition.Result is false and Condition.Error contains the following:
            """
            The URL doesn't contain 'invalid'.
            Actual URL: 'www.github.com'
            Should contain: 'invalid'
            """

    Scenario: UrlContains(fraction, timeout, out var condition) throws the unhandled exception if an unhandled exception occurs
        Given an unhandled exception occurs
        When I use Wait.UntilUrl.Contains('invalid', timeout, out var condition)
        Then the unhandled exception will be thrown