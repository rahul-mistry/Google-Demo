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

           
            string txtSearch = "Hello world";


            IWebElement FName = new Common(_driver).FindElementWithDynamicWait(_driver, By.XPath(".//*[@id='gs_htif0']"), "'Search' textbox on Google page.");        

            Common.enterText(FName, txtSearch);

            IWebElement Search_btn = new Common(_driver).FindElementClick(By.XPath("//input[@value='Google Search']"));

        }

    }
}
