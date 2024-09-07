﻿Feature: Alert IsSwitchedTo Timeout
    Wait.UntilAlert().IsSwitchedTo(timeout)

    Scenario: AlertIsSwitchedTo(timeout) will return the alert if it is available
        Given the alert is available
        When I use Wait.UntilAlert().IsSwitchedTo(timeout)
        Then the method will return the Alert

    Scenario: AlertIsSwitchedTo(timeout) throws a WebDriverTimeoutException if the frame is not available
        Given the alert is not available
        When I use Wait.UntilAlert().IsSwitchedTo(timeout)
        Then the method will throw a WebDriverTimeoutException
            """
            No alert is available to switch to.
            """

    Scenario: AlertIsSwitchedTo(timeout) throws the unhandled exception if an unhandled exception occurs
        Given an unhandled exception occurs
        When I use Wait.UntilAlert().IsSwitchedTo(timeout)
        Then the unhandled exception will be thrown