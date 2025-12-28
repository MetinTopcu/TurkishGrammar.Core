using TurkishGrammar.Core.VowelHarmony;
using TurkishGrammar.Pro.Verbs.Person;

namespace TurkishGrammar.Pro.Verbs.Tense;

/// <summary>
/// Geniş zaman (-ir/-ır/-ur/-ür, -ar/-er) yardımcı sınıfı
/// </summary>
public static class AoristTense
{
    // Tek heceli fiiller ve düzensiz fiiller -ar/-er alır
    private static readonly HashSet<string> _singleSyllableVerbs = new()
    {
        "al", "bil", "bul", "dur", "gel", "gör", "kal", "ol", "öl", "san", "var", "ver", "vur"
    };

    /// <summary>
    /// Fiil kökünü geniş zamana çevirir
    /// </summary>
    /// <param name="verbRoot">Fiil kökü (örn: "gel", "git", "oku")</param>
    /// <param name="person">Kişi eki</param>
    /// <returns>Çekimlenmiş fiil</returns>
    /// <example>
    /// AoristTense.Conjugate("gel", VerbPerson.FirstSingular) // "gelirim"
    /// AoristTense.Conjugate("git", VerbPerson.SecondSingular) // "gidersin"
    /// AoristTense.Conjugate("oku", VerbPerson.ThirdSingular) // "okur"
    /// </example>
    public static string Conjugate(string verbRoot, VerbPerson person)
    {
        if (string.IsNullOrWhiteSpace(verbRoot))
            throw new ArgumentException("Fiil kökü boş olamaz", nameof(verbRoot));

        verbRoot = verbRoot.Trim();

        // Ünsüz yumuşaması uygula
        var softened = ConsonantSofteningHelper.ApplySoftening(verbRoot);

        string baseForm;

        // Tek heceli fiiller veya özel fiiller -ar/-er alır
        if (_singleSyllableVerbs.Contains(verbRoot.ToLowerInvariant()))
        {
            var vowel = VowelHarmonyHelper.GetTwoWayHarmonizedVowel(softened);
            baseForm = softened + vowel + "r";
        }
        else
        {
            // Çok heceli fiiller -ir/-ır/-ur/-ür alır
            var vowel = VowelHarmonyHelper.GetFourWayHarmonizedVowel(softened);
            baseForm = softened + vowel + "r";
        }

        // Kişi eki ekle (geniş zaman için özel kişi ekleri)
        return AddAoristPersonSuffix(baseForm, person);
    }

    private static string AddAoristPersonSuffix(string verb, VerbPerson person)
    {
        var vowel = VowelHarmonyHelper.GetFourWayHarmonizedVowel(verb);

        return person switch
        {
            VerbPerson.FirstSingular => verb + vowel + "m",     // gelirim
            VerbPerson.SecondSingular => verb + "s" + vowel + "n", // gelirsin
            VerbPerson.ThirdSingular => verb,                    // gelir
            VerbPerson.FirstPlural => verb + vowel + "z",        // geliriz
            VerbPerson.SecondPlural => verb + "siniz",           // gelirsiniz
            VerbPerson.ThirdPlural => verb + "ler",              // gelirler
            _ => throw new ArgumentOutOfRangeException(nameof(person))
        };
    }

    /// <summary>
    /// Olumsuz geniş zaman (-maz/-mez)
    /// </summary>
    public static string ConjugateNegative(string verbRoot, VerbPerson person)
    {
        if (string.IsNullOrWhiteSpace(verbRoot))
            throw new ArgumentException("Fiil kökü boş olamaz", nameof(verbRoot));

        verbRoot = verbRoot.Trim();

        // -ma/-me olumsuzluk eki + -z
        var vowel = VowelHarmonyHelper.GetTwoWayHarmonizedVowel(verbRoot);
        var baseForm = verbRoot + "m" + vowel + "z";

        // Kişi eki ekle
        return AddAoristPersonSuffix(baseForm, person);
    }
}
