using System;
using System.Runtime.CompilerServices;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using WebDriverWaitExtensions.ExpectedConditions;

namespace WebDriverWaitExtensions.Until;

/// <summary>
/// Contains methods for handling element conditions.
/// </summary>
public class UntilElement
{
    private readonly WebDriverWait _wait;

    /// <summary>
    /// Initializes a new instance of the <see cref="UntilElement"/> class.
    /// </summary>
    /// <param name="wait">The WebDriverWait instance to be used for waiting for conditions.</param>
    public UntilElement(WebDriverWait wait)
    {
        _wait = wait;
    }

    private IWebElement Exists(By locator, TimeSpan? timeout, out Condition condition, bool throwOnException, string name)
    {
        Utilities.SetTimeout(_wait, timeout, out var originalTimeout);
        condition = new Condition();

        try
        {
            var element = _wait.Until(ElementConditions.Exists(locator, name));

            condition.Result = true;
            condition.Error = null;

            return element;
        }
        catch (WebDriverTimeoutException ex)
        {
            Utilities.HandleException(ElementConditions.ErrorMessage.Value, ex, throwOnException, out condition);
        }
        finally
        {
            Utilities.ResetTimeout(_wait, timeout, originalTimeout);
        }

        return null;
    }

    /// <summary>
    /// An expectation for checking that an element is present on the DOM of a page. This does not necessarily mean that the element is visible.
    /// </summary>
    /// <param name="locator">The locator used to find the element.</param>
    /// <param name="name">The name of the locator, used for better error messages. Shouldn't be provided as it's generated automatically.</param>
    /// <returns>The <see cref="IWebElement"/> once it is located.</returns>
    public IWebElement Exists(By locator, [CallerArgumentExpression("locator")] string name = null)
    {
        return Exists(locator, null, out _, true, name);
    }

    /// <summary>
    /// An expectation for checking that an element is present on the DOM of a page. This does not necessarily mean that the element is visible.
    /// </summary>
    /// <param name="locator">The locator used to find the element.</param>
    /// <param name="timeout">The time to wait for the condition to be successful.</param>
    /// <param name="name">The name of the locator, used for better error messages. Shouldn't be provided as it's generated automatically.</param>
    /// <returns>The <see cref="IWebElement"/> once it is located.</returns>
    public IWebElement Exists(By locator, TimeSpan timeout, [CallerArgumentExpression("locator")] string name = null)
    {
        return Exists(locator, timeout, out _, true, name);
    }

    /// <summary>
    /// An expectation for checking that an element is present on the DOM of a page. This does not necessarily mean that the element is visible.
    /// </summary>
    /// <param name="locator">The locator used to find the element.</param>
    /// <param name="condition">Out parameter that returns a <see cref="Condition"/> object indicating the result of the condition.</param>
    /// <param name="name">The name of the locator, used for better error messages. Shouldn't be provided as it's generated automatically.</param>
    /// <returns>The <see cref="IWebElement"/> once it is located, otherwise null.</returns>
    public IWebElement Exists(By locator, out Condition condition, [CallerArgumentExpression("locator")] string name = null)
    {
        return Exists(locator, null, out condition, false, name);
    }

    /// <summary>
    /// An expectation for checking that an element is present on the DOM of a page. This does not necessarily mean that the element is visible.
    /// </summary>
    /// <param name="locator">The locator used to find the element.</param>
    /// <param name="timeout">The time to wait for the condition to be successful.</param>
    /// <param name="condition">Out parameter that returns a <see cref="Condition"/> object indicating the result of the condition.</param>
    /// <param name="name">The name of the locator, used for better error messages. Shouldn't be provided as it's generated automatically.</param>
    /// <returns>The <see cref="IWebElement"/> once it is located, otherwise null.</returns>
    public IWebElement Exists(By locator, TimeSpan timeout, out Condition condition, [CallerArgumentExpression("locator")] string name = null)
    {
        return Exists(locator, timeout, out condition, false, name);
    }

    private void DoesNotExist(By locator, TimeSpan? timeout, out Condition condition, bool throwOnException, string name)
    {
        Utilities.SetTimeout(_wait, timeout, out var originalTimeout);
        condition = new Condition();

        try
        {
            _wait.Until(ElementConditions.DoesNotExist(locator, name));

            condition.Result = true;
            condition.Error = null;
        }
        catch (WebDriverTimeoutException ex)
        {
            Utilities.HandleException(ElementConditions.ErrorMessage.Value, ex, throwOnException, out condition);
        }
        finally
        {
            Utilities.ResetTimeout(_wait, timeout, originalTimeout);
        }
    }

