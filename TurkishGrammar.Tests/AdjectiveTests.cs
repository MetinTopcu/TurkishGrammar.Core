using TurkishGrammar.Pro.Adjectives;
using TurkishGrammar.Pro.Extensions;

namespace TurkishGrammar.Tests;

public class AdjectiveTests
{
    [Theory]
    [InlineData("güzel", "en güzel")]
    [InlineData("büyük", "en büyük")]
    [InlineData("küçük", "en küçük")]
    public void MakeSuperlative_ShouldAddEnPrefix(string adjective, string expected)
    {
        var result = ComparativeHelper.MakeSuperlative(adjective);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("güzel", "daha güzel")]
    [InlineData("büyük", "daha büyük")]
    [InlineData("küçük", "daha küçük")]
    public void MakeComparative_ShouldAddDahaPrefix(string adjective, string expected)
    {
        var result = ComparativeHelper.MakeComparative(adjective);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("güzel", "Ali", "Aliden daha güzel")]
    [InlineData("büyük", "ev", "evden daha büyük")]
    [InlineData("hızlı", "araba", "arabadan daha hızlı")]
    public void CompareWith_ShouldAddAblativeAndDaha(string adjective, string comparedTo, string expected)
    {
        var result = ComparativeHelper.CompareWith(adjective, comparedTo);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("güzel", "en az güzel")]
    [InlineData("pahalı", "en az pahalı")]
    public void MakeLeastSuperlative_ShouldWork(string adjective, string expected)
    {
        var result = ComparativeHelper.MakeLeastSuperlative(adjective);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("güzel", "daha az güzel")]
    [InlineData("pahalı", "daha az pahalı")]
    public void MakeLessComparative_ShouldWork(string adjective, string expected)
    {
        var result = ComparativeHelper.MakeLessComparative(adjective);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Adjective_Extensions_ShouldWork()
    {
        Assert.Equal("en güzel", "güzel".ToSuperlative());
        Assert.Equal("daha büyük", "büyük".ToComparative());
        Assert.Equal("evden daha küçük", "küçük".CompareWith("ev"));
        Assert.Equal("en az pahalı", "pahalı".ToLeastSuperlative());
        Assert.Equal("daha az hızlı", "hızlı".ToLessComparative());
    }

    [Fact]
    public void Comparative_NullAdjective_ShouldThrowException()
    {
        Assert.Throws<ArgumentException>(() => ComparativeHelper.MakeSuperlative(null!));
        Assert.Throws<ArgumentException>(() => ComparativeHelper.MakeComparative(null!));
    }
}
