using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Reflection;
using System.Threading;

namespace Appsmith
{
    public class Tests
    {
        public IWebDriver _driver { get; set; }
        
        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            //_driver.Url = "https://google.com";
            _driver.Navigate().GoToUrl("https://google.com");

        }

        [Test]
        public void LaunchApp()
        {
            var title = _driver.Title;
            Assert.AreEqual("Google", title);
        }
        [Test]
        public void SearchIbomma()
        {
            _driver.FindElement(By.XPath("//*[@type='text']")).SendKeys("ibomma");
            var ele = _driver.FindElements(By.XPath("//input[@value='Google Search']"));
            ele[1].SendKeys(Keys.Enter);
            Assert.AreEqual("ibomma - Google Search", _driver.Title);
            Thread.Sleep(3000);
        }

        [Test]

        public void IbommaHomePage()
        {
            _driver.Manage().Window.Maximize();
            _driver.FindElement(By.XPath("//*[@type='text']")).SendKeys("ibomma");
            var ele = _driver.FindElements(By.XPath("//input[@value='Google Search']"));
            ele[1].SendKeys(Keys.Enter);
            _driver.FindElement(By.XPath("//h3[contains(text(),'iBOMMA - Watch Telugu Movies Online & FREE Download')]")).Click();
            _driver.FindElement(By.XPath("//button[contains(text(),'INDIA')]")).Click();
            _driver.FindElement(By.XPath("//div[@id='content']/descendant::div[4]/descendant::article[1]")).Click();
        }

        [TearDown]

        public void Teardown()
        {
            _driver.Close();
            _driver.Quit();

        }
    }
}