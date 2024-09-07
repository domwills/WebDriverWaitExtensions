Feature: Element IsFocused
    Wait.UntilElement().IsFocused(By locator)

    Scenario: IsFocused(locator) will return the WebElement if it is focused
        Given the WebElement is focused
        When I use Wait.UntilElement().IsFocused(By.Id('id'))
        Then the method will return the WebElement

    Scenario: IsFocused(locator) throws a WebDriverTimeoutException if element is not focused
        Given the WebElement is not focused
        When I use Wait.UntilElement().IsFocused(By.Id('id'))
        Then the method will throw a WebDriverTimeoutException
            """
            The element is not focused.
            Locator Name: 'submitButton'
            Locator: 'By.Id: id'
            Displayed: True
            Enabled: True
            Location: {X=2,Y=3}
            Selected: True
            Size: {Width=4, Height=5}
            TagName: div
            Text: 'example text'

            Focused element:
            Displayed: True
            Enabled: True
            Location: {X=2,Y=3}
            Selected: True
            Size: {Width=4, Height=5}
            TagName: div
            Text: 'example text'

            """

    Scenario: IsFocused(locator) throws a WebDriverTimeoutException if element does not exist
        Given the WebElement does not exist
        When I use Wait.UntilElement().IsFocused(By.Id('id'))
        Then the method will throw a WebDriverTimeoutException
            """
            The element does not exist, 'NoSuchElementException' has been thrown internally.
            Locator Name: 'submitButton'
            Locator: 'By.Id: id'

            """

    Scenario: IsFocused(locator) throws a WebDriverTimeoutException if element reference is invalid
        Given the WebElement reference is invalid
        When I use Wait.UntilElement().IsFocused(By.Id('id'))
        Then the method will throw a WebDriverTimeoutException
            """
            The element reference is no longer valid, 'StaleElementReferenceException' has been thrown internally.
            Locator Name: 'submitButton'
            Locator: 'By.Id: id'

            """

    Scenario: IsFocused(locator) throws the unhandled exception if an unhandled exception occurs
        Given an unhandled exception occurs
        When I use Wait.UntilElement().IsFocused(By.Id('id'))
        Then the unhandled exception will be thrown