    /// <summary>
    /// An expectation for checking that an element is not present on the DOM of a
    /// page.
    /// </summary>
    /// <param name="locator">The locator used to find the element.</param>
    /// <param name="name">The name of the locator, used for better error messages. Shouldn't be provided as it's generated automatically.</param>
    public void DoesNotExist(By locator, [CallerArgumentExpression("locator")] string name = null)
    {
        DoesNotExist(locator, null, out _, true, name);
    }

    /// <summary>
    /// An expectation for checking that an element is not present on the DOM of a
    /// page.
    /// </summary>
    /// <param name="locator">The locator used to find the element.</param>
    /// <param name="timeout">The time to wait for the condition to be successful.</param>
    /// <param name="name">The name of the locator, used for better error messages. Shouldn't be provided as it's generated automatically.</param>
    public void DoesNotExist(By locator, TimeSpan timeout, [CallerArgumentExpression("locator")] string name = null)
    {
        DoesNotExist(locator, timeout, out _, true, name);
    }

    /// <summary>
    /// An expectation for checking that an element is not present on the DOM of a
    /// page.
    /// </summary>
    /// <param name="locator">The locator used to find the element.</param>
    /// <param name="condition">Out parameter that returns a <see cref="Condition"/> object indicating the result of the condition.</param>
    /// <param name="name">The name of the locator, used for better error messages. Shouldn't be provided as it's generated automatically.</param>
    public void DoesNotExist(By locator, out Condition condition, [CallerArgumentExpression("locator")] string name = null)
    {
        DoesNotExist(locator, null, out condition, false, name);
    }

    /// <summary>
    /// An expectation for checking that an element is not present on the DOM of a
    /// page.
    /// </summary>
    /// <param name="locator">The locator used to find the element.</param>
    /// <param name="timeout">The time to wait for the condition to be successful.</param>
    /// <param name="condition">Out parameter that returns a <see cref="Condition"/> object indicating the result of the condition.</param>
    /// <param name="name">The name of the locator, used for better error messages. Shouldn't be provided as it's generated automatically.</param>
    public void DoesNotExist(By locator, TimeSpan timeout, out Condition condition, [CallerArgumentExpression("locator")] string name = null)
    {
        DoesNotExist(locator, timeout, out condition, false, name);
    }

    private IWebElement IsVisible(By locator, TimeSpan? timeout, out Condition condition, bool throwOnException, string name)
    {
        Utilities.SetTimeout(_wait, timeout, out var originalTimeout);
        condition = new Condition();

        try
        {
            var element = _wait.Until(ElementConditions.IsVisible(locator, name));

            condition.Result = true;
            condition.Error = null;

            return element;
        }
        catch (WebDriverTimeoutException ex)
        {
            Utilities.HandleException(ElementConditions.ErrorMessage.Value, ex, throwOnException, out condition);
        }
        finally
        {
            Utilities.ResetTimeout(_wait, timeout, originalTimeout);
        }

        return null;
    }

    /// <summary>
    /// An expectation for checking that an element is present on the DOM of a page
    /// and visible. Visibility means that the element is not only displayed but
    /// also has a height and width that is greater than 0.
    /// </summary>
    /// <param name="locator">The locator used to find the element.</param>
    /// <param name="name">The name of the locator, used for better error messages. Shouldn't be provided as it's generated automatically.</param>
    /// <returns>The <see cref="IWebElement"/> once it is located and visible.</returns>
    public IWebElement IsVisible(By locator, [CallerArgumentExpression("locator")] string name = null)
    {
        return IsVisible(locator, null, out _, true, name);
    }

    /// <summary>
    /// An expectation for checking that an element is present on the DOM of a page
    /// and visible. Visibility means that the element is not only displayed but
    /// also has a height and width that is greater than 0.
    /// </summary>
    /// <param name="locator">The locator used to find the element.</param>
    /// <param name="condition">Out parameter that returns a <see cref="Condition"/> object indicating the result of the condition.</param>
    /// <param name="name">The name of the locator, used for better error messages. Shouldn't be provided as it's generated automatically.</param>
    /// <returns>The <see cref="IWebElement"/> once it is located and visible, otherwise null.</returns>
    public IWebElement IsVisible(By locator, out Condition condition, [CallerArgumentExpression("locator")] string name = null)
    {
        return IsVisible(locator, null, out condition, false, name);
    }

    /// <summary>
    /// An expectation for checking that an element is present on the DOM of a page
    /// and visible. Visibility means that the element is not only displayed but
    /// also has a height and width that is greater than 0.
    /// </summary>
    /// <param name="locator">The locator used to find the element.</param>
    /// <param name="timeout">The time to wait for the condition to be successful.</param>
    /// <param name="name">The name of the locator, used for better error messages. Shouldn't be provided as it's generated automatically.</param>
    /// <returns>The <see cref="IWebElement"/> once it is located and visible.</returns>
    public IWebElement IsVisible(By locator, TimeSpan timeout, [CallerArgumentExpression("locator")] string name = null)
    {
        return IsVisible(locator, timeout, out _, true, name);
    }

