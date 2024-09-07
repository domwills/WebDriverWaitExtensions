Feature: Element IsFocused Timeout Condition
    Wait.UntilElement().IsFocused(By locator, int waitTimeInSeconds, out Condition condition)

    Scenario: IsFocused(locator, timeout, out var condition) will return a Condition when the WebElement is focused
        Given the WebElement is focused
        When I use Wait.UntilElement().IsFocused(By.Id('id'), timeout, out var condition)
        Then the Condition.Result is true and Condition.Error is null

    Scenario: IsFocused(locator, timeout, out var condition) will return a Condition when the WebElement is not focused
        Given the WebElement is not focused
        When I use Wait.UntilElement().IsFocused(By.Id('id'), timeout, out var condition)
        Then the Condition.Result is false and Condition.Error contains the following:
            """
            The element is not focused.
            Locator Name: 'submitButton'
            Locator: 'By.Id: id'
            Displayed: True
            Enabled: True
            Location: {X=2,Y=3}
            Selected: True
            Size: {Width=4, Height=5}
            TagName: div
            Text: 'example text'

            Focused element:
            Displayed: True
            Enabled: True
            Location: {X=2,Y=3}
            Selected: True
            Size: {Width=4, Height=5}
            TagName: div
            Text: 'example text'

            """

    Scenario: IsFocused(locator, timeout, out var condition) will return a Condition if element does not exist
        Given the WebElement does not exist
        When I use Wait.UntilElement().IsFocused(By.Id('id'), timeout, out var condition)
        Then the Condition.Result is false and Condition.Error contains the following:
            """
            The element does not exist, 'NoSuchElementException' has been thrown internally.
            Locator Name: 'submitButton'
            Locator: 'By.Id: id'
            """

    Scenario: IsFocused(locator, timeout, out var condition) will return a Condition if element reference is invalid
        Given the WebElement reference is invalid
        When I use Wait.UntilElement().IsFocused(By.Id('id'), timeout, out var condition)
        Then the Condition.Result is false and Condition.Error contains the following:
            """
            The element reference is no longer valid, 'StaleElementReferenceException' has been thrown internally.
            Locator Name: 'submitButton'
            Locator: 'By.Id: id'
            """

    Scenario: IsFocused(locator, timeout, out var condition) throws the unhandled exception if an unhandled exception occurs
        Given an unhandled exception occurs
        When I use Wait.UntilElement().IsFocused(By.Id('id'), timeout, out var condition)
        Then the unhandled exception will be thrown