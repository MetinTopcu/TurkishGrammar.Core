using TurkishGrammar.Core.VowelHarmony;

namespace TurkishGrammar.Core.Suffixes.Possessive;

/// <summary>
/// İyelik ekleri oluşturma yardımcı sınıfı
/// </summary>
public static class PossessiveSuffixHelper
{
    /// <summary>
    /// Verilen kelimeye iyelik eki ekler
    /// </summary>
    /// <param name="word">Kelime (örn: "ev", "araba", "masa")</param>
    /// <param name="person">İyelik kişisi</param>
    /// <returns>İyelik ekli kelime</returns>
    public static string AddPossessive(string word, PossessivePerson person)
    {
        if (string.IsNullOrWhiteSpace(word))
            throw new ArgumentException("Kelime boş olamaz", nameof(word));

        word = word.Trim();
        bool endsWithVowel = VowelHarmonyHelper.IsVowel(word[^1]);

        return person switch
        {
            PossessivePerson.FirstSingular => AddFirstSingular(word, endsWithVowel),
            PossessivePerson.SecondSingular => AddSecondSingular(word, endsWithVowel),
            PossessivePerson.ThirdSingular => AddThirdSingular(word, endsWithVowel),
            PossessivePerson.FirstPlural => AddFirstPlural(word, endsWithVowel),
            PossessivePerson.SecondPlural => AddSecondPlural(word, endsWithVowel),
            PossessivePerson.ThirdPlural => AddThirdPlural(word, endsWithVowel),
            _ => throw new ArgumentOutOfRangeException(nameof(person))
        };
    }

    private static string AddFirstSingular(string word, bool endsWithVowel)
    {
        // -(i)m
        if (endsWithVowel)
            return word + "m";

        // Ünsüz yumuşaması uygula
        word = ConsonantSofteningHelper.ApplySoftening(word);
        var vowel = VowelHarmonyHelper.GetFourWayHarmonizedVowel(word);
        return word + vowel + "m";
    }

    private static string AddSecondSingular(string word, bool endsWithVowel)
    {
        // -(i)n
        if (endsWithVowel)
            return word + "n";

        // Ünsüz yumuşaması uygula
        word = ConsonantSofteningHelper.ApplySoftening(word);
        var vowel = VowelHarmonyHelper.GetFourWayHarmonizedVowel(word);
        return word + vowel + "n";
    }

    private static string AddThirdSingular(string word, bool endsWithVowel)
    {
        // -(s)i(n)
        if (endsWithVowel)
        {
            var vowel = VowelHarmonyHelper.GetFourWayHarmonizedVowel(word);
            return word + "s" + vowel;
        }
        else
        {
            // Ünsüz yumuşaması uygula
            word = ConsonantSofteningHelper.ApplySoftening(word);
            var vowel = VowelHarmonyHelper.GetFourWayHarmonizedVowel(word);
            return word + vowel;
        }
    }

    private static string AddFirstPlural(string word, bool endsWithVowel)
    {
        // -(i)miz
        if (endsWithVowel)
        {
            var vowel = VowelHarmonyHelper.GetFourWayHarmonizedVowel(word);
            return word + "m" + vowel + "z";
        }

        // Ünsüz yumuşaması uygula
        word = ConsonantSofteningHelper.ApplySoftening(word);
        var harmonizedVowel = VowelHarmonyHelper.GetFourWayHarmonizedVowel(word);
        return word + harmonizedVowel + "m" + harmonizedVowel + "z";
    }

    private static string AddSecondPlural(string word, bool endsWithVowel)
    {
        // -(i)niz
        if (endsWithVowel)
        {
            var vowel = VowelHarmonyHelper.GetFourWayHarmonizedVowel(word);
            return word + "n" + vowel + "z";
        }

        // Ünsüz yumuşaması uygula
        word = ConsonantSofteningHelper.ApplySoftening(word);
        var harmonizedVowel = VowelHarmonyHelper.GetFourWayHarmonizedVowel(word);
        return word + harmonizedVowel + "n" + harmonizedVowel + "z";
    }

    private static string AddThirdPlural(string word, bool endsWithVowel)
    {
        // -leri/-ları
        var firstVowel = VowelHarmonyHelper.GetTwoWayHarmonizedVowel(word);
        // İkinci sesli harf "ler/lar" eklendikten sonraki duruma göre belirlenmeli
        // "ler" -> "i", "lar" -> "ı"
        var secondVowel = firstVowel == 'e' ? 'i' : 'ı';

        return word + $"l{firstVowel}r{secondVowel}";
    }
}
