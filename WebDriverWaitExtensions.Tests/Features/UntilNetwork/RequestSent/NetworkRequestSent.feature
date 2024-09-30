Feature: Network RequestSent
	Wait.UntilNetwork().RequestSent(string url, Action action)

	Scenario: RequestSent(url, action) will wait until the request is sent
		Given the request that is sent will be 'www.github.com'
		When I use Wait.UntilNetwork().RequestSent('www.github.com', action)
		Then the method will not throw an exception

	Scenario: RequestSent(url, action) throws a WebDriverTimeoutException if the request is not sent
		Given the request that is sent will be 'www.github.com/invalid'
		When I use Wait.UntilNetwork().RequestSent('www.github.com', action)
		Then the method will throw a WebDriverTimeoutException
			"""
			No URL has been found in the list of requests.
			URL: 'www.github.com'

			"""