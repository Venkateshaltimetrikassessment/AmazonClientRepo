using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Bindings;
using SpecFlowProject1.PageClass;
using System.Runtime.InteropServices;
using OpenQA.Selenium;
using Microsoft.VisualBasic.FileIO;

namespace SpecFlowProject1.StepDefinitions
{
    [Binding]
    public class AmazonStepDefinitions : SpecflowBaseTest
    {
        private AmazonPage _amazonPage { get; }
        private AmazonProductPage _aProductPage { get; }
        private AmazonCartPage _aCartPage { get; }
        //protected IWebDriver Driver;

        public AmazonStepDefinitions(AmazonPage amazonPage, AmazonProductPage amazonProductPage, AmazonCartPage amazonCartPage, IWebDriver driver) : base(driver)
        {
            //Driver = driver;
            this._amazonPage = amazonPage;
            this._aProductPage = amazonProductPage;
            this._aCartPage = amazonCartPage;
        }
        [Given(@"navigate to amazon portal")]
        public void GivenNavigateToAmazonPortal()
        {
            _amazonPage.NavigateToAmazon();
        }

        [Given(@"validate amazon log")]
        public void GivenValidateAmazonLog()
        {
            _amazonPage.ValidateAmazonLog();
        }

        [Given(@"select the Humburger menu button")]
        public void GivenSelectTheHumburgerMenuButton()
        {
            _amazonPage.SelectHumburgerMenu();
        }
        [When(@"search the (.*)")]
        public void WhenSearchThe(string Products)
        {
            _amazonPage.SearchProduct(Products);
        }

        [Then(@"validate the (.*)")]
        public void ThenValidateThePhone(string Products)
        {
            _aProductPage.ValidateResultInfoBar(Products);
        }
        [Given(@"search for a product")]
        public void AndSearchForAProduct()
        {
            _amazonPage.SearchForAProduct();
        }
        [Given(@"select the first product")]
        public void AndSelectTheFirstProduct()
       {
            _aProductPage.SelectFirstProduct();
        }
        [When(@"click add to cart button")]
        public void WhenClickAddToCartButton()
        {
            _aCartPage.ClickAddtoCartButton();
        }
        [Then(@"validate product added to the cart")]
        public void ThenValidateProductAddedToTheCart()
        {
            _aCartPage.ValidateProductAddedCart();
        }
        [Then(@"validate log is present under Topcategories section")]
        public void ThenValidateLogIsPresentUnderTopcategoriesSection()
        {
            _aProductPage.ValidateCategoriesLog();
        }
        [When(@"select mainoption '([^']*)'")]
        public void WhenSelectMainoption(string mainopt)
        {
            _amazonPage.SelectMainOption(mainopt);
        }

        [When(@"select suboption '([^']*)'")]
        public void WhenSelectSuboption(string subopt)
        {
            _amazonPage.SelectSubOption(subopt);
        }


    }
}
