Feature: Text CssValueContains Timeout Condition
    Wait.UntilTextInElement().CssValueContains(By locator, string cssValue, string text, int waitTimeInSeconds, out Condition condition)

    Scenario: CssValueContains(locator, cssValue, text, timeout, out var condition) will return a Condition if text is present in cssValue
        Given the WebElement cssValue 'style' has value 'example'
        When I use Wait.UntilTextInElement().CssValueContains(By.Id('id'), 'style', 'exam', timeout, out var condition)
        Then the Condition.Result is true and Condition.Error is null

    Scenario: CssValueContains(locator, cssValue, text, timeout, out var condition) will return a Condition if text is not present in cssValue
        Given the WebElement cssValue 'style' has value 'example'
        When I use Wait.UntilTextInElement().CssValueContains(By.Id('id'), 'style', 'exan', timeout, out var condition)
        Then the Condition.Result is false and Condition.Error contains the following:
            """
            The element CSS value 'style' does not contain 'exan'.
            CSS value: 'style'
            CSS value text: 'example'
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

    Scenario: CssValueContains(locator, cssValue, text, timeout, out var condition) will return a Condition when the WebElement does not exist
        Given the WebElement does not exist
        When I use Wait.UntilTextInElement().CssValueContains(By.Id('id'), 'style', 'exan', timeout, out var condition)
        Then the Condition.Result is false and Condition.Error contains the following:
            """
            The element does not exist, 'NoSuchElementException' has been thrown internally.
            Locator Name: 'submitButton'
            Locator: 'By.Id: id'
            """

    Scenario: CssValueContains(locator, cssValue, text, timeout, out var condition) will return a Condition when element reference is invalid
        Given the WebElement reference is invalid
        When I use Wait.UntilTextInElement().CssValueContains(By.Id('id'), 'style', 'exan', timeout, out var condition)
        Then the Condition.Result is false and Condition.Error contains the following:
            """
            The element reference is no longer valid, 'StaleElementReferenceException' has been thrown internally.
            Locator Name: 'submitButton'
            Locator: 'By.Id: id'
            """

    Scenario: CssValueContains(locator, cssValue, text, timeout, out var condition) throws the unhandled exception if an unhandled exception occurs
        Given an unhandled exception occurs
        When I use Wait.UntilTextInElement().CssValueContains(By.Id('id'), 'style', 'exan', timeout, out var condition)
        Then the unhandled exception will be thrown