Feature: Element DoesNotExist Condition
    Wait.UntilElement().DoesNotExist(By locator, out Condition condition)

    Scenario: DoesNotExist(locator, out var condition) will return a Condition when the WebElement does not exist
        Given the WebElement does not exist
        When I use Wait.UntilElement().DoesNotExist(By.Id('id'), out var condition)
        Then the Condition.Result is true and Condition.Error is null

    Scenario: DoesNotExist(locator, out var condition) will return a Condition when the WebElement exists
        Given the WebElement exists
        When I use Wait.UntilElement().DoesNotExist(By.Id('id'), out var condition)
        Then the Condition.Result is false and Condition.Error contains the following:
            """
            The element still exists.
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

    Scenario: DoesNotExist(locator, out var condition) will return a Condition when element reference is invalid
        Given the WebElement reference is invalid
        When I use Wait.UntilElement().DoesNotExist(By.Id('id'), out var condition)
        Then the Condition.Result is false and Condition.Error contains the following:
            """
            The element reference is no longer valid, 'StaleElementReferenceException' has been thrown internally.
            Locator Name: 'submitButton'
            Locator: 'By.Id: id'
            """

    Scenario: DoesNotExist(locator, out var condition) throws the unhandled exception if an unhandled exception occurs
        Given an unhandled exception occurs
        When I use Wait.UntilElement().DoesNotExist(By.Id('id'), out var condition)
        Then the unhandled exception will be thrown