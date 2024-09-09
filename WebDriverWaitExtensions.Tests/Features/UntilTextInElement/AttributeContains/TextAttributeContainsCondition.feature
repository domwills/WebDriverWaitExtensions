Feature: Text AttributeContains Condition
    Wait.UntilTextInElement().AttributeContains(By locator, string attribute, string text, out Condition condition)

    Scenario: AttributeContains(locator, attribute, text, out var condition) will return a Condition if text is present in attribute
        Given the WebElement attribute 'href' has value 'example'
        When I use Wait.UntilTextInElement().AttributeContains(By.Id('id'), 'href', 'exam', out var condition)
        Then the Condition.Result is true and Condition.Error is null

    Scenario: AttributeContains(locator, attribute, text, out var condition) will return a Condition if text is not present in attribute
        Given the WebElement attribute 'href' has value 'example'
        When I use Wait.UntilTextInElement().AttributeContains(By.Id('id'), 'href', 'exan', out var condition)
        Then the Condition.Result is false and Condition.Error contains the following:
            """
            The element attribute 'href' does not contain 'exan'.
            Attribute: 'href'
            Attribute text: 'example'
            Should contain: 'exan'
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

    Scenario: AttributeContains(locator, attribute, text, out var condition) will return a Condition when the WebElement does not exist
        Given the WebElement does not exist
        When I use Wait.UntilTextInElement().AttributeContains(By.Id('id'), 'href', 'exan', out var condition)
        Then the Condition.Result is false and Condition.Error contains the following:
            """
            The element does not exist, 'NoSuchElementException' has been thrown internally.
            Locator Name: 'submitButton'
            Locator: 'By.Id: id'
            """

    Scenario: AttributeContains(locator, attribute, text, out var condition) will return a Condition when element reference is invalid
        Given the WebElement reference is invalid
        When I use Wait.UntilTextInElement().AttributeContains(By.Id('id'), 'href', 'exan', out var condition)
        Then the Condition.Result is false and Condition.Error contains the following:
            """
            The element reference is no longer valid, 'StaleElementReferenceException' has been thrown internally.
            Locator Name: 'submitButton'
            Locator: 'By.Id: id'
            """

    Scenario: AttributeContains(locator, attribute, text, out var condition) throws the unhandled exception if an unhandled exception occurs
        Given an unhandled exception occurs
        When I use Wait.UntilTextInElement().AttributeContains(By.Id('id'), 'href', 'exan', out var condition)
        Then the unhandled exception will be thrown