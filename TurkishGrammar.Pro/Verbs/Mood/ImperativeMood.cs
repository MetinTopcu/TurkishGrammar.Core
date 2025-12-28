using TurkishGrammar.Core.VowelHarmony;
using TurkishGrammar.Pro.Verbs.Person;

namespace TurkishGrammar.Pro.Verbs.Mood;

/// <summary>
/// Emir kipi yardımcı sınıfı
/// </summary>
public static class ImperativeMood
{
    /// <summary>
    /// Fiil kökünü emir kipine çevirir
    /// </summary>
    /// <param name="verbRoot">Fiil kökü (örn: "gel", "git", "oku")</param>
    /// <param name="person">Kişi eki (emir kipi için sadece 2. ve 3. şahıslar kullanılır)</param>
    /// <returns>Çekimlenmiş fiil</returns>
    /// <example>
    /// ImperativeMood.Conjugate("gel", VerbPerson.SecondSingular) // "gel"
    /// ImperativeMood.Conjugate("git", VerbPerson.SecondPlural) // "gidin"
    /// ImperativeMood.Conjugate("oku", VerbPerson.ThirdSingular) // "okusun"
    /// </example>
    public static string Conjugate(string verbRoot, VerbPerson person)
    {
        if (string.IsNullOrWhiteSpace(verbRoot))
            throw new ArgumentException("Fiil kökü boş olamaz", nameof(verbRoot));

        verbRoot = verbRoot.Trim();

        // Ünsüz yumuşaması uygula
        var softened = ConsonantSofteningHelper.ApplySoftening(verbRoot);

        return person switch
        {
            // 1. şahıslar emir kipinde kullanılmaz, istek kipi kullanılır
            VerbPerson.FirstSingular => throw new InvalidOperationException("Birinci tekil şahıs için emir kipi kullanılamaz. İstek kipi kullanın."),
            VerbPerson.FirstPlural => throw new InvalidOperationException("Birinci çoğul şahıs için emir kipi kullanılamaz. İstek kipi kullanın."),

            // 2. tekil şahıs - kök hali
            VerbPerson.SecondSingular => softened,  // gel, git, oku

            // 2. çoğul şahıs - -in/-ın/-un/-ün
            VerbPerson.SecondPlural => softened + VowelHarmonyHelper.GetFourWayHarmonizedVowel(softened) + "n",  // gelin, gidin

            // 3. tekil şahıs - -sin/-sın/-sun/-sün
            VerbPerson.ThirdSingular => softened + "s" + VowelHarmonyHelper.GetFourWayHarmonizedVowel(softened) + "n",  // gelsin

            // 3. çoğul şahıs - -sinler
            VerbPerson.ThirdPlural => softened + "s" + VowelHarmonyHelper.GetFourWayHarmonizedVowel(softened) + "nler",  // gelsinler

            _ => throw new ArgumentOutOfRangeException(nameof(person))
        };
    }

    /// <summary>
    /// Olumsuz emir kipi (-ma/-me)
    /// </summary>
    public static string ConjugateNegative(string verbRoot, VerbPerson person)
    {
        if (string.IsNullOrWhiteSpace(verbRoot))
            throw new ArgumentException("Fiil kökü boş olamaz", nameof(verbRoot));

        verbRoot = verbRoot.Trim();

        // -ma/-me olumsuzluk eki
        var vowel = VowelHarmonyHelper.GetTwoWayHarmonizedVowel(verbRoot);
        var negativeForm = verbRoot + "m" + vowel;

        return person switch
        {
            VerbPerson.FirstSingular => throw new InvalidOperationException("Birinci tekil şahıs için emir kipi kullanılamaz."),
            VerbPerson.FirstPlural => throw new InvalidOperationException("Birinci çoğul şahıs için emir kipi kullanılamaz."),

            VerbPerson.SecondSingular => negativeForm,  // gelme, gitme

            VerbPerson.SecondPlural => negativeForm + "yin",  // gelmeyin (özel durum, sabit -yin)

            VerbPerson.ThirdSingular => negativeForm + "s" + VowelHarmonyHelper.GetFourWayHarmonizedVowel(negativeForm) + "n",  // gelmesin

            VerbPerson.ThirdPlural => negativeForm + "sinler",  // gelmesinler

            _ => throw new ArgumentOutOfRangeException(nameof(person))
        };
    }

    /// <summary>
    /// Kibarlık ifadesi için emir kipi (-iniz/-ınız/-unuz/-ünüz)
    /// </summary>
    public static string ConjugatePolite(string verbRoot)
    {
        if (string.IsNullOrWhiteSpace(verbRoot))
            throw new ArgumentException("Fiil kökü boş olamaz", nameof(verbRoot));

        verbRoot = verbRoot.Trim();

        // Ünsüz yumuşaması uygula
        var softened = ConsonantSofteningHelper.ApplySoftening(verbRoot);

        // -iniz/-ınız/-unuz/-ünüz
        var vowel = VowelHarmonyHelper.GetFourWayHarmonizedVowel(softened);
        return softened + vowel + "n" + vowel + "z";  // geliniz, gidiniz
    }
}
