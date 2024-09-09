Feature: Element StopsMoving
    Wait.UntilElement().StopsMoving(By locator)

    Scenario: StopsMoving(locator) will return the WebElement if it stops moving
        Given the WebElement has stopped moving
        When I use Wait.UntilElement().StopsMoving(By.Id('id'))
        Then the method will return the WebElement

    Scenario: StopsMoving(locator) throws a WebDriverTimeoutException if element keeps moving
        Given the WebElement keeps moving
        When I use Wait.UntilElement().StopsMoving(By.Id('id'))
        Then the method will throw a WebDriverTimeoutException
            """
            The element has not stopped moving.
            First location: {X=1,Y=2}
            Second location: {X=3,Y=4}
            Locator Name: 'submitButton'
            Locator: 'By.Id: id'
            Displayed: True
            Enabled: True
            Location: {X=5,Y=6}
            Selected: True
            Size: {Width=4, Height=5}
            TagName: div
            Text: 'example text'

            """

    Scenario: StopsMoving(locator) throws a WebDriverTimeoutException if element does not exist
        Given the WebElement does not exist
        When I use Wait.UntilElement().StopsMoving(By.Id('id'))
        Then the method will throw a WebDriverTimeoutException
            """
            The element does not exist, 'NoSuchElementException' has been thrown internally.
            Locator Name: 'submitButton'
            Locator: 'By.Id: id'

            """

    Scenario: StopsMoving(locator) throws a WebDriverTimeoutException if element reference is invalid
        Given the WebElement reference is invalid
        When I use Wait.UntilElement().StopsMoving(By.Id('id'))
        Then the method will throw a WebDriverTimeoutException
            """
            The element reference is no longer valid, 'StaleElementReferenceException' has been thrown internally.
            Locator Name: 'submitButton'
            Locator: 'By.Id: id'

            """

    Scenario: StopsMoving(locator) throws the unhandled exception if an unhandled exception occurs
        Given an unhandled exception occurs
        When I use Wait.UntilElement().StopsMoving(By.Id('id'))
        Then the unhandled exception will be thrown