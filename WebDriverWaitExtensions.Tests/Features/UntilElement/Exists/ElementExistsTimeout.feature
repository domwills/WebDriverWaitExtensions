Feature: Element Exists Timeout
    Wait.UntilElement().Exists(By locator, int waitTimeInSeconds)

    Scenario: Exists(locator, timeout) will return the WebElement if it exists
        Given the WebElement exists
        When I use Wait.UntilElement().Exists(By.Id('id'), timeout)
        Then the method will return the WebElement

    Scenario: Exists(locator, timeout) throws a WebDriverTimeoutException if element does not exist
        Given the WebElement does not exist
        When I use Wait.UntilElement().Exists(By.Id('id'), timeout)
        Then the method will throw a WebDriverTimeoutException
            """
            The element does not exist, 'NoSuchElementException' has been thrown internally.
            Locator Name: 'submitButton'
            Locator: 'By.Id: id'

            """

    Scenario: Exists(locator, timeout) throws a WebDriverTimeoutException if element reference is invalid
        Given the WebElement reference is invalid
        When I use Wait.UntilElement().Exists(By.Id('id'), timeout)
        Then the method will throw a WebDriverTimeoutException
            """
            The element reference is no longer valid, 'StaleElementReferenceException' has been thrown internally.
            Locator Name: 'submitButton'
            Locator: 'By.Id: id'

            """

    Scenario: Exists(locator, timeout) throws the unhandled exception if an unhandled exception occurs
        Given an unhandled exception occurs
        When I use Wait.UntilElement().Exists(By.Id('id'), timeout)
        Then the unhandled exception will be thrown