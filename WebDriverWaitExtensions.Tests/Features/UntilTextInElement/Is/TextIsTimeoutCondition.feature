Feature: Text Is Timeout Condition
    Wait.UntilTextInElement().Is(By locator, string text, int waitTimeInSeconds, out Condition condition)

    Scenario: Is(locator, text, timeout, out var condition) will return a Condition if text matches
        Given the WebElement text value is 'example'
        When I use Wait.UntilTextInElement().Is(By.Id('id'), 'example', timeout, out var condition)
        Then the Condition.Result is true and Condition.Error is null

    Scenario: Is(locator, text, timeout, out var condition) will return a Condition if text does not match
        Given the WebElement text value is 'example'
        When I use Wait.UntilTextInElement().Is(By.Id('id'), 'exam', timeout, out var condition)
        Then the Condition.Result is false and Condition.Error contains the following:
            """
            The element text does not match 'exam'.
            Element text: 'example'
            Should be: 'exam'
            Locator Name: 'submitButton'
            Locator: 'By.Id: id'
            Displayed: True
            Enabled: True
            Location: {X=2,Y=3}
            Selected: True
            Size: {Width=4, Height=5}
            TagName: div
            Text: 'example'
            """

    Scenario: Is(locator, text, timeout, out var condition) will return a Condition when the WebElement does not exist
        Given the WebElement does not exist
        When I use Wait.UntilTextInElement().Is(By.Id('id'), 'exam', timeout, out var condition)
        Then the Condition.Result is false and Condition.Error contains the following:
            """
            The element does not exist, 'NoSuchElementException' has been thrown internally.
            Locator Name: 'submitButton'
            Locator: 'By.Id: id'
            """

    Scenario: Is(locator, text, timeout, out var condition) will return a Condition when element reference is invalid
        Given the WebElement reference is invalid
        When I use Wait.UntilTextInElement().Is(By.Id('id'), 'exam', timeout, out var condition)
        Then the Condition.Result is false and Condition.Error contains the following:
            """
            The element reference is no longer valid, 'StaleElementReferenceException' has been thrown internally.
            Locator Name: 'submitButton'
            Locator: 'By.Id: id'
            """

    Scenario: Is(locator, text, timeout, out var condition) throws the unhandled exception if an unhandled exception occurs
        Given an unhandled exception occurs
        When I use Wait.UntilTextInElement().Is(By.Id('id'), 'exam', timeout, out var condition)
        Then the unhandled exception will be thrown