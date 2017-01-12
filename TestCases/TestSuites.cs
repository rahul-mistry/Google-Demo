using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.Init;
using NUnit.Framework;
using TestCases;

namespace TestCases
{
    [TestFixture]

    public class TestSuites
    {

        static bool IsTestFinished;
        static Int32 intLoginPassCnt = 0;
        static Int32 intLoginFailCnt = 0;
        static Int32 intLoginWarningCnt = 0;

        public TestSuites()
        {
            Report.sbHtml = null;
            Report.sbSummaryHtml = null;
            IsTestFinished = true;
            intLoginPassCnt = 0;
            intLoginFailCnt = 0;

            Report.TCcnt = 1;
            Report.IsPassed = 0;


            Home.IsTcAdded = false;
            Report.IsHeaderUpdated = false;
            Report.sbTcHtml = null;
            Report.sbFeatureHtml = null;

        }
        
        [TestFixtureSetUp]
        public void Init()
        {
            DateTime strDtTm = DateTime.Now;
            Report.strPath = AppDomain.CurrentDomain.BaseDirectory + "\\Report\\" + strDtTm.ToString("ddMMMyyyy_HH-mm") + "\\";
        }

        #region "DemoQa"

        [Test]
        public void Demo_MouseHover()
        {
            try
            {
                waitForPrevTestToFinish();
                IsTestFinished = false;
                Home objHome = new Home();
                objHome.Demo_MouseHover();
            }
            finally
            {
                Report.AddToHtmlReportFeatureFinish();
                Report.GenerateHtmlReport();
                IsTestFinished = true;
                if (Report.IsFtrPassed == 1) intLoginPassCnt++;
                else if (Report.IsFtrPassed == 2) intLoginFailCnt++;
                else if (Report.IsFtrPassed == 3) intLoginWarningCnt++;
                Home.IsTcAdded = true;

            }

        }

        #endregion

         [TestFixtureTearDown]
        public void zzzGenerateSummaryReport()
        {
            try
            {
                Report.AddToHtmlSummaryReport("Gmail Test Cases", intLoginPassCnt, intLoginFailCnt, intLoginWarningCnt);
                Report.AddToHtmlSummaryReportTotal();
                Report.GenerateHtmlSummaryReport();
            }
            finally
            {
                Report._intPassedCnt = 0;
                Report._intFailedCnt = 0;
                Report._inTotalCnt = 0;
            }
        }

        private void waitForPrevTestToFinish()
        {
            while (true)
            {
                if (!IsTestFinished) Common.pauseStatic(2000);
                else break;
            }
        }
    }




}
