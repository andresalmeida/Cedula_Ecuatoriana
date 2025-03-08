//using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using System.Threading;

//namespace MSTestUnit
//{
//    [TestClass]
//    public class UnitTest1
//    {
//        By googleSearchBar = By.Id("APjFqb");
//        By googleButtonClick = By.Name("btnK");
//        By resultGoogleSearch = By.Id("_rV27ZsnGL4aqwbkP1fvcwQE_44");

//        int tiempoEspera = 3000;

//        private IWebDriver driver;

//        [TestInitialize]
//        public void Setup()
//        {
//            // Specify the path to the ChromeDriver executable if not in PATH
//            var chromeOptions = new ChromeOptions();
//            //string driverPath = @"C:\Users\ASUS\Downloads\chrome-win64"; // Update this path
//            //driver = new ChromeDriver(driverPath, chromeOptions);
//        }

//        [TestCleanup]
//        public void Teardown()
//        {
//            driver.Quit();
//            driver.Dispose();
//        }

//        //[TestMethod]
//        //public void TestPageGoogle()
//        //{
//        //    IWebDriver driver = new ChromeDriver();
//        //    driver.Manage().Window.Maximize();
//        //    driver.Navigate().GoToUrl("https://www.google.com/");
//        //    Thread.Sleep(tiempoEspera);
//        //    driver.FindElement(googleSearchBar).SendKeys("Visual Studio Code");
//        //    Thread.Sleep(tiempoEspera);
//        //    driver.FindElement(googleButtonClick).Click();
//        //    Thread.Sleep(tiempoEspera);
//        //    var resultadoBusqueda = driver.FindElement(resultGoogleSearch);
//        //    Assert.IsNotNull(resultadoBusqueda);
//        //    driver.Quit();
//        //}

//        [TestMethod]
//        public void Create_Get_ReturnCreateView()
//        {
//            driver.Manage().Window.Maximize();
//            Thread.Sleep(tiempoEspera);
//            driver.Navigate().GoToUrl("https://localhost:7053/ClientePostgreSQL/Create");
//            Thread.Sleep(tiempoEspera);
//            driver.FindElement(By.Name("Cedula")).SendKeys("1234567890");
//            Thread.Sleep(tiempoEspera);
//            //    // Uncomment and fill in the remaining fields as needed
//            //    //driver.FindElement(By.Name("Apellidos")).SendKeys("Perez");
//            //    //driver.FindElement(By.Name("Nombres")).SendKeys("Juan");
//            //    //driver.FindElement(By.Name("FechaNacimiento")).SendKeys("01/01/1990");
//            //    //driver.FindElement(By.Name("Mail")).SendKeys("juan.perez@email,com");
//            //    //driver.FindElement(By.Name("Telefono")).SendKeys("0999999999");
//            //    //driver.FindElement(By.Name("Direccion")).SendKeys("Av. Colon");
//            //    //driver.FindElement(By.Name("Estado")).SendKeys("True");
//            //    //driver.FindElement(By.Name("submit")).Click();
//        }
//    }
//}



// FIREFOX

//using OpenQA.Selenium;
//using OpenQA.Selenium.Firefox;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using System.Threading;
//using WebDriverManager;
//using WebDriverManager.DriverConfigs.Impl;

//namespace MSTestUnit
//{
//    [TestClass]
//    public class UnitTest1
//    {
//        By googleSearchBar = By.Name("q");
//        By googleButtonClick = By.Name("btnK");
//        By resultGoogleSearch = By.Id("search");
//        int tiempoEspera = 3000;
//        private IWebDriver driver;

//        [TestInitialize]
//        public void Setup()
//        {
//            new DriverManager().SetUpDriver(new FirefoxConfig());
//            driver = new FirefoxDriver();
//        }

//        [TestCleanup]
//        public void Teardown()
//        {
//            if (driver != null)
//            {
//                driver.Quit();
//                driver.Dispose();
//            }
//        }

//        [TestMethod]
//        public void TestPageGoogle()
//        {
//            driver.Manage().Window.Maximize();
//            driver.Navigate().GoToUrl("https://www.google.com/");
//            Thread.Sleep(tiempoEspera);
//            driver.FindElement(googleSearchBar).SendKeys("Visual Studio Code");
//            Thread.Sleep(tiempoEspera);
//            driver.FindElement(googleButtonClick).Click();
//            Thread.Sleep(tiempoEspera);
//            var resultadoBusqueda = driver.FindElement(resultGoogleSearch);
//            Assert.IsNotNull(resultadoBusqueda);
//        }
//    }
//}

// FIREFOX PROYECTO MVC
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using System;

namespace MSTestUnit
{
    [TestClass]
    public class UnitTest1
    {
        private IWebDriver driver;
        private const string BaseUrl = "https://localhost:7053";
        private const int TiempoEspera = 3000;

        [TestInitialize]
        public void Setup()
        {
            new DriverManager().SetUpDriver(new FirefoxConfig());
            driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [TestCleanup]
        public void Teardown()
        {
            driver?.Quit();
            driver?.Dispose();
        }

        [TestMethod]
        public void Create_Get_ReturnCreateView()
        {
            driver.Navigate().GoToUrl($"{BaseUrl}/ClientePostgreSQL/Create");
            Thread.Sleep(TiempoEspera);

            driver.FindElement(By.Name("Cedula")).SendKeys("1234567890");
            Thread.Sleep(TiempoEspera);
            driver.FindElement(By.Name("Apellidos")).SendKeys("Perez");
            Thread.Sleep(TiempoEspera);
            driver.FindElement(By.Name("Nombres")).SendKeys("Juan");
            Thread.Sleep(TiempoEspera);
            driver.FindElement(By.Name("FechaNacimiento")).SendKeys("01/01/1990");
            Thread.Sleep(TiempoEspera);
            driver.FindElement(By.Name("Mail")).SendKeys("juan.perez@email.com");
            Thread.Sleep(TiempoEspera);
            driver.FindElement(By.Name("Telefono")).SendKeys("0999999999");
            Thread.Sleep(TiempoEspera);
            driver.FindElement(By.Name("Direccion")).SendKeys("Av. Colon");
            Thread.Sleep(TiempoEspera);
            driver.FindElement(By.Name("Estado")).SendKeys("True");
            Thread.Sleep(TiempoEspera);

            driver.FindElement(By.CssSelector("input[type='submit']")).Click();
            Thread.Sleep(TiempoEspera);

            // Aquí puedes agregar aserciones para verificar que la creación fue exitosa
            // Por ejemplo:
            // Assert.IsTrue(driver.Url.Contains("/Index"), "No se redirigió a la página de índice después de crear");
        }
    }
}