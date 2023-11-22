using Day12SpecFlowXpath.Pages;
using Day12SpecFlowXpath.Utilities;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace Day12SpecFlowXpath.StepDefinitions
{
    [Binding]
    public class TMFeatureStepDefinitions : CommonDriver
    {
        TMPage tmPageObject = new TMPage();
        LoginPage loginPageObj = new LoginPage();
        HomePage homePageObj = new HomePage();

        [Given(@"I loged into TurnUp portal successfully")]
        public void GivenILogedIntoTurnUpPortalSuccessfully()
        {
            driver2 = new ChromeDriver();
            loginPageObj.LoginActionTM(driver2);

        }

        [When(@"I navigate to time and material page")]
        public void WhenINavigateToTimeAndMaterialPage()
        {
           homePageObj.GoToTMPage(driver2);
        }

        [Then(@"I create a new time record")]
        //public void ThenICreateANewTimeRecord()
        //{
            
        //    //Create
        //    tmPageObject.Create_TimeRecord(driver2);
        //}

        [Then(@"the time record should be created successfully")]
        public void ThenTheTimeRecordShouldBeCreatedSuccessfully()
        {
           
            string newCode = tmPageObject.GetCode(driver2);
            string newDescription = tmPageObject.GetDescription(driver2);
            string newPrice =tmPageObject.GetPrice(driver2);
            Assert.That(newCode == "HelloTan", "New Code and expected code do Not match.");
            Assert.That(newDescription == "HelloTanDes", "New Description and expected code do Not match.");
            Assert.That(newPrice == "$111.00", "New Price and expected code do Not match.");
          

        }

        //[Then(@"I edit a time record")]
        //public void ThenIEditATimeRecord()
        //{

        //    tmPageObject.Update_TimeRecord(driver2, code, description);
        //}

        [Then(@"the time record should be edited successfully")]
        public void ThenTheTimeRecordShouldBeEditedSuccessfully()
        {
            
            string editnewCode = tmPageObject.GetCode(driver2);
            string editnewDescription = tmPageObject.GetDescription(driver2);
            string editnewPrice = tmPageObject.GetPrice(driver2);
            Assert.That(editnewCode == "HelloTan1", "New Code and expected code do Not match.");
            Assert.That(editnewDescription == "HelloTanDes1", "New Description and expected code do Not match.");
            Assert.That(editnewPrice == "$111.00", "New Price and expected code do Not match.");
            
        }

        //[Then(@"I delete a time record")]
        //public void ThenIDeleteATimeRecord()
        //{

        //    tmPageObject.Delete_TimeRecord(driver2);
        //}

        [Then(@"the time record should be deleted successfully")]
        public void ThenTheTimeRecordShouldBeDeletedSuccessfully()
        {
           
            string DeletedRecord = tmPageObject.GetLastRecordDeleted(driver2);
            Assert.AreNotEqual("TanEdit3", DeletedRecord, "Last record is equal to 'TanEdit3'.");
            
        }

        [AfterScenario]
        public void AfterScenario()
        {
            if (driver1 != null)
            {
                driver1.Quit();
                driver1 = null; // Optional: Set it to null after quitting to avoid accidental usage
            }

            // Check if the second driver is not null before quitting
            if (driver2 != null)
            {
                driver2.Quit();
                driver2 = null; // Optional: Set it to null after quitting to avoid accidental usage
            }


        }


        [Then(@"I create a new '([^']*)', '([^']*)', '([^']*)' in time record")]
        public void ThenICreateANewInTimeRecord(string code, string description, string price)
        {
            //Create
            tmPageObject.Create_TimeRecord(driver2,code,description, price);
        }

        [Then(@"the time record should be created '([^']*)', '([^']*)', '([^']*)' successfully")]
        public void ThenTheTimeRecordShouldBeCreatedSuccessfully(string code, string description, string price)
        {

            string newCode = tmPageObject.GetCode(driver2);
            string newDescription = tmPageObject.GetDescription(driver2);
            string newPrice = tmPageObject.GetPrice(driver2);
            Assert.That(newCode == code, "New Code and expected code do Not match.");
            Assert.That(newDescription == description, "New Description and expected code do Not match.");
            Assert.That(newPrice == price, "New Price and expected code do Not match.");


        }



        [When(@"I update the '([^']*)', '([^']*)' of an existing time record")]
        public void WhenIUpdateTheOfAnExistingTimeRecord(string code, string description)
        {
            tmPageObject.Update_TimeRecord(driver2, code, description);
        }

        //[Then(@"the time record should be update '([^']*)', '([^']*)' successfully")]
        //public void ThenTheTimeRecordShouldBeUpdateSuccessfully(string code, string description)
        //{
        //    string editnewCode = tmPageObject.GetCode(driver2);
        //    string editnewDescription = tmPageObject.GetDescription(driver2);
        //    Assert.That(editnewCode == code, "New Code and expected code do Not match.");
        //    Assert.That(editnewDescription == description, "New Description and expected code do Not match.");

        //}

        [Then(@"the time record should be updated '([^']*)', '([^']*)' successfully")]
        public void ThenTheTimeRecordShouldBeUpdatedSuccessfully(string code, string description)
        {
            string editnewCode = tmPageObject.GetCode(driver2);
            string editnewDescription = tmPageObject.GetDescription(driver2);
            Assert.That(editnewCode == code, "New Code and expected code do Not match.");
            Assert.That(editnewDescription == description, "New Description and expected code do Not match.");

        }


        [Then(@"I delete a time record '([^']*)', '([^']*)', '([^']*)'")]
        public void ThenIDeleteATimeRecord(string code, string description, string price)
        {
            tmPageObject.Delete_TimeRecord(driver2, code, description,price);
        }

        [Then(@"the time record should be deleted '([^']*)', '([^']*)', '([^']*)' successfully")]
        public void ThenTheTimeRecordShouldBeDeletedSuccessfully(string code, string description, string price)
        {
            string DeletedRecordcode = tmPageObject.GetLastRecordDeleted(driver2);
            string DeletedRecordDescription = tmPageObject.GetLastRecordDeletedDescription(driver2);
            string DeletedRecordprice = tmPageObject.GetLastRecordDeletedprice(driver2);
            Assert.AreNotEqual(code, DeletedRecordcode, "Last record is equal to 'TanEdit3'.");
            Assert.AreNotEqual(description, DeletedRecordDescription, "Last record is equal to 'TanEdit3Des'.");
            Assert.AreNotEqual(price, DeletedRecordprice, "Last record is equal to '$113.00' .");

        }



    }
}
