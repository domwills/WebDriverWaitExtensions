﻿Feature: Text Contains Timeout
    Wait.UntilTextInElement().Contains(By locator, string text, int waitTimeInSeconds, out Condition condition)

    Scenario: Contains(locator, text, timeout) will return the WebElement if text is present
        Given the WebElement text value is 'example'
        When I use Wait.UntilTextInElement().Contains(By.Id('id'), 'exam', timeout)
        Then the method will return the WebElement

    Scenario: Contains(locator, text, timeout) throws a WebDriverTimeoutException if text is not present
        Given the WebElement text value is 'example'
        When I use Wait.UntilTextInElement().Contains(By.Id('id'), 'exan', timeout)
        Then the method will throw a WebDriverTimeoutException
            """
            The element text does not contain 'exan'.
            Element text: 'example'
            Should contain: 'exan'
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

    Scenario: Contains(locator, text, timeout) throws a WebDriverTimeoutException if element does not exist
        Given the WebElement does not exist
        When I use Wait.UntilTextInElement().Contains(By.Id('id'), 'exan', timeout)
        Then the method will throw a WebDriverTimeoutException
            """
            The element does not exist, 'NoSuchElementException' has been thrown internally.
            Locator Name: 'submitButton'
            Locator: 'By.Id: id'

            """

    Scenario: Contains(locator, text, timeout) throws a WebDriverTimeoutException if element reference is invalid
        Given the WebElement reference is invalid
        When I use Wait.UntilTextInElement().Contains(By.Id('id'), 'exan', timeout)
        Then the method will throw a WebDriverTimeoutException
            """
            The element reference is no longer valid, 'StaleElementReferenceException' has been thrown internally.
            Locator Name: 'submitButton'
            Locator: 'By.Id: id'

            """

    Scenario: Contains(locator, text, timeout) throws the unhandled exception if an unhandled exception occurs
        Given an unhandled exception occurs
        When I use Wait.UntilTextInElement().Contains(By.Id('id'), 'exan', timeout)
        Then the unhandled exception will be thrown