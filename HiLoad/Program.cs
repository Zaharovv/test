using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;

using NUnit.Framework;

namespace HiLoad
{
    [TestFixture]
    class Program
    {

        [Test]
        static void Main(string[] args)
        {
            DateTime start = DateTime.Now;
            Console.WriteLine(start);
            FireFox();
            Chrome();

            DateTime end = DateTime.Now;
            Console.WriteLine(end);
            Console.Read();

        }

        private static async void FireFox()
        {
            IWebDriver FfDriver = new FirefoxDriver();
            int counter = 0;
            string url = "http://status-service.testing-05.livetex/?method=label.isAvailable&siteId=10015983";
            for (int i = 0; i < 10000; i++)
            {
                FfDriver.Navigate().GoToUrl(url);
                await TestAsync(i);
                counter++;
            }
            Console.WriteLine("FF - " + counter);
            DateTime end = DateTime.Now;
            Console.WriteLine("FFr - " + end);
        }
        private static async void Chrome()
        {
            IWebDriver FfDriver = new ChromeDriver();
            int counter = 0;
            string url = "http://status-service.testing-05.livetex/?method=label.isAvailable&siteId=10015983";
            for (int i = 0; i < 10000; i++)

            {
                FfDriver.Navigate().GoToUrl(url);
                await TestAsync(i);
                counter++;
            }
            Console.WriteLine("Chrome - " + counter);
            DateTime end = DateTime.Now;
            Console.WriteLine("Chrome - " + end);
        }

        private static Task TestAsync(int i)
        {

            return Task.Run(() => TaskToDo(i));
        }

        private async static void TaskToDo(int i)
        {
            await Task.Delay(1);

        }


    }
}





