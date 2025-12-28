using TurkishGrammar.Pro.Verbs.Mood;
using TurkishGrammar.Pro.Verbs.Person;
using TurkishGrammar.Pro.Extensions;

namespace TurkishGrammar.Tests;

public class VerbMoodTests
{
    // ============ Şart Kipi Tests ============

    [Theory]
    [InlineData("gel", VerbPerson.FirstSingular, "gelsem")]
    [InlineData("gel", VerbPerson.SecondSingular, "gelsen")]
    [InlineData("gel", VerbPerson.ThirdSingular, "gelse")]
    [InlineData("git", VerbPerson.FirstSingular, "gidsem")]  // git -> gid (yumuşama)
    [InlineData("oku", VerbPerson.FirstSingular, "okusam")]
    public void Conditional_ShouldConjugateCorrectly(string verb, VerbPerson person, string expected)
    {
        var result = ConditionalMood.Conjugate(verb, person);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Conditional_Extension_ShouldWork()
    {
        Assert.Equal("gelsem", "gel".ToConditional_I());
        Assert.Equal("gelsen", "gel".ToConditional_You());
        Assert.Equal("gidse", "git".ToConditional_He());  // git -> gid (yumuşama)
    }

    // ============ İstek Kipi Tests ============

    [Theory]
    [InlineData("gel", VerbPerson.FirstSingular, "geleyim")]
    [InlineData("gel", VerbPerson.FirstPlural, "gelelim")]
    [InlineData("gel", VerbPerson.ThirdSingular, "gele")]
    [InlineData("git", VerbPerson.FirstSingular, "gideyim")]
    [InlineData("oku", VerbPerson.FirstPlural, "okualum")]  // okua + lum (sesli harfle bitiyor)
    public void Optative_ShouldConjugateCorrectly(string verb, VerbPerson person, string expected)
    {
        var result = OptativeMood.Conjugate(verb, person);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Optative_Extension_ShouldWork()
    {
        Assert.Equal("geleyim", "gel".ToOptative_I());
        Assert.Equal("gidelim", "git".ToOptative_We());
        Assert.Equal("okua", "oku".ToOptative_He());  // sesli harfle bitiyor
    }

    // ============ Emir Kipi Tests ============

    [Theory]
    [InlineData("gel", VerbPerson.SecondSingular, "gel")]
    [InlineData("gel", VerbPerson.SecondPlural, "gelin")]
    [InlineData("gel", VerbPerson.ThirdSingular, "gelsin")]
    [InlineData("git", VerbPerson.SecondSingular, "gid")]  // git -> gid (yumuşama)
    [InlineData("oku", VerbPerson.SecondSingular, "oku")]
    public void Imperative_ShouldConjugateCorrectly(string verb, VerbPerson person, string expected)
    {
        var result = ImperativeMood.Conjugate(verb, person);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Imperative_Extension_ShouldWork()
    {
        Assert.Equal("gel", "gel".ToImperative());
        Assert.Equal("gidin", "git".ToImperative_Plural());
        Assert.Equal("geliniz", "gel".ToImperativePolite());
    }

    [Fact]
    public void Imperative_FirstPerson_ShouldThrowException()
    {
        Assert.Throws<InvalidOperationException>(() =>
            ImperativeMood.Conjugate("gel", VerbPerson.FirstSingular));

        Assert.Throws<InvalidOperationException>(() =>
            ImperativeMood.Conjugate("gel", VerbPerson.FirstPlural));
    }

    [Theory]
    [InlineData("gel", VerbPerson.SecondSingular, "gelme")]
    [InlineData("gel", VerbPerson.SecondPlural, "gelmeyin")]
    [InlineData("git", VerbPerson.SecondSingular, "gitme")]
    public void Imperative_Negative_ShouldWork(string verb, VerbPerson person, string expected)
    {
        var result = ImperativeMood.ConjugateNegative(verb, person);
        Assert.Equal(expected, result);
    }
}
