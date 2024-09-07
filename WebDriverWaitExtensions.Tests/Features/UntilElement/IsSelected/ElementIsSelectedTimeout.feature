Feature: Element IsSelected Timeout
    Wait.UntilElement().IsSelected(By locator, int waitTimeInSeconds)

    Scenario: IsSelected(locator, timeout) will return the WebElement if it is selected
        Given the WebElement is selected
        When I use Wait.UntilElement().IsSelected(By.Id('id'), timeout)
        Then the method will return the WebElement

    Scenario: IsSelected(locator, timeout) throws a WebDriverTimeoutException if element is not selected
        Given the WebElement is not selected
        When I use Wait.UntilElement().IsSelected(By.Id('id'), timeout)
        Then the method will throw a WebDriverTimeoutException
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

    Scenario: IsSelected(locator, timeout) throws a WebDriverTimeoutException if element does not exist
        Given the WebElement does not exist
        When I use Wait.UntilElement().IsSelected(By.Id('id'), timeout)
        Then the method will throw a WebDriverTimeoutException
            """
            The element does not exist, 'NoSuchElementException' has been thrown internally.
            Locator Name: 'submitButton'
            Locator: 'By.Id: id'

            """

    Scenario: IsSelected(locator, timeout) throws a WebDriverTimeoutException if element reference is invalid
        Given the WebElement reference is invalid
        When I use Wait.UntilElement().IsSelected(By.Id('id'), timeout)
        Then the method will throw a WebDriverTimeoutException
            """
            The element reference is no longer valid, 'StaleElementReferenceException' has been thrown internally.
            Locator Name: 'submitButton'
            Locator: 'By.Id: id'

            """

    Scenario: IsSelected(locator, timeout) throws the unhandled exception if an unhandled exception occurs
        Given an unhandled exception occurs
        When I use Wait.UntilElement().IsSelected(By.Id('id'), timeout)
        Then the unhandled exception will be thrown