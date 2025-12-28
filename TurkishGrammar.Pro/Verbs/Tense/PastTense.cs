using TurkishGrammar.Core.VowelHarmony;
using TurkishGrammar.Pro.Verbs.Person;

namespace TurkishGrammar.Pro.Verbs.Tense;

/// <summary>
/// Geçmiş zaman (-di/-dı/-du/-dü) yardımcı sınıfı
/// </summary>
public static class PastTense
{
    /// <summary>
    /// Fiil kökünü geçmiş zamana çevirir
    /// </summary>
    /// <param name="verbRoot">Fiil kökü (örn: "gel", "git", "oku")</param>
    /// <param name="person">Kişi eki</param>
    /// <returns>Çekimlenmiş fiil</returns>
    /// <example>
    /// PastTense.Conjugate("gel", VerbPerson.FirstSingular) // "geldim"
    /// PastTense.Conjugate("git", VerbPerson.SecondSingular) // "gittin"
    /// PastTense.Conjugate("oku", VerbPerson.ThirdSingular) // "okudu"
    /// </example>
    public static string Conjugate(string verbRoot, VerbPerson person)
    {
        if (string.IsNullOrWhiteSpace(verbRoot))
            throw new ArgumentException("Fiil kökü boş olamaz", nameof(verbRoot));

        verbRoot = verbRoot.Trim();

        // Ünsüz yumuşaması uygula
        var softened = ConsonantSofteningHelper.ApplySoftening(verbRoot);

        // -di/-dı/-du/-dü ekini belirle
        var vowel = VowelHarmonyHelper.GetFourWayHarmonizedVowel(softened);
        var baseForm = softened + "d" + vowel;

        // Kişi eki ekle
        return PersonSuffixHelper.AddPastTensePersonSuffix(baseForm, person);
    }

    /// <summary>
    /// Olumsuz geçmiş zaman (-madi/-madı/-medi/-medü)
    /// </summary>
    public static string ConjugateNegative(string verbRoot, VerbPerson person)
    {
        if (string.IsNullOrWhiteSpace(verbRoot))
            throw new ArgumentException("Fiil kökü boş olamaz", nameof(verbRoot));

        verbRoot = verbRoot.Trim();

        // -ma/-me olumsuzluk eki
        var negativeVowel = VowelHarmonyHelper.GetTwoWayHarmonizedVowel(verbRoot);
        var negativeForm = verbRoot + "m" + negativeVowel;

        // -di ekini ekle
        var tenseVowel = VowelHarmonyHelper.GetFourWayHarmonizedVowel(negativeForm);
        var baseForm = negativeForm + "d" + tenseVowel;

        // Kişi eki ekle
        return PersonSuffixHelper.AddPastTensePersonSuffix(baseForm, person);
    }
}
