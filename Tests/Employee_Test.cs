using NUnit.Framework;
using Day12SpecFlowXpath.Pages;
using Day12SpecFlowXpath.Utilities;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day12SpecFlowXpath.Tests
{
    
    [TestFixture]
    public class Employee_Test : CommonDriver
    {
        [SetUp]
        public void EmployeeSetUp()
        {
            driver1 = new ChromeDriver();
            LoginPage loginPageObj = new LoginPage();
            loginPageObj.LoginAction(driver1);
            HomePage homePageObj = new HomePage();
            homePageObj.GoToEmployeePage(driver1);
        }
        [Test, Order(1)]
        public void Create_Employee()
        {
           
            EmployeePage EmployeePageObj = new EmployeePage();

            //Create
            EmployeePageObj.Create_EmployeeRecord(driver1);
        }
        [Test, Order(2)]
        public void Edit_Employee()
        {
          
            EmployeePage EmployeePageObj = new EmployeePage();
            EmployeePageObj.Edit_EmployeeRecord(driver1);
        }
        [Test, Order(3)]
        public void Delete_Employee()
        {
           
            EmployeePage EmployeePageObj = new EmployeePage();
            EmployeePageObj.Delete_EmployeeRecord(driver1);
        }
        [TearDown]
        public void EmployeeTearDown() 
        {
            driver1.Quit();
        }

    }
}
