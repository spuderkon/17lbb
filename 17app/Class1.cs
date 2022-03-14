using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace _17app
{
    [TestFixture]
    public class Class1
    {
        IWebDriver driver = new ChromeDriver();

        [TestCase]
        public void mainTitle()
        {
            driver.Url = "https://www.spacex.com/";
            Assert.AreEqual("SpaceX",driver.Title);
        }
        [TestCase]
        public void clickRewatch()
        {
            driver.Url = "https://www.spacex.com/";
            if (IsLoaded("//*[@id=\"navigation\"]/ul/li[2]/a"))
            {
                IWebElement element = driver.FindElement(By.XPath("//*[@id=\"navigation\"]/ul/li[2]/a"));
                element.Click();
                Assert.AreEqual("https://www.spacex.com/vehicles/falcon-heavy/", driver.Url);
            }
        }
        [TestCase]
        public void chooseOption()
        {
            driver.Url = "https://www.spacex.com/";
            if (IsLoaded("//*[@id=\"hamburger\"]"))
            {
                IWebElement element = driver.FindElement(By.XPath("//*[@id=\"hamburger\"]"));
                element.Click();
                if (IsLoaded("/html/body/div[1]/div[1]/div[5]/div[2]/ul/li[7]/a"))
                {
                    IWebElement element1 = driver.FindElement(By.XPath("/html/body/div[1]/div[1]/div[5]/div[2]/ul/li[7]/a"));
                    bool status = element1.Displayed;
                    Assert.IsTrue(status);
                }
            }
        }
        [TestCase]
        public void 
        [TearDown]
        public void testEnd()
        {
          //  driver.Quit();
        }
        public bool IsLoaded(string XPath)
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));

            var element = wait.Until(condition =>
            {
                try
                {
                    var elementToBeDisplayed =
                    driver.FindElement(By.XPath(XPath));
                    return elementToBeDisplayed.Displayed;
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });
            return element;
        }
    }
}
