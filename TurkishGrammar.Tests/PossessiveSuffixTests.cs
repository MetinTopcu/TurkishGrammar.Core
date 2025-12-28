using TurkishGrammar.Core.Suffixes.Possessive;

namespace TurkishGrammar.Tests;

public class PossessiveSuffixTests
{
    [Theory]
    [InlineData("ev", "evim")]
    [InlineData("masa", "masam")]
    [InlineData("kitap", "kitabım")]
    [InlineData("kedi", "kedim")]
    [InlineData("göl", "gölüm")]
    [InlineData("kol", "kolum")]
    public void AddPossessive_FirstSingular_ShouldAddCorrectSuffix(string word, string expected)
    {
        var result = PossessiveSuffixHelper.AddPossessive(word, PossessivePerson.FirstSingular);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("ev", "evin")]
    [InlineData("masa", "masan")]
    [InlineData("kitap", "kitabın")]
    [InlineData("araba", "araban")]
    [InlineData("göl", "gölün")]
    [InlineData("kol", "kolun")]
    public void AddPossessive_SecondSingular_ShouldAddCorrectSuffix(string word, string expected)
    {
        var result = PossessiveSuffixHelper.AddPossessive(word, PossessivePerson.SecondSingular);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("ev", "evi")]
    [InlineData("masa", "masası")]
    [InlineData("kitap", "kitabı")]
    [InlineData("araba", "arabası")]
    [InlineData("göl", "gölü")]
    [InlineData("kol", "kolu")]
    [InlineData("Ali", "Alisi")]
    public void AddPossessive_ThirdSingular_ShouldAddCorrectSuffix(string word, string expected)
    {
        var result = PossessiveSuffixHelper.AddPossessive(word, PossessivePerson.ThirdSingular);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("ev", "evimiz")]
    [InlineData("masa", "masamız")]
    [InlineData("kitap", "kitabımız")]
    [InlineData("araba", "arabamız")]
    [InlineData("göl", "gölümüz")]
    [InlineData("kol", "kolumuz")]
    public void AddPossessive_FirstPlural_ShouldAddCorrectSuffix(string word, string expected)
    {
        var result = PossessiveSuffixHelper.AddPossessive(word, PossessivePerson.FirstPlural);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("ev", "eviniz")]
    [InlineData("masa", "masanız")]
    [InlineData("kitap", "kitabınız")]
    [InlineData("araba", "arabanız")]
    [InlineData("göl", "gölünüz")]
    [InlineData("kol", "kolunuz")]
    public void AddPossessive_SecondPlural_ShouldAddCorrectSuffix(string word, string expected)
    {
        var result = PossessiveSuffixHelper.AddPossessive(word, PossessivePerson.SecondPlural);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("ev", "evleri")]
    [InlineData("masa", "masaları")]
    [InlineData("kitap", "kitapları")]
    [InlineData("araba", "arabaları")]
    [InlineData("göl", "gölleri")]
    [InlineData("kol", "kolları")]
    public void AddPossessive_ThirdPlural_ShouldAddCorrectSuffix(string word, string expected)
    {
        var result = PossessiveSuffixHelper.AddPossessive(word, PossessivePerson.ThirdPlural);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void AddPossessive_NullWord_ShouldThrowException()
    {
        Assert.Throws<ArgumentException>(() =>
            PossessiveSuffixHelper.AddPossessive(null!, PossessivePerson.FirstSingular));
    }

    [Fact]
    public void AddPossessive_EmptyWord_ShouldThrowException()
    {
        Assert.Throws<ArgumentException>(() =>
            PossessiveSuffixHelper.AddPossessive("", PossessivePerson.FirstSingular));
    }
}
