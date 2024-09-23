Feature: Element IsClicked Condition
    Wait.UntilElement().IsClicked(By locator, out Condition condition)

    Scenario: IsClicked(locator, out var condition) will return a Condition when the WebElement exists
        Given the WebElement exists
        When I use Wait.UntilElement().IsClicked(By.Id('id'), out var condition)
        Then the Condition.Result is true and Condition.Error is null

    Scenario: IsClicked(locator, out var condition) will return a Condition when the WebElement does not exist
        Given the WebElement does not exist
        When I use Wait.UntilElement().IsClicked(By.Id('id'), out var condition)
        Then the Condition.Result is false and Condition.Error contains the following:
            """
            The element does not exist, 'NoSuchElementException' has been thrown internally.
            Locator Name: 'submitButton'
            Locator: 'By.Id: id'
            """

    Scenario: IsClicked(locator, out var condition) will return a Condition when element reference is invalid
        Given the WebElement reference is invalid when clicked
        When I use Wait.UntilElement().IsClicked(By.Id('id'), out var condition)
        Then the Condition.Result is false and Condition.Error contains the following:
            """
            The element reference is no longer valid, 'StaleElementReferenceException' has been thrown internally.
            Locator Name: 'submitButton'
            Locator: 'By.Id: id'
            """

    Scenario: IsClicked(locator, out var condition) throws a WebDriverTimeoutException if click is intercepted
        Given the WebElement is overlaid by another element when clicked
        When I use Wait.UntilElement().IsClicked(By.Id('id'), out var condition)
        Then the Condition.Result is false and Condition.Error contains the following:
            """
            Element has not been clicked, 'ElementClickInterceptedException' has been thrown internally.
            Locator Name: 'submitButton'
            Locator: 'By.Id: id'
            """

    Scenario: IsClicked(locator, out var condition) throws the unhandled exception if an unhandled exception occurs
        Given an unhandled exception occurs
        When I use Wait.UntilElement().IsClicked(By.Id('id'), out var condition)
        Then the unhandled exception will be thrown