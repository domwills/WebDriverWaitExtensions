﻿Feature: Frame IsSwitchedTo String Condition
    Wait.UntilFrame().IsSwitchedTo(string frameLocator, out Condition condition)

    Scenario: FrameIsSwitchedTo(frameLocator, out var condition) will return a Condition when the frame has been switched to
        Given the frame is available when found using a string
        When I use Wait.UntilFrame().IsSwitchedTo('id', out var condition)
        Then the Condition.Result is true and Condition.Error is null

    Scenario: FrameIsSwitchedTo(frameLocator, out var condition) will return a Condition when the frame has not been switched to
        Given the frame is not available when found using a string
        When I use Wait.UntilFrame().IsSwitchedTo('id', out var condition)
        Then the Condition.Result is false and Condition.Error contains the following:
            """
            No frame is available to switch to.
            Frame locator: 'id'
            """

    Scenario: FrameIsSwitchedTo(frameLocator, out var condition) throws the unhandled exception if an unhandled exception occurs
        Given an unhandled exception occurs
        When I use Wait.UntilFrame().IsSwitchedTo('id', out var condition)
        Then the unhandled exception will be thrown