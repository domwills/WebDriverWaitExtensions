Feature: Title Contains
    Wait.UntilTitle.Contains(string title)

    Scenario: TitleContains(title) will wait until title contains expected text
        Given the page title changes to be 'github'
        When I use Wait.UntilTitle.Contains('git')
        Then the method will not throw an exception

    Scenario: TitleContains(title) throws a WebDriverTimeoutException if the title does not contain expected text
        Given the page title is 'github'
        When I use Wait.UntilTitle.Contains('invalid')
        Then the method will throw a WebDriverTimeoutException
            """
            The browser window title doesn't contain 'invalid'.
            Actual title: 'github'
            Should contain: 'invalid'

            """

    Scenario: TitleContains(title) throws the unhandled exception if an unhandled exception occurs
        Given an unhandled exception occurs
        When I use Wait.UntilTitle.Contains('invalid')
        Then the unhandled exception will be thrown