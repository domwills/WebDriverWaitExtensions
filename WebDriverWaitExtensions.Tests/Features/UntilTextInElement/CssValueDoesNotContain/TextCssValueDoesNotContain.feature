﻿Feature: Text CssValueDoesNotContain
    Wait.UntilTextInElement().CssValueDoesNotContain(By locator, string cssValue, string text)

    Scenario: CssValueDoesNotContain(locator, attribute, text) will return the WebElement if text is not present in cssValue
        Given the WebElement cssValue 'style' has value 'example'
        When I use Wait.UntilTextInElement().CssValueDoesNotContain(By.Id('id'), 'style', 'exan')
        Then the method will return the WebElement

    Scenario: CssValueDoesNotContain(locator, attribute, text) throws a WebDriverTimeoutException if text is present in cssValue
        Given the WebElement cssValue 'style' has value 'example'
        When I use Wait.UntilTextInElement().CssValueDoesNotContain(By.Id('id'), 'style', 'exam')
        Then the method will throw a WebDriverTimeoutException
            """
            The element CSS value 'style' still contains 'exam'.
            CSS value: 'style'
            CSS value text: 'example'
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

    Scenario: CssValueDoesNotContain(locator, attribute, text) throws a WebDriverTimeoutException if element does not exist
        Given the WebElement does not exist
        When I use Wait.UntilTextInElement().CssValueDoesNotContain(By.Id('id'), 'style', 'exam')
        Then the method will throw a WebDriverTimeoutException
            """
            The element does not exist, 'NoSuchElementException' has been thrown internally.
            Locator Name: 'submitButton'
            Locator: 'By.Id: id'

            """

    Scenario: CssValueDoesNotContain(locator, attribute, text) throws a WebDriverTimeoutException if element reference is invalid
        Given the WebElement reference is invalid
        When I use Wait.UntilTextInElement().CssValueDoesNotContain(By.Id('id'), 'style', 'exam')
        Then the method will throw a WebDriverTimeoutException
            """
            The element reference is no longer valid, 'StaleElementReferenceException' has been thrown internally.
            Locator Name: 'submitButton'
            Locator: 'By.Id: id'

            """

    Scenario: CssValueDoesNotContain(locator, attribute, text) throws the unhandled exception if an unhandled exception occurs
        Given an unhandled exception occurs
        When I use Wait.UntilTextInElement().CssValueDoesNotContain(By.Id('id'), 'style', 'exam')
        Then the unhandled exception will be thrown