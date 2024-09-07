Feature: Frame IsSwitchedTo By Condition
    Wait.UntilFrame().IsSwitchedTo(By locator, out Condition condition)

    Scenario: FrameIsSwitchedTo(locator, out var condition) will return a Condition when the frame has been switched to
        Given the frame is available when found using a WebElement
        When I use Wait.UntilFrame().IsSwitchedTo(By.Id('id'), out var condition)
        Then the Condition.Result is true and Condition.Error is null

    Scenario: FrameIsSwitchedTo(locator, out var condition) will return a Condition when the frame has not been switched to
        Given the frame is not available when found using a WebElement
        When I use Wait.UntilFrame().IsSwitchedTo(By.Id('id'), out var condition)
        Then the Condition.Result is false and Condition.Error contains the following:
            """
            No frame is available to switch to.
            Locator Name: 'submitButton'
            Locator: 'By.Id: id'
            """

    Scenario: FrameIsSwitchedTo(locator, out var condition) will return a Condition when the WebElement does not exist
        Given the WebElement does not exist
        When I use Wait.UntilFrame().IsSwitchedTo(By.Id('id'), out var condition)
        Then the Condition.Result is false and Condition.Error contains the following:
            """
            The element does not exist, 'NoSuchElementException' has been thrown internally.
            Locator Name: 'submitButton'
            Locator: 'By.Id: id'
            """

    Scenario: FrameIsSwitchedTo(locator, out var condition) will return a Condition when element reference is invalid
        Given the WebElement reference is invalid
        When I use Wait.UntilFrame().IsSwitchedTo(By.Id('id'), out var condition)
        Then the Condition.Result is false and Condition.Error contains the following:
            """
            The element reference is no longer valid, 'StaleElementReferenceException' has been thrown internally.
            Locator Name: 'submitButton'
            Locator: 'By.Id: id'
            """

    Scenario: FrameIsSwitchedTo(locator, out var condition) throws the unhandled exception if an unhandled exception occurs
        Given an unhandled exception occurs
        When I use Wait.UntilFrame().IsSwitchedTo(By.Id('id'), out var condition)
        Then the unhandled exception will be thrown