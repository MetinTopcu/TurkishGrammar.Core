using TurkishGrammar.Core.VowelHarmony;
using TurkishGrammar.Pro.Verbs.Person;

namespace TurkishGrammar.Pro.Verbs.Mood;

/// <summary>
/// Şart kipi (-se/-sa) yardımcı sınıfı
/// </summary>
public static class ConditionalMood
{
    /// <summary>
    /// Fiil kökünü şart kipine çevirir
    /// </summary>
    /// <param name="verbRoot">Fiil kökü (örn: "gel", "git", "oku")</param>
    /// <param name="person">Kişi eki</param>
    /// <returns>Çekimlenmiş fiil</returns>
    /// <example>
    /// ConditionalMood.Conjugate("gel", VerbPerson.FirstSingular) // "gelsem"
    /// ConditionalMood.Conjugate("git", VerbPerson.SecondSingular) // "gidersen"
    /// ConditionalMood.Conjugate("oku", VerbPerson.ThirdSingular) // "okusa"
    /// </example>
    public static string Conjugate(string verbRoot, VerbPerson person)
    {
        if (string.IsNullOrWhiteSpace(verbRoot))
            throw new ArgumentException("Fiil kökü boş olamaz", nameof(verbRoot));

        verbRoot = verbRoot.Trim();

        // Ünsüz yumuşaması uygula
        var softened = ConsonantSofteningHelper.ApplySoftening(verbRoot);

        // -se/-sa ekini belirle
        var vowel = VowelHarmonyHelper.GetTwoWayHarmonizedVowel(softened);
        var baseForm = softened + "s" + vowel;

        // Kişi eki ekle
        return AddConditionalPersonSuffix(baseForm, person);
    }

    private static string AddConditionalPersonSuffix(string verb, VerbPerson person)
    {
        return person switch
        {
            VerbPerson.FirstSingular => verb + "m",      // gelsem
            VerbPerson.SecondSingular => verb + "n",     // gelsen
            VerbPerson.ThirdSingular => verb,            // gelse
            VerbPerson.FirstPlural => verb + "k",        // gelsek
            VerbPerson.SecondPlural => verb + "niz",     // gelseniz
            VerbPerson.ThirdPlural => verb + "ler",      // gelseler
            _ => throw new ArgumentOutOfRangeException(nameof(person))
        };
    }

    /// <summary>
    /// Olumsuz şart kipi (-masa/-mese)
    /// </summary>
    public static string ConjugateNegative(string verbRoot, VerbPerson person)
    {
        if (string.IsNullOrWhiteSpace(verbRoot))
            throw new ArgumentException("Fiil kökü boş olamaz", nameof(verbRoot));

        verbRoot = verbRoot.Trim();

        // -ma/-me olumsuzluk eki
        var negativeVowel = VowelHarmonyHelper.GetTwoWayHarmonizedVowel(verbRoot);
        var negativeForm = verbRoot + "m" + negativeVowel;

        // -sa/-se şart eki
        var conditionalVowel = VowelHarmonyHelper.GetTwoWayHarmonizedVowel(negativeForm);
        var baseForm = negativeForm + "s" + conditionalVowel;

        // Kişi eki ekle
        return AddConditionalPersonSuffix(baseForm, person);
    }
}