    /// <summary>
    /// An expectation for checking that an element is present on the DOM of a page
    /// and visible. Visibility means that the element is not only displayed but
    /// also has a height and width that is greater than 0.
    /// </summary>
    /// <param name="locator">The locator used to find the element.</param>
    /// <param name="timeout">The time to wait for the condition to be successful.</param>
    /// <param name="condition">Out parameter that returns a <see cref="Condition"/> object indicating the result of the condition.</param>
    /// <param name="name">The name of the locator, used for better error messages. Shouldn't be provided as it's generated automatically.</param>
    /// <returns>The <see cref="IWebElement"/> once it is located and visible, otherwise null.</returns>
    public IWebElement IsVisible(By locator, TimeSpan timeout, out Condition condition, [CallerArgumentExpression("locator")] string name = null)
    {
        return IsVisible(locator, timeout, out condition, false, name);
    }

    private IWebElement IsNotVisible(By locator, TimeSpan? timeout, out Condition condition, bool throwOnException, string name)
    {
        Utilities.SetTimeout(_wait, timeout, out var originalTimeout);
        condition = new Condition();

        try
        {
            var element = _wait.Until(ElementConditions.IsNotVisible(locator, name));

            condition.Result = true;
            condition.Error = null;

            return element;
        }
        catch (WebDriverTimeoutException ex)
        {
            Utilities.HandleException(ElementConditions.ErrorMessage.Value, ex, throwOnException, out condition);
        }
        finally
        {
            Utilities.ResetTimeout(_wait, timeout, originalTimeout);
        }

        return null;
    }

    /// <summary>
    /// An expectation for checking that an element is either invisible or not present on the DOM.
    /// </summary>
    /// <param name="locator">The locator used to find the element.</param>
    /// <param name="name">The name of the locator, used for better error messages. Shouldn't be provided as it's generated automatically.</param>
    /// <returns>The <see cref="IWebElement"/> once it is located and visible.</returns>
    public IWebElement IsNotVisible(By locator, [CallerArgumentExpression("locator")] string name = null)
    {
        return IsNotVisible(locator, null, out _, true, name);
    }

    /// <summary>
    /// An expectation for checking that an element is either invisible or not present on the DOM.
    /// </summary>
    /// <param name="locator">The locator used to find the element.</param>
    /// <param name="timeout">The time to wait for the condition to be successful.</param>
    /// <param name="name">The name of the locator, used for better error messages. Shouldn't be provided as it's generated automatically.</param>
    /// <returns>The <see cref="IWebElement"/> once it is located and visible.</returns>
    public IWebElement IsNotVisible(By locator, TimeSpan timeout, [CallerArgumentExpression("locator")] string name = null)
    {
        return IsNotVisible(locator, timeout, out _, true, name);
    }

    /// <summary>
    /// An expectation for checking that an element is either invisible or not present on the DOM.
    /// </summary>
    /// <param name="locator">The locator used to find the element.</param>
    /// <param name="condition">Out parameter that returns a <see cref="Condition"/> object indicating the result of the condition.</param>
    /// <param name="name">The name of the locator, used for better error messages. Shouldn't be provided as it's generated automatically.</param>
    /// <returns>The <see cref="IWebElement"/> once it is located and visible, otherwise null.</returns>
    public IWebElement IsNotVisible(By locator, out Condition condition, [CallerArgumentExpression("locator")] string name = null)
    {
        return IsNotVisible(locator, null, out condition, false, name);
    }

    /// <summary>
    /// An expectation for checking that an element is either invisible or not present on the DOM.
    /// </summary>
    /// <param name="locator">The locator used to find the element.</param>
    /// <param name="timeout">The time to wait for the condition to be successful.</param>
    /// <param name="condition">Out parameter that returns a <see cref="Condition"/> object indicating the result of the condition.</param>
    /// <param name="name">The name of the locator, used for better error messages. Shouldn't be provided as it's generated automatically.</param>
    /// <returns>The <see cref="IWebElement"/> once it is located and visible, otherwise null.</returns>
    public IWebElement IsNotVisible(By locator, TimeSpan timeout, out Condition condition, [CallerArgumentExpression("locator")] string name = null)
    {
        return IsNotVisible(locator, timeout, out condition, false, name);
    }

    private IWebElement IsClickable(By locator, TimeSpan? timeout, out Condition condition, bool throwOnException, string name)
    {
        Utilities.SetTimeout(_wait, timeout, out var originalTimeout);
        condition = new Condition();

        try
        {
            var element = _wait.Until(ElementConditions.IsClickable(locator, name));

            condition.Result = true;
            condition.Error = null;

            return element;
        }
        catch (WebDriverTimeoutException ex)
        {
            Utilities.HandleException(ElementConditions.ErrorMessage.Value, ex, throwOnException, out condition);
        }
        finally
        {
            Utilities.ResetTimeout(_wait, timeout, originalTimeout);
        }

        return null;
    }

