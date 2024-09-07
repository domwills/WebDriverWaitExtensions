Feature: Element AttributeDoesNotExist Condition
    Wait.UntilElement().AttributeDoesNotExist(By locator, string attribute, out Condition condition)

    Scenario: AttributeDoesNotExist(locator, attribute, out var condition) will return a Condition if the attribute does not exist
        Given the WebElement does not have attribute 'disabled'
        When I use Wait.UntilElement().AttributeDoesNotExist(By.Id('id'), 'disabled', out var condition)
        Then the Condition.Result is true and Condition.Error is null

    Scenario: AttributeDoesNotExist(locator, attribute, out var condition) will return a Condition if the attribute exists
        Given the WebElement has attribute 'disabled'
        When I use Wait.UntilElement().AttributeDoesNotExist(By.Id('id'), 'disabled', out var condition)
        Then the Condition.Result is false and Condition.Error contains the following:
            """
            The attribute 'disabled' still exists for the element.
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

    Scenario: AttributeDoesNotExist(locator, attribute, out var condition) will return a Condition when the WebElement does not exist
        Given the WebElement does not exist
        When I use Wait.UntilElement().AttributeDoesNotExist(By.Id('id'), 'disabled', out var condition)
        Then the Condition.Result is false and Condition.Error contains the following:
            """
            The element does not exist, 'NoSuchElementException' has been thrown internally.
            Locator Name: 'submitButton'
            Locator: 'By.Id: id'
            """

    Scenario: AttributeDoesNotExist(locator, attribute, out var condition) will return a Condition when element reference is invalid
        Given the WebElement reference is invalid
        When I use Wait.UntilElement().AttributeDoesNotExist(By.Id('id'), 'disabled', out var condition)
        Then the Condition.Result is false and Condition.Error contains the following:
            """
            The element reference is no longer valid, 'StaleElementReferenceException' has been thrown internally.
            Locator Name: 'submitButton'
            Locator: 'By.Id: id'
            """

    Scenario: AttributeDoesNotExist(locator, attribute, out var condition) throws the unhandled exception if an unhandled exception occurs
        Given an unhandled exception occurs
        When I use Wait.UntilElement().AttributeDoesNotExist(By.Id('id'), 'disabled', out var condition)
        Then the unhandled exception will be thrown