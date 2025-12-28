using TurkishGrammar.Core.VowelHarmony;

namespace TurkishGrammar.Pro.Suffixes.Plural;

/// <summary>
/// Çoğul ekleri oluşturma yardımcı sınıfı (Pro feature)
/// </summary>
public static class PluralSuffixHelper
{
    /// <summary>
    /// Kelimeye çoğul eki ekler (-ler/-lar)
    /// </summary>
    /// <param name="word">Kelime (örn: "ev", "masa", "kitap")</param>
    /// <returns>Çoğul ekli kelime</returns>
    /// <example>
    /// PluralSuffixHelper.MakePlural("ev") // "evler"
    /// PluralSuffixHelper.MakePlural("masa") // "masalar"
    /// </example>
    public static string MakePlural(string word)
    {
        if (string.IsNullOrWhiteSpace(word))
            throw new ArgumentException("Kelime boş olamaz", nameof(word));

        word = word.Trim();

        var vowel = VowelHarmonyHelper.GetTwoWayHarmonizedVowel(word);
        return word + "l" + vowel + "r";
    }

    /// <summary>
    /// Kelimeye çoğul ve iyelik eki birlikte ekler
    /// Örnek: evlerim (benim evlerim), arabalarımız (bizim arabalarımız)
    /// </summary>
    /// <param name="word">Kelime</param>
    /// <param name="person">İyelik kişisi</param>
    /// <returns>Çoğul + iyelik ekli kelime</returns>
    public static string MakePluralWithPossessive(string word, Core.Suffixes.Possessive.PossessivePerson person)
    {
        if (string.IsNullOrWhiteSpace(word))
            throw new ArgumentException("Kelime boş olamaz", nameof(word));

        // Önce çoğul yap
        var pluralWord = MakePlural(word);

        // Sonra iyelik eki ekle
        return Core.Suffixes.Possessive.PossessiveSuffixHelper.AddPossessive(pluralWord, person);
    }
}
