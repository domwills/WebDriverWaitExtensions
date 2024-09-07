Feature: Element StopsMoving Timeout
    Wait.UntilElement().StopsMoving(By locator, int waitTimeInSeconds)

    Scenario: StopsMoving(locator, timeout) will return the WebElement if it stops moving
        Given the WebElement has stopped moving
        When I use Wait.UntilElement().StopsMoving(By.Id('id'), timeout)
        Then the method will return the WebElement

    Scenario: StopsMoving(locator, timeout) throws a WebDriverTimeoutException if element keeps moving
        Given the WebElement keeps moving
        When I use Wait.UntilElement().StopsMoving(By.Id('id'), timeout)
        Then the method will throw a WebDriverTimeoutException
            """
            The element has not stopped moving.
            First location: {X=7,Y=8}
            Second location: {X=9,Y=10}
            Locator Name: 'submitButton'
            Locator: 'By.Id: id'
            Displayed: True
            Enabled: True
            Location: {X=11,Y=12}
            Selected: True
            Size: {Width=4, Height=5}
            TagName: div
            Text: 'example text'

            """

    Scenario: StopsMoving(locator, timeout) throws a WebDriverTimeoutException if element does not exist
        Given the WebElement does not exist
        When I use Wait.UntilElement().StopsMoving(By.Id('id'), timeout)
        Then the method will throw a WebDriverTimeoutException
            """
            The element does not exist, 'NoSuchElementException' has been thrown internally.
            Locator Name: 'submitButton'
            Locator: 'By.Id: id'

            """

    Scenario: StopsMoving(locator, timeout) throws a WebDriverTimeoutException if element reference is invalid
        Given the WebElement reference is invalid
        When I use Wait.UntilElement().StopsMoving(By.Id('id'), timeout)
        Then the method will throw a WebDriverTimeoutException
            """
            The element reference is no longer valid, 'StaleElementReferenceException' has been thrown internally.
            Locator Name: 'submitButton'
            Locator: 'By.Id: id'

            """

    Scenario: StopsMoving(locator, timeout) throws the unhandled exception if an unhandled exception occurs
        Given an unhandled exception occurs
        When I use Wait.UntilElement().StopsMoving(By.Id('id'), timeout)
        Then the unhandled exception will be thrown