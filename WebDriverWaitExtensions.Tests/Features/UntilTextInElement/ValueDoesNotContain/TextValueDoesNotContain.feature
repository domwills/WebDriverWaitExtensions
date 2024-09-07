Feature: Text ValueDoesNotContain
    Wait.UntilTextInElement().ValueDoesNotContain(By locator, string text)

    Scenario: ValueDoesNotContain(locator, text) will return the WebElement if text is not present in value attribute
        Given the WebElement attribute 'value' has value 'example'
        When I use Wait.UntilTextInElement().ValueDoesNotContain(By.Id('id'), 'exan')
        Then the method will return the WebElement

    Scenario: ValueDoesNotContain(locator, text) throws a WebDriverTimeoutException if text is present in value attribute
        Given the WebElement attribute 'value' has value 'example'
        When I use Wait.UntilTextInElement().ValueDoesNotContain(By.Id('id'), 'exam')
        Then the method will throw a WebDriverTimeoutException
            """
            The element attribute 'value' still contains 'exam'.
            Attribute: 'value'
            Attribute text: 'example'
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

    Scenario: ValueDoesNotContain(locator, text) throws a WebDriverTimeoutException if element does not exist
        Given the WebElement does not exist
        When I use Wait.UntilTextInElement().ValueDoesNotContain(By.Id('id'), 'exam')
        Then the method will throw a WebDriverTimeoutException
            """
            The element does not exist, 'NoSuchElementException' has been thrown internally.
            Locator Name: 'submitButton'
            Locator: 'By.Id: id'

            """

    Scenario: ValueDoesNotContain(locator, text) throws a WebDriverTimeoutException if element reference is invalid
        Given the WebElement reference is invalid
        When I use Wait.UntilTextInElement().ValueDoesNotContain(By.Id('id'), 'exam')
        Then the method will throw a WebDriverTimeoutException
            """
            The element reference is no longer valid, 'StaleElementReferenceException' has been thrown internally.
            Locator Name: 'submitButton'
            Locator: 'By.Id: id'

            """

    Scenario: ValueDoesNotContain(locator, text) throws the unhandled exception if an unhandled exception occurs
        Given an unhandled exception occurs
        When I use Wait.UntilTextInElement().ValueDoesNotContain(By.Id('id'), 'exam')
        Then the unhandled exception will be thrown