    /// <summary>
    /// An expectation for checking an element is visible and enabled such that you
    /// can click it.
    /// </summary>
    /// <param name="locator">The locator used to find the element.</param>
    /// <param name="name">The name of the locator, used for better error messages. Shouldn't be provided as it's generated automatically.</param>
    /// <returns>The <see cref="IWebElement"/> once it is located and clickable (visible and enabled).</returns>
    public IWebElement IsClickable(By locator, [CallerArgumentExpression("locator")] string name = null)
    {
        return IsClickable(locator, null, out _, true, name);
    }

    /// <summary>
    /// An expectation for checking an element is visible and enabled such that you
    /// can click it.
    /// </summary>
    /// <param name="locator">The locator used to find the element.</param>
    /// <param name="condition">Out parameter that returns a <see cref="Condition"/> object indicating the result of the condition.</param>
    /// <param name="name">The name of the locator, used for better error messages. Shouldn't be provided as it's generated automatically.</param>
    /// <returns>The <see cref="IWebElement"/> once it is located and clickable (visible and enabled), otherwise null.</returns>
    public IWebElement IsClickable(By locator, out Condition condition, [CallerArgumentExpression("locator")] string name = null)
    {
        return IsClickable(locator, null, out condition, false, name);
    }

    /// <summary>
    /// An expectation for checking an element is visible and enabled such that you
    /// can click it.
    /// </summary>
    /// <param name="locator">The locator used to find the element.</param>
    /// <param name="timeout">The time to wait for the condition to be successful.</param>
    /// <param name="name">The name of the locator, used for better error messages. Shouldn't be provided as it's generated automatically.</param>
    /// <returns>The <see cref="IWebElement"/> once it is located and clickable (visible and enabled).</returns>
    public IWebElement IsClickable(By locator, TimeSpan timeout, [CallerArgumentExpression("locator")] string name = null)
    {
        return IsClickable(locator, timeout, out _, true, name);
    }

    /// <summary>
    /// An expectation for checking an element is visible and enabled such that you
    /// can click it.
    /// </summary>
    /// <param name="locator">The locator used to find the element.</param>
    /// <param name="timeout">The time to wait for the condition to be successful.</param>
    /// <param name="condition">Out parameter that returns a <see cref="Condition"/> object indicating the result of the condition.</param>
    /// <param name="name">The name of the locator, used for better error messages. Shouldn't be provided as it's generated automatically.</param>
    /// <returns>The <see cref="IWebElement"/> once it is located and clickable (visible and enabled), otherwise null.</returns>
    public IWebElement IsClickable(By locator, TimeSpan timeout, out Condition condition, [CallerArgumentExpression("locator")] string name = null)
    {
        return IsClickable(locator, timeout, out condition, false, name);
    }

    private IWebElement IsSelected(By locator, TimeSpan? timeout, out Condition condition, bool throwOnException, string name)
    {
        Utilities.SetTimeout(_wait, timeout, out var originalTimeout);
        condition = new Condition();

        try
        {
            var element = _wait.Until(ElementConditions.IsSelected(locator, name));

            condition.Result = true;
            condition.Error = null;

            return element;
        }
        catch (WebDriverTimeoutException ex)
        {
            Utilities.HandleException(ElementConditions.ErrorMessage.Value, ex, throwOnException, out condition);
        }
        finally
        {
            Utilities.ResetTimeout(_wait, timeout, originalTimeout);
        }

        return null;
    }

    /// <summary>
    /// An expectation for checking if the given element is selected.
    /// </summary>
    /// <param name="locator">The locator used to find the element.</param>
    /// <param name="name">The name of the locator, used for better error messages. Shouldn't be provided as it's generated automatically.</param>
    /// <returns>The <see cref="IWebElement"/> once given element is selected.</returns>
    public IWebElement IsSelected(By locator, [CallerArgumentExpression("locator")] string name = null)
    {
        return IsSelected(locator, null, out _, true, name);
    }

    /// <summary>
    /// An expectation for checking if the given element is selected.
    /// </summary>
    /// <param name="locator">The locator used to find the element.</param>
    /// <param name="condition">Out parameter that returns a <see cref="Condition"/> object indicating the result of the condition.</param>
    /// <param name="name">The name of the locator, used for better error messages. Shouldn't be provided as it's generated automatically.</param>
    /// <returns>The <see cref="IWebElement"/> once given element is in correct state, otherwise null.</returns>
    public IWebElement IsSelected(By locator, out Condition condition, [CallerArgumentExpression("locator")] string name = null)
    {
        return IsSelected(locator, null, out condition, false, name);
    }

