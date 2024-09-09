Feature: Element AttributeExists Timeout
    Wait.UntilElement().AttributeExists(By locator, string attribute, int waitTimeInSeconds)

    Scenario: AttributeExists(locator, timeout) will return the WebElement if the attribute exists
        Given the WebElement has attribute 'disabled'
        When I use Wait.UntilElement().AttributeExists(By.Id('id'), 'disabled', timeout)
        Then the method will return the WebElement

    Scenario: AttributeExists(locator, timeout) throws a WebDriverTimeoutException if the attribute does not exist
        Given the WebElement does not have attribute 'disabled'
        When I use Wait.UntilElement().AttributeExists(By.Id('id'), 'disabled', timeout)
        Then the method will throw a WebDriverTimeoutException
            """
            The attribute 'disabled' does not exist for the element.
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

    Scenario: AttributeExists(locator, timeout) throws a WebDriverTimeoutException if element does not exist
        Given the WebElement does not exist
        When I use Wait.UntilElement().AttributeExists(By.Id('id'), 'disabled', timeout)
        Then the method will throw a WebDriverTimeoutException
            """
            The element does not exist, 'NoSuchElementException' has been thrown internally.
            Locator Name: 'submitButton'
            Locator: 'By.Id: id'

            """

    Scenario: AttributeExists(locator, timeout) throws a WebDriverTimeoutException if element reference is invalid
        Given the WebElement reference is invalid
        When I use Wait.UntilElement().AttributeExists(By.Id('id'), 'disabled', timeout)
        Then the method will throw a WebDriverTimeoutException
            """
            The element reference is no longer valid, 'StaleElementReferenceException' has been thrown internally.
            Locator Name: 'submitButton'
            Locator: 'By.Id: id'

            """

    Scenario: AttributeExists(locator, timeout) throws the unhandled exception if an unhandled exception occurs
        Given an unhandled exception occurs
        When I use Wait.UntilElement().AttributeExists(By.Id('id'), 'disabled', timeout)
        Then the unhandled exception will be thrown