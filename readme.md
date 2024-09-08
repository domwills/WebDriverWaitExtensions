# WebDriverWait Extensions

## About

WebDriverWait Extensions is a C# library that provides extension methods for the WebDriverWait class in Selenium WebDriver. It is designed to simplify the process of waiting for certain conditions to be met in a web page when automating browser interactions.

There has been a lot of focus on the returned error messages when the condition isn't met which will even include the name of the parameter. This is especially helpful when using the page object model.

```csharp
var signUpButton = By.Id("sign-up");
var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
wait.UntilElement().IsVisible(signUpButton);
```
In the above example the element was found but was not visible which returned the follow error:
```
Locator Name: 'signUpButton'
Locator: 'By.Id: sign-up']'
Displayed: False
Enabled: True
Location: {X=90,Y=110}
Selected: False
Size: {Width=211, Height=66}
TagName: a
Text: ''
```
You can use the 'out' keyword to return a `Condition` object which will contain the condition result and will contain the error if one occured. This allows you to use these wait conditions as asserts.

If we had a method to determine an element was visible which we use in an assert, and wanted to ensure we have a wait to give it enough time to become visible, we have an issue where it'll always return true otherwise it'll throw an exception.
Using the `Condition` object we can suppress the exception and allow the condition to run and return the result.
```csharp
wait.UntilElement().IsVisible(signUpButton, out var condition);
Assert.That(condition.Result, Is.True, condition.Error);
```

## Features

The library provides the following features:

- [Alert Conditions](https://github.com/domwills/WebDriverWaitExtensions/wiki/UntilAlert()): Methods for handling alert conditions.
- [Element Conditions](https://github.com/domwills/WebDriverWaitExtensions/wiki/UntilElement()): Methods for handling element conditions.
- [Frame Conditions](https://github.com/domwills/WebDriverWaitExtensions/wiki/UntilFrame()): Methods for handling frame conditions.
- [Text in Element Conditions](https://github.com/domwills/WebDriverWaitExtensions/wiki/UntilTextInElement()): Methods for handling text in element conditions.
- [Title Conditions](https://github.com/domwills/WebDriverWaitExtensions/wiki/UntilTitle()): Methods for handling title conditions.
- [URL Conditions](https://github.com/domwills/WebDriverWaitExtensions/wiki/UntilUrl()): Methods for handling URL conditions.

## More Documentation
For more detailed documentation, please visit the [wiki](https://github.com/domwills/WebDriverWaitExtensions/wiki).

## Donate
If you find this project useful and would like to support its development, please consider making a donation. 
Your contributions help to improve and maintain the project.  
[Donate via PayPal](https://paypal.me/expectedresult)