using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace okfks5_voroshilov
{
    public class UserAccessTests : IDisposable
    {
        private readonly WebDriver _driver = new ChromeDriver();
        private const string login = "testFor6";
        private const string password = "P@ssw0rd";

        //включенность кнопки при редактировании своей заметки
        [Fact]
        public void CheckButtonInMineNote()
        {
            _driver.Url = "https://test.webmx.ru/";

            IWebElement inputLogin = _driver.FindElement(By.Id("authUsername"));
            IWebElement inputPassword = _driver.FindElement(By.Id("authPassword"));

            inputLogin.SendKeys(login);
            inputPassword.SendKeys(password);

            IWebElement loginBtn = _driver.FindElement(By.Id("authSubmit"));
            loginBtn.Click();

            Thread.Sleep(500);

            var notes = _driver.FindElements(By.CssSelector("#notesList li"));

            notes[0].Click();

            Thread.Sleep(200);

            IWebElement deleteBtn = _driver.FindElement(By.Id("deleteBtn"));

            Assert.True(deleteBtn.Enabled);
        }


        //отключенность кнопки при редактировании общей заметки
        [Fact]
        public void CheckButtonInSharedNote()
        {
            _driver.Url = "https://test.webmx.ru/";

            IWebElement inputLogin = _driver.FindElement(By.Id("authUsername"));
            IWebElement inputPassword = _driver.FindElement(By.Id("authPassword"));

            inputLogin.SendKeys(login);
            inputPassword.SendKeys(password);

            IWebElement loginBtn = _driver.FindElement(By.Id("authSubmit"));
            loginBtn.Click();

            Thread.Sleep(500);

            var notes = _driver.FindElements(By.CssSelector("#notesList li"));

            notes[1].Click();

            Thread.Sleep(200);

            IWebElement deleteBtn = _driver.FindElement(By.Id("deleteBtn"));

            Assert.False(deleteBtn.Enabled);
        }


        //включенность блока для добавления участников
        [Fact]
        public void CheckShareBlockInMineNote()
        {
            _driver.Url = "https://test.webmx.ru/";

            IWebElement inputLogin = _driver.FindElement(By.Id("authUsername"));
            IWebElement inputPassword = _driver.FindElement(By.Id("authPassword"));

            inputLogin.SendKeys(login);
            inputPassword.SendKeys(password);

            IWebElement loginBtn = _driver.FindElement(By.Id("authSubmit"));
            loginBtn.Click();

            Thread.Sleep(500);

            var notes = _driver.FindElements(By.CssSelector("#notesList li"));

            notes[0].Click();

            Thread.Sleep(200);

            IWebElement shareBlock = _driver.FindElement(By.Id("shareBlock"));

            Thread.Sleep(200);

            string classes = shareBlock.GetAttribute("class");
            string expectedClass = "hidden";

            Assert.DoesNotContain(expectedClass, classes);
        }

        //отключенность блока для добавления участников
        [Fact]
        public void CheckShareBlockInSharedNote()
        {
            _driver.Url = "https://test.webmx.ru/";

            IWebElement inputLogin = _driver.FindElement(By.Id("authUsername"));
            IWebElement inputPassword = _driver.FindElement(By.Id("authPassword"));

            inputLogin.SendKeys(login);
            inputPassword.SendKeys(password);

            IWebElement loginBtn = _driver.FindElement(By.Id("authSubmit"));
            loginBtn.Click();

            Thread.Sleep(500);

            var notes = _driver.FindElements(By.CssSelector("#notesList li"));

            notes[1].Click();

            Thread.Sleep(200);

            IWebElement shareBlock = _driver.FindElement(By.Id("shareBlock"));

            Thread.Sleep(200);

            string classes = shareBlock.GetAttribute("class");
            string expectedClass = "hidden";

            Assert.Contains(expectedClass, classes);
        }


        public void Dispose()
        {
            _driver.Quit();
        }
    }
}
