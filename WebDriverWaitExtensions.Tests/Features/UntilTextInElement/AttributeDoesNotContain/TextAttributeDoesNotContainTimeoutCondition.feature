Feature: Text IsNotPresentInElementAttribute Timeout Condition
    Wait.UntilTextInElement().AttributeDoesNotContain(By locator, string attribute, string text, int waitTimeInSeconds, out Condition condition)

    Scenario: AttributeDoesNotContain(locator, attribute, text, timeout, out var condition) will return a Condition if text is not present in attribute
        Given the WebElement attribute 'href' has value 'example'
        When I use Wait.UntilTextInElement().AttributeDoesNotContain(By.Id('id'), 'href', 'exan', timeout, out var condition)
        Then the Condition.Result is true and Condition.Error is null

    Scenario: AttributeDoesNotContain(locator, attribute, text, timeout, out var condition) will return a Condition if text is present in attribute
        Given the WebElement attribute 'href' has value 'example'
        When I use Wait.UntilTextInElement().AttributeDoesNotContain(By.Id('id'), 'href', 'exam', timeout, out var condition)
        Then the Condition.Result is false and Condition.Error contains the following:
            """
            The element attribute 'href' still contains 'exam'.
            Attribute: 'href'
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

    Scenario: AttributeDoesNotContain(locator, attribute, text, timeout, out var condition) will return a Condition when the WebElement does not exist
        Given the WebElement does not exist
        When I use Wait.UntilTextInElement().AttributeDoesNotContain(By.Id('id'), 'href', 'exam', timeout, out var condition)
        Then the Condition.Result is false and Condition.Error contains the following:
            """
            The element does not exist, 'NoSuchElementException' has been thrown internally.
            Locator Name: 'submitButton'
            Locator: 'By.Id: id'
            """

    Scenario: AttributeDoesNotContain(locator, attribute, text, timeout, out var condition) will return a Condition when element reference is invalid
        Given the WebElement reference is invalid
        When I use Wait.UntilTextInElement().AttributeDoesNotContain(By.Id('id'), 'href', 'exam', timeout, out var condition)
        Then the Condition.Result is false and Condition.Error contains the following:
            """
            The element reference is no longer valid, 'StaleElementReferenceException' has been thrown internally.
            Locator Name: 'submitButton'
            Locator: 'By.Id: id'
            """

    Scenario: AttributeDoesNotContain(locator, attribute, text, timeout, out var condition) throws the unhandled exception if an unhandled exception occurs
        Given an unhandled exception occurs
        When I use Wait.UntilTextInElement().AttributeDoesNotContain(By.Id('id'), 'href', 'exam', timeout, out var condition)
        Then the unhandled exception will be thrown