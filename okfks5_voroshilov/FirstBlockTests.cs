using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace okfks5_voroshilov
{
    public class FirstBlockTests : IDisposable
    {
        private readonly WebDriver _driver = new ChromeDriver();
        [Fact]
        public void CorrectTitle()
        {
            _driver.Url = "https://test.webmx.ru/";
            const string title = "Сервис заметок";
            Assert.Equal(title, _driver.Title);
        }


        //В ДРУГОЙ БЛОК !!!!
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

        [Fact]
        public void CorrectButton()
        {
            _driver.Url = "https://test.webmx.ru/";
            IWebElement button = _driver.FindElement(By.Id("authSubmit"));

            const string expectedText = "Войти";

            Assert.Equal(expectedText, button.Text);
        }

        [Fact]
        public void CorrectButtonAfterClickRegBtn()
        {
            _driver.Url = "https://test.webmx.ru/";
            IWebElement switchBtn = _driver.FindElement(By.Id("registerTab"));
            switchBtn.Click();
            IWebElement button = _driver.FindElement(By.Id("authSubmit"));

            const string expectedText = "Зарегистрироваться";

            Assert.Equal(expectedText, button.Text);
        }

        public void Dispose()
        {
            _driver.Close();
        }
    }
}