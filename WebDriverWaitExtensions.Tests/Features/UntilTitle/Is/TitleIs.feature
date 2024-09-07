Feature: Title Is
    Wait.UntilTitle.Is(string title)

    Scenario: TitleIs(title) will wait until title is the expected title
        Given the page title changes to be 'github'
        When I use Wait.UntilTitle.Is('github')
        Then the method will not throw an exception

    Scenario: TitleIs(title) will throw a WebDriverTimeoutException if the title is not the expected title
        Given the page title is 'github'
        When I use Wait.UntilTitle.Is('invalid')
        Then the method will throw a WebDriverTimeoutException
            """
            The browser window title doesn't match 'invalid'.
            Actual title: 'github'
            Expected title: 'invalid'

            """

    Scenario: TitleIs(title) throws the unhandled exception if an unhandled exception occurs
        Given an unhandled exception occurs
        When I use Wait.UntilTitle.Is('invalid')
        Then the unhandled exception will be thrown