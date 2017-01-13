using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using OpenQA.Selenium.Interactions;
using Framework.Init;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Runtime.InteropServices;
using System.Reflection;

namespace Framework.PageObjects
{
    public class HomeObjects
    {
        IWebDriver _driver;
      
        public static string strFirstName;
        public static string strLastName;

        public IWebDriver Demo_MouseHover(IWebDriver driver)
        {
            _driver = driver;

            Demo_MouseHover();
           
            return _driver;
        }

        public void Demo_MouseHover()
        {
            //Windows Resizing
            Report.AddToHtmlReport("STEP 2: Enter text for the search on google page.", false, true);

           
             //IWebElement FName = new Common(_driver).FindElementWithDynamicWait(_driver, By.XPath("//a[contains(.,'Images')]"), "'Search' textbox on Google page.");

            // FName.SendKeys("Hello world");

            IWebElement Search_btn = new Common(_driver).FindElementClick(By.XPath("//a[contains(.,'Images')]"),"CLick on 'Images' link on google page.");


            _driver.Navigate().GoToUrl("http://www.msn.com/en-in/");

            new Common(_driver).pause(2000);
        }
    }
}
