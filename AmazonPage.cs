using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using SpecFlowProject1.StepDefinitions;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TechTalk.SpecFlow;
using System.Linq.Expressions;

namespace SpecFlowProject1.PageClass
{
    [Binding]
    public class AmazonPage : SpecflowBaseTest
    {

        public AmazonPage(IWebDriver driver) : base(driver)

        {
            //_driver = browser;
            PageFactory.InitElements(Driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//a[@id='nav-logo-sprites']")]
        private IWebElement Amazonlogo { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='twotabsearchtextbox']")]
        private IWebElement SearchBar { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'results for')]//following::span[2]")]
        private IWebElement PhoneText { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'results for')]//following::span[2]")]
        private IWebElement ToyText { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@value='Go']")]
        private IWebElement SearchBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@id='nav-hamburger-menu']")]
        private IWebElement HumburgerMenu { get; set; }

        public void NavigateToAmazon()
        {
            Driver.Navigate().GoToUrl("https://www.amazon.in/");
        }

        public void ValidateAmazonLog()
        {
            bool AmazonLogresult = Amazonlogo.Displayed;
            Assert.That(AmazonLogresult);
        }

        public void SearchProduct(string Products)
        {
            SearchBar.Click();
            SearchBar.SendKeys(Products);
            SearchBtn.Click();
        }

        public void ValidateResultInfoBar(string Product)
        {
            if(Product == "phone")
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

        public void SearchForAProduct()
        {
            SearchBar.Click();
            SearchBar.SendKeys("Toy");
            SearchBtn.Click();
        }

        public void SelectHumburgerMenu()
        {
            HumburgerMenu.Click();
        }

        public void SelectMainOption(string mainoption)
        {
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            List<IWebElement> mainoptionsele = Driver.FindElements(By.XPath("//a[@class='hmenu-item']//div[contains(text(),'" + mainoption + "')]")).ToList();
            foreach (var m in mainoptionsele)
            {
                m.Click();
                //WebElement subopt = (WebElement)suboptionsele.First();
                //Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                //subopt.Click();
                break;
            }
            //Actions actions = new Actions(Driver);
            //actions.MoveToElement(mainopt).Click().Build();
            //actions.Perform();
            //mainopt.Click();
            //List<IWebElement> mainoptionsele = Driver.FindElements(By.XPath("//ul[@class='hmenu hmenu-visible']//following::a[@data-menu-id='']")).ToList();
            //int mainoptions_count = mainoptionsele.Count;
            //for (int i = 0; i < mainoptions_count; i++)
            //{
            //    WebElement mainopt = (WebElement)mainoptionsele.First();
            //    Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            //    mainopt.Click();
            //    break;
            //}
        }

        public void SelectSubOption(string suboption)
        {
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(8);
            List<IWebElement> suboptionsele = Driver.FindElements(By.XPath("//div[contains(text(),'Mobiles, Tablets & More')]//following::a[contains(text(),'"+ suboption+"')]")).ToList();
            foreach (var s in suboptionsele)
            {   
                s.Click();
                //WebElement subopt = (WebElement)suboptionsele.First();
                //Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                //subopt.Click();
                break;
            }
        }
    }

}
