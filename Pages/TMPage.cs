using OpenQA.Selenium;
using Day12SpecFlowXpath.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;




namespace Day12SpecFlowXpath.Pages
{
    public class TMPage
    {
        public void Create_TimeRecord(IWebDriver driver2, string code, string description, string price)
        {
            Wait.WaitToBeClickable(driver2, "Xpath","//*[@id=\"container\"]/p/a", 5);
            //Add
            IWebElement createNew = driver2.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
            createNew.Click();
            IWebElement typeCode = driver2.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[1]"));
            typeCode.Click();
            IWebElement typeCodeTime = driver2.FindElement(By.XPath("//*[@id='TypeCode_listbox']/li[2]"));
            typeCodeTime.Click();
            IWebElement createCode = driver2.FindElement(By.XPath("//*[@id=\"Code\"]"));
            createCode.SendKeys(code);
            IWebElement createDescription = driver2.FindElement(By.XPath("//*[@id=\"Description\"]"));
            createDescription.SendKeys(description);
            Thread.Sleep(1000);
            IWebElement pricePerUnit = driver2.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
            pricePerUnit.SendKeys(price);
            IWebElement createSave = driver2.FindElement(By.XPath("//*[@id=\"SaveButton\"]"));
            createSave.Click();
            Wait.WaitToBeClickable(driver2, "Xpath", "//*[@id=\"tmsGrid\"]/div[4]/a[4]/span", 3);
            ////Go to last page
            //IWebElement lastPage = driver2.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            //lastPage.Click();
            //IWebElement newCode = driver2.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            //Assert.That(newCode.Text == "HelloTan", "Record has not been created.");
            //Thread.Sleep(1000);

            // Check if new record has been created successfully
            try
            {
                IWebElement goToLastPageButton = driver2.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
                goToLastPageButton.Click();
            }
            catch (Exception ex)
            {
                Assert.Fail("Go to last page button hasn't been found.", ex.Message);
            }

        }

        public void Update_TimeRecord(IWebDriver driver2, string code, string description)
        {
            Wait.WaitToBeClickable(driver2, "Xpath", "//*[@id=\"tmsGrid\"]/div[4]/a[4]/span", 5);
            IWebElement lastPage = driver2.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            lastPage.Click();
            //Edit
            Thread.Sleep(1000);
            IWebElement editLastRecord = driver2.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
            editLastRecord.Click();                                 
            Wait.WaitToBeClickable(driver2, "Xpath", "//*[@id=\"Code\"]", 3);
         
            IWebElement editCode = driver2.FindElement(By.XPath("//*[@id=\"Code\"]"));
            editCode.Clear();
            editCode.SendKeys(code);
            IWebElement editDescription = driver2.FindElement(By.XPath("//*[@id=\"Description\"]"));
            editDescription.Clear();
            editDescription.SendKeys(description);
            IWebElement EditSave = driver2.FindElement(By.XPath("//*[@id=\"SaveButton\"]"));
            EditSave.Click();
            Wait.WaitToBeClickable(driver2, "Xpath", "/html/body/div[4]/div/div/div[4]/a[4]/span", 3);
            
            //Go to last page
            IWebElement lastPageEdit = driver2.FindElement(By.XPath("/html/body/div[4]/div/div/div[4]/a[4]/span"));
            Thread.Sleep(1000);
            lastPageEdit.Click();
            IWebElement newCodeEdit = driver2.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            Assert.That(newCodeEdit.Text == code, "Record has not been created.");
            Thread.Sleep(1000);


        }

        public void Delete_TimeRecord(IWebDriver driver2, string code, string description,string price) 
        {
            Thread.Sleep(1000);
            IWebElement lastPage = driver2.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            lastPage.Click();                                                       
            IWebElement newCodeDelete = driver2.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            Assert.That(newCodeDelete.Text == code, "Record has not been deleted.");
            IWebElement newDescriptionDelete = driver2.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[3]"));
            Assert.That(newDescriptionDelete.Text == description, "Record has not been deleted.");
            IWebElement newpriceDelete = driver2.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[4]"));
            Assert.That(newpriceDelete.Text == price, "Record has not been deleted.");
            IWebElement lastPageRecordDelete = driver2.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
            lastPageRecordDelete.Click();
            driver2.SwitchTo().Alert().Accept();
           // IWebElement lastRecordElement = driver2.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[3]/a[2]"));

           // // Get the text of the last record
           //string lastRecordText = lastRecordElement.Text;

           // // Assert that the last record is not equal to "HelloTan1"
           // Assert.AreNotEqual("HelloTan1", lastRecordText, "Last record is equal to 'HelloTan1'.");
           // Thread.Sleep(4000);
        }
        //

        public string GetCode(IWebDriver driver2)
        {
            IWebElement newCode = driver2.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            return newCode.Text;
        }

        public string GetDescription(IWebDriver driver2)
        {
            IWebElement newDescription = driver2.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[3]"));
            return newDescription.Text;
        }

        public string GetPrice(IWebDriver driver2)
        {
            IWebElement newPrice = driver2.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[4]"));
            return newPrice.Text;
        }

        public string GetLastRecordDeleted(IWebDriver driver2)
        {
            Thread.Sleep(1000);
            IWebElement lastRecordElement = driver2.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            return lastRecordElement.Text;
        }

        public string GetLastRecordDeletedDescription(IWebDriver driver2)
        {
            Thread.Sleep(1000);
            IWebElement lastRecordElementDescription = driver2.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[3]"));
            return lastRecordElementDescription.Text;
        }

        public string GetLastRecordDeletedprice(IWebDriver driver2)
        {
            Thread.Sleep(1000);
            IWebElement lastRecordElementprice = driver2.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[4]"));
            return lastRecordElementprice.Text;
        }

    }
}
