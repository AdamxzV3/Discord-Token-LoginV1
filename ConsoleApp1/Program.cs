using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string token = "<YOUR_DISCORD_TOKEN_HERE>";

            ChromeOptions options = new ChromeOptions();
            options.AddArgument("start-maximized");

            IWebDriver driver = new ChromeDriver(options);

            driver.Navigate().GoToUrl("https://discord.com/login");

            IWebElement tokenInput = driver.FindElement(By.Name("email"));
            tokenInput.SendKeys(token);

            IWebElement loginButton = driver.FindElement(By.XPath("//button[@type='submit']"));
            loginButton.Click();

            Console.WriteLine(driver.PageSource);

            string path = @"login_info.txt";
            using (StreamWriter sw = File.CreateText(path))
            {
                sw.WriteLine(driver.PageSource);
            }

            driver.Quit();
        }
    }
}
