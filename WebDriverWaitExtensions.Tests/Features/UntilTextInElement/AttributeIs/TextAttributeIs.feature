Feature: Text AttributeIs
    Wait.UntilTextInElement().AttributeIs(By locator, string attribute, string text)

    Scenario: AttributeIs(locator, attribute, text) will return the WebElement if text matches attribute text
        Given the WebElement attribute 'href' has value 'example'
        When I use Wait.UntilTextInElement().AttributeIs(By.Id('id'), 'href', 'example')
        Then the method will return the WebElement

    Scenario: AttributeIs(locator, attribute, text) throws a WebDriverTimeoutException if text does not match attribute text
        Given the WebElement attribute 'href' has value 'example'
        When I use Wait.UntilTextInElement().AttributeIs(By.Id('id'), 'href', 'exam')
        Then the method will throw a WebDriverTimeoutException
            """
            The element attribute 'href' does not match 'exam'.
            Attribute: 'href'
            Attribute text: 'example'
            Should be: 'exam'
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

    Scenario: AttributeIs(locator, attribute, text) throws a WebDriverTimeoutException if element does not exist
        Given the WebElement does not exist
        When I use Wait.UntilTextInElement().AttributeIs(By.Id('id'), 'href', 'exam')
        Then the method will throw a WebDriverTimeoutException
            """
            The element does not exist, 'NoSuchElementException' has been thrown internally.
            Locator Name: 'submitButton'
            Locator: 'By.Id: id'

            """

    Scenario: AttributeIs(locator, attribute, text) throws a WebDriverTimeoutException if element reference is invalid
        Given the WebElement reference is invalid
        When I use Wait.UntilTextInElement().AttributeIs(By.Id('id'), 'href', 'exam')
        Then the method will throw a WebDriverTimeoutException
            """
            The element reference is no longer valid, 'StaleElementReferenceException' has been thrown internally.
            Locator Name: 'submitButton'
            Locator: 'By.Id: id'

            """

    Scenario: AttributeIs(locator, attribute, text) throws the unhandled exception if an unhandled exception occurs
        Given an unhandled exception occurs
        When I use Wait.UntilTextInElement().AttributeIs(By.Id('id'), 'href', 'exam')
        Then the unhandled exception will be thrown