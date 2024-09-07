Feature: Element IsVisible Condition
    Wait.UntilElement().IsVisible(By locator, out Condition condition)

    Scenario: IsVisible(locator, out var condition) will return a Condition when the WebElement is visible
        Given the WebElement is visible
        When I use Wait.UntilElement().IsVisible(By.Id('id'), out var condition)
        Then the Condition.Result is true and Condition.Error is null

    Scenario: IsVisible(locator, out var condition) will return a Condition when the WebElement is not visible
        Given the WebElement is not visible
        When I use Wait.UntilElement().IsVisible(By.Id('id'), out var condition)
        Then the Condition.Result is false and Condition.Error contains the following:
            """
            The element is not visible.
            Locator Name: 'submitButton'
            Locator: 'By.Id: id'
            Displayed: False
            Enabled: True
            Location: {X=2,Y=3}
            Selected: True
            Size: {Width=4, Height=5}
            TagName: div
            Text: 'example text'
            """

    Scenario: IsVisible(locator, out var condition) will return a Condition if element does not exist
        Given the WebElement does not exist
        When I use Wait.UntilElement().IsVisible(By.Id('id'), out var condition)
        Then the Condition.Result is false and Condition.Error contains the following:
            """
            The element does not exist, 'NoSuchElementException' has been thrown internally.
            Locator Name: 'submitButton'
            Locator: 'By.Id: id'
            """

    Scenario: IsVisible(locator, out var condition) will return a Condition if element reference is invalid
        Given the WebElement reference is invalid
        When I use Wait.UntilElement().IsVisible(By.Id('id'), out var condition)
        Then the Condition.Result is false and Condition.Error contains the following:
            """
            The element reference is no longer valid, 'StaleElementReferenceException' has been thrown internally.
            Locator Name: 'submitButton'
            Locator: 'By.Id: id'
            """

    Scenario: IsVisible(locator, out var condition) throws the unhandled exception if an unhandled exception occurs
        Given an unhandled exception occurs
        When I use Wait.UntilElement().IsVisible(By.Id('id'), out var condition)
        Then the unhandled exception will be thrown