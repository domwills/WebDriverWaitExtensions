Feature: Element IsClicked
    Wait.UntilElement().IsClicked(By locator)

    Scenario: IsClicked(locator) will return the WebElement if it exists
        Given the WebElement exists
        When I use Wait.UntilElement().IsClicked(By.Id('id'))
        Then the method will not throw an exception

    Scenario: IsClicked(locator) throws a WebDriverTimeoutException if element does not exist
        Given the WebElement does not exist
        When I use Wait.UntilElement().IsClicked(By.Id('id'))
        Then the method will throw a WebDriverTimeoutException
            """
            The element does not exist, 'NoSuchElementException' has been thrown internally.
            Locator Name: 'submitButton'
            Locator: 'By.Id: id'

            """

    Scenario: IsClicked(locator) throws a WebDriverTimeoutException if element reference is invalid
        Given the WebElement reference is invalid when clicked
        When I use Wait.UntilElement().IsClicked(By.Id('id'))
        Then the method will throw a WebDriverTimeoutException
            """
            The element reference is no longer valid, 'StaleElementReferenceException' has been thrown internally.
            Locator Name: 'submitButton'
            Locator: 'By.Id: id'

            """

    Scenario: IsClicked(locator) throws the unhandled exception if an unhandled exception occurs
        Given an unhandled exception occurs
        When I use Wait.UntilElement().IsClicked(By.Id('id'))
        Then the unhandled exception will be thrown