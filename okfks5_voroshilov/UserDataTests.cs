using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace okfks5_voroshilov
{
    public class UserDataTests : IDisposable
    {

        private readonly WebDriver _driver = new ChromeDriver();

        //добавление элемента только с заголовком
        [Fact]
        public void AddNoteWithOnlyTitle()
        {
            const string login = "testFor4";
            const string password = "P@ssw0rd";

            _driver.Url = "https://test.webmx.ru/";

            const string titleInputText = "testInputOnlyTitle";

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
            
            var notes = _driver.FindElements(By.CssSelector("#notesList li"));

            string expectedTitle = "testInputOnlyTitle";

            Assert.Contains(expectedTitle, notes[0].Text);
        }

        //добавление элемента с заголовком и описанием
        [Fact]
        public void AddNoteWithTitleAndDescription()
        {
            const string login = "testFor4v2";
            const string password = "P@ssw0rd";

            _driver.Url = "https://test.webmx.ru/";

            const string titleInputText = "testInputTitleAndDesc";
            const string descInputText = "title plus desc";

            IWebElement inputLogin = _driver.FindElement(By.Id("authUsername"));
            IWebElement inputPassword = _driver.FindElement(By.Id("authPassword"));

            inputLogin.SendKeys(login);
            inputPassword.SendKeys(password);

            IWebElement loginBtn = _driver.FindElement(By.Id("authSubmit"));
            loginBtn.Click();

            Thread.Sleep(500);

            IWebElement titleInput = _driver.FindElement(By.Id("noteTitle"));
            titleInput.SendKeys(titleInputText);

            IWebElement descInput = _driver.FindElement(By.Id("noteContent"));
            descInput.SendKeys(descInputText);

            IWebElement saveBtn = _driver.FindElement(By.Id("saveBtn"));
            saveBtn.Click();

            Thread.Sleep(200);

            _driver.Navigate().Refresh();

            Thread.Sleep(200);

            var notes = _driver.FindElements(By.CssSelector("#notesList li"));

            notes[0].Click();

            IWebElement checkTitleInput = _driver.FindElement(By.Id("noteTitle"));
            IWebElement checkDescInput = _driver.FindElement(By.Id("noteContent"));

            const string expectedTitle = "testInputTitleAndDesc";
            const string expectedDesc = "title plus desc";


            Assert.Multiple(() =>
            {
                Assert.Contains(expectedTitle, checkTitleInput.GetAttribute("value"));
                Assert.Contains(expectedDesc, checkDescInput.GetAttribute("value"));
            });
        }

        //удаление заметки
        [Fact]
        public void DeleteNote()
        {
            const string login = "testFor4v3";
            const string password = "P@ssw0rd";

            _driver.Url = "https://test.webmx.ru/";

            const string titleInputText = "testInputForDelete";

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

            IWebElement deleteBtn = _driver.FindElement(By.Id("deleteBtn"));
            deleteBtn.Click();

            Thread.Sleep(500);

            IAlert alert = _driver.SwitchTo().Alert();
            alert.Accept();

            Thread.Sleep(200);

            var notes = _driver.FindElements(By.CssSelector("#notesList li"));

            string expectedTitle = "testInputForDelete";

            Assert.DoesNotContain(expectedTitle, notes[0].Text);
        }

        //редактирование с сохранением по кнопке
        [Fact]
        public void EditNoteWithSaveButton()
        {
            const string login = "testFor4v4";
            const string password = "P@ssw0rd";

            _driver.Url = "https://test.webmx.ru/";

            const string titleInputText = "testInputEditSave";
            const string descInputText = "testInputEditSave in desc";

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

            var notes = _driver.FindElements(By.CssSelector("#notesList li"));

            notes[0].Click();

            IWebElement descInput = _driver.FindElement(By.Id("noteContent"));
            descInput.SendKeys(descInputText);

            saveBtn.Click();

            Thread.Sleep(500);

            var newNotes = _driver.FindElements(By.CssSelector("#notesList li"));

            newNotes[0].Click();

            IWebElement checkTitleInput = _driver.FindElement(By.Id("noteTitle"));
            IWebElement checkDescInput = _driver.FindElement(By.Id("noteContent"));

            string expectedTitle = "testInputEditSave";
            string expectedDesc = "testInputEditSave in desc";

            Assert.Multiple(() =>
            {
                Assert.Contains(expectedTitle, checkTitleInput.GetAttribute("value"));
                Assert.Contains(expectedDesc, checkDescInput.GetAttribute("value"));
            });
        }

        //редактирование БЕЗ сохранения по кнопке
        [Fact]
        public void EditNoteWithoutSaveButton()
        {
            const string login = "testFor4v4";
            const string password = "P@ssw0rd";

            _driver.Url = "https://test.webmx.ru/";

            const string titleInputText = "testInputEditSave";
            const string descInputText = "testInputEditSave in desc";

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

            var notes = _driver.FindElements(By.CssSelector("#notesList li"));

            notes[0].Click();

            IWebElement descInput = _driver.FindElement(By.Id("noteContent"));
            descInput.SendKeys(descInputText);

            var newNotes = _driver.FindElements(By.CssSelector("#notesList li"));

            newNotes[0].Click();

            IWebElement checkTitleInput = _driver.FindElement(By.Id("noteTitle"));
            IWebElement checkDescInput = _driver.FindElement(By.Id("noteContent"));

            string expectedTitle = "testInputEditSave";
            string expectedDesc = "testInputEditSave in desc";

            Assert.Multiple(() =>
            {
                Assert.Contains(expectedTitle, checkTitleInput.GetAttribute("value"));
                Assert.DoesNotContain(expectedDesc, checkDescInput.GetAttribute("value"));
            });
        }

        //добавление пустого заголовка
        [Fact]
        public void AddNoteWithEmptyTitle()
        {
            const string login = "testFor4";
            const string password = "P@ssw0rd";

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

        public void Dispose()
        {
            _driver.Quit();
        }
    }
}
