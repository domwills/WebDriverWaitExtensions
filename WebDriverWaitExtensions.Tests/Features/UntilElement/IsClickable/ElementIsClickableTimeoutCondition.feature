Feature: Element IsClickable Timeout Condition
    Wait.UntilElement().IsClickable(By locator, int waitTimeInSeconds, out Condition condition)

    Scenario: IsClickable(locator, timeout, out var condition) will return a Condition when the WebElement is visible and enabled
        Given the WebElement is visible
        And the WebElement is enabled
        When I use Wait.UntilElement().IsClickable(By.Id('id'), timeout, out var condition)
        Then the Condition.Result is true and Condition.Error is null

    Scenario: IsClickable(locator, timeout, out var condition) will return a Condition when the WebElement is not visible but is enabled
        Given the WebElement is enabled
        And the WebElement is not visible
        When I use Wait.UntilElement().IsClickable(By.Id('id'), timeout, out var condition)
        Then the Condition.Result is false and Condition.Error contains the following:
            """
            The element is not clickable as it's not visible.
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

    Scenario: IsClickable(locator, timeout, out var condition) will return a Condition when the WebElement is visible but not enabled
        Given the WebElement is visible
        And the WebElement is not enabled
        When I use Wait.UntilElement().IsClickable(By.Id('id'), timeout, out var condition)
        Then the Condition.Result is false and Condition.Error contains the following:
            """
            The element is not clickable as it's not enabled.
            Locator Name: 'submitButton'
            Locator: 'By.Id: id'
            Displayed: True
            Enabled: False
            Location: {X=2,Y=3}
            Selected: True
            Size: {Width=4, Height=5}
            TagName: div
            Text: 'example text'
            """

    Scenario: IsClickable(locator, timeout, out var condition) will return a Condition when the WebElement is not visible and not enabled
        Given the WebElement is not visible
        And the WebElement is not enabled
        When I use Wait.UntilElement().IsClickable(By.Id('id'), timeout, out var condition)
        Then the Condition.Result is false and Condition.Error contains the following:
            """
            The element is not clickable as it's not visible and not enabled.
            Locator Name: 'submitButton'
            Locator: 'By.Id: id'
            Displayed: False
            Enabled: False
            Location: {X=2,Y=3}
            Selected: True
            Size: {Width=4, Height=5}
            TagName: div
            Text: 'example text'
            """

    Scenario: IsClickable(locator, timeout, out var condition) will return a Condition if element does not exist
        Given the WebElement does not exist
        When I use Wait.UntilElement().IsClickable(By.Id('id'), timeout, out var condition)
        Then the Condition.Result is false and Condition.Error contains the following:
            """
            The element does not exist, 'NoSuchElementException' has been thrown internally.
            Locator Name: 'submitButton'
            Locator: 'By.Id: id'
            """

    Scenario: IsClickable(locator, timeout, out var condition) will return a Condition if element reference is invalid
        Given the WebElement reference is invalid
        When I use Wait.UntilElement().IsClickable(By.Id('id'), timeout, out var condition)
        Then the Condition.Result is false and Condition.Error contains the following:
            """
            The element reference is no longer valid, 'StaleElementReferenceException' has been thrown internally.
            Locator Name: 'submitButton'
            Locator: 'By.Id: id'
            """

    Scenario: IsClickable(locator, timeout, out var condition) throws the unhandled exception if an unhandled exception occurs
        Given an unhandled exception occurs
        When I use Wait.UntilElement().IsClickable(By.Id('id'), timeout, out var condition)
        Then the unhandled exception will be thrown