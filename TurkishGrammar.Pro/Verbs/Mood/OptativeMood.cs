using TurkishGrammar.Core.VowelHarmony;
using TurkishGrammar.Pro.Verbs.Person;

namespace TurkishGrammar.Pro.Verbs.Mood;

/// <summary>
/// İstek kipi (-e/-a, -eyim/-ayım) yardımcı sınıfı
/// </summary>
public static class OptativeMood
{
    /// <summary>
    /// Fiil kökünü istek kipine çevirir
    /// </summary>
    /// <param name="verbRoot">Fiil kökü (örn: "gel", "git", "oku")</param>
    /// <param name="person">Kişi eki</param>
    /// <returns>Çekimlenmiş fiil</returns>
    /// <example>
    /// OptativeMood.Conjugate("gel", VerbPerson.FirstSingular) // "geleyim"
    /// OptativeMood.Conjugate("git", VerbPerson.SecondSingular) // "gidesin"
    /// OptativeMood.Conjugate("oku", VerbPerson.ThirdSingular) // "okusun" veya "okuya"
    /// </example>
    public static string Conjugate(string verbRoot, VerbPerson person)
    {
        if (string.IsNullOrWhiteSpace(verbRoot))
            throw new ArgumentException("Fiil kökü boş olamaz", nameof(verbRoot));

        verbRoot = verbRoot.Trim();

        // Ünsüz yumuşaması uygula
        var softened = ConsonantSofteningHelper.ApplySoftening(verbRoot);

        // -e/-a ekini belirle
        var vowel = VowelHarmonyHelper.GetTwoWayHarmonizedVowel(softened);

        // Kişiye göre farklı şekilde ekle
        return person switch
        {
            VerbPerson.FirstSingular => softened + vowel + "y" + VowelHarmonyHelper.GetFourWayHarmonizedVowel(softened) + "m",  // geleyim
            VerbPerson.SecondSingular => softened + vowel + "sin",         // gelesin
            VerbPerson.ThirdSingular => softened + vowel,                  // gele
            VerbPerson.FirstPlural => softened + vowel + "l" + VowelHarmonyHelper.GetFourWayHarmonizedVowel(softened) + "m",    // gelelim
            VerbPerson.SecondPlural => softened + vowel + "siniz",         // gelesiniz
            VerbPerson.ThirdPlural => softened + vowel + "ler",            // geleler
            _ => throw new ArgumentOutOfRangeException(nameof(person))
        };
    }

    /// <summary>
    /// Olumsuz istek kipi (-maya/-meye)
    /// </summary>
    public static string ConjugateNegative(string verbRoot, VerbPerson person)
    {
        if (string.IsNullOrWhiteSpace(verbRoot))
            throw new ArgumentException("Fiil kökü boş olamaz", nameof(verbRoot));

        verbRoot = verbRoot.Trim();

        // -ma/-me olumsuzluk eki
        var negativeVowel = VowelHarmonyHelper.GetTwoWayHarmonizedVowel(verbRoot);
        var negativeForm = verbRoot + "m" + negativeVowel;

        // İstek kipi ekle
        return Conjugate(negativeForm, person);
    }
}
