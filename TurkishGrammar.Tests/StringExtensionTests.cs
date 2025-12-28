using TurkishGrammar.Core.Extensions;
using TurkishGrammar.Core.Suffixes.Case;
using TurkishGrammar.Core.Suffixes.Possessive;

namespace TurkishGrammar.Tests;

public class StringExtensionTests
{
    [Theory]
    [InlineData("ev", "evi")]
    [InlineData("masa", "masayı")]
    public void ToAccusative_ShouldReturnCorrectForm(string word, string expected)
    {
        Assert.Equal(expected, word.ToAccusative());
    }

    [Theory]
    [InlineData("ev", "eve")]
    [InlineData("masa", "masaya")]
    public void ToDative_ShouldReturnCorrectForm(string word, string expected)
    {
        Assert.Equal(expected, word.ToDative());
    }

    [Theory]
    [InlineData("ev", "evde")]
    [InlineData("masa", "masada")]
    public void ToLocative_ShouldReturnCorrectForm(string word, string expected)
    {
        Assert.Equal(expected, word.ToLocative());
    }

    [Theory]
    [InlineData("ev", "evden")]
    [InlineData("masa", "masadan")]
    public void ToAblative_ShouldReturnCorrectForm(string word, string expected)
    {
        Assert.Equal(expected, word.ToAblative());
    }

    [Theory]
    [InlineData("ev", "evle")]
    [InlineData("masa", "masayla")]
    public void ToInstrumental_ShouldReturnCorrectForm(string word, string expected)
    {
        Assert.Equal(expected, word.ToInstrumental());
    }

    [Theory]
    [InlineData("ev", "evim")]
    [InlineData("masa", "masam")]
    public void ToMyPossessive_ShouldReturnCorrectForm(string word, string expected)
    {
        Assert.Equal(expected, word.ToMyPossessive());
    }

    [Theory]
    [InlineData("ev", "evin")]
    [InlineData("masa", "masan")]
    public void ToYourPossessive_ShouldReturnCorrectForm(string word, string expected)
    {
        Assert.Equal(expected, word.ToYourPossessive());
    }

    [Theory]
    [InlineData("ev", "evi")]
    [InlineData("masa", "masası")]
    public void ToHisPossessive_ShouldReturnCorrectForm(string word, string expected)
    {
        Assert.Equal(expected, word.ToHisPossessive());
    }

    [Theory]
    [InlineData("ev", "evimiz")]
    [InlineData("masa", "masamız")]
    public void ToOurPossessive_ShouldReturnCorrectForm(string word, string expected)
    {
        Assert.Equal(expected, word.ToOurPossessive());
    }

    [Theory]
    [InlineData("ev", "eviniz")]
    [InlineData("masa", "masanız")]
    public void ToYourPluralPossessive_ShouldReturnCorrectForm(string word, string expected)
    {
        Assert.Equal(expected, word.ToYourPluralPossessive());
    }

    [Theory]
    [InlineData("ev", "evleri")]
    [InlineData("masa", "masaları")]
    public void ToTheirPossessive_ShouldReturnCorrectForm(string word, string expected)
    {
        Assert.Equal(expected, word.ToTheirPossessive());
    }

    [Fact]
    public void WithCase_ShouldWorkCorrectly()
    {
        Assert.Equal("eve", "ev".WithCase(CaseType.Dative));
        Assert.Equal("evde", "ev".WithCase(CaseType.Locative));
    }

    [Fact]
    public void WithPossessive_ShouldWorkCorrectly()
    {
        Assert.Equal("evim", "ev".WithPossessive(PossessivePerson.FirstSingular));
        Assert.Equal("evleri", "ev".WithPossessive(PossessivePerson.ThirdPlural));
    }

    [Fact]
    public void ChainedExtensions_ShouldWorkCorrectly()
    {
        // "evim"e -> evime
        var result = "ev".ToMyPossessive().ToDative();
        Assert.Equal("evime", result);
    }
}
