Feature: Element IsClickable Timeout
    Wait.UntilElement().IsClickable(By locator, int waitTimeInSeconds)

    Scenario: IsClickable(locator, timeout) will return the WebElement if it is visible and enabled
        Given the WebElement is visible
        And the WebElement is enabled
        When I use Wait.UntilElement().IsClickable(By.Id('id'), timeout)
        Then the method will return the WebElement

    Scenario: IsClickable(locator, timeout) throws a WebDriverTimeoutException if element is not visible but is enabled
        Given the WebElement is enabled
        And the WebElement is not visible
        When I use Wait.UntilElement().IsClickable(By.Id('id'), timeout)
        Then the method will throw a WebDriverTimeoutException
            """
            The element is not clickable as it's not visible.
            Locator Name: 'submitButton'
            Locator: 'By.Id: id'
            Displayed: False
            Enabled: True
            Location: {X=2,Y=3}
            Selected: True
            Size: {Width=4, Height=5}
            TagName: div
            Text: 'example text'

            """

    Scenario: IsClickable(locator, timeout) throws a WebDriverTimeoutException if element is visible but not enabled
        Given the WebElement is visible
        And the WebElement is not enabled
        When I use Wait.UntilElement().IsClickable(By.Id('id'), timeout)
        Then the method will throw a WebDriverTimeoutException
            """
            The element is not clickable as it's not enabled.
            Locator Name: 'submitButton'
            Locator: 'By.Id: id'
            Displayed: True
            Enabled: False
            Location: {X=2,Y=3}
            Selected: True
            Size: {Width=4, Height=5}
            TagName: div
            Text: 'example text'

            """

    Scenario: IsClickable(locator, timeout) throws a WebDriverTimeoutException if element is not visible and not enabled
        Given the WebElement is not visible
        And the WebElement is not enabled
        When I use Wait.UntilElement().IsClickable(By.Id('id'), timeout)
        Then the method will throw a WebDriverTimeoutException
            """
            The element is not clickable as it's not visible and not enabled.
            Locator Name: 'submitButton'
            Locator: 'By.Id: id'
            Displayed: False
            Enabled: False
            Location: {X=2,Y=3}
            Selected: True
            Size: {Width=4, Height=5}
            TagName: div
            Text: 'example text'

            """

    Scenario: IsClickable(locator, timeout) throws a WebDriverTimeoutException if element does not exist
        Given the WebElement does not exist
        When I use Wait.UntilElement().IsClickable(By.Id('id'), timeout)
        Then the method will throw a WebDriverTimeoutException
            """
            The element does not exist, 'NoSuchElementException' has been thrown internally.
            Locator Name: 'submitButton'
            Locator: 'By.Id: id'

            """

    Scenario: IsClickable(locator, timeout) throws a WebDriverTimeoutException if element reference is invalid
        Given the WebElement reference is invalid
        When I use Wait.UntilElement().IsClickable(By.Id('id'), timeout)
        Then the method will throw a WebDriverTimeoutException
            """
            The element reference is no longer valid, 'StaleElementReferenceException' has been thrown internally.
            Locator Name: 'submitButton'
            Locator: 'By.Id: id'

            """

    Scenario: IsClickable(locator, timeout) throws the unhandled exception if an unhandled exception occurs
        Given an unhandled exception occurs
        When I use Wait.UntilElement().IsClickable(By.Id('id'), timeout)
        Then the unhandled exception will be thrown