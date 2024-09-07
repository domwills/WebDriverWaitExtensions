Feature: Element IsSelected Timeout Condition
    Wait.UntilElement().IsSelected(By locator, int waitTimeInSeconds, out Condition condition)

    Scenario: IsSelected(locator, timeout, out var condition) will return a Condition when the WebElement is selected
        Given the WebElement is selected
        When I use Wait.UntilElement().IsSelected(By.Id('id'), timeout, out var condition)
        Then the Condition.Result is true and Condition.Error is null

    Scenario: IsSelected(locator, timeout, out var condition) will return a Condition when the WebElement is not selected
        Given the WebElement is not selected
        When I use Wait.UntilElement().IsSelected(By.Id('id'), timeout, out var condition)
        Then the Condition.Result is false and Condition.Error contains the following:
            """
            The element selected state is not set to 'True'.
            Locator Name: 'submitButton'
            Locator: 'By.Id: id'
            Displayed: True
            Enabled: True
            Location: {X=2,Y=3}
            Selected: False
            Size: {Width=4, Height=5}
            TagName: div
            Text: 'example text'
            """

    Scenario: IsSelected(locator, timeout, out var condition) will return a Condition if element does not exist
        Given the WebElement does not exist
        When I use Wait.UntilElement().IsSelected(By.Id('id'), timeout, out var condition)
        Then the Condition.Result is false and Condition.Error contains the following:
            """
            The element does not exist, 'NoSuchElementException' has been thrown internally.
            Locator Name: 'submitButton'
            Locator: 'By.Id: id'
            """

    Scenario: IsSelected(locator, timeout, out var condition) will return a Condition if element reference is invalid
        Given the WebElement reference is invalid
        When I use Wait.UntilElement().IsSelected(By.Id('id'), timeout, out var condition)
        Then the Condition.Result is false and Condition.Error contains the following:
            """
            The element reference is no longer valid, 'StaleElementReferenceException' has been thrown internally.
            Locator Name: 'submitButton'
            Locator: 'By.Id: id'
            """

    Scenario: IsSelected(locator, timeout, out var condition) throws the unhandled exception if an unhandled exception occurs
        Given an unhandled exception occurs
        When I use Wait.UntilElement().IsSelected(By.Id('id'), timeout, out var condition)
        Then the unhandled exception will be thrown