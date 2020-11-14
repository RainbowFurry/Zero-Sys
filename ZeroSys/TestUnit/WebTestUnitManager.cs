using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Opera;
using OpenQA.Selenium.Safari;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Threading;

namespace ZeroSys.TestUnit.WebTestUnit
{
    /// <summary>
    /// WebTestUnitManager
    /// </summary>
    public class WebTestUnitManager
    {

        //Send keys

        private IWebDriver webDriver;

        /// <summary>
        /// Initialize WebTestUnitManager
        /// </summary>
        public WebTestUnitManager()
        {
            //
        }

        #region Browser

        //ChromeOptions o = new ChromeOptions();

        /// <summary>
        /// Start Test in Chrome
        /// </summary>
        public void StartChromeTest()
        {
            webDriver = new ChromeDriver();
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            webDriver.Manage().Window.Maximize();
        }

        /// <summary>
        /// Start Test in Chrome
        /// </summary>
        /// <param name="wait">Wait for Elements and Page if not loaded</param>
        public void StartChromeTest(int wait)
        {
            webDriver = new ChromeDriver();
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(wait);
            webDriver.Manage().Window.Maximize();
        }

        /// <summary>
        /// Start Test in IE
        /// </summary>
        public void StartIETest()
        {
            webDriver = new InternetExplorerDriver();
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            webDriver.Manage().Window.Maximize();
        }

        /// <summary>
        /// Start Test in IE
        /// </summary>
        /// <param name="wait">Wait for Elements and Page if not loaded</param>
        public void StartIETest(int wait)
        {
            webDriver = new InternetExplorerDriver();
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(wait);
            webDriver.Manage().Window.Maximize();
        }

        /// <summary>
        /// Start Test in Opera
        /// </summary>
        public void StartOperaTest()
        {
            webDriver = new OperaDriver();
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            webDriver.Manage().Window.Maximize();
        }

        /// <summary>
        /// Start Test in Opera
        /// </summary>
        /// <param name="wait">Wait for Elements and Page if not loaded</param>
        public void StartOperaTest(int wait)
        {
            webDriver = new OperaDriver();
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(wait);
            webDriver.Manage().Window.Maximize();
        }

        /// <summary>
        /// Start Test in Safari
        /// </summary>
        public void StartSafariTest()
        {
            webDriver = new SafariDriver();
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            webDriver.Manage().Window.Maximize();
        }

        /// <summary>
        /// Start Test in Safari
        /// </summary>
        /// <param name="wait">Wait for Elements and Page if not loaded</param>
        public void StartSafariTest(int wait)
        {
            webDriver = new SafariDriver();
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(wait);
            webDriver.Manage().Window.Maximize();
        }

        //
        private void StartAllBrowserTest()
        {
            //
        }

        #endregion

        #region Page
        /// <summary>
        /// Open Page with URL
        /// </summary>
        /// <param name="url"></param>
        public void OpenPage(string url)
        {
            webDriver.Navigate().GoToUrl(url);
        }

        /// <summary>
        /// Refresh current Page
        /// </summary>
        public void ReloadPage()
        {
            webDriver.Navigate().Refresh();
        }

        /// <summary>
        /// Go one Page Forward
        /// </summary>
        public void PageForward()
        {
            webDriver.Navigate().Forward();
        }

        /// <summary>
        /// Go one Page Backward
        /// </summary>
        public void PageBackward()
        {
            webDriver.Navigate().Back();
        }

        /// <summary>
        /// Get Current URL
        /// </summary>
        /// <returns></returns>
        public string GetPageUrl()
        {
            return webDriver.Url;
        }

        #endregion

        #region Element
        //ELEMENT EXIST IWEBELEMENT element

        /// <summary>
        /// Check if the Web Element exist
        /// </summary>
        /// <param name="by"></param>
        /// <returns></returns>
        public bool ElementExist(By by)
        {
            if (webDriver.FindElements(by).Count > 0)
                return true;
            return false;
        }

        /// <summary>
        /// Get Element from Web
        /// </summary>
        /// <param name="by"></param>
        /// <returns></returns>
        public IWebElement GetElement(By by)
        {
            if (ElementExist(by))
                return webDriver.FindElement(by);
            return null;
        }

        /// <summary>
        /// Get all Elements from Web
        /// </summary>
        /// <param name="by"></param>
        /// <returns></returns>
        public List<IWebElement> GetElements(By by)
        {
            IReadOnlyCollection<IWebElement> elements = webDriver.FindElements(by);
            List<IWebElement> result = new List<IWebElement>();

            if (elements.Count > 0)
            {
                foreach (IWebElement element in elements)
                {
                    result.Add(element);
                }
            }
            else
            {
                //throw new Exeption("Element not found");
            }
            return result;
        }

