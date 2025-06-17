using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using OpenQA.Selenium.BiDi.Modules.Input;
using OpenQA.Selenium.Support.UI;
// Para esperar tiempo en el alert
using SeleniumExtras.WaitHelpers;


namespace UIAutomationTests
{
    public class Selenium
    {
        private IWebDriver _driver;
        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
        }
        [Test]
        public void Enter_To_List_Of_Countries_And_Register_Country_Test()
        {
            //Arrange
            //Abre una nueva ventana
            var URL = "http://localhost:8080/";

            //Maximiza la pantalla
            _driver.Manage().Window.Maximize();

            //Act
            //Navega a la página que se necesita probar
            _driver.Navigate().GoToUrl(URL);

            // Los comentarios son bastante redundantes pero lo veo necesario para documentar 
            // que hace cada llamado a funciones

            // Obtener el botón de la página usando el XPath (Obtenido manualmente)
            IWebElement element = _driver.FindElement(By.XPath("//*[@id=\"app\"]/div/div/div/a/button"));
            element.Click();

            // Buscar la caja de texto de Pais
            // Se tuvo que modificar el "nombre" para que C# escape los "
            element = _driver.FindElement(By.XPath("//*[@id=\"nombre\"]"));
            // Escribir Rusia en dicha caja de texto
            element.SendKeys("Rusia");

            // Buscar el dropdown de continentes
            element = _driver.FindElement(By.XPath("//*[@id=\"continente\"]"));
            // Crear un SelectElement para poder seleccionar elementos en el dropdown menu
            SelectElement select = new SelectElement(element);
            // Seleccionar el continente Europa
            select.SelectByText("Europa");

            // Buscar la caja de texto de Idioma
            element = _driver.FindElement(By.XPath("//*[@id=\"idioma\"]"));
            // Escribir Ruso en dicha caja de texto
            element.SendKeys("Ruso");

            // Buscar el botón de guardar el país
            element = _driver.FindElement(By.XPath("//*[@id=\"app\"]/div/div/form/div[4]/button"));
            // Enviar el guardado del nuevo país
            // Submit es como un Click pero especial para botones de registro en HTML form
            element.Submit();

            // Esperar a que el alert  sea mostrado en pantalla
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());

            // Seleccionar el alert
            IAlert alert = _driver.SwitchTo().Alert();
            // Hacer un Assert para ver si la alerta dice lo esperado.
            Assert.AreEqual("País registrado correctamente.", alert.Text);
            // Clickear el aceptar del alert
            alert.Accept();
        }
        [Test]
        public void Enter_To_List_Of_Countries_Test()
        {
            // Este es el ejemplo dado por la profesora en el enunciado

            //Arrange
            //Abre una nueva ventana
            var URL = "http://localhost:8080/";

            //Maximiza la pantalla
            _driver.Manage().Window.Maximize();

            //Act
            //Navega a la página que se necesita probar
            _driver.Navigate().GoToUrl(URL);

            //Assert
            //No es un buen ejemplo de assert, use uno diferente
            Assert.IsNotNull(_driver);
        }
    }
}
