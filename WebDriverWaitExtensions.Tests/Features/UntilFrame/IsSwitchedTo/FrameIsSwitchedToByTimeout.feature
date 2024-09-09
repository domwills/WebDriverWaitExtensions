Feature: Frame IsSwitchedTo By Timeout
    Wait.UntilFrame().IsSwitchedTo(By locator, int waitTimeInSeconds)

    Scenario: FrameIsSwitchedTo(locator, timeout) will return the frame if it is available
        Given the frame is available when found using a WebElement
        When I use Wait.UntilFrame().IsSwitchedTo(By.Id('id'), timeout)
        Then the method will return the WebDriver

    Scenario: FrameIsSwitchedTo(locator, timeout) throws a WebDriverTimeoutException if the frame is not available
        Given the frame is not available when found using a WebElement
        When I use Wait.UntilFrame().IsSwitchedTo(By.Id('id'), timeout)
        Then the method will throw a WebDriverTimeoutException
            """
            No frame is available to switch to.
            Locator Name: 'submitButton'
            Locator: 'By.Id: id'

            """

    Scenario: FrameIsSwitchedTo(locator, timeout) throws a WebDriverTimeoutException if element does not exist
        Given the WebElement does not exist
        When I use Wait.UntilFrame().IsSwitchedTo(By.Id('id'), timeout)
        Then the method will throw a WebDriverTimeoutException
            """
            The element does not exist, 'NoSuchElementException' has been thrown internally.
            Locator Name: 'submitButton'
            Locator: 'By.Id: id'

            """

    Scenario: FrameIsSwitchedTo(locator, timeout) throws a WebDriverTimeoutException if element reference is invalid
        Given the WebElement reference is invalid
        When I use Wait.UntilFrame().IsSwitchedTo(By.Id('id'), timeout)
        Then the method will throw a WebDriverTimeoutException
            """
            The element reference is no longer valid, 'StaleElementReferenceException' has been thrown internally.
            Locator Name: 'submitButton'
            Locator: 'By.Id: id'

            """

    Scenario: FrameIsSwitchedTo(locator, timeout) throws the unhandled exception if an unhandled exception occurs
        Given an unhandled exception occurs
        When I use Wait.UntilFrame().IsSwitchedTo(By.Id('id'), timeout)
        Then the unhandled exception will be thrown