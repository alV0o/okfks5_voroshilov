using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace okfks5_voroshilov
{
    public class StartAccessTests : IDisposable
    {
        private readonly WebDriver _driver = new ChromeDriver();

        //правильный заголовок
        [Fact]
        public void CorrectTitle()
        {
            _driver.Url = "https://test.webmx.ru/";
            const string title = "Сервис заметок";
            Assert.Equal(title, _driver.Title);
        }

        //правильное название кнопки
        [Fact]
        public void CorrectButton()
        {
            _driver.Url = "https://test.webmx.ru/";
            IWebElement button = _driver.FindElement(By.Id("authSubmit"));

            const string expectedText = "Войти";

            Assert.Equal(expectedText, button.Text);
        }

        //правильное название кнопки после перехода
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

        //возможность ввода текста в поле Логин
        [Fact]
        public void CorrectInputToLogin()
        {
            _driver.Url = "https://test.webmx.ru/";
            IWebElement loginInput = _driver.FindElement(By.Id("authUsername"));

            loginInput.SendKeys("test");

            const string expectedText = "test";

            Assert.Equal(expectedText, loginInput.GetAttribute("value"));
        }

        //возможность ввода текста в поле Пароль
        [Fact]
        public void CorrectInputToPassword()
        {
            _driver.Url = "https://test.webmx.ru/";
            IWebElement passwordInput = _driver.FindElement(By.Id("authPassword"));

            passwordInput.SendKeys("123456");

            const string expectedText = "123456";

            Assert.Equal(expectedText, passwordInput.GetAttribute("value"));
        }

        //проверка на значение из пробелов в логине
        [Fact]
        public void AlertAfterEmptyLogin()
        {
            _driver.Url = "https://test.webmx.ru/";
            IWebElement switchBtn = _driver.FindElement(By.Id("registerTab"));
            switchBtn.Click();
            
            IWebElement inputLogin = _driver.FindElement(By.Id("authUsername"));
            inputLogin.SendKeys("     ");

            IWebElement inputPassword = _driver.FindElement(By.Id("authPassword"));
            inputPassword.SendKeys("123456");

            IWebElement registerButton = _driver.FindElement(By.Id("authSubmit"));
            registerButton.Click();

            Thread.Sleep(100);

            IWebElement message = _driver.FindElement(By.Id("message"));
            const string expectedText = "Логин должен быть не короче 3 символов.";

            Assert.Contains(expectedText, message.Text);
        }

        //проверка на значение из пробелов в пароле
        //СПРОСИТЬ КАК ОФОРМИТЬ !!!!
        [Fact]
        public void AlertAfterEmptyPassword()
        {
            _driver.Url = "https://test.webmx.ru/";
            IWebElement switchBtn = _driver.FindElement(By.Id("registerTab"));
            switchBtn.Click();

            IWebElement inputLogin = _driver.FindElement(By.Id("authUsername"));
            inputLogin.SendKeys("test23");

            IWebElement inputPassword = _driver.FindElement(By.Id("authPassword"));
            inputPassword.SendKeys("       ");

            IWebElement registerButton = _driver.FindElement(By.Id("authSubmit"));
            registerButton.Click();

            Thread.Sleep(100);

            IWebElement message = _driver.FindElement(By.Id("message"));
            const string expectedText = "Пароль должен быть не короче 3 символов.";

            Assert.Contains(expectedText, message.Text);
        }

        //проверка на неверный пароль 
        [Fact]
        public void IncorrectPassword()
        {
            _driver.Url = "https://test.webmx.ru/";
            IWebElement inputLogin = _driver.FindElement(By.Id("authUsername"));

            inputLogin.SendKeys("alvo");

            IWebElement inputPassword = _driver.FindElement(By.Id("authPassword"));

            inputPassword.SendKeys("333333333");

            IWebElement loginBtn = _driver.FindElement(By.Id("authSubmit"));

            loginBtn.Click();

            Thread.Sleep(500);

            IWebElement message = _driver.FindElement(By.Id("message"));
            const string expectedText = "Неверный логин или пароль.";

            Assert.Contains(expectedText, message.Text);
        }

        //проверка на неверный логин 
        [Fact]
        public void IncorrectLogin()
        {
            _driver.Url = "https://test.webmx.ru/";
            IWebElement inputLogin = _driver.FindElement(By.Id("authUsername"));

            inputLogin.SendKeys("alvooooo");

            IWebElement inputPassword = _driver.FindElement(By.Id("authPassword"));

            inputPassword.SendKeys("123456");

            IWebElement loginBtn = _driver.FindElement(By.Id("authSubmit"));

            loginBtn.Click();

            Thread.Sleep(100);

            IWebElement message = _driver.FindElement(By.Id("message"));
            const string expectedText = "Неверный логин или пароль.";

            Assert.Contains(expectedText, message.Text);
        }

        public void Dispose()
        {
            _driver.Quit();
        }
    }
}