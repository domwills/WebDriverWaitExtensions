Feature: URL Contains
    Wait.UntilUrl.Contains(string fraction)

    Scenario: Contains(fraction) will wait until URL contains the expected fraction
        Given the current URL changes to be 'www.github.com'
        When I use Wait.UntilUrl.Contains('git')
        Then the method will not throw an exception

    Scenario: Contains(fraction) throws a WebDriverTimeoutException if the URL does not contain the expected fraction
        Given the current URL is 'www.github.com'
        When I use Wait.UntilUrl.Contains('invalid')
        Then the method will throw a WebDriverTimeoutException
            """
            The URL doesn't contain 'invalid'.
            Actual URL: 'www.github.com'
            Should contain: 'invalid'

            """

    Scenario: Contains(fraction) throws the unhandled exception if an unhandled exception occurs
        Given an unhandled exception occurs
        When I use Wait.UntilUrl.Contains('invalid')
        Then the unhandled exception will be thrown