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
    public class MainPlaceTests : IDisposable
    {
        private readonly WebDriver _driver = new ChromeDriver();
        //отображение и включенность кнопки новой заметки
        [Fact]
        public void CheckButtonNewNote()
        {
            _driver.Url = "https://test.webmx.ru/";

            IWebElement inputLogin = _driver.FindElement(By.Id("authUsername"));
            IWebElement inputPassword = _driver.FindElement(By.Id("authPassword"));

            inputLogin.SendKeys("alvo");
            inputPassword.SendKeys("123456");

            IWebElement loginBtn = _driver.FindElement(By.Id("authSubmit"));
            loginBtn.Click();

            Thread.Sleep(500);

            IWebElement newNoteBtn = _driver.FindElement(By.Id("newNoteBtn"));
            Assert.Multiple(() => { 
                Assert.True(newNoteBtn.Displayed); 
                Assert.True(newNoteBtn.Enabled); 
            });
        }

        //отображение и доступность поля для поиска
        [Fact]
        public void CheckSearchInput()
        {
            _driver.Url = "https://test.webmx.ru/";

            IWebElement inputLogin = _driver.FindElement(By.Id("authUsername"));
            IWebElement inputPassword = _driver.FindElement(By.Id("authPassword"));

            inputLogin.SendKeys("alvo");
            inputPassword.SendKeys("123456");

            IWebElement loginBtn = _driver.FindElement(By.Id("authSubmit"));
            loginBtn.Click();

            Thread.Sleep(500);

            IWebElement searchInput = _driver.FindElement(By.Id("searchInput"));
            
            Assert.Multiple(() => { 
                Assert.True(searchInput.Displayed); 
                Assert.True(searchInput.Enabled);
            });
        }

        //отображение и доступность фильтров поиска
        [Fact]
        public void CheckComboBox()
        {
            _driver.Url = "https://test.webmx.ru/";

            IWebElement inputLogin = _driver.FindElement(By.Id("authUsername"));
            IWebElement inputPassword = _driver.FindElement(By.Id("authPassword"));

            inputLogin.SendKeys("alvo");
            inputPassword.SendKeys("123456");

            IWebElement loginBtn = _driver.FindElement(By.Id("authSubmit"));
            loginBtn.Click();

            Thread.Sleep(500);

            IWebElement combobox = _driver.FindElement(By.Id("noteScopeFilter"));
            Assert.Multiple(() => 
            { 
                Assert.True(combobox.Displayed); 
                Assert.True(combobox.Enabled); 
            });
        }

        //отображение списка заметок
        [Fact]
        public void CheckNoteList()
        {
            _driver.Url = "https://test.webmx.ru/";

            IWebElement inputLogin = _driver.FindElement(By.Id("authUsername"));
            IWebElement inputPassword = _driver.FindElement(By.Id("authPassword"));

            inputLogin.SendKeys("alvo");
            inputPassword.SendKeys("123456");

            IWebElement loginBtn = _driver.FindElement(By.Id("authSubmit"));
            loginBtn.Click();

            Thread.Sleep(500);

            IWebElement notesList = _driver.FindElement(By.Id("notesList"));
            Assert.True(notesList.Displayed);
        }

        //отображение и допустимость поля для ввода заголовка заметки
        [Fact]
        public void CheckNoteTitleInput()
        {
            _driver.Url = "https://test.webmx.ru/";

            IWebElement inputLogin = _driver.FindElement(By.Id("authUsername"));
            IWebElement inputPassword = _driver.FindElement(By.Id("authPassword"));

            inputLogin.SendKeys("alvo");
            inputPassword.SendKeys("123456");

            IWebElement loginBtn = _driver.FindElement(By.Id("authSubmit"));
            loginBtn.Click();

            Thread.Sleep(500);

            IWebElement noteTitleInput = _driver.FindElement(By.Id("noteTitle"));
            Assert.Multiple(() =>
            {
                Assert.True(noteTitleInput.Displayed);
                Assert.True(noteTitleInput.Enabled);
            });
        }

        //отображение и допустимость поля для ввода контента заметки
        [Fact]
        public void CheckNoteContentInput()
        {
            _driver.Url = "https://test.webmx.ru/";

            IWebElement inputLogin = _driver.FindElement(By.Id("authUsername"));
            IWebElement inputPassword = _driver.FindElement(By.Id("authPassword"));

            inputLogin.SendKeys("alvo");
            inputPassword.SendKeys("123456");

            IWebElement loginBtn = _driver.FindElement(By.Id("authSubmit"));
            loginBtn.Click();

            Thread.Sleep(500);

            IWebElement noteContentInput = _driver.FindElement(By.Id("noteContent"));
            Assert.Multiple(() =>
            {
                Assert.True(noteContentInput.Displayed);
                Assert.True(noteContentInput.Enabled);
            });
        }
        //отображение и включенность кнопки сохранения
        [Fact]
        public void CheckSaveBtn()
        {
            _driver.Url = "https://test.webmx.ru/";

            IWebElement inputLogin = _driver.FindElement(By.Id("authUsername"));
            IWebElement inputPassword = _driver.FindElement(By.Id("authPassword"));

            inputLogin.SendKeys("alvo");
            inputPassword.SendKeys("123456");

            IWebElement loginBtn = _driver.FindElement(By.Id("authSubmit"));
            loginBtn.Click();

            Thread.Sleep(500);

            IWebElement saveBtn = _driver.FindElement(By.Id("saveBtn"));
            Assert.Multiple(() =>
            {
                Assert.True(saveBtn.Displayed);
                Assert.True(saveBtn.Enabled);
            });
        }

        //отображение кнопки удаления
        [Fact]
        public void CheckDeleteBtn()
        {
            _driver.Url = "https://test.webmx.ru/";

            IWebElement inputLogin = _driver.FindElement(By.Id("authUsername"));
            IWebElement inputPassword = _driver.FindElement(By.Id("authPassword"));

            inputLogin.SendKeys("alvo");
            inputPassword.SendKeys("123456");

            IWebElement loginBtn = _driver.FindElement(By.Id("authSubmit"));
            loginBtn.Click();

            Thread.Sleep(500);

            IWebElement deleteBtn = _driver.FindElement(By.Id("deleteBtn"));
            Assert.True(deleteBtn.Displayed);
        }

        //доступность кнопки удаления
        [Fact]
        public void CheckEnabledDeleteBtn()
        {
            _driver.Url = "https://test.webmx.ru/";

            IWebElement inputLogin = _driver.FindElement(By.Id("authUsername"));
            IWebElement inputPassword = _driver.FindElement(By.Id("authPassword"));

            inputLogin.SendKeys("alvo");
            inputPassword.SendKeys("123456");

            IWebElement loginBtn = _driver.FindElement(By.Id("authSubmit"));
            loginBtn.Click();

            Thread.Sleep(500);

            IWebElement note = _driver.FindElement(By.XPath("//*[@id=\"notesList\"]/li[1]"));
            note.Click();

            Thread.Sleep(500);

            IWebElement deleteBtn = _driver.FindElement(By.Id("deleteBtn"));
            Assert.True(deleteBtn.Enabled);
        }

        //Проверка изменения формы для редактирования записи
        [Fact]
        public void CheckEditNote()
        {
            _driver.Url = "https://test.webmx.ru/";

            IWebElement inputLogin = _driver.FindElement(By.Id("authUsername"));
            IWebElement inputPassword = _driver.FindElement(By.Id("authPassword"));

            inputLogin.SendKeys("alvo");
            inputPassword.SendKeys("123456");

            IWebElement loginBtn = _driver.FindElement(By.Id("authSubmit"));
            loginBtn.Click();

            Thread.Sleep(500);

            IWebElement note = _driver.FindElement(By.XPath("//*[@id=\"notesList\"]/li[1]"));
            note.Click();

            Thread.Sleep(500);

            IWebElement title = _driver.FindElement(By.Id("editorTitle"));

            const string excpectedTitle = "Редактирование заметки";
            Assert.Contains(excpectedTitle, title.Text);
        }

        //Проверка изменения формы для командного редактирования записи
        [Fact]
        public void CheckCoopEditNote()
        {
            _driver.Url = "https://test.webmx.ru/";

            IWebElement inputLogin = _driver.FindElement(By.Id("authUsername"));
            IWebElement inputPassword = _driver.FindElement(By.Id("authPassword"));

            inputLogin.SendKeys("alvo");
            inputPassword.SendKeys("123456");

            IWebElement loginBtn = _driver.FindElement(By.Id("authSubmit"));
            loginBtn.Click();

            Thread.Sleep(500);

            IWebElement note = _driver.FindElement(By.XPath("//*[@id=\"notesList\"]/li[3]"));
            note.Click();

            Thread.Sleep(500);

            IWebElement title = _driver.FindElement(By.Id("editorTitle"));

            const string excpectedTitle = "Совместное редактирование заметки";
            Assert.Contains(excpectedTitle, title.Text);
        }
        //проверка новой заметки
        [Fact]
        public void CheckNewNote()
        {
            _driver.Url = "https://test.webmx.ru/";

            IWebElement inputLogin = _driver.FindElement(By.Id("authUsername"));
            IWebElement inputPassword = _driver.FindElement(By.Id("authPassword"));

            inputLogin.SendKeys("alvo");
            inputPassword.SendKeys("123456");

            IWebElement loginBtn = _driver.FindElement(By.Id("authSubmit"));
            loginBtn.Click();

            Thread.Sleep(500);

            IWebElement btn = _driver.FindElement(By.Id("newNoteBtn"));
            btn.Click();

            Thread.Sleep(500);

            IWebElement title = _driver.FindElement(By.Id("editorTitle"));
            const string expectedTitle = "Новая заметка";
            Assert.Contains(expectedTitle, title.Text);
        }

        //смотрит на наличие блока Поделиться для заметки пользователя
        [Fact]
        public void OpenShareBlock()
        {
            _driver.Url = "https://test.webmx.ru/";

            IWebElement inputLogin = _driver.FindElement(By.Id("authUsername"));
            IWebElement inputPassword = _driver.FindElement(By.Id("authPassword"));

            inputLogin.SendKeys("alvo");
            inputPassword.SendKeys("123456");

            IWebElement loginBtn = _driver.FindElement(By.Id("authSubmit"));
            loginBtn.Click();

            Thread.Sleep(500);

            IWebElement note = _driver.FindElement(By.XPath("//*[@id=\"notesList\"]/li[5]"));
            note.Click();

            Thread.Sleep(500);

            IWebElement shareBlock = _driver.FindElement(By.Id("shareBlock"));
            string classes = shareBlock.GetAttribute("class");
            string expectedClass = "hidden";

            Assert.DoesNotContain(expectedClass, classes);
        }

        //смотрит на наличие блока Поделиться для заметки пользователя
        [Fact]
        public void CloseShareBlock()
        {
            _driver.Url = "https://test.webmx.ru/";

            IWebElement inputLogin = _driver.FindElement(By.Id("authUsername"));
            IWebElement inputPassword = _driver.FindElement(By.Id("authPassword"));

            inputLogin.SendKeys("alvo");
            inputPassword.SendKeys("123456");

            IWebElement loginBtn = _driver.FindElement(By.Id("authSubmit"));
            loginBtn.Click();

            Thread.Sleep(500);

            IWebElement note = _driver.FindElement(By.XPath("//*[@id=\"notesList\"]/li[4]"));
            note.Click();

            Thread.Sleep(500);

            IWebElement shareBlock = _driver.FindElement(By.Id("shareBlock"));
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
