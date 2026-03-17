using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace okfks5_voroshilov
{
    public class AccountTests : IDisposable
    {
        private readonly WebDriver _driver = new ChromeDriver();

        //тест корректной авторизации и перехода в систему
        [Fact]
        public void CorrectAuthorisation()
        {
            _driver.Url = "https://test.webmx.ru/";
            IWebElement inputLogin = _driver.FindElement(By.Id("authUsername"));
            IWebElement inputPassword = _driver.FindElement(By.Id("authPassword"));

            inputLogin.SendKeys("alvo");
            inputPassword.SendKeys("123456");

            IWebElement loginBtn = _driver.FindElement(By.Id("authSubmit"));
            loginBtn.Click();

            Thread.Sleep(500);

            const string expectedWelcomeText = "Здравствуйте, alvo!";
            IWebElement _welcomeText = _driver.FindElement(By.Id("welcomeText"));

            Assert.Equal(expectedWelcomeText, _welcomeText.Text);
        }

        //тест корректного выхода из системы обратно на форму входа
        [Fact]
        public void CorrectLogout()
        {
            _driver.Url = "https://test.webmx.ru/";
            IWebElement inputLogin = _driver.FindElement(By.Id("authUsername"));
            IWebElement inputPassword = _driver.FindElement(By.Id("authPassword"));

            inputLogin.SendKeys("dadaaa");
            inputPassword.SendKeys("123456");

            IWebElement loginBtn = _driver.FindElement(By.Id("authSubmit"));
            loginBtn.Click();

            Thread.Sleep(500);

            IWebElement logoutBtn = _driver.FindElement(By.Id("logoutBtn"));
            logoutBtn.Click();

            Thread.Sleep(500);

            IWebElement message = _driver.FindElement(By.Id("message"));
            const string expectedLoginText = "Вы вышли из системы.";

            Assert.Contains(expectedLoginText, message.Text);
        }

        //изменение видимости формы после входа
        [Fact]
        public void UpdateStateAfterLogin()
        {
            _driver.Url = "https://test.webmx.ru/";
            IWebElement inputLogin = _driver.FindElement(By.Id("authUsername"));
            IWebElement inputPassword = _driver.FindElement(By.Id("authPassword"));

            inputLogin.SendKeys("alvo");
            inputPassword.SendKeys("123456");

            IWebElement loginBtn = _driver.FindElement(By.Id("authSubmit"));
            loginBtn.Click();

            Thread.Sleep(500);

            IWebElement section = _driver.FindElement(By.Id("authSection"));
            string classes = section.GetAttribute("class");
            string expectedClass = "hidden";

            Assert.Contains(expectedClass, classes);
        }

        public void Dispose()
        {
            _driver.Quit();
        }
    }
}
