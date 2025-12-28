using TurkishGrammar.Pro.Verbs.Tense;
using TurkishGrammar.Pro.Verbs.Person;
using TurkishGrammar.Pro.Extensions;

namespace TurkishGrammar.Tests;

public class VerbTenseTests
{
    // ============ Şimdiki Zaman Tests ============

    [Theory]
    [InlineData("gel", VerbPerson.FirstSingular, "geliyorum")]
    [InlineData("gel", VerbPerson.SecondSingular, "geliyorsun")]
    [InlineData("gel", VerbPerson.ThirdSingular, "geliyor")]
    [InlineData("git", VerbPerson.FirstSingular, "gidiyorum")]
    [InlineData("oku", VerbPerson.FirstSingular, "okuyorum")]
    public void PresentContinuous_ShouldConjugateCorrectly(string verb, VerbPerson person, string expected)
    {
        var result = PresentContinuousTense.Conjugate(verb, person);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void PresentContinuous_Extension_ShouldWork()
    {
        Assert.Equal("geliyorum", "gel".ToPresentContinuous_I());
        Assert.Equal("gidiyorsun", "git".ToPresentContinuous_You());
        Assert.Equal("okuyor", "oku".ToPresentContinuous_He());
    }

    // ============ Geçmiş Zaman Tests ============

    [Theory]
    [InlineData("gel", VerbPerson.FirstSingular, "geldim")]
    [InlineData("gel", VerbPerson.SecondSingular, "geldin")]
    [InlineData("gel", VerbPerson.ThirdSingular, "geldi")]
    [InlineData("git", VerbPerson.FirstSingular, "giddim")]  // git -> gid (yumuşama)
    [InlineData("oku", VerbPerson.FirstSingular, "okudum")]
    [InlineData("bak", VerbPerson.FirstSingular, "bağdım")]  // bak -> bağ (k->ğ yumuşaması)
    public void PastTense_ShouldConjugateCorrectly(string verb, VerbPerson person, string expected)
    {
        var result = PastTense.Conjugate(verb, person);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void PastTense_Extension_ShouldWork()
    {
        Assert.Equal("geldim", "gel".ToPastTense_I());
        Assert.Equal("giddin", "git".ToPastTense_You());  // git -> gid (yumuşama)
        Assert.Equal("okudu", "oku".ToPastTense_He());
    }

    // ============ Gelecek Zaman Tests ============

    [Theory]
    [InlineData("gel", VerbPerson.FirstSingular, "geleceğim")]
    [InlineData("gel", VerbPerson.SecondSingular, "geleceksin")]
    [InlineData("gel", VerbPerson.ThirdSingular, "gelecek")]
    [InlineData("git", VerbPerson.FirstSingular, "gideceğim")]
    [InlineData("oku", VerbPerson.FirstSingular, "okuyacağım")]
    public void FutureTense_ShouldConjugateCorrectly(string verb, VerbPerson person, string expected)
    {
        var result = FutureTense.Conjugate(verb, person);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void FutureTense_Extension_ShouldWork()
    {
        Assert.Equal("geleceğim", "gel".ToFutureTense_I());
        Assert.Equal("gideceksin", "git".ToFutureTense_You());
        Assert.Equal("okuyacak", "oku".ToFutureTense_He());
    }

    // ============ Geniş Zaman Tests ============

    [Theory]
    [InlineData("gel", VerbPerson.FirstSingular, "gelerim")]  // gel tek heceli -er alır
    [InlineData("gel", VerbPerson.SecondSingular, "gelersin")]
    [InlineData("gel", VerbPerson.ThirdSingular, "geler")]
    [InlineData("git", VerbPerson.FirstSingular, "gidirim")]  // git -> gidirim (küçük ünlü uyumu)
    [InlineData("oku", VerbPerson.FirstSingular, "okuurum")]  // oku sesli harfle biter
    public void AoristTense_ShouldConjugateCorrectly(string verb, VerbPerson person, string expected)
    {
        var result = AoristTense.Conjugate(verb, person);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void AoristTense_Extension_ShouldWork()
    {
        Assert.Equal("gelerim", "gel".ToAoristTense_I());
        Assert.Equal("gidirsin", "git".ToAoristTense_You());  // git -> gidirsin
        Assert.Equal("okuur", "oku".ToAoristTense_He());  // oku sesli harfle biter
    }
}
