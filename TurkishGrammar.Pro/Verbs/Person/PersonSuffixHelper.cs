using TurkishGrammar.Core.VowelHarmony;

namespace TurkishGrammar.Pro.Verbs.Person;

/// <summary>
/// Fiil kişi ekleri yardımcı sınıfı
/// </summary>
public static class PersonSuffixHelper
{
    /// <summary>
    /// Geçmiş zaman kişi ekleri ekler (-di + kişi eki)
    /// </summary>
    public static string AddPastTensePersonSuffix(string verb, VerbPerson person)
    {
        if (string.IsNullOrWhiteSpace(verb))
            throw new ArgumentException("Fiil boş olamaz", nameof(verb));

        verb = verb.Trim();

        return person switch
        {
            VerbPerson.FirstSingular => verb + "m",      // geldim
            VerbPerson.SecondSingular => verb + "n",     // geldin
            VerbPerson.ThirdSingular => verb,            // geldi
            VerbPerson.FirstPlural => verb + "k",        // geldik
            VerbPerson.SecondPlural => verb + "niz",     // geldiniz (sesli uyumu gerekebilir)
            VerbPerson.ThirdPlural => verb + "ler",      // geldiler (sesli uyumu gerekebilir)
            _ => throw new ArgumentOutOfRangeException(nameof(person))
        };
    }

    /// <summary>
    /// Şimdiki zaman kişi ekleri ekler (-iyor + kişi eki)
    /// </summary>
    public static string AddPresentContinuousPersonSuffix(string verb, VerbPerson person)
    {
        if (string.IsNullOrWhiteSpace(verb))
            throw new ArgumentException("Fiil boş olamaz", nameof(verb));

        verb = verb.Trim();
        var vowel = VowelHarmonyHelper.GetFourWayHarmonizedVowel(verb);

        return person switch
        {
            VerbPerson.FirstSingular => verb + "um",     // geliyorum
            VerbPerson.SecondSingular => verb + "sun",   // geliyorsun
            VerbPerson.ThirdSingular => verb,            // geliyor
            VerbPerson.FirstPlural => verb + "uz",       // geliyoruz
            VerbPerson.SecondPlural => verb + "sunuz",   // geliyorsunuz
            VerbPerson.ThirdPlural => verb + "lar",      // geliyorlar
            _ => throw new ArgumentOutOfRangeException(nameof(person))
        };
    }

    /// <summary>
    /// Gelecek zaman kişi ekleri ekler (-acak + kişi eki)
    /// </summary>
    public static string AddFutureTensePersonSuffix(string verb, VerbPerson person)
    {
        if (string.IsNullOrWhiteSpace(verb))
            throw new ArgumentException("Fiil boş olamaz", nameof(verb));

        verb = verb.Trim();

        // k->ğ yumuşaması için (gelecek + im -> geleceğim)
        string baseForm = verb;
        if (verb.EndsWith("k", StringComparison.OrdinalIgnoreCase))
        {
            baseForm = verb[..^1] + "ğ";  // gelecek -> geleceğ
        }

        var vowel = VowelHarmonyHelper.GetFourWayHarmonizedVowel(baseForm);

        return person switch
        {
            VerbPerson.FirstSingular => baseForm + vowel + "m",     // geleceğim
            VerbPerson.SecondSingular => verb + "s" + vowel + "n",  // geleceksin (k korunur)
            VerbPerson.ThirdSingular => verb,                        // gelecek
            VerbPerson.FirstPlural => baseForm + vowel + "z",        // geleceğiz
            VerbPerson.SecondPlural => verb + "siniz",               // geleceksiniz
            VerbPerson.ThirdPlural => verb + "ler",                  // gelecekler
            _ => throw new ArgumentOutOfRangeException(nameof(person))
        };
    }
}
