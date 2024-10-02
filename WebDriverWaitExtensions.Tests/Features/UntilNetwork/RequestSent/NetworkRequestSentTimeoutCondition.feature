Feature: Network RequestSent Timeout Condition
	Wait.UntilNetwork().RequestSent(string url, Action action, TimeSpan timeout, out Condition condition)

	Scenario: RequestSent(url, action, timeout, out var condition) will out a Condition when the request is sent
		Given the request that is sent will be 'www.github.com'
		When I use Wait.UntilNetwork().RequestSent('www.github.com', action, timeout, out var condition)
		Then the method will return the NetworkEvent object
		And the Condition.Result is true and Condition.Error is null

	Scenario: RequestSent(url, action, timeout, out var condition) will out a Condition if the request is not sent
		Given the request that is sent will be 'www.github.com/invalid'
		When I use Wait.UntilNetwork().RequestSent('www.github.com', action, timeout, out var condition)
		Then the returned NetworkEvent object will be null
		And the Condition.Result is false and Condition.Error contains the following:
			"""
			No URL has been found in the list of requests.
			URL: 'www.github.com'
			"""