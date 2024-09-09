﻿Feature: Text AttributeIs Timeout Condition
    Wait.UntilTextInElement().AttributeIs(By locator, string attribute, string text, int waitTimeInSeconds, out Condition condition)

    Scenario: AttributeIs(locator, attribute, text, timeout, out var condition) will return a Condition if text matches attribute text
        Given the WebElement attribute 'href' has value 'example'
        When I use Wait.UntilTextInElement().AttributeIs(By.Id('id'), 'href', 'example', timeout, out var condition)
        Then the Condition.Result is true and Condition.Error is null

    Scenario: AttributeIs(locator, attribute, text, timeout, out var condition) will return a Condition if text does not match attribute text
        Given the WebElement attribute 'href' has value 'example'
        When I use Wait.UntilTextInElement().AttributeIs(By.Id('id'), 'href', 'exam', timeout, out var condition)
        Then the Condition.Result is false and Condition.Error contains the following:
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

    Scenario: AttributeIs(locator, attribute, text, timeout, out var condition) will return a Condition when the WebElement does not exist
        Given the WebElement does not exist
        When I use Wait.UntilTextInElement().AttributeIs(By.Id('id'), 'href', 'exam', timeout, out var condition)
        Then the Condition.Result is false and Condition.Error contains the following:
            """
            The element does not exist, 'NoSuchElementException' has been thrown internally.
            Locator Name: 'submitButton'
            Locator: 'By.Id: id'
            """

    Scenario: AttributeIs(locator, attribute, text, timeout, out var condition) will return a Condition when element reference is invalid
        Given the WebElement reference is invalid
        When I use Wait.UntilTextInElement().AttributeIs(By.Id('id'), 'href', 'exam', timeout, out var condition)
        Then the Condition.Result is false and Condition.Error contains the following:
            """
            The element reference is no longer valid, 'StaleElementReferenceException' has been thrown internally.
            Locator Name: 'submitButton'
            Locator: 'By.Id: id'
            """

    Scenario: AttributeIs(locator, attribute, text, timeout, out var condition) throws the unhandled exception if an unhandled exception occurs
        Given an unhandled exception occurs
        When I use Wait.UntilTextInElement().AttributeIs(By.Id('id'), 'href', 'exam', timeout, out var condition)
        Then the unhandled exception will be thrown