using TurkishGrammar.Core.VowelHarmony;

namespace TurkishGrammar.Core.Suffixes.Case;

/// <summary>
/// Hal ekleri oluşturma yardımcı sınıfı
/// </summary>
public static class CaseSuffixHelper
{
    // Ünsüz sertleşmesi gerektiren harfler (bulunma ve ayrılma halleri için)
    private static readonly HashSet<char> _voicelessConsonants = new() { 'p', 't', 'ç', 'k', 'f', 's', 'ş', 'h' };

    /// <summary>
    /// Verilen kelimeye hal eki ekler
    /// </summary>
    /// <param name="word">Kelime (örn: "ev", "masa", "kitap")</param>
    /// <param name="caseType">Hal türü</param>
    /// <returns>Hal ekli kelime</returns>
    public static string AddCase(string word, CaseType caseType)
    {
        if (string.IsNullOrWhiteSpace(word))
            throw new ArgumentException("Kelime boş olamaz", nameof(word));

        word = word.Trim();

        return caseType switch
        {
            CaseType.Nominative => word,
            CaseType.Accusative => AddAccusative(word),
            CaseType.Dative => AddDative(word),
            CaseType.Locative => AddLocative(word),
            CaseType.Ablative => AddAblative(word),
            CaseType.Instrumental => AddInstrumental(word),
            _ => throw new ArgumentOutOfRangeException(nameof(caseType))
        };
    }

    private static string AddAccusative(string word)
    {
        // -i, -ı, -u, -ü (belirtme hali)
        bool endsWithVowel = VowelHarmonyHelper.IsVowel(word[^1]);

        if (endsWithVowel)
        {
            // Sesli harfle bitiyorsa yumuşatma ünsüzü ekle: Ali-yi, masa-yı
            var vowel = VowelHarmonyHelper.GetFourWayHarmonizedVowel(word);
            return word + "y" + vowel;
        }
        else
        {
            // Ünsüz yumuşaması uygula: kitap -> kitabı
            word = ConsonantSofteningHelper.ApplySoftening(word);
            var vowel = VowelHarmonyHelper.GetFourWayHarmonizedVowel(word);
            return word + vowel;
        }
    }

    private static string AddDative(string word)
    {
        // -e, -a (yönelme hali)
        bool endsWithVowel = VowelHarmonyHelper.IsVowel(word[^1]);

        if (endsWithVowel)
        {
            // Sesli harfle bitiyorsa yumuşatma ünsüzü ekle: Ali-ye, masa-ya
            var vowel = VowelHarmonyHelper.GetTwoWayHarmonizedVowel(word);
            return word + "y" + vowel;
        }
        else
        {
            // Ünsüz yumuşaması uygula: kitap -> kitaba
            word = ConsonantSofteningHelper.ApplySoftening(word);
            var vowel = VowelHarmonyHelper.GetTwoWayHarmonizedVowel(word);
            return word + vowel;
        }
    }

    private static string AddLocative(string word)
    {
        // -de, -da, -te, -ta (bulunma hali)
        var vowel = VowelHarmonyHelper.GetTwoWayHarmonizedVowel(word);
        var lastChar = char.ToLowerInvariant(word[^1]);

        // Sesli harfle bitenlere direkt -de/-da
        if (VowelHarmonyHelper.IsVowel(lastChar))
        {
            return word + "d" + vowel;
        }

        // Ünsüz sertleşmesi kontrolü
        if (_voicelessConsonants.Contains(lastChar))
        {
            // Sert ünsüzle bitiyorsa -te/-ta: kitap-ta, ağaç-ta
            return word + "t" + vowel;
        }
        else
        {
            // Yumuşak ünsüzle bitiyorsa -de/-da: ev-de, araba-da
            return word + "d" + vowel;
        }
    }

    private static string AddAblative(string word)
    {
        // -den, -dan, -ten, -tan (ayrılma hali)
        var vowel = VowelHarmonyHelper.GetTwoWayHarmonizedVowel(word);
        var lastChar = char.ToLowerInvariant(word[^1]);

        // Sesli harfle bitenlere direkt -den/-dan
        if (VowelHarmonyHelper.IsVowel(lastChar))
        {
            return word + "d" + vowel + "n";
        }

        // Ünsüz sertleşmesi kontrolü
        if (_voicelessConsonants.Contains(lastChar))
        {
            // Sert ünsüzle bitiyorsa -ten/-tan: kitap-tan, ağaç-tan
            return word + "t" + vowel + "n";
        }
        else
        {
            // Yumuşak ünsüzle bitiyorsa -den/-dan: ev-den, araba-dan
            return word + "d" + vowel + "n";
        }
    }

    private static string AddInstrumental(string word)
    {
        // -le, -la, -ile, -yla (vasıta hali)
        var vowel = VowelHarmonyHelper.GetTwoWayHarmonizedVowel(word);
        bool endsWithVowel = VowelHarmonyHelper.IsVowel(word[^1]);

        if (endsWithVowel)
        {
            // Sesli harfle bitiyorsa -yla/-yle: Ali-yle, masa-yla
            return word + "y" + "l" + vowel;
        }
        else
        {
            // Ünsüzle bitiyorsa -le/-la: kalem-le, kitap-la
            return word + "l" + vowel;
        }
    }
}