        #region Element Attribute
        /// <summary>
        /// Get Attribute
        /// </summary>
        /// <param name="by"></param>
        /// <param name="attribute"></param>
        /// <returns></returns>
        public string GetAttribute(By by, string attribute)
        {
            return webDriver.FindElement(by).GetAttribute(attribute);
        }

        /// <summary>
        /// Get Attribute
        /// </summary>
        /// <param name="element"></param>
        /// <param name="attribute"></param>
        /// <returns></returns>
        public string GetAttribute(IWebElement element, string attribute)
        {
            return element.GetAttribute(attribute);
        }

        #endregion

        #endregion

        #region Cookie

        /// <summary>
        /// Add Cookie
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void AddCookie(string key, string value)
        {
            webDriver.Manage().Cookies.AddCookie(new Cookie(key, value));
        }

        /// <summary>
        /// Get Cookie Value
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetCookieValue(string key)
        {
            var cookie = webDriver.Manage().Cookies.GetCookieNamed(key);
            return cookie.Value;
        }

        /// <summary>
        /// Get Cookie
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Cookie GetCookie(string key)
        {
            return webDriver.Manage().Cookies.GetCookieNamed(key);
        }

        /// <summary>
        /// Delete Cookie
        /// </summary>
        public void DeleteCookie(Cookie cookie)
        {
            webDriver.Manage().Cookies.DeleteCookie(cookie);
        }

        /// <summary>
        /// Delete Cookie
        /// </summary>
        public void DeleteCookie(string key)
        {
            webDriver.Manage().Cookies.DeleteCookie(GetCookie(key));
        }

        /// <summary>
        /// Delete all Cookies
        /// </summary>
        public void DeleteAllCookies()
        {
            webDriver.Manage().Cookies.DeleteAllCookies();
        }

        #endregion

        #region Keys

        /// <summary>
        /// Enter Keys to WebView
        /// </summary>
        /// <param name="by"></param>
        /// <param name="content"></param>
        public void SendKeys(By by, string content)
        {
            webDriver.FindElement(by).SendKeys(content);
        }

        /// <summary>
        /// Enter Keys to WebView
        /// </summary>
        /// <param name="element"></param>
        /// <param name="content"></param>
        public void SendKeys(IWebElement element, string content)
        {
            element.SendKeys(content);
        }

        /// <summary>
        /// Enter Keys to WebView
        /// </summary>
        /// <param name="by"></param>
        /// <param name="content"></param>
        public void FillTextField(By by, string content)
        {
            webDriver.FindElement(by).SendKeys(content);
        }

        /// <summary>
        /// Enter Keys to WebView
        /// </summary>
        /// <param name="element"></param>
        /// <param name="content"></param>
        public void FillTextField(IWebElement element, string content)
        {
            element.SendKeys(content);
        }

        /// <summary>
        /// Enter Keys to WebView
        /// </summary>
        /// <param name="by"></param>
        /// <param name="content"></param>
        public void FillTextFiledAndSend(By by, string content)
        {
            webDriver.FindElement(by).SendKeys(content + Keys.Enter);
        }

        /// <summary>
        /// Enter Keys to WebView
        /// </summary>
        /// <param name="element"></param>
        /// <param name="content"></param>
        public void FillTextFiledAndSend(IWebElement element, string content)
        {
            element.SendKeys(content + Keys.Enter);
        }

        #endregion

        #region Click

        /// <summary>
        /// Perform Click Element
        /// </summary>
        /// <param name="element"></param>
        public void PerformClick(IWebElement element)
        {
            element.Click();
        }

        /// <summary>
        /// Perform Click Element
        /// </summary>
        /// <param name="by"></param>
        public void PerformClick(By by)
        {
            if (ElementExist(by))
                GetElement(by).Click();
        }

        #endregion

        #region Else

        /// <summary>
        /// Create Screenshot
        /// </summary>
        /// <param name="savepath"></param>
        /// <param name="name"></param>
        /// <param name="imageFormat"></param>
        public void CreateScreenshot(string savepath, string name, ImageFormat imageFormat)
        {
            ITakesScreenshot screenshotDriver = webDriver as ITakesScreenshot;
            Screenshot screenshot = screenshotDriver.GetScreenshot();
            screenshot.SaveAsFile(savepath + name + imageFormat);
        }

        /// <summary>
        /// End Browser Tests
        /// </summary>
        public void TestCompleted()
        {
            webDriver.Quit();
        }

        /// <summary>
        /// Add for the one Element more time to wait for loading
        /// </summary>
        /// <param name="waitingSeconds"></param>
        public void ExpandDelayOnce(int waitingSeconds)
        {
            //WebDriverWait webDriverWait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(waitingSeconds));//wait for explicit content
            Thread.Sleep(waitingSeconds * 1000);
        }

        #endregion

    }
}
