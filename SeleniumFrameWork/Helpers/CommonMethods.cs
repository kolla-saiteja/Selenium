using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumFrameWork.Config;
using SeleniumFrameWork.Drivers;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumFrameWork.Helpers
{
    public static class CommonMethods
    {

        // Below methods are Common Methods to use

        //click element
        public static void ClickElement(By Element)
        {

            Webdriver.Driver.FindElement(Element).Click();
        }

        public static void ClickJS(By Element)
        {
            if (Element != null)
            {
                try
                {
                    ((IJavaScriptExecutor)Webdriver.Driver).ExecuteScript("arguments[0].click()", Element);
                }
                catch (StaleElementReferenceException)
                {
                }
                catch (ElementClickInterceptedException)
                {
                }
            }
        }

        //send keys
        public static void SendKeys(By Element, string value)
        {

            Webdriver.Driver.FindElement(Element).Clear();
            Webdriver.Driver.FindElement(Element).SendKeys(value);
        }

        //GetText of the webelement
        public static string GetText(By Element)
        {
            return Webdriver.Driver.FindElement(Element).Text;
        }

        //Get Atrribute name of Webelement
        public static string GetAttribute(By Element, string attrName)
        {
            return Webdriver.Driver.FindElement(Element).GetAttribute(attrName);
        }

        //Element Enabled
        public static bool IsEnabled(By Element)
        {
            return Webdriver.Driver.FindElement(Element).Enabled;
        }

        //Element Displayed
        public static bool IsDisplayed(By Element)
        {
            return Webdriver.Driver.FindElement(Element).Displayed;
        }

        public static void ClickOnElement(By Element, string value)
        {
            IList<IWebElement> eleList = Webdriver.Driver.FindElements(Element);
            Console.WriteLine(eleList.Count);
            foreach (IWebElement e in eleList)
            {
                if (e.Text.Equals(value))
                {
                    e.Click();
                    break;
                }
            }
        }

        public static IList<string> GetLinksTextList(By Element)
        {
            IList<string> eleTextList = new List<string>();

            IList<IWebElement> eleList = Webdriver.Driver.FindElements(Element);
            Console.WriteLine("element count: " + eleList.Count);

            foreach (IWebElement e in eleList)
            {
                string text = e.Text;
                if (text.Length > 0)
                {
                    eleTextList.Add(text);
                }
            }
            return eleTextList;
        }

        public static IList<IWebElement> GetElementList(By Element)
        {
            IList<IWebElement> eleList = Webdriver.Driver.FindElements(Element);
            if (eleList.Count > 0)
            {
                return eleList;
            }
            else
                return null;
        }

        public static bool IsElementExist(By Element)
        {
            IList<IWebElement> listEle = Webdriver.Driver.FindElements(Element);
            if (listEle.Count > 0)
            {
                Console.WriteLine("element is present");
                return true;
            }
            Console.WriteLine("element is not present");
            return false;
        }



        /************************ Drop Down Utils (Select tag) ***********************/

        public static void SelectByVisibleText(By Element, string text)
        {
            SelectElement select = new SelectElement(Webdriver.Driver.FindElement(Element));
            select.SelectByText(text);
        }

        public static void SelectByValue(By Element, string text)
        {
            SelectElement select = new SelectElement(Webdriver.Driver.FindElement(Element));
            select.SelectByValue(text);
        }

        public static void SelectByIndex(By Element, int index)
        {
            SelectElement select = new SelectElement(Webdriver.Driver.FindElement(Element));
            select.SelectByIndex(index);
        }


        public static IList<string> DropDownOptionsList(By Element)
        {
            IList<string> optionsValList = new List<string>();
            SelectElement select = new SelectElement(Webdriver.Driver.FindElement(Element));
            IList<IWebElement> optionsList = select.Options;

            Console.WriteLine(optionsList.Count);

            foreach (IWebElement e in optionsList)
            {
                string text = e.Text;
                optionsValList.Add(text);
            }
            return optionsValList;
        }

        public static void SelectDropDownValue(By Element, string value)
        {
            SelectElement select = new SelectElement(Webdriver.Driver.FindElement(Element));
            IList<IWebElement> optionsList = select.Options;
            Console.WriteLine(optionsList.Count);

            foreach (IWebElement e in optionsList)
            {
                string text = e.Text;
                if (text.Equals(value))
                {
                    e.Click();
                    break;
                }
            }
        }

        public static void ClickDropDownValue(By Element, string value)
        {
            IList<IWebElement> optionsList = Webdriver.Driver.FindElements(Element);
            Console.WriteLine(optionsList.Count);
            foreach (IWebElement e in optionsList)
            {
                string text = e.Text;
                if (text.Equals(value))
                {
                    e.Click();
                    break;
                }
            }
        }

        /************************* User Actions Utils *************************/
        public static void TwoLevelMenuHandle(By parentMenu, By childMenu)
        {
            Actions act = new Actions(Webdriver.Driver);
            act.MoveToElement(Webdriver.Driver.FindElement(parentMenu)).Perform();
            Thread.Sleep(2000);
            Webdriver.Driver.FindElement(childMenu).Click();
        }

        public static void ThreeLevelMenuHandle(By parentMenu1, By parentMenu2, By childMenu)
        {
            Actions act = new Actions(Webdriver.Driver);
            act.MoveToElement(Webdriver.Driver.FindElement(parentMenu1)).Perform();
            Thread.Sleep(2000);
            act.MoveToElement(Webdriver.Driver.FindElement(parentMenu2)).Perform();
            Thread.Sleep(2000);
            Webdriver.Driver.FindElement(childMenu).Click();
        }

        public static void DoActionsSendKeys(By Element, string value)
        {
            Actions act = new Actions(Webdriver.Driver);
            act.SendKeys(Webdriver.Driver.FindElement(Element), value).Perform();
        }

        public static void DoActionsClick(By Element)
        {
            Actions act = new Actions(Webdriver.Driver);
            act.Click(Webdriver.Driver.FindElement(Element)).Perform();
        }

        /*************************** Wait Utils *****************************/


        public static Func<IWebDriver, IAlert> AlertIsPresent()
        {
            return (Driver) =>
            {
                try
                {
                    IAlert alert = Driver.SwitchTo().Alert();

                    return alert;
                }
                catch (NoAlertPresentException)
                {
                    return null;
                }
            };
        }


        public static IAlert WaitForAlert()
        {
            WebDriverWait wait = new WebDriverWait(Webdriver.Driver, TimeSpan.FromSeconds(30));
            return wait.Until(AlertIsPresent());
        }

        public static void AcceptAlert()
        {
            WaitForAlert().Accept();
        }

        public static string GetAlertText()
        {
            string text = WaitForAlert().Text;
            AcceptAlert();
            return text;
        }

        public static void DismissAlert()
        {
            WaitForAlert().Dismiss();
        }
        public static void SendKeysOnAlert(string value)
        {
            WaitForAlert().SendKeys(value);
        }

        public static string WaitForTitleContains(string titleValue)
        {
            WebDriverWait wait = new WebDriverWait(Webdriver.Driver, TimeSpan.FromSeconds(30));
            if (wait.Until(Driver => Webdriver.Driver.Title.Contains(titleValue)))
            {
                return Webdriver.Driver.Title;
            }
            return null;
        }

        public static string WaitForTitleIs(string fullTitle)
        {
            WebDriverWait wait = new WebDriverWait(Webdriver.Driver, TimeSpan.FromSeconds(30));
            if (wait.Until(Driver => Webdriver.Driver.Title.Equals(fullTitle)))
            {
                return Webdriver.Driver.Title;
            }
            return null;
        }

        public static string WaitForUrlContains(string urlFraction)
        {
            WebDriverWait wait = new WebDriverWait(Webdriver.Driver, TimeSpan.FromSeconds(30));
            if (wait.Until(Driver => Webdriver.Driver.Url.Contains(urlFraction)))
            {
                return Webdriver.Driver.Url;
            }
            return null;
        }

        public static string WaitForFullUrl(string urlValue)
        {
            WebDriverWait wait = new WebDriverWait(Webdriver.Driver, TimeSpan.FromSeconds(30));
            if (wait.Until(Driver => Webdriver.Driver.Url.Equals(urlValue)))
            {
                return Webdriver.Driver.Url;
            }
            return null;
        }

        public static void WaitForFrameAndSwitchToIt(string frameName)
        {
            WebDriverWait wait = new WebDriverWait(Webdriver.Driver, TimeSpan.FromSeconds(30));
            wait.Until(Driver => Webdriver.Driver.SwitchTo().Frame(frameName));
        }

        public static void WaitForFrameAndSwitchToIt(By Element)
        {
            WebDriverWait wait = new WebDriverWait(Webdriver.Driver, TimeSpan.FromSeconds(30));
            wait.Until(Driver => Webdriver.Driver.SwitchTo().Frame((IWebElement)Element));
        }

        public static void WaitForFrameAndSwitchToIt(int frameIndex)
        {
            WebDriverWait wait = new WebDriverWait(Webdriver.Driver, TimeSpan.FromSeconds(30));
            wait.Until(Driver => Webdriver.Driver.SwitchTo().Frame(frameIndex));
        }


        /**
        * An expectation for checking that an element is present on the DOM of a page.
        * This does not necessarily mean that the element is visible.
        * 
        * @param locator
        * @param timeOut
        * @return
        */

        public static IWebElement WaitForElementPresence(By Element)
        {
            WebDriverWait wait = new WebDriverWait(Webdriver.Driver, TimeSpan.FromSeconds(30));
            return wait.Until(Driver => Webdriver.Driver.FindElement(Element));
        }

        public static IWebElement RetryingElement(By Element, int maxAttempts)
        {
            IWebElement element = null;
            int attempts = 0;
            while (attempts < maxAttempts)
            {
                try
                {
                    element = Webdriver.Driver.FindElement(Element);
                    break;
                }
                catch (Exception)
                {
                    try
                    {
                        Thread.Sleep(1000);
                    }
                    catch (Exception e1)
                    {
                        Console.WriteLine(e1.ToString());
                        Console.Write(e1.StackTrace);
                    }
                    Console.WriteLine("element is not found in attempt : " + (attempts + 1));
                }


                attempts++;
            }
            return element;
        }

    }
}
