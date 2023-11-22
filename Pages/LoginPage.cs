using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Day12SpecFlowXpath.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Day12SpecFlowXpath.Pages
{
    public class LoginPage
    {
        public void LoginAction(IWebDriver driver1)
        {
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver1.Manage().Window.Maximize();

            //Lunch TurnUp Portal and navigate to the website login page
            driver1.Navigate().GoToUrl("http://horse.industryconnect.io/Account/Login?ReturnUrl=%2f");
            Wait.WaitToExist(driver1, "Xpath", "//*[@id='UserName']", 8);
            //user login
            IWebElement usernameTextbox = driver1.FindElement(By.XPath("//*[@id='UserName']"));
            usernameTextbox.SendKeys("hari");

            IWebElement passwordTextbox = driver1.FindElement(By.XPath("//*[@id=\"Password\"]"));
            passwordTextbox.SendKeys("123123");

            IWebElement loginButton = driver1.FindElement(By.XPath("//*[@id='loginForm']/form/div[3]/input[1]"));
            loginButton.Click();

        }

        public void LoginActionTM(IWebDriver driver2)
        {
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver2.Manage().Window.Maximize();

            //Lunch TurnUp Portal and navigate to the website login page
            driver2.Navigate().GoToUrl("http://horse.industryconnect.io/Account/Login?ReturnUrl=%2f");
            Wait.WaitToExist(driver2, "Xpath", "//*[@id='UserName']", 8);
            //user login
            IWebElement usernameTextbox = driver2.FindElement(By.XPath("//*[@id='UserName']"));
            usernameTextbox.SendKeys("TanyaN");

            IWebElement passwordTextbox = driver2.FindElement(By.XPath("//*[@id=\"Password\"]"));
            passwordTextbox.SendKeys("123123");

            IWebElement loginButton = driver2.FindElement(By.XPath("//*[@id='loginForm']/form/div[3]/input[1]"));
            loginButton.Click();

        }
    }
}
