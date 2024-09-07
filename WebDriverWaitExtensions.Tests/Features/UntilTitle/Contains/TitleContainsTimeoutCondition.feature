Feature: Title Contains Timeout Condition
    Wait.UntilTitle.Contains(string title, int waitTimeInSeconds, out Condition condition)

    Scenario: TitleContains(title, timeout, out var condition) will return a Condition when title contains expected text
        Given the page title changes to be 'github'
        When I use Wait.UntilTitle.Contains('github', timeout, out var condition)
        Then the Condition.Result is true and Condition.Error is null

    Scenario: TitleContains(title, timeout, out var condition)  will return a Condition title does not contain expected text
        Given the page title is 'github'
        When I use Wait.UntilTitle.Contains('invalid', timeout, out var condition)
        Then the Condition.Result is false and Condition.Error contains the following:
            """
            The browser window title doesn't contain 'invalid'.
            Actual title: 'github'
            Should contain: 'invalid'
            """

    Scenario: TitleContains(title, timeout, out var condition) throws the unhandled exception if an unhandled exception occurs
        Given an unhandled exception occurs
        When I use Wait.UntilTitle.Contains('invalid', timeout, out var condition)
        Then the unhandled exception will be thrown