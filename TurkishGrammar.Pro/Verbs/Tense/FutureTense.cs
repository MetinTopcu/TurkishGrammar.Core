using TurkishGrammar.Core.VowelHarmony;
using TurkishGrammar.Pro.Verbs.Person;

namespace TurkishGrammar.Pro.Verbs.Tense;

/// <summary>
/// Gelecek zaman (-acak/-ecek) yardımcı sınıfı
/// </summary>
public static class FutureTense
{
    /// <summary>
    /// Fiil kökünü gelecek zamana çevirir
    /// </summary>
    /// <param name="verbRoot">Fiil kökü (örn: "gel", "git", "oku")</param>
    /// <param name="person">Kişi eki</param>
    /// <returns>Çekimlenmiş fiil</returns>
    /// <example>
    /// FutureTense.Conjugate("gel", VerbPerson.FirstSingular) // "geleceğim"
    /// FutureTense.Conjugate("git", VerbPerson.SecondSingular) // "gideceksin"
    /// FutureTense.Conjugate("oku", VerbPerson.ThirdSingular) // "okuyacak"
    /// </example>
    public static string Conjugate(string verbRoot, VerbPerson person)
    {
        if (string.IsNullOrWhiteSpace(verbRoot))
            throw new ArgumentException("Fiil kökü boş olamaz", nameof(verbRoot));

        verbRoot = verbRoot.Trim();

        // Sesli harfle bitiyorsa yumuşatma ünsüzü ekle
        bool endsWithVowel = VowelHarmonyHelper.IsVowel(verbRoot[^1]);

        // Ünsüz yumuşaması uygula
        var softened = ConsonantSofteningHelper.ApplySoftening(verbRoot);

        // -acak/-ecek ekini belirle
        var vowel = VowelHarmonyHelper.GetTwoWayHarmonizedVowel(softened);
        string baseForm;

        if (endsWithVowel)
        {
            // Sesli harfle bitiyorsa yumuşatma ünsüzü ekle: oku-y-acak
            baseForm = softened + "y" + vowel + "c" + vowel + "k";
        }
        else
        {
            // Ünsüzle bitiyorsa direkt ek: gel-ecek
            baseForm = softened + vowel + "c" + vowel + "k";
        }

        // Kişi eki ekle
        return PersonSuffixHelper.AddFutureTensePersonSuffix(baseForm, person);
    }

    /// <summary>
    /// Olumsuz gelecek zaman (-mayacak/-meyecek)
    /// </summary>
    public static string ConjugateNegative(string verbRoot, VerbPerson person)
    {
        if (string.IsNullOrWhiteSpace(verbRoot))
            throw new ArgumentException("Fiil kökü boş olamaz", nameof(verbRoot));

        verbRoot = verbRoot.Trim();

        // -ma/-me olumsuzluk eki
        var negativeVowel = VowelHarmonyHelper.GetTwoWayHarmonizedVowel(verbRoot);
        var negativeForm = verbRoot + "m" + negativeVowel;

        // -yacak/-yecek ekini ekle
        var tenseVowel = VowelHarmonyHelper.GetTwoWayHarmonizedVowel(negativeForm);
        var baseForm = negativeForm + "y" + tenseVowel + "c" + tenseVowel + "k";

        // Kişi eki ekle
        return PersonSuffixHelper.AddFutureTensePersonSuffix(baseForm, person);
    }
}
