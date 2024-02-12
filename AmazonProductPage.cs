using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SpecFlowProject1.PageClass
{
    [Binding]
    public class AmazonProductPage : SpecflowBaseTest
    {
        public AmazonProductPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(Driver, this);
        }
        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'results for')]//following::span[2]")]
        private IWebElement PhoneText { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'results for')]//following::span[2]")]
        private IWebElement ToyText { get; set; }

        [FindsBy(How = How.XPath, Using = "//strong[contains(text(),'Top categories')]//following::div[@class='bxc-grid__row   bxc-grid__row--light  '][1]")]
        private IWebElement TopLogo { get; set; }
        public void ValidateResultInfoBar(string Product)
        {
            if (Product == "phone")
            {
                string actualresult = PhoneText.Text;
                string actualresult1 = Regex.Replace(actualresult, "[^0-9A-Za-z _-]", "");
                Assert.That(Product, (Is.EqualTo(actualresult1)));
            }
            else
            {
                string actualresult = ToyText.Text;
                string actualresult1 = Regex.Replace(actualresult, "[^0-9A-Za-z _-]", "");
                Assert.That(Product, (Is.EqualTo(actualresult1)));
            }
        }

        public void SelectFirstProduct()
        {
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            List<IWebElement> prod = Driver.FindElements(By.XPath("//span[@class='a-price-symbol']")).ToList();
            //int prod_count = prod.Count;
            foreach (var p in prod)
            {
                p.Click();
                break;
            }
        }
        public void ValidateCategoriesLog()
        {
            bool Topcat = TopLogo.Displayed;
            Assert.That(Topcat);
        }
    }
}
