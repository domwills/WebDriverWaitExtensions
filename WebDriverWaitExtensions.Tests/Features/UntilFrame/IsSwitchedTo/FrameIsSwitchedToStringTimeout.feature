Feature: Frame IsSwitchedTo String Timeout
    Wait.UntilFrame().FrameToBeAvailableAndSwitchToIt(string frameLocator, int waitTimeInSeconds)

    Scenario: FrameIsSwitchedTo(frameLocator, timeout) will return the frame if it is available
        Given the frame is available when found using a string
        When I use Wait.UntilFrame().IsSwitchedTo('id', timeout)
        Then the method will return the WebDriver

    Scenario: FrameIsSwitchedTo(frameLocator, timeout) throws a WebDriverTimeoutException if the frame is not available
        Given the frame is not available when found using a string
        When I use Wait.UntilFrame().IsSwitchedTo('id', timeout)
        Then the method will throw a WebDriverTimeoutException
            """
            No frame is available to switch to.
            Frame locator: 'id'

            """

    Scenario: FrameIsSwitchedTo(frameLocator, timeout) throws the unhandled exception if an unhandled exception occurs
        Given an unhandled exception occurs
        When I use Wait.UntilFrame().IsSwitchedTo('id', timeout)
        Then the unhandled exception will be thrown