    /// <summary>
    /// An expectation for checking if the given element is selected.
    /// </summary>
    /// <param name="locator">The locator used to find the element.</param>
    /// <param name="name">The name of the locator, used for better error messages. Shouldn't be provided as it's generated automatically.</param>
    /// <param name="timeout">The time to wait for the condition to be successful.</param>
    /// <returns>The <see cref="IWebElement"/> once given element is selected.</returns>
    public IWebElement IsSelected(By locator, TimeSpan timeout, [CallerArgumentExpression("locator")] string name = null)
    {
        return IsSelected(locator, timeout, out _, true, name);
    }

    /// <summary>
    /// An expectation for checking if the given element is selected.
    /// </summary>
    /// <param name="locator">The locator used to find the element.</param>
    /// <param name="timeout">The time to wait for the condition to be successful.</param>
    /// <param name="condition">Out parameter that returns a <see cref="Condition"/> object indicating the result of the condition.</param>
    /// <param name="name">The name of the locator, used for better error messages. Shouldn't be provided as it's generated automatically.</param>
    /// <returns>The <see cref="IWebElement"/> once given element is in correct state, otherwise null.</returns>
    public IWebElement IsSelected(By locator, TimeSpan timeout, out Condition condition, [CallerArgumentExpression("locator")] string name = null)
    {
        return IsSelected(locator, timeout, out condition, false, name);
    }

    private IWebElement SelectedStateIs(By locator, bool isSelected, TimeSpan? timeout, out Condition condition, bool throwOnException, string name)
    {
        Utilities.SetTimeout(_wait, timeout, out var originalTimeout);
        condition = new Condition();

        try
        {
            var element = _wait.Until(ElementConditions.SelectedStateIs(locator, isSelected, name));

            condition.Result = true;
            condition.Error = null;

            return element;
        }
        catch (WebDriverTimeoutException ex)
        {
            Utilities.HandleException(ElementConditions.ErrorMessage.Value, ex, throwOnException, out condition);
        }
        finally
        {
            Utilities.ResetTimeout(_wait, timeout, originalTimeout);
        }

        return null;
    }

    /// <summary>
    /// An expectation for checking if the given element is in correct state.
    /// </summary>
    /// <param name="locator">The locator used to find the element.</param>
    /// <param name="isSelected">selected or not selected</param>
    /// <param name="name">The name of the locator, used for better error messages. Shouldn't be provided as it's generated automatically.</param>
    /// <returns>The <see cref="IWebElement"/> once given element is in correct state.</returns>
    public IWebElement SelectedStateIs(By locator, bool isSelected, [CallerArgumentExpression("locator")] string name = null)
    {
        return SelectedStateIs(locator, isSelected, null, out _, true, name);
    }

    /// <summary>
    /// An expectation for checking if the given element is in correct state.
    /// </summary>
    /// <param name="locator">The locator used to find the element.</param>
    /// <param name="isSelected">selected or not selected</param>
    /// <param name="condition">Out parameter that returns a <see cref="Condition"/> object indicating the result of the condition.</param>
    /// <param name="name">The name of the locator, used for better error messages. Shouldn't be provided as it's generated automatically.</param>
    /// <returns>The <see cref="IWebElement"/> once given element is in correct state, otherwise null.</returns>
    public IWebElement SelectedStateIs(By locator, bool isSelected, out Condition condition, [CallerArgumentExpression("locator")] string name = null)
    {
        return SelectedStateIs(locator, isSelected, null, out condition, false, name);
    }

    /// <summary>
    /// An expectation for checking if the given element is in correct state.
    /// </summary>
    /// <param name="locator">The locator used to find the element.</param>
    /// <param name="isSelected">selected or not selected</param>
    /// <param name="timeout">The time to wait for the condition to be successful.</param>
    /// <param name="name">The name of the locator, used for better error messages. Shouldn't be provided as it's generated automatically.</param>
    /// <returns>The <see cref="IWebElement"/> once given element is in correct state.</returns>
    public IWebElement SelectedStateIs(By locator, bool isSelected, TimeSpan timeout, [CallerArgumentExpression("locator")] string name = null)
    {
        return SelectedStateIs(locator, isSelected, timeout, out _, true, name);
    }

    /// <summary>
    /// An expectation for checking if the given element is in correct state.
    /// </summary>
    /// <param name="locator">The locator used to find the element.</param>
    /// <param name="isSelected">selected or not selected</param>
    /// <param name="timeout">The time to wait for the condition to be successful.</param>
    /// <param name="condition">Out parameter that returns a <see cref="Condition"/> object indicating the result of the condition.</param>
    /// <param name="name">The name of the locator, used for better error messages. Shouldn't be provided as it's generated automatically.</param>
    /// <returns>The <see cref="IWebElement"/> once given element is in correct state, otherwise null.</returns>
    public IWebElement SelectedStateIs(By locator, bool isSelected, TimeSpan timeout, out Condition condition, [CallerArgumentExpression("locator")] string name = null)
    {
        return SelectedStateIs(locator, isSelected, timeout, out condition, false, name);
    }

