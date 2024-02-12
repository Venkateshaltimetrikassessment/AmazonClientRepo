using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SpecFlowProject1
{
    [Binding]
    public class SpecflowBaseTest : TechTalk.SpecFlow.Steps
    {
        protected IWebDriver Driver { get; }

        public SpecflowBaseTest(IWebDriver driver)
        {
            Driver = driver;
        }

        //public void NavigateToURL(string URL)
        //{
        //    Driver.Navigate().GoToUrl(URL);
        //}
    }
}
