using System;
using System.ComponentModel;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;

namespace BotX3.Shared
{
    public class BotService
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        private BackgroundWorker worker;
        public BotService()
        {
            worker = new BackgroundWorker();
            worker.WorkerSupportsCancellation = true;
            worker.DoWork += BotStart;
        }

        public void StartService()
        {
            worker.RunWorkerAsync();
        }

        private void BotStart(object? sender, DoWorkEventArgs evnt)
        {
            IWebDriver driver = new InternetExplorerDriver();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(16));
            try
            {
                driver.Navigate().GoToUrl("https://yandex.ru");
                IWebElement element = wait.Until(d => d.FindElement(By.Id("text")));
                Thread.Sleep(5000);
                driver.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}