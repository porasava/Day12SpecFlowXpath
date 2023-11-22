using NUnit.Framework;
using Day12SpecFlowXpath.Pages;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Day12SpecFlowXpath.Utilities;

namespace Day12SpecFlowXpath.Tests
{
  //  [Parallelizable]
    [TestFixture]
    public class TM_test : CommonDriver
    {
        [SetUp]
        public void TimeSetUp()
        {
            driver2 = new ChromeDriver();
            LoginPage loginPageObj = new LoginPage();
            loginPageObj.LoginActionTM(driver2);
            HomePage homePageObj = new HomePage();
            homePageObj.GoToTMPage(driver2);
        }
        [Test,Order(1)]
        public void Create_TimeRecord() 
        {
            
            TMPage TMPageObj = new TMPage();

            //Create
            TMPageObj.Create_TimeRecord(driver2, "anything", "two","3");
        }

        [Test, Order(2)]
        public void EditTime_Test()
        {
           
            TMPage TMPageObj = new TMPage();
            TMPageObj.Update_TimeRecord(driver2, "anything", "two");
        }

        [Test, Order(3)]
        public void DeleteTime_Test()
        {
            
            TMPage TMPageObj = new TMPage();
            TMPageObj.Delete_TimeRecord(driver2, "anything", "two", "3");
        }
        [TearDown]
        public void CloseTestRun()
        {
            driver2.Quit();
        }


    }
}
