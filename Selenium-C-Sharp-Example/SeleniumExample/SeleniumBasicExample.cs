using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumExample
{
    [TestClass]
    public class SeleniumBasicExample
    {
        [TestMethod]
        public void SearchForSeleniumHQ()
        {
            ChromeOptions options = new ChromeOptions();

            using (var chromeDriver = new ChromeDriver(options))
            {
                var url = "https://www.saucedemo.com";
                chromeDriver.Navigate().GoToUrl(url);

                //Create new wait timer and set it to 1 minute
                var wait = new WebDriverWait(chromeDriver, new TimeSpan(0, 0, 1, 0));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName("login_logo")));

                var usernameBox = chromeDriver.FindElement(By.Id("user-name"));
                var passwordBox = chromeDriver.FindElement(By.Id("password"));
                usernameBox.Clear();
                passwordBox.Clear();

                usernameBox.SendKeys("standard_user");
                passwordBox.SendKeys("secret_sauce");

                var loginButton = chromeDriver.FindElement(By.Id("login-button"));
                loginButton.Click();

                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName("peek")));

                var item4 = chromeDriver.FindElement(By.ClassName("inventory_item_name"));
                Assert.IsTrue(item4.Text.Contains("Sauce"));

                //close Chrome
                chromeDriver.Close();
            }
        }
    }
}
