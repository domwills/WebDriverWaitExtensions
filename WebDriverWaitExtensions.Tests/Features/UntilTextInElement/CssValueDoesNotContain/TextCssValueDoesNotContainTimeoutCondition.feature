Feature: Text CssValueDoesNotContain Timeout Condition
    Wait.UntilTextInElement().CssValueDoesNotContain(By locator, string cssValue, string text, int waitTimeInSeconds, out Condition condition)

    Scenario: CssValueDoesNotContain(locator, cssValue, text, timeout, out var condition) will return a Condition if text is not present in cssValue
        Given the WebElement cssValue 'style' has value 'example'
        When I use Wait.UntilTextInElement().CssValueDoesNotContain(By.Id('id'), 'style', 'exan', timeout, out var condition)
        Then the Condition.Result is true and Condition.Error is null

    Scenario: CssValueDoesNotContain(locator, cssValue, text, timeout, out var condition) will return a Condition if text is present in cssValue
        Given the WebElement cssValue 'style' has value 'example'
        When I use Wait.UntilTextInElement().CssValueDoesNotContain(By.Id('id'), 'style', 'exam', timeout, out var condition)
        Then the Condition.Result is false and Condition.Error contains the following:
            """
            The element CSS value 'style' still contains 'exam'.
            CSS value: 'style'
            CSS value text: 'example'
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

    Scenario: CssValueDoesNotContain(locator, cssValue, text, timeout, out var condition) will return a Condition when the WebElement does not exist
        Given the WebElement does not exist
        When I use Wait.UntilTextInElement().CssValueDoesNotContain(By.Id('id'), 'style', 'exam', timeout, out var condition)
        Then the Condition.Result is false and Condition.Error contains the following:
            """
            The element does not exist, 'NoSuchElementException' has been thrown internally.
            Locator Name: 'submitButton'
            Locator: 'By.Id: id'
            """

    Scenario: CssValueDoesNotContain(locator, cssValue, text, timeout, out var condition) will return a Condition when element reference is invalid
        Given the WebElement reference is invalid
        When I use Wait.UntilTextInElement().CssValueDoesNotContain(By.Id('id'), 'style', 'exam', timeout, out var condition)
        Then the Condition.Result is false and Condition.Error contains the following:
            """
            The element reference is no longer valid, 'StaleElementReferenceException' has been thrown internally.
            Locator Name: 'submitButton'
            Locator: 'By.Id: id'
            """

    Scenario: CssValueDoesNotContain(locator, cssValue, text, timeout, out var condition) throws the unhandled exception if an unhandled exception occurs
        Given an unhandled exception occurs
        When I use Wait.UntilTextInElement().CssValueDoesNotContain(By.Id('id'), 'style', 'exam', timeout, out var condition)
        Then the unhandled exception will be thrown