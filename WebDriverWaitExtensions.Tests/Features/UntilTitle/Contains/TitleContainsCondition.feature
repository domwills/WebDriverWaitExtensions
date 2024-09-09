Feature: Title Contains Condition
    Wait.UntilTitle.Contains(string title, out Condition condition)

    Scenario: TitleContains(title, out var condition) will return a Condition when title contains expected text
        Given the page title changes to be 'github'
        When I use Wait.UntilTitle.Contains('github', out var condition)
        Then the Condition.Result is true and Condition.Error is null

    Scenario: TitleContains(title, out var condition) will return a Condition when title does not contain expected text
        Given the page title is 'github'
        When I use Wait.UntilTitle.Contains('invalid', out var condition)
        Then the Condition.Result is false and Condition.Error contains the following:
            """
            The browser window title doesn't contain 'invalid'.
            Actual title: 'github'
            Should contain: 'invalid'
            """

    Scenario: TitleContains(title, out var condition) throws the unhandled exception if an unhandled exception occurs
        Given an unhandled exception occurs
        When I use Wait.UntilTitle.Contains('invalid', out var condition)
        Then the unhandled exception will be thrown