using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace okfks5_voroshilov
{
    public class FilterTests : IDisposable
    {
        IWebDriver _driver = new ChromeDriver();

        private const string login = "testFor5";
        private const string password = "P@ssw0rd";

        //тест поиска автора
        [Fact]
        public void TestSearchAuthor()
        {
            _driver.Url = "https://test.webmx.ru/";

            const string author = "alvo";

            IWebElement inputLogin = _driver.FindElement(By.Id("authUsername"));
            IWebElement inputPassword = _driver.FindElement(By.Id("authPassword"));

            inputLogin.SendKeys(login);
            inputPassword.SendKeys(password);

            IWebElement loginBtn = _driver.FindElement(By.Id("authSubmit"));
            loginBtn.Click();

            Thread.Sleep(500);

            IWebElement inputSearch = _driver.FindElement(By.Id("searchInput"));

            //inputSearch.SendKeys(author);

            //!!!!!!!!!!!!!
            inputSearch.SendKeys("a");
            inputSearch.SendKeys("l");
            inputSearch.SendKeys("v");
            inputSearch.SendKeys("o");

            Thread.Sleep(500);

            var notes = _driver.FindElements(By.CssSelector("#notesList li"));

            int expectedCount = 2;

            Assert.Equal(expectedCount, notes.Count());
        }
        //тест поиска заголовка
        [Fact]
        public void TestSearchTitle()
        {
            _driver.Url = "https://test.webmx.ru/";

            const string title = "first";

            IWebElement inputLogin = _driver.FindElement(By.Id("authUsername"));
            IWebElement inputPassword = _driver.FindElement(By.Id("authPassword"));

            inputLogin.SendKeys(login);
            inputPassword.SendKeys(password);

            IWebElement loginBtn = _driver.FindElement(By.Id("authSubmit"));
            loginBtn.Click();

            Thread.Sleep(500);

            IWebElement inputSearch = _driver.FindElement(By.Id("searchInput"));

            //inputSearch.SendKeys(title);

            inputSearch.SendKeys("f");
            inputSearch.SendKeys("i");
            inputSearch.SendKeys("r");
            inputSearch.SendKeys("s");
            inputSearch.SendKeys("t");

            Thread.Sleep(200);

            var notes = _driver.FindElements(By.CssSelector("#notesList li"));

            int expectedCount = 1;

            Assert.Equal(expectedCount, notes.Count());
        }

        //тест поиска описания
        [Fact]
        public void TestSearchDescription()
        {
            _driver.Url = "https://test.webmx.ru/";

            const string desc = "desc";

            IWebElement inputLogin = _driver.FindElement(By.Id("authUsername"));
            IWebElement inputPassword = _driver.FindElement(By.Id("authPassword"));

            inputLogin.SendKeys(login);
            inputPassword.SendKeys(password);

            IWebElement loginBtn = _driver.FindElement(By.Id("authSubmit"));
            loginBtn.Click();

            Thread.Sleep(500);

            IWebElement inputSearch = _driver.FindElement(By.Id("searchInput"));

            //inputSearch.SendKeys(desc);
            inputSearch.SendKeys("d");
            inputSearch.SendKeys("e");
            inputSearch.SendKeys("s");
            inputSearch.SendKeys("c");

            Thread.Sleep(200);

            var notes = _driver.FindElements(By.CssSelector("#notesList li"));

            int expectedCount = 2;

            Assert.Equal(expectedCount, notes.Count());
        }

        [Theory]
        [InlineData("mine", 3)]//мои
        [InlineData("all", 5)]//все
        [InlineData("shared", 2)]//общие
        public void TestMineNotes(string _value, int _count)
        {
            _driver.Url = "https://test.webmx.ru/";

            string value = _value;

            IWebElement inputLogin = _driver.FindElement(By.Id("authUsername"));
            IWebElement inputPassword = _driver.FindElement(By.Id("authPassword"));

            inputLogin.SendKeys(login);
            inputPassword.SendKeys(password);

            IWebElement loginBtn = _driver.FindElement(By.Id("authSubmit"));
            loginBtn.Click();

            Thread.Sleep(500);

            IWebElement combobox = _driver.FindElement(By.Id("noteScopeFilter"));
            SelectElement selectElement = new SelectElement(combobox);
            selectElement.SelectByValue(value);

            Thread.Sleep(200);

            var notes = _driver.FindElements(By.CssSelector("#notesList li"));

            int expectedCount = _count;

            Assert.Equal(expectedCount, notes.Count());
        }



        public void Dispose()
        {
            _driver.Quit();
        }
    }
}
