using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Day12SpecFlowXpath.Utilities;

namespace Day12SpecFlowXpath.Pages
{
    public class HomePage
    {
        public void GoToTMPage(IWebDriver driver2)
        {
            //Navigate to time and material 
            IWebElement Administration = driver2.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
            Administration.Click();

            Wait.WaitToBeClickable(driver2, "Xpath","/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a", 3);
            IWebElement timeAndMaterial = driver2.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
            timeAndMaterial.Click();
        }

        public void GoToEmployeePage(IWebDriver driver1)
        {
            //Navigate to time and material 
            IWebElement Administration = driver1.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
            Administration.Click();

            Wait.WaitToBeClickable(driver1, "Xpath", "/html/body/div[3]/div/div/ul/li[5]/ul/li[2]/a", 3);
            IWebElement employee = driver1.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[2]/a"));
            employee.Click();
        }
    }
}
