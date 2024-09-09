Feature: Title Contains Timeout
    Wait.UntilTitle.Contains(string title, int waitTimeInSeconds)

    Scenario: TitleContains(title, timeout) will wait until title contains expected text
        Given the page title changes to be 'github'
        When I use Wait.UntilTitle.Contains('git', timeout)
        Then the method will not throw an exception

    Scenario: TitleContains(title, timeout) throws a WebDriverTimeoutException if the title does not contain expected text
        Given the page title is 'github'
        When I use Wait.UntilTitle.Contains('invalid', timeout)
        Then the method will throw a WebDriverTimeoutException
            """
            The browser window title doesn't contain 'invalid'.
            Actual title: 'github'
            Should contain: 'invalid'

            """

    Scenario: TitleContains(title, timeout) throws the unhandled exception if an unhandled exception occurs
        Given an unhandled exception occurs
        When I use Wait.UntilTitle.Contains('invalid', timeout)
        Then the unhandled exception will be thrown