    private IWebElement StopsMoving(By locator, TimeSpan? timeout, out Condition condition, bool throwOnException, string name)
    {
        Utilities.SetTimeout(_wait, timeout, out var originalTimeout);
        condition = new Condition();

        try
        {
            var element = _wait.Until(ElementConditions.StopsMoving(locator, name));

            condition.Result = true;
            condition.Error = null;

            return element;
        }
        catch (WebDriverTimeoutException ex)
        {
            Utilities.HandleException(ElementConditions.ErrorMessage.Value, ex, throwOnException, out condition);
        }
        finally
        {
            Utilities.ResetTimeout(_wait, timeout, originalTimeout);
        }

        return null;
    }

    /// <summary>
    /// An expectation for checking if the given element has stopped moving.
    /// </summary>
    /// <param name="locator">The locator used to find the element.</param>
    /// <param name="name">The name of the locator, used for better error messages. Shouldn't be provided as it's generated automatically.</param>
    /// <returns>The <see cref="IWebElement"/> once given element has stopped moving.</returns>
    public IWebElement StopsMoving(By locator, [CallerArgumentExpression("locator")] string name = null)
    {
        return StopsMoving(locator, null, out _, true, name);
    }

    /// <summary>
    /// An expectation for checking if the given element has stopped moving.
    /// </summary>
    /// <param name="locator">The locator used to find the element.</param>
    /// <param name="condition">Out parameter that returns a <see cref="Condition"/> object indicating the result of the condition.</param>
    /// <param name="name">The name of the locator, used for better error messages. Shouldn't be provided as it's generated automatically.</param>
    /// <returns>The <see cref="IWebElement"/> once given element has stopped moving, otherwise null.</returns>
    public IWebElement StopsMoving(By locator, out Condition condition, [CallerArgumentExpression("locator")] string name = null)
    {
        return StopsMoving(locator, null, out condition, false, name);
    }

    /// <summary>
    /// An expectation for checking if the given element has stopped moving.
    /// </summary>
    /// <param name="locator">The locator used to find the element.</param>
    /// <param name="timeout">The time to wait for the condition to be successful.</param>
    /// <param name="name">The name of the locator, used for better error messages. Shouldn't be provided as it's generated automatically.</param>
    /// <returns>The <see cref="IWebElement"/> once given element has stopped moving.</returns>
    public IWebElement StopsMoving(By locator, TimeSpan timeout, [CallerArgumentExpression("locator")] string name = null)
    {
        return StopsMoving(locator, timeout, out _, true, name);
    }

    /// <summary>
    /// An expectation for checking if the given element has stopped moving.
    /// </summary>
    /// <param name="locator">The locator used to find the element.</param>
    /// <param name="timeout">The time to wait for the condition to be successful.</param>
    /// <param name="condition">Out parameter that returns a <see cref="Condition"/> object indicating the result of the condition.</param>
    /// <param name="name">The name of the locator, used for better error messages. Shouldn't be provided as it's generated automatically.</param>
    /// <returns>The <see cref="IWebElement"/> once given element has stopped moving, otherwise null.</returns>
    public IWebElement StopsMoving(By locator, TimeSpan timeout, out Condition condition, [CallerArgumentExpression("locator")] string name = null)
    {
        return StopsMoving(locator, timeout, out condition, false, name);
    }

    private IWebElement IsFocused(By locator, TimeSpan? timeout, out Condition condition, bool throwOnException, string name)
    {
        Utilities.SetTimeout(_wait, timeout, out var originalTimeout);
        condition = new Condition();

        try
        {
            var element = _wait.Until(ElementConditions.IsFocused(locator, name));

            condition.Result = true;
            condition.Error = null;

            return element;
        }
        catch (WebDriverTimeoutException ex)
        {
            Utilities.HandleException(ElementConditions.ErrorMessage.Value, ex, throwOnException, out condition);
        }
        finally
        {
            Utilities.ResetTimeout(_wait, timeout, originalTimeout);
        }

        return null;
    }

    /// <summary>
    /// An expectation for checking if the given element is focused.
    /// </summary>
    /// <param name="locator">The locator used to find the element.</param>
    /// <param name="name">The name of the locator, used for better error messages. Shouldn't be provided as it's generated automatically.</param>
    /// <returns>The <see cref="IWebElement"/> once the given element is focused.</returns>
    public IWebElement IsFocused(By locator, [CallerArgumentExpression("locator")] string name = null)
    {
        return IsFocused(locator, null, out _, true, name);
    }

