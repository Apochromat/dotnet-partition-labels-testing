namespace PartitionLabels.UnitTests;

public class Tests {
    [SetUp]
    public void Setup() {
    }

    /// <summary>
    /// Проверка на прохождение первого приложенного примера
    /// </summary>
    [Test]
    public void Test_ExampleOne_Pass() {
        Assert.That(PartitionLabels.Solution("ababcbacadefegdehijhklij"), Is.EqualTo(new[] { 9, 7, 8 }));
    }

    /// <summary>
    /// Проверка на прохождение второго приложенного примера
    /// </summary>
    [Test]
    public void Test_ExampleTwo_Pass() {
        Assert.That(PartitionLabels.Solution("eccbbbbdec"), Is.EqualTo(new[] { 10 }));
    }

    /// <summary>
    /// Проверка на строку длинной 0, ниже минимального корректного значения
    /// </summary>
    [Test]
    public void Test_EmptyString_ThrowArgumentOutOfRangeException() {
        // Action
        // Assert
        Assert.Throws<ArgumentOutOfRangeException>(delegate { PartitionLabels.Solution(""); });
    }
    
    /// <summary>
    /// Проерка на строку длинной 1, минимальное корректное значение
    /// </summary>
    [Test]
    public void Test_StringWithLength1_DoesNotThrowException() {
        // Preparation
        var s = string.Concat(Enumerable.Repeat("a", 1));
        // Action
        // Assert
        Assert.DoesNotThrow(delegate { PartitionLabels.Solution(s); });
    }

    /// <summary>
    /// Проерка на строку длинной 500, максимальное корректное значение
    /// </summary>
    [Test]
    public void Test_StringWithLength500_DoesNotThrowException() {
        // Preparation
        var s = string.Concat(Enumerable.Repeat("a", 500));
        // Action
        // Assert
        Assert.DoesNotThrow(delegate { PartitionLabels.Solution(s); });
    }

    /// <summary>
    /// Проерка на строку длинной 501, выше максимального корректного значения
    /// </summary>
    [Test]
    public void Test_StringWithLength501_ThrowArgumentOutOfRangeException() {
        // Preparation
        var s = string.Concat(Enumerable.Repeat("a", 501));
        // Action
        // Assert
        Assert.Throws<ArgumentOutOfRangeException>(delegate { PartitionLabels.Solution(s); });
    }
    
