Feature: Text Is
    Wait.UntilTextInElement().Is(By locator, string text)

    Scenario: Is(locator, text) will return the WebElement if text matches
        Given the WebElement text value is 'example'
        When I use Wait.UntilTextInElement().Is(By.Id('id'), 'example')
        Then the method will return the WebElement

    Scenario: Is(locator, text) throws a WebDriverTimeoutException if text does not match
        Given the WebElement text value is 'example'
        When I use Wait.UntilTextInElement().Is(By.Id('id'), 'exam')
        Then the method will throw a WebDriverTimeoutException
            """
            The element text does not match 'exam'.
            Element text: 'example'
            Should be: 'exam'
            Locator Name: 'submitButton'
            Locator: 'By.Id: id'
            Displayed: True
            Enabled: True
            Location: {X=2,Y=3}
            Selected: True
            Size: {Width=4, Height=5}
            TagName: div
            Text: 'example'

            """

    Scenario: Is(locator, text) throws a WebDriverTimeoutException if element does not exist
        Given the WebElement does not exist
        When I use Wait.UntilTextInElement().Is(By.Id('id'), 'exam')
        Then the method will throw a WebDriverTimeoutException
            """
            The element does not exist, 'NoSuchElementException' has been thrown internally.
            Locator Name: 'submitButton'
            Locator: 'By.Id: id'

            """

    Scenario: Is(locator, text) throws a WebDriverTimeoutException if element reference is invalid
        Given the WebElement reference is invalid
        When I use Wait.UntilTextInElement().Is(By.Id('id'), 'exam')
        Then the method will throw a WebDriverTimeoutException
            """
            The element reference is no longer valid, 'StaleElementReferenceException' has been thrown internally.
            Locator Name: 'submitButton'
            Locator: 'By.Id: id'

            """

    Scenario: Is(locator, text) throws the unhandled exception if an unhandled exception occurs
        Given an unhandled exception occurs
        When I use Wait.UntilTextInElement().Is(By.Id('id'), 'exam')
        Then the unhandled exception will be thrown