Feature: Element StopsMoving Condition
    Wait.UntilElement().StopsMoving(By locator, out Condition condition)

    Scenario: StopsMoving(locator, out var condition) will return a Condition when the WebElement stops moving
        Given the WebElement has stopped moving
        When I use Wait.UntilElement().StopsMoving(By.Id('id'), out var condition)
        Then the Condition.Result is true and Condition.Error is null

    Scenario: StopsMoving(locator, out var condition) will return a Condition when the WebElement has stopped moving
        Given the WebElement keeps moving
        When I use Wait.UntilElement().StopsMoving(By.Id('id'), out var condition)
        Then the Condition.Result is false and Condition.Error contains the following:
            """
            The element has not stopped moving.
            First location: {X=1,Y=2}
            Second location: {X=3,Y=4}
            Locator Name: 'submitButton'
            Locator: 'By.Id: id'
            Displayed: True
            Enabled: True
            Location: {X=5,Y=6}
            Selected: True
            Size: {Width=4, Height=5}
            TagName: div
            Text: 'example text'
            """

    Scenario: StopsMoving(locator, out var condition) will return a Condition if element does not exist
        Given the WebElement does not exist
        When I use Wait.UntilElement().StopsMoving(By.Id('id'), out var condition)
        Then the Condition.Result is false and Condition.Error contains the following:
            """
            The element does not exist, 'NoSuchElementException' has been thrown internally.
            Locator Name: 'submitButton'
            Locator: 'By.Id: id'
            """

    Scenario: StopsMoving(locator, out var condition) will return a Condition if element reference is invalid
        Given the WebElement reference is invalid
        When I use Wait.UntilElement().StopsMoving(By.Id('id'), out var condition)
        Then the Condition.Result is false and Condition.Error contains the following:
            """
            The element reference is no longer valid, 'StaleElementReferenceException' has been thrown internally.
            Locator Name: 'submitButton'
            Locator: 'By.Id: id'
            """

    Scenario: StopsMoving(locator, out var condition) throws the unhandled exception if an unhandled exception occurs
        Given an unhandled exception occurs
        When I use Wait.UntilElement().StopsMoving(By.Id('id'), out var condition)
        Then the unhandled exception will be thrown