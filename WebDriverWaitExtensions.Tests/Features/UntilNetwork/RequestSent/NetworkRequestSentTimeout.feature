Feature: Network RequestSent Timeout
	Wait.UntilNetwork().RequestSent(string url, Action action, TimeSpan timeout)

	Scenario: RequestSent(url, action, timeout) will wait until the request is sent
		Given the request that is sent will be 'www.github.com'
		When I use Wait.UntilNetwork().RequestSent('www.github.com', action, timeout)
		Then the method will return the NetworkEvent object

	Scenario: RequestSent(url, action, timeout) throws a WebDriverTimeoutException if the request is not sent
		Given the request that is sent will be 'www.github.com/invalid'
		When I use Wait.UntilNetwork().RequestSent('www.github.com', action, timeout)
		Then the method will throw a WebDriverTimeoutException
			"""
			No URL has been found in the list of requests.
			URL: 'www.github.com'

			"""