    /// <summary>
    /// An expectation for checking if the given element is focused.
    /// </summary>
    /// <param name="locator">The locator used to find the element.</param>
    /// <param name="condition">Out parameter that returns a <see cref="Condition"/> object indicating the result of the condition.</param>
    /// <param name="name">The name of the locator, used for better error messages. Shouldn't be provided as it's generated automatically.</param>
    /// <returns>The <see cref="IWebElement"/> once the given element is focused, otherwise null.</returns>
    public IWebElement IsFocused(By locator, out Condition condition, [CallerArgumentExpression("locator")] string name = null)
    {
        return IsFocused(locator, null, out condition, false, name);
    }

    /// <summary>
    /// An expectation for checking if the given element is focused.
    /// </summary>
    /// <param name="locator">The locator used to find the element.</param>
    /// <param name="timeout">The time to wait for the condition to be successful.</param>
    /// <param name="name">The name of the locator, used for better error messages. Shouldn't be provided as it's generated automatically.</param>
    /// <returns>The <see cref="IWebElement"/> once the given element is focused.</returns>
    public IWebElement IsFocused(By locator, TimeSpan timeout, [CallerArgumentExpression("locator")] string name = null)
    {
        return IsFocused(locator, timeout, out _, true, name);
    }

    /// <summary>
    /// An expectation for checking if the given element is focused.
    /// </summary>
    /// <param name="locator">The locator used to find the element.</param>
    /// <param name="timeout">The time to wait for the condition to be successful.</param>
    /// <param name="condition">Out parameter that returns a <see cref="Condition"/> object indicating the result of the condition.</param>
    /// <param name="name">The name of the locator, used for better error messages. Shouldn't be provided as it's generated automatically.</param>
    /// <returns>The <see cref="IWebElement"/> once the given element is focused, otherwise null.</returns>
    public IWebElement IsFocused(By locator, TimeSpan timeout, out Condition condition, [CallerArgumentExpression("locator")] string name = null)
    {
        return IsFocused(locator, timeout, out condition, false, name);
    }

    private IWebElement AttributeExists(By locator, string attribute, TimeSpan? timeout, out Condition condition, bool throwOnException, string name)
    {
        Utilities.SetTimeout(_wait, timeout, out var originalTimeout);
        condition = new Condition();

        try
        {
            var element = _wait.Until(ElementConditions.AttributeExists(locator, attribute, name));

            condition.Result = true;
            condition.Error = null;

            return element;
        }
        catch (WebDriverTimeoutException ex)
        {
            Utilities.HandleException(ElementConditions.ErrorMessage.Value, ex, throwOnException, out condition);
        }
        finally
        {
            Utilities.ResetTimeout(_wait, timeout, originalTimeout);
        }

        return null;
    }

    /// <summary>
    /// Checks if a specific attribute exists for an element identified by the provided locator.
    /// </summary>
    /// <param name="locator">The locator used to find the element.</param>
    /// <param name="attribute">The name of the attribute to check for existence on the element.</param>
    /// <param name="name">The name of the locator, used for better error messages. Shouldn't be provided as it's generated automatically.</param>
    /// <returns>The <see cref="IWebElement"/> once it is located and the attribute exists.</returns>
    public IWebElement AttributeExists(By locator, string attribute, [CallerArgumentExpression("locator")] string name = null)
    {
        return AttributeExists(locator, attribute, null, out _, true, name);
    }

    /// <summary>
    /// Checks if a specific attribute exists for an element identified by the provided locator.
    /// </summary>
    /// <param name="locator">The locator used to find the element.</param>
    /// <param name="attribute">The name of the attribute to check for existence on the element.</param>
    /// <param name="timeout">The time to wait for the condition to be successful.</param>
    /// <param name="name">The name of the locator, used for better error messages. Shouldn't be provided as it's generated automatically.</param>
    /// <returns>The <see cref="IWebElement"/> once it is located and the attribute exists.</returns>
    public IWebElement AttributeExists(By locator, string attribute, TimeSpan timeout, [CallerArgumentExpression("locator")] string name = null)
    {
        return AttributeExists(locator, attribute, timeout, out _, true, name);
    }

    /// <summary>
    /// Checks if a specific attribute exists for an element identified by the provided locator.
    /// </summary>
    /// <param name="locator">The locator used to find the element.</param>
    /// <param name="attribute">The name of the attribute to check for existence on the element.</param>
    /// <param name="condition">Out parameter that returns a <see cref="Condition"/> object indicating the result of the condition.</param>
    /// <param name="name">The name of the locator, used for better error messages. Shouldn't be provided as it's generated automatically.</param>
    /// <returns>The <see cref="IWebElement"/> once it is located and the attribute exists, otherwise null.</returns>
    public IWebElement AttributeExists(By locator, string attribute, out Condition condition, [CallerArgumentExpression("locator")] string name = null)
    {
        return AttributeExists(locator, attribute, null, out condition, false, name);
    }

