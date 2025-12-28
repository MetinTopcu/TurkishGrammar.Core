using TurkishGrammar.Core.VowelHarmony;
using TurkishGrammar.Pro.Verbs.Person;

namespace TurkishGrammar.Pro.Verbs.Tense;

/// <summary>
/// Şimdiki zaman (-iyor) yardımcı sınıfı
/// </summary>
public static class PresentContinuousTense
{
    /// <summary>
    /// Fiil kökünü şimdiki zamana çevirir
    /// </summary>
    /// <param name="verbRoot">Fiil kökü (örn: "gel", "git", "oku")</param>
    /// <param name="person">Kişi eki</param>
    /// <returns>Çekimlenmiş fiil</returns>
    /// <example>
    /// PresentContinuousTense.Conjugate("gel", VerbPerson.FirstSingular) // "geliyorum"
    /// PresentContinuousTense.Conjugate("git", VerbPerson.SecondSingular) // "gidiyorsun"
    /// </example>
    public static string Conjugate(string verbRoot, VerbPerson person)
    {
        if (string.IsNullOrWhiteSpace(verbRoot))
            throw new ArgumentException("Fiil kökü boş olamaz", nameof(verbRoot));

        verbRoot = verbRoot.Trim();

        // Sesli harfle bitiyorsa yumuşatma ünsüzü ekle
        bool endsWithVowel = VowelHarmonyHelper.IsVowel(verbRoot[^1]);

        // Ünsüz yumuşaması uygula (git -> gid)
        var softened = ConsonantSofteningHelper.ApplySoftening(verbRoot);

        // -iyor ekini ekle
        var vowel = VowelHarmonyHelper.GetFourWayHarmonizedVowel(softened);
        string baseForm;

        if (endsWithVowel)
        {
            baseForm = softened + "yor";
        }
        else
        {
            baseForm = softened + vowel + "yor";
        }

        // Kişi eki ekle
        return PersonSuffixHelper.AddPresentContinuousPersonSuffix(baseForm, person);
    }

    /// <summary>
    /// Olumsuz şimdiki zaman (-miyor)
    /// </summary>
    public static string ConjugateNegative(string verbRoot, VerbPerson person)
    {
        if (string.IsNullOrWhiteSpace(verbRoot))
            throw new ArgumentException("Fiil kökü boş olamaz", nameof(verbRoot));

        verbRoot = verbRoot.Trim();

        // -miyor ekini ekle
        var vowel = VowelHarmonyHelper.GetFourWayHarmonizedVowel(verbRoot);
        var baseForm = verbRoot + "m" + vowel + "yor";

        // Kişi eki ekle
        return PersonSuffixHelper.AddPresentContinuousPersonSuffix(baseForm, person);
    }
}
