Feature: Text Contains Timeout Condition
    Wait.UntilTextInElement().Contains(By locator, string text, int waitTimeInSeconds, out Condition condition)

    Scenario: Contains(locator, text, timeout, out var condition) will return a Condition if text is not present in value attribute
        Given the WebElement text value is 'example'
        When I use Wait.UntilTextInElement().Contains(By.Id('id'), 'exam', timeout, out var condition)
        Then the Condition.Result is true and Condition.Error is null

    Scenario: Contains(locator, text, timeout, out var condition) will return a Condition if text is present in value attribute
        Given the WebElement text value is 'example'
        When I use Wait.UntilTextInElement().Contains(By.Id('id'), 'exan', timeout, out var condition)
        Then the Condition.Result is false and Condition.Error contains the following:
            """
            The element text does not contain 'exan'.
            Element text: 'example'
            Should contain: 'exan'
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

    Scenario: Contains(locator, text, timeout, out var condition) will return a Condition when the WebElement does not exist
        Given the WebElement does not exist
        When I use Wait.UntilTextInElement().Contains(By.Id('id'), 'exan', timeout, out var condition)
        Then the Condition.Result is false and Condition.Error contains the following:
            """
            The element does not exist, 'NoSuchElementException' has been thrown internally.
            Locator Name: 'submitButton'
            Locator: 'By.Id: id'
            """

    Scenario: Contains(locator, text, timeout, out var condition) will return a Condition when element reference is invalid
        Given the WebElement reference is invalid
        When I use Wait.UntilTextInElement().Contains(By.Id('id'), 'exan', timeout, out var condition)
        Then the Condition.Result is false and Condition.Error contains the following:
            """
            The element reference is no longer valid, 'StaleElementReferenceException' has been thrown internally.
            Locator Name: 'submitButton'
            Locator: 'By.Id: id'
            """

    Scenario: Contains(locator, text, timeout, out var condition) throws the unhandled exception if an unhandled exception occurs
        Given an unhandled exception occurs
        When I use Wait.UntilTextInElement().Contains(By.Id('id'), 'exan', timeout, out var condition)
        Then the unhandled exception will be thrown