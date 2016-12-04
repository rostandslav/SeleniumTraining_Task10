using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using System.Collections;
using System.Collections.Generic;


namespace CheckOpeningCorrectProductPageProject
{
    [TestClass]
    public class UnitTest1
    {
        private IWebDriver driver;
        private WebDriverWait wait;


        [TestInitialize]
        public void Init()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
        }


        [TestMethod]
        public void CheckOpeningCorrectProductPage()
        {
            driver.Url = "http://litecart/";

            string campaingsProductsSelector = "#box-campaigns ul";
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(campaingsProductsSelector)));
            var firstCampaingsProduct = driver.FindElement(By.CssSelector(campaingsProductsSelector + " li:first-of-type")); // первый товар в Campaigns

            string name = firstCampaingsProduct.FindElement(By.CssSelector(".name")).Text; // название товара

            var regularPrice = firstCampaingsProduct.FindElement(By.CssSelector(".regular-price")); // обычная цена
            string regularPriceText = regularPrice.Text; // цена
            string regularPriceColor = regularPrice.GetCssValue("color"); // цвет текста
            string regularPriceTextDecoration = regularPrice.GetCssValue("text-decoration"); // зачеркнут ли текст
            string regularPriceFontSize = regularPrice.GetCssValue("font-size"); // размер шрифта
            //string regularPriceClassName = regularPrice.GetAttribute("className"); // класс

            var campaignPrice = firstCampaingsProduct.FindElement(By.CssSelector(".campaign-price")); // цена по акции
            string campaignPriceText = campaignPrice.Text; // цена
            string campaignPriceColor = campaignPrice.GetCssValue("color"); // цвет текста
            string campaignPriceTextDecoration = campaignPrice.GetCssValue("text-decoration"); // зачеркнут ли текст
            string campaignPriceFontSize = campaignPrice.GetCssValue("font-size"); // размер шрифта
            //string campaignPriceClassName = campaignPrice.GetAttribute("className"); // класс


            firstCampaingsProduct.FindElement(By.CssSelector("a.link")).Click(); // переход на страницу товара


            string productPageInfoSelector = "#box-product";
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(productPageInfoSelector)));
            var productPageInfo = driver.FindElement(By.CssSelector(productPageInfoSelector));

            string productPageName = productPageInfo.FindElement(By.CssSelector("h1.title")).Text; // название товара на его странице

            var productPageRegularPrice = productPageInfo.FindElement(By.CssSelector(".regular-price")); // обычная цена на странице товара
            string productPageRegularPriceText = productPageRegularPrice.Text; // цена на странице товара
            string productPageRegularPriceColor = productPageRegularPrice.GetCssValue("color"); // цвет текста на странице товара
            string productPageRegularPriceTextDecoration = productPageRegularPrice.GetCssValue("text-decoration"); // зачеркнут ли текст на странице товара
            string productPageRegularPriceFontSize = productPageRegularPrice.GetCssValue("font-size"); // размер шрифта на странице товара
            //string productPageRegularPriceClassName = productPageRegularPrice.GetAttribute("className"); // класс на странице товара

            var productPageCampaignPrice = productPageInfo.FindElement(By.CssSelector(".campaign-price")); // цена по акции
            string productPageCampaignPriceText = productPageCampaignPrice.Text; // цена
            string productPageCampaignPriceColor = productPageCampaignPrice.GetCssValue("color"); // цвет текста
            string productPageCampaignPriceTextDecoration = productPageCampaignPrice.GetCssValue("text-decoration"); // зачеркнут ли текст
            string productPageCampaignPriceFontSize = productPageCampaignPrice.GetCssValue("font-size"); // размер шрифта
            //string productPageCampaignPriceClassName = productPageCampaignPrice.GetAttribute("className"); // класс


            // проверки

            Assert.AreEqual(name, productPageName, "Ожидаемое ('{0}') и фактическое ('{1}') названия товара на страницах отличаются!", name, productPageName);


            string expectedRegularPriceColor = "rgba(119, 119, 119, 1)";
            string expectedProductPageRegularPriceColor = "rgba(102, 102, 102, 1)";
            string expectedRegularPriceTextDecoration = "line-through";
            string expectedRegularPriceFontSize = "14.4px";
            string expectedProductPageRegularPriceFontSize = "16px";

            Assert.AreEqual(regularPriceText, productPageRegularPriceText, "Ожидаемое ('{0}') и фактическое ('{1}') значения обычной цены товара на страницах отличаются!", regularPriceText, productPageRegularPriceText);
            Assert.AreEqual(regularPriceColor, expectedRegularPriceColor, "Ожидаемый ('{0}') и фактический ('{1}') цвета обычной цены товара на главной странице отличаются!", regularPriceColor, expectedRegularPriceColor);
            Assert.AreEqual(productPageRegularPriceColor, expectedProductPageRegularPriceColor, "Ожидаемый ('{0}') и фактический ('{1}') цвета обычной цены товара на его странице отличаются!", productPageRegularPriceColor, expectedProductPageRegularPriceColor);
            Assert.AreEqual(regularPriceTextDecoration, expectedRegularPriceTextDecoration, "Ожидаемый ('{0}') и фактический ('{1}') стили обычной цены товара на главной странице отличаются!", regularPriceTextDecoration, expectedRegularPriceTextDecoration);
            Assert.AreEqual(productPageRegularPriceTextDecoration, expectedRegularPriceTextDecoration, "Ожидаемый ('{0}') и фактический ('{1}') стили обычной цены товара на его странице отличаются!", productPageRegularPriceTextDecoration, expectedRegularPriceTextDecoration);
            Assert.AreEqual(regularPriceFontSize, expectedRegularPriceFontSize, "Ожидаемый ('{0}') и фактический ('{1}') размеры обычной цены товара на главной странице отличаются!", regularPriceFontSize, expectedRegularPriceFontSize);
            Assert.AreEqual(productPageRegularPriceFontSize, expectedProductPageRegularPriceFontSize, "Ожидаемый ('{0}') и фактический ('{1}') размеры обычной цены товара на его странице отличаются!", regularPriceFontSize, expectedProductPageRegularPriceFontSize);


            string expectedCampaignPriceColor = "rgba(204, 0, 0, 1)";
            string expectedProductPageCampaignPriceColor = "rgba(204, 0, 0, 1)";
            string expectedCampaignPriceTextDecoration = "none";
            string expectedCampaignPriceFontSize = "18px";
            string expectedProductPageCampaignPriceFontSize = "22px";

            Assert.AreEqual(campaignPriceText, productPageCampaignPriceText, "Ожидаемое ('{0}') и фактическое ('{1}') значения цены товара по акции на страницах отличаются!", campaignPriceText, productPageCampaignPriceText);
            Assert.AreEqual(campaignPriceColor, expectedCampaignPriceColor, "Ожидаемый ('{0}') и фактический ('{1}') цвета цены товара по акции на главной странице отличаются!", campaignPriceColor, expectedCampaignPriceColor);
            Assert.AreEqual(productPageCampaignPriceColor, expectedProductPageCampaignPriceColor, "Ожидаемый ('{0}') и фактический ('{1}') цвета цены товара по акции на его странице отличаются!", productPageCampaignPriceColor, expectedProductPageCampaignPriceColor);
            Assert.AreEqual(campaignPriceTextDecoration, expectedCampaignPriceTextDecoration, "Ожидаемый ('{0}') и фактический ('{1}') стили цены товара по акции на главной странице отличаются!", campaignPriceTextDecoration, expectedCampaignPriceTextDecoration);
            Assert.AreEqual(productPageCampaignPriceTextDecoration, expectedCampaignPriceTextDecoration, "Ожидаемый ('{0}') и фактический ('{1}') стили цены товара по акции на его странице отличаются!", productPageCampaignPriceTextDecoration, expectedCampaignPriceTextDecoration);
            Assert.AreEqual(campaignPriceFontSize, expectedCampaignPriceFontSize, "Ожидаемый ('{0}') и фактический ('{1}') размеры цены товара по акции на главной странице отличаются!", campaignPriceFontSize, expectedCampaignPriceFontSize);
            Assert.AreEqual(productPageCampaignPriceFontSize, expectedProductPageCampaignPriceFontSize, "Ожидаемый ('{0}') и фактический ('{1}') размеры цены товара по акции на его странице отличаются!", productPageCampaignPriceFontSize, expectedProductPageCampaignPriceFontSize);
        }


        [TestCleanup]
        public void Finish()
        {
            driver.Quit();
            //driver = null;
        }
    }
}
