using Day12SpecFlowXpath.Pages;
using Day12SpecFlowXpath.Utilities;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Security.Policy;
using TechTalk.SpecFlow;

namespace Day12SpecFlowXpath.StepDefinitions
{
    [Binding]
    public class EmployeeFeatureStepDefinitions : CommonDriver
    {

        [Given(@"I loged into TurnUp portal successfully Driver1")]
        public void GivenILogedIntoTurnUpPortalSuccessfullyDriver1()
        {
            driver1 = new ChromeDriver();
            LoginPage loginPageObj = new LoginPage();
            loginPageObj.LoginAction(driver1);

        }
        [When(@"I navigate to employee page")]
        public void WhenINavigateToEmployeePage()
        {
            HomePage homePageObj = new HomePage();
            homePageObj.GoToEmployeePage(driver1);
        }

        [Then(@"I create a new employee record")]
        public void ThenICreateANewEmployeeRecord()
        {
            EmployeePage EmployeePageObj = new EmployeePage();

            //Create
            EmployeePageObj.Create_EmployeeRecord(driver1);
        }

        [Then(@"the employee record should be created successfully")]
        public void ThenTheEmployeeRecordShouldBeCreatedSuccessfully()
        {
            EmployeePage EmployeePageObj = new EmployeePage();
            string newEmployeeName = EmployeePageObj.GetnewEmployeeName(driver1);
            Assert.That(newEmployeeName == "EmpTanya", "Record has not been created.");
            
        }

        [Then(@"I edit a employee record")]
        public void ThenIEditAEmployeeRecord()
        {
            EmployeePage EmployeePageObj = new EmployeePage();
            EmployeePageObj.Edit_EmployeeRecord(driver1);
        }

        [Then(@"the employee record should be edited successfully")]
        public void ThenTheEmployeeRecordShouldBeEditedSuccessfully()
        {
            EmployeePage EmployeePageObj = new EmployeePage();
            string newEmployeeNameEdit = EmployeePageObj.GetnewEmployeeNameEdit(driver1);
            Assert.That(newEmployeeNameEdit == "EmpTanyaEdit", "New Code edit and expected code do Not match.");
           
        }

        [Then(@"I delete a employee record")]
        public void ThenIDeleteAEmployeeRecord()
        {
            EmployeePage EmployeePageObj = new EmployeePage();
            EmployeePageObj.Delete_EmployeeRecord(driver1);
        }

        [Then(@"the employee record should be deleted successfully")]
        public void ThenTheEmployeeRecordShouldBeDeletedSuccessfully()
        {
            EmployeePage EmployeePageObj = new EmployeePage();
            string newEmployeeNameDeleted = EmployeePageObj.GetLastRecordDeleted(driver1);
            Assert.AreNotEqual("EmpTanyaEdit", newEmployeeNameDeleted , "The record has not been delete");

        }

        //[AfterScenario]
        //public void AfterScenario()
        //{
        //    // Close or quit the WebDriver after each scenario
        //    driver1.Quit();
        //}

    }
}
