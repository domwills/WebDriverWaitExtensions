Feature: Text ValueContains Timeout Condition
    Wait.UntilTextInElement().ValueContains(By locator, string text, int waitTimeInSeconds, out Condition condition)

    Scenario: ValueContains(locator, text, timeout, out var condition) will return a Condition if text is present in value attribute
        Given the WebElement attribute 'value' has value 'example'
        When I use Wait.UntilTextInElement().ValueContains(By.Id('id'), 'exam', timeout, out var condition)
        Then the Condition.Result is true and Condition.Error is null

    Scenario: ValueContains(locator, text, timeout, out var condition) will return a Condition if text is not present in value attribute
        Given the WebElement attribute 'value' has value 'example'
        When I use Wait.UntilTextInElement().ValueContains(By.Id('id'), 'exan', timeout, out var condition)
        Then the Condition.Result is false and Condition.Error contains the following:
            """
            The element attribute 'value' does not contain 'exan'.
            Attribute: 'value'
            Attribute text: 'example'
            Should contain: 'exan'
            Locator Name: 'submitButton'
            Locator: 'By.Id: id'
            Displayed: True
            Enabled: True
            Location: {X=2,Y=3}
            Selected: True
            Size: {Width=4, Height=5}
            TagName: div
            Text: 'example text'
            """

    Scenario: ValueContains(locator, text, timeout, out var condition) will return a Condition when the WebElement does not exist
        Given the WebElement does not exist
        When I use Wait.UntilTextInElement().ValueContains(By.Id('id'), 'exan', timeout, out var condition)
        Then the Condition.Result is false and Condition.Error contains the following:
            """
            The element does not exist, 'NoSuchElementException' has been thrown internally.
            Locator Name: 'submitButton'
            Locator: 'By.Id: id'
            """

    Scenario: ValueContains(locator, text, timeout, out var condition) will return a Condition when element reference is invalid
        Given the WebElement reference is invalid
        When I use Wait.UntilTextInElement().ValueContains(By.Id('id'), 'exan', timeout, out var condition)
        Then the Condition.Result is false and Condition.Error contains the following:
            """
            The element reference is no longer valid, 'StaleElementReferenceException' has been thrown internally.
            Locator Name: 'submitButton'
            Locator: 'By.Id: id'
            """

    Scenario: ValueContains(locator, text, timeout, out var condition) throws the unhandled exception if an unhandled exception occurs
        Given an unhandled exception occurs
        When I use Wait.UntilTextInElement().ValueContains(By.Id('id'), 'exan', timeout, out var condition)
        Then the unhandled exception will be thrown