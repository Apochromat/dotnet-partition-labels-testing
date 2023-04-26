using System.Net;
using System.Net.Http.Json;

namespace PartitionLabels.APITests;

public class Tests {
    private static readonly HttpClient Client = new HttpClient();
    private static readonly String BaseUrl = "http://localhost:5151/Main";

    [SetUp]
    public void Setup() {
    }

    /// <summary>
    /// Проверка на корректный ответ при использовании корректного метода и тела запроса
    /// </summary>
    [Test]
    public async Task Test_CorrectBodyAndMethod_OkStatusCode() {
        // Preparation
        var requestBody = new Dictionary<string, string> {
            { "input", "ababcbacadefegdehijhklij" }
        };

        // Action
        var response = await Client.PostAsJsonAsync(BaseUrl, requestBody);
        //var responseString = await response.Content.ReadAsStringAsync();

        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
    }

    /// <summary>
    /// Проверка на MethodNotAllowed при использовании некорректного метода и корректного тела запроса
    /// </summary>
    [Test]
    public async Task Test_CorrectBodyAndWrongMethod_MethodNotAllowedStatusCode() {
        // Preparation
        var requestBody = new Dictionary<string, string> {
            { "input", "ababcbacadefegdehijhklij" }
        };

        // Action
        var response = await Client.PatchAsJsonAsync(BaseUrl, requestBody);

        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.MethodNotAllowed));
    }

    /// <summary>
    /// Проверка на BadRequest при использовании корректного метода и некорректного тела запроса (неверный тип данных)
    /// </summary>
    [Test]
    public async Task Test_IncorrectBodyWithNumberAndCorrectMethod_BadRequestStatusCode() {
        // Preparation
        var requestBody = new Dictionary<string, int> {
            { "input", 1 }
        };

        // Action
        var response = await Client.PostAsJsonAsync(BaseUrl, requestBody);

        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
    }

    /// <summary>
    /// Проверка на MethodNotAllowed при использовании некорректного метода и некорректного тела запроса (неверный тип данных)
    /// </summary>
    [Test]
    public async Task Test_IncorrectBodyAndWrongMethod_MethodNotAllowedStatusCode() {
        // Preparation
        var requestBody = new Dictionary<string, int> {
            { "input", 123 }
        };

        // Action
        var response = await Client.PatchAsJsonAsync(BaseUrl, requestBody);

        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.MethodNotAllowed));
    }

    /// <summary>
    /// Проверка на BadRequest при использовании корректного метода и пустого тела запроса
    /// </summary>
    [Test]
    public async Task Test_EmptyBodyAndCorrectMethod_BadRequestStatusCode() {
        // Preparation
        var requestBody = new Dictionary<string, string>();

        // Action
        var response = await Client.PostAsJsonAsync(BaseUrl, requestBody);

        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
    }

    /// <summary>
    /// Проверка на MethodNotAllowed при использовании некорректного метода и отсутствующего тела запроса
    /// </summary>
    [Test]
    public async Task Test_WithoutBodyAndIncorrectMethod_MethodNotAllowedStatusCode() {
        // Action
        var response = await Client.GetAsync(BaseUrl);

        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.MethodNotAllowed));
    }

    /// <summary>
    /// Проверка на BadRequest при использовании корректного метода и тела запроса с неверным именем параметра
    /// </summary>
    [Test]
    public async Task Test_IncorrectBodyWithWrongParameterAndCorrectMethod_BadRequestStatusCode() {
        // Preparation
        var requestBody = new Dictionary<string, string> {
            { "output", "ababcbacadefegdehijhklij" }
        };

        // Action
        var response = await Client.PostAsJsonAsync(BaseUrl, requestBody);

        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
    }

    /// <summary>
    /// Проверка на корректный ответ при использовании корректного метода и тела запроса с нужным и лишним параметром 
    /// </summary>
    [Test]
    public async Task Test_CorrectBodyWithUselessParameterAndCorrectMethod_OkStatusCode() {
        // Preparation
        var requestBody = new Dictionary<string, string> {
            { "input", "ababcbacadefegdehijhklij" },
            { "useless", "veryinteresting" }
        };

        // Action
        var response = await Client.PostAsJsonAsync(BaseUrl, requestBody);

        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
    }

    /// <summary>
    /// Проверка на BadRequest при использовании корректного метода и тела запроса с пустой строкой
    /// </summary>
    [Test]
    public async Task Test_CorrectBodyWithEmptyString_BadRequestStatusCode() {
        // Preparation
        var requestBody = new Dictionary<string, string> {
            { "input", "" }
        };

        // Action
        var response = await Client.PostAsJsonAsync(BaseUrl, requestBody);

        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
    }

    /// <summary>
    /// Проверка на корректный ответ при использовании корректного метода и тела запроса с строкой длиной 1
    /// </summary>
    [Test]
    public async Task Test_CorrectBodyWithStringWithLength1_OkStatusCode() {
        // Preparation
        var requestBody = new Dictionary<string, string> {
            { "input", "a" }
        };

        // Action
        var response = await Client.PostAsJsonAsync(BaseUrl, requestBody);

        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
    }

    /// <summary>
    /// Проверка на корректный ответ при использовании корректного метода и тела запроса с строкой длиной 500
    /// </summary>
    [Test]
    public async Task Test_CorrectBodyWithStringWithLength500_OkStatusCode() {
        // Preparation
        var str = string.Concat(Enumerable.Repeat("a", 500));
        var requestBody = new Dictionary<string, string> {
            { "input", str }
        };

        // Action
        var response = await Client.PostAsJsonAsync(BaseUrl, requestBody);

        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
    }

    /// <summary>
    /// Проверка на BadRequest при использовании корректного метода и тела запроса с строкой длиной 501
    /// </summary>
    [Test]
    public async Task Test_CorrectBodyWithStringWithLength501_BadRequestStatusCode() {
        // Preparation
        var str = string.Concat(Enumerable.Repeat("a", 501));
        var requestBody = new Dictionary<string, string> {
            { "input", str }
        };

        // Action
        var response = await Client.PostAsJsonAsync(BaseUrl, requestBody);

        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
    }

    /// <summary>
    /// Проверка на BadRequest при использовании корректного метода и тела запроса со строкой некорректных символов
    /// </summary>
    /// <param name="s"></param>
    [TestCase("A")]
    [TestCase("B")]
    [TestCase("C")]
    [TestCase("а")]
    [TestCase("б")]
    [TestCase("в")]
    [TestCase("А")]
    [TestCase("Б")]
    [TestCase("В")]
    [TestCase("0")]
    [TestCase("1")]
    [TestCase("2")]
    [TestCase("\n")]
    [TestCase("\r")]
    [TestCase("\v")]
    [TestCase("☺")]
    [TestCase("ඞ")]
    [TestCase("$")]
    [TestCase("@")]
    [TestCase(" ")]
    [TestCase("фqФQ!@\n\v")]
    [TestCase("Qq %&\nчЧ")]
    [TestCase("фqФQ!@\n\v")]
    [TestCase("fF")]
    [TestCase("Ff")]
    public async Task Test_CorrectBodyWithStringWithIncorrectSymbols_BadRequestStatusCode(string s) {
        // Preparation
        var requestBody = new Dictionary<string, string> {
            { "input", s }
        };

        // Action
        var response = await Client.PostAsJsonAsync(BaseUrl, requestBody);
        
        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
    }
    
    /// <summary>
    /// Проверка на корректный ответ при использовании корректного метода и тела запроса со строкой корректных символов
    /// </summary>
    /// <param name="s"></param>
    [TestCase("a")]
    [TestCase("b")]
    [TestCase("c")]
    [TestCase("d")]
    [TestCase("qw")]
    [TestCase("qwe")]
    [TestCase("qwer")]
    [TestCase("qwert")]
    [TestCase("qwerty")]
    [TestCase("aaaabbbb")]
    [TestCase("aabbbbbb")]
    [TestCase("zxzxzxspspsp")]
    public async Task Test_CorrectBodyWithStringWithCorrectSymbols_OkStatusCode(string s) {
        // Preparation
        var requestBody = new Dictionary<string, string> {
            { "input", s }
        };

        // Action
        var response = await Client.PostAsJsonAsync(BaseUrl, requestBody);
        
        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
    }
    
    [TestCase("a", "[1]")]
    [TestCase("aa", "[2]")]
    [TestCase("qwe", "[1,1,1]")]
    [TestCase("aaaaaabb", "[6,2]")]
    [TestCase("aabbbbbcc", "[2,5,2]")]
    [TestCase("zxzxzxspspsp", "[6,6]")]
    [TestCase("abababc", "[6,1]")]
    [TestCase("abababcd", "[6,1,1]")]
    [TestCase("abababxydfdfdf", "[6,1,1,6]")]
    [TestCase("abababxxdfdfdf", "[6,2,6]")]
    [TestCase("abababdfdfdfqwerty", "[6,6,1,1,1,1,1,1]")]
    [TestCase("cvcvztytytyxqwqwqwqw", "[4,1,6,1,8]")]
    [TestCase("cvcvztytytyzqwqwqwqw", "[4,8,8]")]
    public async Task Test_DifferentInputs_CorrectResponseContent(string input, string expected) {
        // Preparation
        var requestBody = new Dictionary<string, string> {
            { "input", input }
        };

        // Action
        var response = await Client.PostAsJsonAsync(BaseUrl, requestBody);
        var responseString = await response.Content.ReadAsStringAsync();

        // Assert
        Assert.That(responseString, Is.EqualTo(expected));
    }
}