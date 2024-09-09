Feature: Title Is Condition
    Wait.UntilTitle.Is(string title, out Condition condition)

    Scenario: TitleIs(title, out var condition) will return a Condition when title is the expected title
        Given the page title changes to be 'github'
        When I use Wait.UntilTitle.Is('github', out var condition)
        Then the Condition.Result is true and Condition.Error is null

    Scenario: TitleIs(title, out var condition) will return a Condition when title is not the expected title
        Given the page title is 'github'
        When I use Wait.UntilTitle.Is('invalid', out var condition)
        Then the Condition.Result is false and Condition.Error contains the following:
            """
            The browser window title doesn't match 'invalid'.
            Actual title: 'github'
            Expected title: 'invalid'
            """

    Scenario: TitleIs(title, out var condition) throws the unhandled exception if an unhandled exception occurs
        Given an unhandled exception occurs
        When I use Wait.UntilTitle.Is('invalid', out var condition)
        Then the unhandled exception will be thrown