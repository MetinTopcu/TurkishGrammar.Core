using TurkishGrammar.Core.VowelHarmony;

namespace TurkishGrammar.Tests;

public class VowelHarmonyTests
{
    [Theory]
    [InlineData('a', true)]
    [InlineData('e', true)]
    [InlineData('ı', true)]
    [InlineData('i', true)]
    [InlineData('o', true)]
    [InlineData('ö', true)]
    [InlineData('u', true)]
    [InlineData('ü', true)]
    [InlineData('b', false)]
    [InlineData('k', false)]
    [InlineData('m', false)]
    public void IsVowel_ShouldIdentifyVowelsCorrectly(char c, bool expected)
    {
        var result = VowelHarmonyHelper.IsVowel(c);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("ev", 'e')]
    [InlineData("masa", 'a')]
    [InlineData("kitap", 'a')]
    [InlineData("gül", 'ü')]
    [InlineData("kız", 'ı')]
    [InlineData("kök", 'ö')]
    public void GetLastVowel_ShouldReturnCorrectVowel(string word, char expected)
    {
        var result = VowelHarmonyHelper.GetLastVowel(word);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("ev", 'e', 'a', 'e')]  // ince sesli -> 'e'
    [InlineData("masa", 'e', 'a', 'a')] // kalın sesli -> 'a'
    [InlineData("kitap", 'e', 'a', 'a')]
    [InlineData("gül", 'e', 'a', 'e')]
    public void GetHarmonizedVowel_ShouldReturnCorrectVowel(string word, char front, char back, char expected)
    {
        var result = VowelHarmonyHelper.GetHarmonizedVowel(word, front, back);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("ev", 'i')]    // ince düz -> i
    [InlineData("masa", 'ı')]  // kalın düz -> ı
    [InlineData("kol", 'u')]   // kalın yuvarlak -> u
    [InlineData("göl", 'ü')]   // ince yuvarlak -> ü
    [InlineData("dal", 'ı')]
    [InlineData("el", 'i')]
    [InlineData("gül", 'ü')]
    [InlineData("yol", 'u')]
    public void GetFourWayHarmonizedVowel_ShouldReturnCorrectVowel(string word, char expected)
    {
        var result = VowelHarmonyHelper.GetFourWayHarmonizedVowel(word);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("ev", 'e')]
    [InlineData("masa", 'a')]
    [InlineData("kitap", 'a')]
    [InlineData("gül", 'e')]
    public void GetTwoWayHarmonizedVowel_ShouldReturnCorrectVowel(string word, char expected)
    {
        var result = VowelHarmonyHelper.GetTwoWayHarmonizedVowel(word);
        Assert.Equal(expected, result);
    }
}
