using Day12SpecFlowXpath.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V117.Browser;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Day12SpecFlowXpath.Pages
{
    public class EmployeePage
    {
        public void Create_EmployeeRecord(IWebDriver driver1)
        {
            Wait.WaitToBeClickable(driver1, "Xpath", "//*[@id=\"container\"]/p/a", 5);
            IWebElement createNewEmployee = driver1.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
            createNewEmployee.Click();
            IWebElement EmployeeName = driver1.FindElement(By.XPath("//*[@id=\"Name\"]"));
            EmployeeName.SendKeys("EmpTanya");
            IWebElement EmployeeUserName= driver1.FindElement(By.XPath("//*[@id=\"Username\"]"));
            EmployeeUserName.SendKeys("EmpTanyaUser");
            IWebElement EmployeeContact = driver1.FindElement(By.XPath("//*[@id=\"EditContactButton\"]"));
            Thread.Sleep(1000);
            EmployeeContact.Click();

            driver1.SwitchTo().Frame(0);
            Wait.WaitToBeClickable(driver1, "Xpath", "//*[@id=\"FirstName\"]", 5);
            IWebElement EmployeeFirstName = driver1.FindElement(By.XPath("//*[@id=\"FirstName\"]"));
            EmployeeFirstName.SendKeys("EmpTanyaFirstUser");
            IWebElement EmployeeLastName = driver1.FindElement(By.XPath("//*[@id=\"LastName\"]"));
            EmployeeLastName.SendKeys("EmpTanyaLastUser");
            IWebElement EmployeePreferedName = driver1.FindElement(By.XPath("//*[@id=\"PreferedName\"]"));
            EmployeePreferedName.SendKeys("EmpTanyaPFName");
            IWebElement EmployeePhoneName = driver1.FindElement(By.XPath("//*[@id=\"Phone\"]"));
            EmployeePhoneName.SendKeys("0000000000");
            IWebElement EmployeeEmail = driver1.FindElement(By.XPath("//*[@id=\"email\"]"));
            EmployeeEmail.SendKeys("yyy@hotmail.com");
            IWebElement EmployeeContactSave = driver1.FindElement(By.XPath("//*[@id=\"submitButton\"]"));
            EmployeeContactSave.Click();
            Thread.Sleep(1000);
            driver1.SwitchTo().DefaultContent();
            IWebElement EmployeePassword = driver1.FindElement(By.XPath("//*[@id=\"Password\"]"));
            EmployeePassword.SendKeys("123123");
            IWebElement EmployeeRetypePassword = driver1.FindElement(By.XPath("//*[@id=\"RetypePassword\"]"));
            EmployeeRetypePassword.SendKeys("123123");

            IWebElement EmployeeContactCreateSave = driver1.FindElement(By.XPath("//*[@id=\"SaveButton\"]"));
            EmployeeContactCreateSave.Click();
            IWebElement EmployeeContactBackToList = driver1.FindElement(By.XPath("//*[@id=\"container\"]/div/a"));
            EmployeeContactBackToList.Click();
            Thread.Sleep(1000);
            IWebElement EmployeeLastPage = driver1.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[4]/a[4]/span"));
            EmployeeLastPage.Click();
            IWebElement newEmployeeName = driver1.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            Assert.That(newEmployeeName.Text == "EmpTanya", "Record has not been created.");
            Thread.Sleep(1000);


        }

        public void Edit_EmployeeRecord(IWebDriver driver1)
        {
            Thread.Sleep(1000);
            IWebElement EmployeeLastPage = driver1.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[4]/a[4]/span"));
            EmployeeLastPage.Click();                                                         
            IWebElement EmployeeEdit = driver1.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            Assert.That(EmployeeEdit.Text == "EmpTanya", "New Code is not show and expected code do Not match.");
            IWebElement EmployeeEditclick = driver1.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[last()]/td[3]/a[1]"));
            EmployeeEditclick.Click();
            Wait.WaitToBeClickable(driver1, "Xpath", "//*[@id=\"Name\"]", 5);
            IWebElement EmployeeName = driver1.FindElement(By.XPath("//*[@id=\"Name\"]"));
            EmployeeName.Clear();
            EmployeeName.SendKeys("EmpTanyaEdit");
            Thread.Sleep(1000);
            IWebElement EmployeeContactEditSave = driver1.FindElement(By.XPath("//*[@id=\"SaveButton\"]"));
            EmployeeContactEditSave.Click();
            EmployeeContactEditSave.Click();
            IWebElement EmployeeContactBackToList = driver1.FindElement(By.XPath("//*[@id=\"container\"]/div/a"));
            EmployeeContactBackToList.Click();
            Thread.Sleep(1000);
            IWebElement EmployeeLastPageEdit = driver1.FindElement(By.XPath("//*[@id='usersGrid']/div[4]/a[4]/span"));
            EmployeeLastPageEdit.Click();
            //IWebElement EmployeeEditName = driver1.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
           // Assert.That(EmployeeEditName.Text == "EmpTanyaEdit", "Record has not been Edited.");
            Thread.Sleep(1000);

        }

        public void Delete_EmployeeRecord(IWebDriver driver1)
        {
            Thread.Sleep(1000);
            IWebElement EmployeeLastPage = driver1.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[4]/a[4]/span"));
            EmployeeLastPage.Click();
            IWebElement EmployeeDeleteCheck = driver1.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            Assert.That(EmployeeDeleteCheck.Text == "EmpTanyaEdit", "New Code is not show and expected code do Not match.");
            IWebElement EmployeeDelete = driver1.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[last()]/td[3]/a[2]"));
            EmployeeDelete.Click();                              
            Thread.Sleep(1000);
            driver1.SwitchTo().Alert().Accept();

         //   IWebElement lastRecordElement = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[last()]/td[3]/a[2]"));

            // Get the text of the last record
         //   string lastRecordText = lastRecordElement.Text;

            // Assert that the last record is not equal to "EmpTanyaEdit"
          //  Assert.AreNotEqual("EmpTanyaEdit", lastRecordText, "Last record is equal to 'EmpTanyaEdit'.");
            Thread.Sleep(1000);


        }

        public string GetnewEmployeeName(IWebDriver driver1)
        {
            IWebElement newEmployeeName = driver1.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            return newEmployeeName.Text;
        }

        public string GetnewEmployeeNameEdit(IWebDriver driver1)
        {
            IWebElement newEmployeeNameEdit = driver1.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            return newEmployeeNameEdit.Text;
        }

        public string GetLastRecordDeleted(IWebDriver driver1)
        {
            IWebElement lastRecordElement = driver1.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[last()]/td[3]/a[2]"));
            return lastRecordElement.Text;
        }
    }
}