    /// <summary>
    /// Проверка на одну английскую строчную букву
    /// </summary>
    /// <param name="s"></param>
    /// <param name="expected"></param>
    [TestCase("a", new[] { 1 })]
    [TestCase("b", new[] { 1 })]
    [TestCase("c", new[] { 1 })]
    public void Test_OneEnglishLowercaseLetter_Pass(string s, int[] expected) {
        // Action
        var result = PartitionLabels.Solution(s);
        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    /// <summary>
    /// Проверка на одну английскую заглавную букву
    /// </summary>
    /// <param name="s"></param>
    [TestCase("A")]
    [TestCase("B")]
    [TestCase("C")]
    public void Test_OneEnglishUppercaseLetter_ThrowArgumentException(string s) {
        // Action
        // Assert
        Assert.Throws<ArgumentException>(delegate { PartitionLabels.Solution(s); });
    }

    /// <summary>
    /// Проерка на одну русскую строчную букву
    /// </summary>
    /// <param name="s"></param>
    [TestCase("а")]
    [TestCase("б")]
    [TestCase("в")]
    public void Test_OneRussianLowercaseLetter_ThrowArgumentException(string s) {
        // Action
        // Assert
        Assert.Throws<ArgumentException>(delegate { PartitionLabels.Solution(s); });
    }
    
    /// <summary>
    /// Проерка на одну русскую заглавную букву
    /// </summary>
    /// <param name="s"></param>
    [TestCase("А")]
    [TestCase("Б")]
    [TestCase("В")]
    public void Test_OneRussianUppercaseLetter_ThrowArgumentException(string s) {
        // Action
        // Assert
        Assert.Throws<ArgumentException>(delegate { PartitionLabels.Solution(s); });
    }

    /// <summary>
    /// Проерка на одну цифру
    /// </summary>
    /// <param name="s"></param>
    [TestCase("0")]
    [TestCase("1")]
    [TestCase("2")]
    public void Test_OneDigit_ThrowArgumentException(string s) {
        // Action
        // Assert
        Assert.Throws<ArgumentException>(delegate { PartitionLabels.Solution(s); });
    }

    /// <summary>
    /// Проверка на один непечатаемый символ
    /// </summary>
    /// <param name="s"></param>
    [TestCase("\n")]
    [TestCase("\r")]
    [TestCase("\v")]
    public void Test_OneNonPrintableCharacter_ThrowArgumentException(string s) {
        // Action
        // Assert
        Assert.Throws<ArgumentException>(delegate { PartitionLabels.Solution(s); });
    }

    /// <summary>
    /// Проерка на один не алфавитно-цифровой печатаемый символ
    /// </summary>
    /// <param name="s"></param>
    [TestCase("☺")]
    [TestCase("ඞ")]
    [TestCase("$")]
    [TestCase("@")]
    [TestCase(" ")]
    public void Test_OneNonAlphanumericCharacter_ThrowArgumentException(string s) {
        // Action
        // Assert
        Assert.Throws<ArgumentException>(delegate { PartitionLabels.Solution(s); });
    }

    /// <summary>
    /// Проверка на комбинацию разных некорректных символов
    /// </summary>
    /// <param name="s"></param>
    [TestCase("фqФQ!@\n\v")]
    [TestCase("Qq %&\nчЧ")]
    [TestCase("фqФQ!@\n\v")]
    public void Test_StringWithCombinationOfDifferentCharacters_ThrowArgumentException(string s) {
        // Action
        // Assert
        Assert.Throws<ArgumentException>(delegate { PartitionLabels.Solution(s); });
    }
    
    /// <summary>
    /// Проверка на строчную и заглавную одинаковую букву
    /// </summary>
    /// <param name="s"></param>
    [TestCase("fF")]
    [TestCase("Ff")]
    public void Test_TwoLettersWithDifferentCase_ThrowArgumentException(string s) {
        // Action
        // Assert
        Assert.Throws<ArgumentException>(delegate { PartitionLabels.Solution(s); });
    }

    /// <summary>
    /// Проерка на строку из нескольких одинаковых символов
    /// </summary>
    /// <param name="letter"></param>
    /// <param name="repeat"></param>
    /// <param name="expected"></param>
    [TestCase("a", 2, new[] { 2 })]
    [TestCase("b", 3, new[] { 3 })]
    [TestCase("c", 4, new[] { 4 })]
    [TestCase("d", 5, new[] { 5 })]
    public void Test_StringWithSeveralEqualLetters_Pass(string letter, int repeat, int[] expected) {
        // Preparation
        var s = string.Concat(Enumerable.Repeat(letter, repeat));
        // Action
        var result = PartitionLabels.Solution(s);
        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    /// <summary>
    /// Проерка на строку из нескольких разных неповторяющихся символов
    /// </summary>
    /// <param name="s"></param>
    /// <param name="expected"></param>
    [TestCase("qw", new[] { 1, 1 })]
    [TestCase("qwe", new[] { 1, 1, 1 })]
    [TestCase("qwer", new[] { 1, 1, 1, 1 })]
    [TestCase("qwert", new[] { 1, 1, 1, 1, 1 })]
    public void Test_StringWithSeveralDifferentUnrepeatableLetters_Pass(string s, int[] expected) {
        // Action
        var result = PartitionLabels.Solution(s);
        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    /// <summary>
    /// Проверка на строку из двух блоков одинаковых символов
    /// </summary>
    /// <param name="s"></param>
    /// <param name="expected"></param>
    [TestCase("aaaabbbb", new[] { 4, 4 })]
    [TestCase("aabbbbbb", new[] { 2, 6 })]
    [TestCase("aaaaaabb", new[] { 6, 2 })]
    [TestCase("aaaaaaab", new[] { 7, 1 })]
    [TestCase("abbbbbbb", new[] { 1, 7 })]
    public void Test_StringWithTwoBlocksOfEqualLetters_Pass(string s, int[] expected) {
        // Action
        var result = PartitionLabels.Solution(s);
        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    /// <summary>
    /// Проерка на строку из трех блоков одинаковых символов
    /// </summary>
    /// <param name="s"></param>
    /// <param name="expected"></param>
    [TestCase("aaabbbccc", new[] { 3, 3, 3 })]
    [TestCase("aabbbbbcc", new[] { 2, 5, 2 })]
    [TestCase("aabbbcccc", new[] { 2, 3, 4 })]
    public void Test_StringWithThreeBlocksOfEqualLetters_Pass(string s, int[] expected) {
        // Action
        var result = PartitionLabels.Solution(s);
        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
    
    /// <summary>
    /// Проверка на строку из двух блоков с двумя разными повторяющимися символами в каждом
    /// </summary>
    /// <returns></returns>
    [TestCase("abbapeppe", new[] { 4, 5 })]
    [TestCase("zxzxzxspspsp", new[] { 6, 6 })]
    public void Test_StringWithTwoBlocksFromTwoDifferentRepeatableLetters_Pass(string s, int[] expected) {
        // Action
        var result = PartitionLabels.Solution(s);
        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
    
    /// <summary>
    /// Проверка на строку из блока с двумя разными символами и блока с одним символом
    /// </summary>
    /// <param name="s"></param>
    /// <param name="expected"></param>
    [TestCase("abababcccc", new[] { 6, 4 })]
    [TestCase("ccccababab", new[] { 4, 6 })]
    public void Test_StringWithTwoBlocksFromTwoAndOneLetters_Pass(string s, int[] expected) {
        // Action
        var result = PartitionLabels.Solution(s);
        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
    
    /// <summary>
    /// Проверка на строку из блока с двумя разными символами и одного другого символа
    /// </summary>
    /// <param name="s"></param>
    /// <param name="expected"></param>
    [TestCase("abababc", new[] { 6, 1 })]
    [TestCase("cababab", new[] { 1, 6 })]
    public void Test_StringWithOneBlockFromTwoDifferentRepeatableLettersAndOneLetter_Pass(string s, int[] expected) {
        // Action
        var result = PartitionLabels.Solution(s);
        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
    
    /// <summary>
    /// Проверка на строку из блока с двумя разными символами и двух разных символов
    /// </summary>
    /// <param name="s"></param>
    /// <param name="expected"></param>
    [TestCase("abababcd", new[] { 6, 1, 1 })]
    [TestCase("cdababab", new[] { 1, 1, 6 })]
    public void Test_StringWithOneBlockFromTwoDifferentRepeatableLettersAndTwoDifferentLetters_Pass(string s, int[] expected) {
        // Action
        var result = PartitionLabels.Solution(s);
        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
    
    /// <summary>
    /// Проверка на строку из двух блоков с двумя разными символами и одного символа между ними
    /// </summary>
    /// <param name="s"></param>
    /// <param name="expected"></param>
    [TestCase("abababcdfdfdf", new[] { 6, 1, 6 })]
    [TestCase("qpqwuyu", new[] { 3, 1, 3 })]
    public void Test_StringWithTwoBlockFromTwoDifferentRepeatableLettersAndOneLetterBetweenThem_Pass(string s, int[] expected) {
        // Action
        var result = PartitionLabels.Solution(s);
        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
    
    /// <summary>
    /// Проверка на строку из двух блоков с двумя разными символами и двух разных символов между ними
    /// </summary>
    /// <param name="s"></param>
    /// <param name="expected"></param>
    [TestCase("abababxydfdfdf", new[] { 6, 1, 1, 6 })]
    [TestCase("qpqabuyu", new[] { 3, 1, 1, 3 })]
    public void Test_StringWithTwoBlockFromTwoDifferentRepeatableLettersAndTwoDifferentLettersBetweenThem_Pass(string s, int[] expected) {
        // Action
        var result = PartitionLabels.Solution(s);
        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
    
    /// <summary>
    /// Проверка на строку из двух блоков с двумя разными символами и двух одинаковых символов между ними
    /// </summary>
    /// <param name="s"></param>
    /// <param name="expected"></param>
    [TestCase("abababxxdfdfdf", new[] { 6, 2, 6 })]
    [TestCase("qpqaauyu", new[] { 3, 2, 3 })]
    public void Test_StringWithTwoBlockFromTwoDifferentRepeatableLettersAndTwoEqualLettersBetweenThem_Pass(string s, int[] expected) {
        // Action
        var result = PartitionLabels.Solution(s);
        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
    
    /// <summary>
    /// Проверка на строку из двух блоков с двумя разными символами и  разных неповторяющихся символов рядом ними
    /// </summary>
    /// <param name="s"></param>
    /// <param name="expected"></param>
    [TestCase("abababdfdfdfqwerty", new[] { 6, 6, 1, 1, 1, 1, 1, 1 })]
    [TestCase("zxcqpquyu", new[] { 1, 1, 1, 3, 3 })]
    [TestCase("qwabbacddcer", new[] { 1, 1, 4, 4, 1, 1})]
    public void Test_StringWithTwoBlockFromTwoDifferentRepeatableLettersAndSomeDifferentUnrepeatableLettersNearThem_Pass(string s, int[] expected) {
        // Action
        var result = PartitionLabels.Solution(s);
        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
    
    /// <summary>
    /// Проверка на строку из двух блоков с двумя разными символами и одного символа между ними (символы между 1 и 2, 2 и 3 блоками различны)
    /// </summary>
    /// <param name="s"></param>
    /// <param name="expected"></param>
    [TestCase("ababzpqpqxkiki", new[] { 4, 1, 4, 1, 4 })]
    [TestCase("cvcvztytytyxqwqwqwqw", new[] { 4, 1, 6, 1, 8 })]
    public void Test_StringWithThreeBlockFromTwoDifferentRepeatableLettersAndOneLetterUniqueBetweenEveryOfThem_Pass(string s, int[] expected) {
        // Action
        var result = PartitionLabels.Solution(s);
        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
    
    /// <summary>
    /// Проверка на строку из двух блоков с двумя разными символами и одного символа между ними (символы между 1 и 2, 2 и 3 блоками одинаковые)
    /// </summary>
    /// <param name="s"></param>
    /// <param name="expected"></param>
    [TestCase("ababzpqpqzkiki", new[] { 4, 6, 4 })]
    [TestCase("cvcvztytytyzqwqwqwqw", new[] { 4, 8, 8 })]
    public void Test_StringWithThreeBlockFromTwoDifferentRepeatableLettersAndOneLetterEqualBetweenEveryOfThem_Pass(string s, int[] expected) {
        // Action
        var result = PartitionLabels.Solution(s);
        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}