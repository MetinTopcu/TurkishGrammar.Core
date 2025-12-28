using TurkishGrammar.Core.Suffixes.Case;

namespace TurkishGrammar.Tests;

public class CaseSuffixTests
{
    [Theory]
    [InlineData("ev", "evi")]
    [InlineData("masa", "masayı")]
    [InlineData("kitap", "kitabı")]
    [InlineData("Ali", "Aliyi")]
    [InlineData("göl", "gölü")]
    [InlineData("kol", "kolu")]
    public void AddCase_Accusative_ShouldAddCorrectSuffix(string word, string expected)
    {
        var result = CaseSuffixHelper.AddCase(word, CaseType.Accusative);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("ev", "eve")]
    [InlineData("masa", "masaya")]
    [InlineData("kitap", "kitaba")]
    [InlineData("Ali", "Aliye")]
    [InlineData("göl", "göle")]
    [InlineData("okul", "okula")]
    public void AddCase_Dative_ShouldAddCorrectSuffix(string word, string expected)
    {
        var result = CaseSuffixHelper.AddCase(word, CaseType.Dative);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("ev", "evde")]
    [InlineData("masa", "masada")]
    [InlineData("kitap", "kitapta")]   // sert ünsüz p -> ta
    [InlineData("ağaç", "ağaçta")]     // sert ünsüz ç -> ta
    [InlineData("Ali", "Alide")]
    [InlineData("okul", "okulda")]
    [InlineData("göl", "gölde")]
    public void AddCase_Locative_ShouldAddCorrectSuffix(string word, string expected)
    {
        var result = CaseSuffixHelper.AddCase(word, CaseType.Locative);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("ev", "evden")]
    [InlineData("masa", "masadan")]
    [InlineData("kitap", "kitaptan")]  // sert ünsüz p -> tan
    [InlineData("ağaç", "ağaçtan")]    // sert ünsüz ç -> tan
    [InlineData("Ali", "Aliden")]
    [InlineData("okul", "okuldan")]
    [InlineData("göl", "gölden")]
    public void AddCase_Ablative_ShouldAddCorrectSuffix(string word, string expected)
    {
        var result = CaseSuffixHelper.AddCase(word, CaseType.Ablative);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("ev", "evle")]
    [InlineData("masa", "masayla")]
    [InlineData("kalem", "kalemle")]
    [InlineData("Ali", "Aliyle")]
    [InlineData("kitap", "kitapla")]
    [InlineData("göl", "gölle")]
    public void AddCase_Instrumental_ShouldAddCorrectSuffix(string word, string expected)
    {
        var result = CaseSuffixHelper.AddCase(word, CaseType.Instrumental);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("ev", "ev")]
    [InlineData("masa", "masa")]
    public void AddCase_Nominative_ShouldReturnOriginalWord(string word, string expected)
    {
        var result = CaseSuffixHelper.AddCase(word, CaseType.Nominative);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void AddCase_NullWord_ShouldThrowException()
    {
        Assert.Throws<ArgumentException>(() =>
            CaseSuffixHelper.AddCase(null!, CaseType.Accusative));
    }

    [Fact]
    public void AddCase_EmptyWord_ShouldThrowException()
    {
        Assert.Throws<ArgumentException>(() =>
            CaseSuffixHelper.AddCase("", CaseType.Accusative));
    }
}