    /// <summary>
    /// Checks if a specific attribute exists for an element identified by the provided locator.
    /// </summary>
    /// <param name="locator">The locator used to find the element.</param>
    /// <param name="attribute">The name of the attribute to check for existence on the element.</param>
    /// <param name="timeout">The time to wait for the condition to be successful.</param>
    /// <param name="condition">Out parameter that returns a <see cref="Condition"/> object indicating the result of the condition.</param>
    /// <param name="name">The name of the locator, used for better error messages. Shouldn't be provided as it's generated automatically.</param>
    /// <returns>The <see cref="IWebElement"/> once it is located and the attribute exists, otherwise null.</returns>
    public IWebElement AttributeExists(By locator, string attribute, TimeSpan timeout, out Condition condition, [CallerArgumentExpression("locator")] string name = null)
    {
        return AttributeExists(locator, attribute, timeout, out condition, false, name);
    }

    private IWebElement AttributeDoesNotExist(By locator, string attribute, TimeSpan? timeout, out Condition condition, bool throwOnException, string name)
    {
        Utilities.SetTimeout(_wait, timeout, out var originalTimeout);
        condition = new Condition();

        try
        {
            var element = _wait.Until(ElementConditions.AttributeDoesNotExists(locator, attribute, name));

            condition.Result = true;
            condition.Error = null;

            return element;
        }
        catch (WebDriverTimeoutException ex)
        {
            Utilities.HandleException(ElementConditions.ErrorMessage.Value, ex, throwOnException, out condition);
        }
        finally
        {
            Utilities.ResetTimeout(_wait, timeout, originalTimeout);
        }

        return null;
    }

    /// <summary>
    /// Checks if a specific attribute does not exist for an element identified by the provided locator.
    /// </summary>
    /// <param name="locator">The locator used to find the element.</param>
    /// <param name="attribute">The name of the attribute to check for existence on the element.</param>
    /// <param name="name">The name of the locator, used for better error messages. Shouldn't be provided as it's generated automatically.</param>
    /// <returns>The <see cref="IWebElement"/> once it is located and the attribute does not exist.</returns>
    public IWebElement AttributeDoesNotExist(By locator, string attribute, [CallerArgumentExpression("locator")] string name = null)
    {
        return AttributeDoesNotExist(locator, attribute, null, out _, true, name);
    }

    /// <summary>
    /// Checks if a specific attribute does not exist for an element identified by the provided locator.
    /// </summary>
    /// <param name="locator">The locator used to find the element.</param>
    /// <param name="attribute">The name of the attribute to check for existence on the element.</param>
    /// <param name="timeout">The time to wait for the condition to be successful.</param>
    /// <param name="name">The name of the locator, used for better error messages. Shouldn't be provided as it's generated automatically.</param>
    /// <returns>The <see cref="IWebElement"/> once it is located and the attribute does not exist.</returns>
    public IWebElement AttributeDoesNotExist(By locator, string attribute, TimeSpan timeout, [CallerArgumentExpression("locator")] string name = null)
    {
        return AttributeDoesNotExist(locator, attribute, timeout, out _, true, name);
    }

    /// <summary>
    /// Checks if a specific attribute does not exist for an element identified by the provided locator.
    /// </summary>
    /// <param name="locator">The locator used to find the element.</param>
    /// <param name="attribute">The name of the attribute to check for existence on the element.</param>
    /// <param name="condition">Out parameter that returns a <see cref="Condition"/> object indicating the result of the condition.</param>
    /// <param name="name">The name of the locator, used for better error messages. Shouldn't be provided as it's generated automatically.</param>
    /// <returns>The <see cref="IWebElement"/> once it is located and the attribute does not exist, otherwise null.</returns>
    public IWebElement AttributeDoesNotExist(By locator, string attribute, out Condition condition, [CallerArgumentExpression("locator")] string name = null)
    {
        return AttributeDoesNotExist(locator, attribute, null, out condition, false, name);
    }

    /// <summary>
    /// Checks if a specific attribute does not exist for an element identified by the provided locator.
    /// </summary>
    /// <param name="locator">The locator used to find the element.</param>
    /// <param name="attribute">The name of the attribute to check for existence on the element.</param>
    /// <param name="timeout">The time to wait for the condition to be successful.</param>
    /// <param name="condition">Out parameter that returns a <see cref="Condition"/> object indicating the result of the condition.</param>
    /// <param name="name">The name of the locator, used for better error messages. Shouldn't be provided as it's generated automatically.</param>
    /// <returns>The <see cref="IWebElement"/> once it is located and the attribute does not exist, otherwise null.</returns>
    public IWebElement AttributeDoesNotExist(By locator, string attribute, TimeSpan timeout, out Condition condition, [CallerArgumentExpression("locator")] string name = null)
    {
        return AttributeDoesNotExist(locator, attribute, timeout, out condition, false, name);
    }
}