using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

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
        [TearDown]
        public void testEnd()
        {
            driver.Quit();
        }
    }
}
