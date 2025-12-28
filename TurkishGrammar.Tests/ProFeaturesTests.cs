using TurkishGrammar.Pro.Suffixes.Plural;
using TurkishGrammar.Pro.Suffixes.Question;
using TurkishGrammar.Pro.Extensions;

namespace TurkishGrammar.Tests;

public class ProFeaturesTests
{
    [Theory]
    [InlineData("ev", "evler")]
    [InlineData("masa", "masalar")]
    [InlineData("kitap", "kitaplar")]
    [InlineData("göl", "göller")]
    [InlineData("kol", "kollar")]
    public void MakePlural_ShouldAddCorrectSuffix(string word, string expected)
    {
        var result = PluralSuffixHelper.MakePlural(word);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("ev", "evler")]
    [InlineData("masa", "masalar")]
    public void ToPlural_Extension_ShouldWork(string word, string expected)
    {
        Assert.Equal(expected, word.ToPlural());
    }

    [Theory]
    [InlineData("geldin", "geldin mi")]
    [InlineData("evde", "evde mi")]
    [InlineData("okuyor", "okuyor mu")]
    [InlineData("gördün", "gördün mü")]
    public void AddQuestionParticle_ShouldAddCorrectSuffix(string word, string expected)
    {
        var result = QuestionParticleHelper.AddQuestionParticle(word);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("geldin", "geldin mi")]
    [InlineData("evde", "evde mi")]
    public void ToQuestion_Extension_ShouldWork(string word, string expected)
    {
        Assert.Equal(expected, word.ToQuestion());
    }

    [Theory]
    [InlineData("öğrenci", "öğrenci değil mi")]
    [InlineData("doktor", "doktor değil mi")]
    public void AddNegativeQuestion_ShouldAddCorrectSuffix(string word, string expected)
    {
        var result = QuestionParticleHelper.AddNegativeQuestion(word);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("ev", "evlerim")]
    [InlineData("araba", "arabalarım")]
    public void MakePluralWithPossessive_FirstSingular_ShouldWork(string word, string expected)
    {
        var result = PluralSuffixHelper.MakePluralWithPossessive(word, Core.Suffixes.Possessive.PossessivePerson.FirstSingular);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("ev", "evlerimiz")]
    [InlineData("araba", "arabalarımız")]
    public void ToOurPluralPossessive_ShouldWork(string word, string expected)
    {
        Assert.Equal(expected, word.ToOurPluralPossessive());
    }

    [Fact]
    public void ProFeatures_NullWord_ShouldThrowException()
    {
        Assert.Throws<ArgumentException>(() => PluralSuffixHelper.MakePlural(null!));
        Assert.Throws<ArgumentException>(() => QuestionParticleHelper.AddQuestionParticle(null!));
    }
}
