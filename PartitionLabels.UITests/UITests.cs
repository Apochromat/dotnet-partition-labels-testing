using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace PartitionLabels.UITests;

[TestFixture()]
public class Tests {
    private readonly string _baseUrl = "http://localhost:5239/";
    IWebDriver _driver;
    
    /// <summary>
    /// Запуск браузера и переход на страницу приложения
    /// </summary>
    [SetUp]
    public void Setup() {
        _driver = new ChromeDriver();
        _driver.Navigate().GoToUrl(_baseUrl);
    }
    
    /// <summary>
    /// Закрытие браузера
    /// </summary>
    [TearDown]
    public void Teardown() {
        _driver.Quit();
    }

    /// <summary>
    /// Проверка что заголовок страницы содержит название приложения
    /// </summary>
    [Test]
    public void Test_HomepageTitle_ContainsAppName() {
        // Assert
        Assert.That(_driver.Title.Contains("PartitionLabels.WebUI"), Is.True);
    }
    
    /// <summary>
    /// Проверка что заголовок страницы содержит название страницы
    /// </summary>
    [Test]
    public void Test_HomepageTitle_ContainsHomepage() {
        // Assert
        Assert.That(_driver.Title.Contains("Home Page"), Is.True);
    }
    
    /// <summary>
    /// Проверка что на странице есть поле ввода и оно отображается
    /// </summary>
    [Test]
    public void Test_InputField_IsDisplayed() {
        // Assert
        Assert.That(_driver.FindElement(By.Id("Input")).Displayed, Is.True);
    }
    
    /// <summary>
    /// Проверка что на странице есть поле результата и оно не отображается
    /// </summary>
    [Test]
    public void Test_ResultFieldByDefault_IsNotDisplayed() {
        // Assert
        Assert.That(_driver.FindElement(By.Id("Result")).Displayed, Is.False);
    }
    
    /// <summary>
    /// Проверка что на странице есть кнопка отправки и она отображается
    /// </summary>
    [Test]
    public void Test_SubmitButtonIsDisplayed_Pass() {
        // Assert
        Assert.That(_driver.FindElement(By.Id("Submit")).Displayed, Is.True);
    }

    /// <summary>
    /// Проверка что результат после отправки корректных данных не пустой
    /// </summary>
    /// <param name="input"></param>
    [TestCase("a")]
    [TestCase("aa")]
    [TestCase("aabb")]
    public void Test_ResultFieldAfterSubmitWithCorrectInput_IsNotEmpty(string input) {
        // Action
        _driver.FindElement(By.Id("Input")).SendKeys(input);
        _driver.FindElement(By.Id("Submit")).Click();

        // Assert
        Assert.That(_driver.FindElement(By.Id("Result")).GetAttribute("value"), Is.Not.EqualTo(string.Empty));
    }
    
    /// <summary>
    /// Проверка что результат после отправки некорректных данных (неправильные символы) не пустой
    /// </summary>
    /// <param name="input"></param>
    [TestCase("F")]
    [TestCase("0")]
    [TestCase("@")]
    public void Test_ResultFieldAfterSubmitWithWrongInputSymbols_IsNotEmpty(string input) {
        // Action
        _driver.FindElement(By.Id("Input")).SendKeys(input);
        _driver.FindElement(By.Id("Submit")).Click();

        // Assert
        Assert.That(_driver.FindElement(By.Id("Result")).GetAttribute("value"), Is.Not.EqualTo(string.Empty));
    }
    
    /// <summary>
    /// Проверка что результат после отправки некорректных данных (неправильные символы) содержит текст ошибки
    /// </summary>
    /// <param name="input"></param>
    [TestCase("F")]
    [TestCase("0")]
    [TestCase("@")]
    public void Test_ResultFieldAfterSubmitWithWrongInputSymbols_ShowError(string input) {
        // Action
        _driver.FindElement(By.Id("Input")).SendKeys(input);
        _driver.FindElement(By.Id("Submit")).Click();

        // Assert
        Assert.That(_driver.FindElement(By.Id("Result")).GetAttribute("value"), Is.EqualTo("String must consist of lowercase English letters (Parameter 's')"));
    }
    
    /// <summary>
    /// Проверка что результат после отправки некорректных данных (слишком длинная строка) не пустой
    /// </summary>
    [Test]
    public void Test_ResultFieldAfterSubmitWithWrongInputLength_IsNotEmpty() {
        // Preparation
        var str = string.Concat(Enumerable.Repeat("a", 501));
        
        // Action
        _driver.FindElement(By.Id("Input")).SendKeys(str);
        _driver.FindElement(By.Id("Submit")).Click();

        // Assert
        Assert.That(_driver.FindElement(By.Id("Result")).GetAttribute("value"), Is.Not.EqualTo(string.Empty));
    }
    
    /// <summary>
    /// Проверка что результат после отправки некорректных данных (слишком длинная строка) содержит текст ошибки
    /// </summary>
    [Test]
    public void Test_ResultFieldAfterSubmitWithWrongInputLength_ShowError() {
        // Preparation
        var str = string.Concat(Enumerable.Repeat("a", 501));
        
        // Action
        _driver.FindElement(By.Id("Input")).SendKeys(str);
        _driver.FindElement(By.Id("Submit")).Click();

        // Assert
        Assert.That(_driver.FindElement(By.Id("Result")).GetAttribute("value"), Is.EqualTo("Specified argument was out of the range of valid values. (Parameter 's')"));
    }
    
    /// <summary>
    /// Проверка что результат после отправки пустой строки не пустой
    /// </summary>
    /// <param name="input"></param>
    [TestCase(" ")]
    [TestCase("\n")]
    [TestCase("\r")]
    [TestCase("\v")]
    public void Test_ResultFieldAfterSubmitWithEmptyVisuallyInput_IsNotDisplayed(string input) {
        // Action
        _driver.FindElement(By.Id("Input")).SendKeys(input);
        _driver.FindElement(By.Id("Submit")).Click();

        // Assert
        Assert.That(_driver.FindElement(By.Id("Result")).Displayed, Is.False);
    }
    
    /// <summary>
    /// Проверка что результат после отправки корректной строки содержит правильный ответ
    /// </summary>
    /// <param name="input"></param>
    /// <param name="expected"></param>
    [TestCase("a", "1")]
    [TestCase("aa", "2")]
    [TestCase("qwe", "1, 1, 1")]
    [TestCase("aaaaaabb", "6, 2")]
    [TestCase("aabbbbbcc", "2, 5, 2")]
    [TestCase("zxzxzxspspsp", "6, 6")]
    [TestCase("abababc", "6, 1")]
    [TestCase("abababcd", "6, 1, 1")]
    [TestCase("abababxydfdfdf", "6, 1, 1, 6")]
    [TestCase("abababxxdfdfdf", "6, 2, 6")]
    [TestCase("abababdfdfdfqwerty", "6, 6, 1, 1, 1, 1, 1, 1")]
    [TestCase("cvcvztytytyxqwqwqwqw", "4, 1, 6, 1, 8")] 
    [TestCase("cvcvztytytyzqwqwqwqw", "4, 8, 8")]
    public void Test_ResultFieldAfterSubmitWithCorrectInput_HaveRightAnswer(string input, string expected) {
        // Action
        _driver.FindElement(By.Id("Input")).SendKeys(input);
        _driver.FindElement(By.Id("Submit")).Click();

        // Assert
        Assert.That(_driver.FindElement(By.Id("Result")).GetAttribute("value"), Is.EqualTo(expected));
    }
}