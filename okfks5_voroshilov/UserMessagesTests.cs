using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace okfks5_voroshilov
{
    public class UserMessagesTests : IDisposable
    {
        private const string login = "testFor7";
        private const string password = "P@ssw0rd";

        private readonly WebDriver _driver = new ChromeDriver();

        //сообщение при проверки на значение из пробелов в логине
        [Fact]
        public void AlertAfterEmptyLogin()
        {
            _driver.Url = "https://test.webmx.ru/";

            string _login = "         ";
            string _password = "123456";

            IWebElement switchBtn = _driver.FindElement(By.Id("registerTab"));
            switchBtn.Click();

            IWebElement inputLogin = _driver.FindElement(By.Id("authUsername"));
            inputLogin.SendKeys(_login);

            IWebElement inputPassword = _driver.FindElement(By.Id("authPassword"));
            inputPassword.SendKeys(_password);

            IWebElement registerButton = _driver.FindElement(By.Id("authSubmit"));
            registerButton.Click();

            Thread.Sleep(100);

            IWebElement message = _driver.FindElement(By.Id("message"));
            const string expectedText = "Логин должен быть не короче 3 символов.";

            Assert.Contains(expectedText, message.Text);
        }

        //сообщение при добавлении пустого заголовка
        [Fact]
        public void AddNoteWithEmptyTitle()
        {
            _driver.Url = "https://test.webmx.ru/";

            const string titleInputText = "         ";

            IWebElement inputLogin = _driver.FindElement(By.Id("authUsername"));
            IWebElement inputPassword = _driver.FindElement(By.Id("authPassword"));

            inputLogin.SendKeys(login);
            inputPassword.SendKeys(password);

            IWebElement loginBtn = _driver.FindElement(By.Id("authSubmit"));
            loginBtn.Click();

            Thread.Sleep(500);

            IWebElement titleInput = _driver.FindElement(By.Id("noteTitle"));
            titleInput.SendKeys(titleInputText);

            IWebElement saveBtn = _driver.FindElement(By.Id("saveBtn"));
            saveBtn.Click();

            Thread.Sleep(200);

            IWebElement message = _driver.FindElement(By.Id("message"));

            string expectedText = "Заполните заголовок заметки.";

            Assert.Contains(expectedText, message.Text);

        }

        //сообщение после выхода
        [Fact]
        public void CorrectLogout()
        {
            _driver.Url = "https://test.webmx.ru/";

            const string _login = "dadaaa";
            const string _password = "123456";

            IWebElement inputLogin = _driver.FindElement(By.Id("authUsername"));
            IWebElement inputPassword = _driver.FindElement(By.Id("authPassword"));

            inputLogin.SendKeys(_login);
            inputPassword.SendKeys(_password);

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

        //сообщение при проверке на неверный пароль 
        [Fact]
        public void IncorrectPassword()
        {
            _driver.Url = "https://test.webmx.ru/";

            const string _login = "alvo";
            const string _password = "3333333333333333";

            IWebElement inputLogin = _driver.FindElement(By.Id("authUsername"));

            inputLogin.SendKeys(_login);

            IWebElement inputPassword = _driver.FindElement(By.Id("authPassword"));

            inputPassword.SendKeys(_password);

            IWebElement loginBtn = _driver.FindElement(By.Id("authSubmit"));

            loginBtn.Click();

            Thread.Sleep(500);

            IWebElement message = _driver.FindElement(By.Id("message"));
            const string expectedText = "Неверный логин или пароль.";

            Assert.Contains(expectedText, message.Text);
        }

        //сообщение при проверке на неверный логин 
        [Fact]
        public void IncorrectLogin()
        {
            _driver.Url = "https://test.webmx.ru/";

            const string _login = "alvoooooooo";
            const string _password = "123456";

            IWebElement inputLogin = _driver.FindElement(By.Id("authUsername"));

            inputLogin.SendKeys(_login);

            IWebElement inputPassword = _driver.FindElement(By.Id("authPassword"));

            inputPassword.SendKeys(_password);

            IWebElement loginBtn = _driver.FindElement(By.Id("authSubmit"));

            loginBtn.Click();

            Thread.Sleep(400);

            IWebElement message = _driver.FindElement(By.Id("message"));
            const string expectedText = "Неверный логин или пароль.";

            Assert.Contains(expectedText, message.Text);
        }

        //сообщение при создании заметки
        [Fact]
        public void NoteCreatedMessage()
        {
            _driver.Url = "https://test.webmx.ru/";

            const string titleInputText = "created msg";

            IWebElement inputLogin = _driver.FindElement(By.Id("authUsername"));

            inputLogin.SendKeys(login);

            IWebElement inputPassword = _driver.FindElement(By.Id("authPassword"));

            inputPassword.SendKeys(password);

            IWebElement loginBtn = _driver.FindElement(By.Id("authSubmit"));

            loginBtn.Click();

            Thread.Sleep(500);

            IWebElement titleInput = _driver.FindElement(By.Id("noteTitle"));
            titleInput.SendKeys(titleInputText);

            IWebElement saveBtn = _driver.FindElement(By.Id("saveBtn"));
            saveBtn.Click();

            Thread.Sleep(200);

            IWebElement message = _driver.FindElement(By.Id("message"));
            const string expectedText = "Заметка создана.";

            Assert.Contains(expectedText, message.Text);
        }

        //сообщение при удалении заметки
        [Fact]
        public void NoteDeleteMessage()
        {
            _driver.Url = "https://test.webmx.ru/";

            const string titleInputText = "deleted msg";

            IWebElement inputLogin = _driver.FindElement(By.Id("authUsername"));

            inputLogin.SendKeys(login);

            IWebElement inputPassword = _driver.FindElement(By.Id("authPassword"));

            inputPassword.SendKeys(password);

            IWebElement loginBtn = _driver.FindElement(By.Id("authSubmit"));

            loginBtn.Click();

            Thread.Sleep(500);

            IWebElement titleInput = _driver.FindElement(By.Id("noteTitle"));
            titleInput.SendKeys(titleInputText);

            IWebElement saveBtn = _driver.FindElement(By.Id("saveBtn"));
            saveBtn.Click();

            Thread.Sleep(200);

            IWebElement deleteBtn = _driver.FindElement(By.Id("deleteBtn"));
            deleteBtn.Click();

            Thread.Sleep(200);

            IAlert alert = _driver.SwitchTo().Alert();
            alert.Accept();

            Thread.Sleep(200);


            IWebElement message = _driver.FindElement(By.Id("message"));
            const string expectedText = "Заметка удалена.";

            Assert.Contains(expectedText, message.Text);
        }

        //сохранение интерфейса при отмене удаления
        [Fact]
        public void NoteNotDeleteMessage()
        {
            _driver.Url = "https://test.webmx.ru/";

            const string titleInputText = "not deleted msg";

            IWebElement inputLogin = _driver.FindElement(By.Id("authUsername"));

            inputLogin.SendKeys(login);

            IWebElement inputPassword = _driver.FindElement(By.Id("authPassword"));

            inputPassword.SendKeys(password);

            IWebElement loginBtn = _driver.FindElement(By.Id("authSubmit"));

            loginBtn.Click();

            Thread.Sleep(500);

            IWebElement titleInput = _driver.FindElement(By.Id("noteTitle"));
            titleInput.SendKeys(titleInputText);

            IWebElement saveBtn = _driver.FindElement(By.Id("saveBtn"));
            saveBtn.Click();

            Thread.Sleep(200);

            IWebElement deleteBtn = _driver.FindElement(By.Id("deleteBtn"));
            deleteBtn.Click();

            Thread.Sleep(200);

            IAlert alert = _driver.SwitchTo().Alert();
            alert.Dismiss();

            Thread.Sleep(100);

            IWebElement editorTitle = _driver.FindElement(By.Id("editorTitle"));

            string expectedText = "Редактирование заметки";

            Assert.Contains(expectedText, editorTitle.Text);
        }


        //сообщение при добавлении совместного доступа для пустого пользователя
        [Fact]
        public void NoteEmptySharedUserMessage()
        {
            _driver.Url = "https://test.webmx.ru/";

            const string titleInputText = "empty shared user msg";

            IWebElement inputLogin = _driver.FindElement(By.Id("authUsername"));

            inputLogin.SendKeys(login);

            IWebElement inputPassword = _driver.FindElement(By.Id("authPassword"));

            inputPassword.SendKeys(password);

            IWebElement loginBtn = _driver.FindElement(By.Id("authSubmit"));

            loginBtn.Click();

            Thread.Sleep(500);

            IWebElement titleInput = _driver.FindElement(By.Id("noteTitle"));
            titleInput.SendKeys(titleInputText);

            IWebElement saveBtn = _driver.FindElement(By.Id("saveBtn"));
            saveBtn.Click();

            Thread.Sleep(200);

            IWebElement shareBtn = _driver.FindElement(By.Id("shareBtn"));
            shareBtn.Click();

            Thread.Sleep(200);

            IWebElement message = _driver.FindElement(By.Id("message"));
            const string expectedText = "Укажите логин пользователя для совместного доступа.";

            Assert.Contains(expectedText, message.Text);
        }

        //сообщение при добавлении совместного доступа для несуществующего пользователя
        [Fact]
        public void NoteIncorrectSharedUserMessage()
        {
            _driver.Url = "https://test.webmx.ru/";

            const string titleInputText = "empty shared user msg";
            const string incorrectUser = "zxczxccxcxxc";

            IWebElement inputLogin = _driver.FindElement(By.Id("authUsername"));

            inputLogin.SendKeys(login);

            IWebElement inputPassword = _driver.FindElement(By.Id("authPassword"));

            inputPassword.SendKeys(password);

            IWebElement loginBtn = _driver.FindElement(By.Id("authSubmit"));

            loginBtn.Click();

            Thread.Sleep(500);

            IWebElement titleInput = _driver.FindElement(By.Id("noteTitle"));
            titleInput.SendKeys(titleInputText);

            IWebElement saveBtn = _driver.FindElement(By.Id("saveBtn"));
            saveBtn.Click();

            Thread.Sleep(200);

            IWebElement shareUser = _driver.FindElement(By.Id("shareUsername"));
            shareUser.SendKeys(incorrectUser);

            Thread.Sleep(100);

            IWebElement shareBtn = _driver.FindElement(By.Id("shareBtn"));
            shareBtn.Click();

            Thread.Sleep(200);

            IWebElement message = _driver.FindElement(By.Id("message"));
            const string expectedText = "Пользователь не найден.";

            Assert.Contains(expectedText, message.Text);
        }

        //сообщение при добавлении самого себя для совместного доступа
        [Fact]
        public void NoteMineSharedUserMessage()
        {
            _driver.Url = "https://test.webmx.ru/";

            const string titleInputText = "mine shared user msg";

            IWebElement inputLogin = _driver.FindElement(By.Id("authUsername"));

            inputLogin.SendKeys(login);

            IWebElement inputPassword = _driver.FindElement(By.Id("authPassword"));

            inputPassword.SendKeys(password);

            IWebElement loginBtn = _driver.FindElement(By.Id("authSubmit"));

            loginBtn.Click();

            Thread.Sleep(500);

            IWebElement titleInput = _driver.FindElement(By.Id("noteTitle"));
            titleInput.SendKeys(titleInputText);

            IWebElement saveBtn = _driver.FindElement(By.Id("saveBtn"));
            saveBtn.Click();

            Thread.Sleep(200);

            IWebElement shareUser = _driver.FindElement(By.Id("shareUsername"));
            shareUser.SendKeys(login);

            Thread.Sleep(100);

            IWebElement shareBtn = _driver.FindElement(By.Id("shareBtn"));
            shareBtn.Click();

            Thread.Sleep(200);

            IWebElement message = _driver.FindElement(By.Id("message"));
            const string expectedText = "Нельзя предоставить доступ самому себе.";

            Assert.Contains(expectedText, message.Text);
        }

        //сообщение при добавлении корректного пользователя
        [Fact]
        public void NoteCorrectSharedUserMessage()
        {
            _driver.Url = "https://test.webmx.ru/";

            const string titleInputText = "correct shared user msg";
            const string correctUser = "alvo";

            IWebElement inputLogin = _driver.FindElement(By.Id("authUsername"));

            inputLogin.SendKeys(login);

            IWebElement inputPassword = _driver.FindElement(By.Id("authPassword"));

            inputPassword.SendKeys(password);

            IWebElement loginBtn = _driver.FindElement(By.Id("authSubmit"));

            loginBtn.Click();

            Thread.Sleep(500);

            IWebElement titleInput = _driver.FindElement(By.Id("noteTitle"));
            titleInput.SendKeys(titleInputText);

            IWebElement saveBtn = _driver.FindElement(By.Id("saveBtn"));
            saveBtn.Click();

            Thread.Sleep(200);

            IWebElement closeBtn = _driver.FindElement(By.XPath("//*[@id=\"message\"]/button"));
            closeBtn.Click();

            Thread.Sleep(200);

            IWebElement shareUser = _driver.FindElement(By.Id("shareUsername"));
            shareUser.SendKeys(correctUser);

            Thread.Sleep(100);

            IWebElement shareBtn = _driver.FindElement(By.Id("shareBtn"));
            shareBtn.Click();

            Thread.Sleep(200);

            IWebElement message = _driver.FindElement(By.Id("message"));
            const string expectedText = "Доступ успешно выдан.";

            Assert.Contains(expectedText, message.Text);
        }

        //сообщение при отмене совместного доступа пользователям
        [Fact]
        public void NoteCancelCorrectSharedUserMessage()
        {
            _driver.Url = "https://test.webmx.ru/";

            const string titleInputText = "correct shared user cancel msg";
            const string correctUser = "alvo";

            IWebElement inputLogin = _driver.FindElement(By.Id("authUsername"));

            inputLogin.SendKeys(login);

            IWebElement inputPassword = _driver.FindElement(By.Id("authPassword"));

            inputPassword.SendKeys(password);

            IWebElement loginBtn = _driver.FindElement(By.Id("authSubmit"));

            loginBtn.Click();

            Thread.Sleep(500);

            IWebElement titleInput = _driver.FindElement(By.Id("noteTitle"));
            titleInput.SendKeys(titleInputText);

            IWebElement saveBtn = _driver.FindElement(By.Id("saveBtn"));
            saveBtn.Click();

            Thread.Sleep(200);

            IWebElement shareUser = _driver.FindElement(By.Id("shareUsername"));
            shareUser.SendKeys(correctUser);

            Thread.Sleep(100);

            IWebElement shareBtn = _driver.FindElement(By.Id("shareBtn"));
            shareBtn.Click();

            Thread.Sleep(200);

            IWebElement closeBtn = _driver.FindElement(By.XPath("//*[@id=\"message\"]/button"));
            closeBtn.Click();
            
            Thread.Sleep(200);

            IWebElement cancelBtn = _driver.FindElement(By.XPath("//*[@id=\"sharedUsersList\"]/li/button"));
            cancelBtn.Click();

            Thread.Sleep(200);

            IAlert alert = _driver.SwitchTo().Alert();
            alert.Accept();

            Thread.Sleep(200);

            IWebElement message = _driver.FindElement(By.Id("message"));
            const string expectedText = "Доступ пользователя отозван.";

            Assert.Contains(expectedText, message.Text);
        }


        //сообщение при обновлении заметки
        [Fact]
        public void NoteUpdatedMessage()
        {
            _driver.Url = "https://test.webmx.ru/";

            const string titleInputText = "updated msg";

            IWebElement inputLogin = _driver.FindElement(By.Id("authUsername"));

            inputLogin.SendKeys(login);

            IWebElement inputPassword = _driver.FindElement(By.Id("authPassword"));

            inputPassword.SendKeys(password);

            IWebElement loginBtn = _driver.FindElement(By.Id("authSubmit"));

            loginBtn.Click();

            Thread.Sleep(500);

            IWebElement titleInput = _driver.FindElement(By.Id("noteTitle"));
            titleInput.SendKeys(titleInputText);

            IWebElement saveBtn = _driver.FindElement(By.Id("saveBtn"));
            saveBtn.Click();

            Thread.Sleep(200);

            IWebElement newSaveBtn = _driver.FindElement(By.Id("saveBtn"));
            newSaveBtn.Click();

            Thread.Sleep(200);

            IWebElement message = _driver.FindElement(By.Id("message"));
            const string expectedText = "Заметка обновлена.";

            Assert.Contains(expectedText, message.Text);
        }

        public void Dispose()
        {
            _driver.Quit();
        }
    }
}
