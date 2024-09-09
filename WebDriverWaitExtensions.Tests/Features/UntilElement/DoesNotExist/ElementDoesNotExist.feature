Feature: Element DoesNotExist
    Wait.UntilElement().DoesNotExist(By locator)

    Scenario: DoesNotExist(locator) will wait until the WebElement does not exist
        Given the WebElement does not exist
        When I use Wait.UntilElement().DoesNotExist(By.Id('id'))
        Then the method will not throw an exception

    Scenario: DoesNotExist(locator) throws a WebDriverTimeoutException when the WebElement exists
        Given the WebElement exists
        When I use Wait.UntilElement().DoesNotExist(By.Id('id'))
        Then the method will throw a WebDriverTimeoutException
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

    Scenario: DoesNotExist(locator) throws a WebDriverTimeoutException if element reference is invalid
        Given the WebElement reference is invalid
        When I use Wait.UntilElement().DoesNotExist(By.Id('id'))
        Then the method will throw a WebDriverTimeoutException
            """
            The element reference is no longer valid, 'StaleElementReferenceException' has been thrown internally.
            Locator Name: 'submitButton'
            Locator: 'By.Id: id'

            """

    Scenario: DoesNotExist(locator) throws the unhandled exception if an unhandled exception occurs
        Given an unhandled exception occurs
        When I use Wait.UntilElement().DoesNotExist(By.Id('id'))
        Then the unhandled exception will be thrown