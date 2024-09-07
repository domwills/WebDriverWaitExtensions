Feature: Text CssValueIs Timeout Condition
    Wait.UntilTextInElement().CssValueIs(By locator, string cssValue, string text, int waitTimeInSeconds, out Condition condition)

    Scenario: CssValueIs(locator, cssValue, text, timeout, out var condition) will return a Condition if text matches cssValue
        Given the WebElement cssValue 'style' has value 'example'
        When I use Wait.UntilTextInElement().CssValueIs(By.Id('id'), 'style', 'example', timeout, out var condition)
        Then the Condition.Result is true and Condition.Error is null

    Scenario: CssValueIs(locator, cssValue, text, timeout, out var condition) will return a Condition if text does not match cssValue
        Given the WebElement cssValue 'style' has value 'example'
        When I use Wait.UntilTextInElement().CssValueIs(By.Id('id'), 'style', 'exam', timeout, out var condition)
        Then the Condition.Result is false and Condition.Error contains the following:
            """
            The element CSS value 'style' does not match 'exam'.
            CSS value: 'style'
            CSS value text: 'example'
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

    Scenario: CssValueIs(locator, cssValue, text, timeout, out var condition) will return a Condition when the WebElement does not exist
        Given the WebElement does not exist
        When I use Wait.UntilTextInElement().CssValueIs(By.Id('id'), 'style', 'exam', timeout, out var condition)
        Then the Condition.Result is false and Condition.Error contains the following:
            """
            The element does not exist, 'NoSuchElementException' has been thrown internally.
            Locator Name: 'submitButton'
            Locator: 'By.Id: id'
            """

    Scenario: CssValueIs(locator, cssValue, text, timeout, out var condition) will return a Condition when element reference is invalid
        Given the WebElement reference is invalid
        When I use Wait.UntilTextInElement().CssValueIs(By.Id('id'), 'style', 'exam', timeout, out var condition)
        Then the Condition.Result is false and Condition.Error contains the following:
            """
            The element reference is no longer valid, 'StaleElementReferenceException' has been thrown internally.
            Locator Name: 'submitButton'
            Locator: 'By.Id: id'
            """

    Scenario: CssValueIs(locator, cssValue, text, timeout, out var condition) throws the unhandled exception if an unhandled exception occurs
        Given an unhandled exception occurs
        When I use Wait.UntilTextInElement().CssValueIs(By.Id('id'), 'style', 'exam', timeout, out var condition)
        Then the unhandled exception will be thrown