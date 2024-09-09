Feature: Alert IsSwitchedTo Timeout Condition
    Wait.UntilAlert().IsSwitchedTo(timeout, out Condition condition)

    Scenario: AlertIsSwitchedTo(timeout, out var condition) will return a Condition when the alert is available
        Given the alert is available
        When I use Wait.UntilAlert().IsSwitchedTo(timeout, out var condition)
        Then the Condition.Result is true and Condition.Error is null
        And the method will return the Alert

    Scenario: AlertIsSwitchedTo(timeout, out var condition) will return a Condition when the alert is not available
        Given the alert is not available
        When I use Wait.UntilAlert().IsSwitchedTo(timeout, out var condition)
        Then the Condition.Result is false and Condition.Error contains the following:
            """
            No alert is available to switch to.
            """
        And the returned Alert will be null

    Scenario: AlertIsSwitchedTo(timeout, out var condition) throws the unhandled exception if an unhandled exception occurs
        Given an unhandled exception occurs
        When I use Wait.UntilAlert().IsSwitchedTo(timeout, out var condition)
        Then the unhandled exception will be thrown