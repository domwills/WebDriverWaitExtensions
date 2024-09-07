Feature: Text ValueIs Condition
    Wait.UntilTextInElement().ValueIs(By locator, string text, out Condition condition)

    Scenario: ValueIs(locator, text, out var condition) will return a Condition if text matches value attribute
        Given the WebElement attribute 'value' has value 'example'
        When I use Wait.UntilTextInElement().ValueIs(By.Id('id'), 'example', out var condition)
        Then the Condition.Result is true and Condition.Error is null

    Scenario: ValueIs(locator, text, out var condition) will return a Condition if text does not match value attribute
        Given the WebElement attribute 'value' has value 'example'
        When I use Wait.UntilTextInElement().ValueIs(By.Id('id'), 'exam', out var condition)
        Then the Condition.Result is false and Condition.Error contains the following:
            """
            The element attribute 'value' does not match 'exam'.
            Attribute: 'value'
            Attribute text: 'example'
            Should be: 'exam'
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

    Scenario: ValueIs(locator, text, out var condition) will return a Condition when the WebElement does not exist
        Given the WebElement does not exist
        When I use Wait.UntilTextInElement().ValueIs(By.Id('id'), 'exam', out var condition)
        Then the Condition.Result is false and Condition.Error contains the following:
            """
            The element does not exist, 'NoSuchElementException' has been thrown internally.
            Locator Name: 'submitButton'
            Locator: 'By.Id: id'
            """

    Scenario: ValueIs(locator, text, out var condition) will return a Condition when element reference is invalid
        Given the WebElement reference is invalid
        When I use Wait.UntilTextInElement().ValueIs(By.Id('id'), 'exam', out var condition)
        Then the Condition.Result is false and Condition.Error contains the following:
            """
            The element reference is no longer valid, 'StaleElementReferenceException' has been thrown internally.
            Locator Name: 'submitButton'
            Locator: 'By.Id: id'
            """

    Scenario: ValueIs(locator, text, out var condition) throws the unhandled exception if an unhandled exception occurs
        Given an unhandled exception occurs
        When I use Wait.UntilTextInElement().ValueIs(By.Id('id'), 'exam', out var condition)
        Then the unhandled exception will be thrown