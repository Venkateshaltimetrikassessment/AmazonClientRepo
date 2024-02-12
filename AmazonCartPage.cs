using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject1.PageClass
{
    public class AmazonCartPage : SpecflowBaseTest
    {
        public AmazonCartPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(Driver, this);
        }

        string ProductTitle_Cart;

       [FindsBy(How = How.XPath, Using = "//input[@id='add-to-cart-button']")]
        private IWebElement AddtoCartBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name='proceedToRetailCheckout']//following::a[1]")]
        private IWebElement GotoCartBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='centerCol']//span[@id='productTitle']")]
        private IWebElement ProductTitle { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[@class='a-truncate-cut']")]
        private IWebElement ProductTitleProd {  get; set; }
        public void ClickAddtoCartButton()
        {
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            ////WebDriverWait inst = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
            ////inst.PollingInterval = TimeSpan.FromMilliseconds(200);
            ////inst.Until(ExpectedConditions.ElementExists(By.Id("dp")));

            IList<string> totWindowHandles = new List<string>(Driver.WindowHandles);
            int win_count = totWindowHandles.Count;
            if (win_count > 1)
            {
                Driver.SwitchTo().Window(totWindowHandles[1]);
                ProductTitle_Cart = ProductTitle.Text;
                AddtoCartBtn.Click();
                GotoCartBtn.Click();
            }
            else
            {
                ProductTitle_Cart = ProductTitle.Text;
                AddtoCartBtn.Click();
                GotoCartBtn.Click();
            }
        }

        public void ValidateProductAddedCart()
        {
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            string ProductTitle_Prod = ProductTitleProd.Text;
            Assert.That(ProductTitle_Cart.Substring(0, 25), (Is.EqualTo(ProductTitle_Prod.Substring(0, 25))));
        }

    }
}
