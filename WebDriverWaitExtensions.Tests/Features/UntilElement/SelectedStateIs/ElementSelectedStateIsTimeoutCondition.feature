Feature: Element SelectedStateIs Timeout Condition
    Wait.UntilElement().SelectedStateIs(By locator, bool isSelected, int waitTimeInSeconds, out Condition condition)

    Scenario: SelectedStateIs(locator, true, timeout, out var condition) will return a Condition when the WebElement is selected
        Given the WebElement is selected
        When I use Wait.UntilElement().SelectedStateIs(By.Id('id'), 'true', timeout, out var condition)
        Then the Condition.Result is true and Condition.Error is null

    Scenario: SelectedStateIs(locator, false, timeout, out var condition) will return a Condition when the WebElement is not selected
        Given the WebElement is not selected
        When I use Wait.UntilElement().SelectedStateIs(By.Id('id'), 'false', timeout, out var condition)
        Then the Condition.Result is true and Condition.Error is null

    Scenario: SelectedStateIs(locator, true, timeout, out var condition) will return a Condition when the WebElement is not selected
        Given the WebElement is not selected
        When I use Wait.UntilElement().SelectedStateIs(By.Id('id'), 'true', timeout, out var condition)
        Then the Condition.Result is false and Condition.Error contains the following:
            """
            The element selected state is not set to 'True'.
            Locator Name: 'submitButton'
            Locator: 'By.Id: id'
            Displayed: True
            Enabled: True
            Location: {X=2,Y=3}
            Selected: False
            Size: {Width=4, Height=5}
            TagName: div
            Text: 'example text'
            """

    Scenario: SelectedStateIs(locator, false, timeout, out var condition) will return a Condition when the WebElement is selected
        Given the WebElement is selected
        When I use Wait.UntilElement().SelectedStateIs(By.Id('id'), 'false', timeout, out var condition)
        Then the Condition.Result is false and Condition.Error contains the following:
            """
            The element selected state is not set to 'False'.
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

    Scenario: SelectedStateIs(locator, false, timeout, out var condition) will return a Condition if element does not exist
        Given the WebElement does not exist
        When I use Wait.UntilElement().SelectedStateIs(By.Id('id'), 'false', timeout, out var condition)
        Then the Condition.Result is false and Condition.Error contains the following:
            """
            The element does not exist, 'NoSuchElementException' has been thrown internally.
            Locator Name: 'submitButton'
            Locator: 'By.Id: id'
            """

    Scenario: SelectedStateIs(locator, false, timeout, out var condition) will return a Condition if element reference is invalid
        Given the WebElement reference is invalid
        When I use Wait.UntilElement().SelectedStateIs(By.Id('id'), 'false', timeout, out var condition)
        Then the Condition.Result is false and Condition.Error contains the following:
            """
            The element reference is no longer valid, 'StaleElementReferenceException' has been thrown internally.
            Locator Name: 'submitButton'
            Locator: 'By.Id: id'
            """

    Scenario: SelectedStateIs(locator, false, timeout, out var condition) throws the unhandled exception if an unhandled exception occurs
        Given an unhandled exception occurs
        When I use Wait.UntilElement().SelectedStateIs(By.Id('id'), 'false', timeout, out var condition)
        Then the unhandled exception will be thrown