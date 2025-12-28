using TurkishGrammar.Pro.Suffixes.Plural;
using TurkishGrammar.Pro.Suffixes.Question;

namespace TurkishGrammar.Pro.Extensions.Tr;

/// <summary>
/// Pro string extension metodları (Türkçe API - advanced features)
/// </summary>
public static class TurkishStringProTrExtensions
{
    /// <summary>
    /// Kelimeyi çoğul yapar (-ler/-lar)
    /// </summary>
    /// <example>"ev".Çoğul() // "evler"</example>
    public static string Çoğul(this string word)
    {
        return PluralSuffixHelper.MakePlural(word);
    }

    /// <summary>
    /// Kelimeye soru eki ekler (-mi/-mı/-mu/-mü)
    /// </summary>
    /// <example>"geldin".SoruEki() // "geldin mi"</example>
    public static string SoruEki(this string word)
    {
        return QuestionParticleHelper.AddQuestionParticle(word);
    }

    /// <summary>
    /// Kelimeye olumsuz soru eki ekler
    /// </summary>
    /// <example>"öğrenci".OlumsuzSoru() // "öğrenci değil mi"</example>
    public static string OlumsuzSoru(this string word)
    {
        return QuestionParticleHelper.AddNegativeQuestion(word);
    }

    /// <summary>
    /// Çoğul + iyelik eki kombinasyonu
    /// </summary>
    /// <example>"ev".Çoğulİyelik(PossessivePerson.FirstSingular) // "evlerim"</example>
    public static string Çoğulİyelik(this string word, Core.Suffixes.Possessive.PossessivePerson person)
    {
        return PluralSuffixHelper.MakePluralWithPossessive(word, person);
    }

    /// <summary>
    /// Çoğul + iyelik (benim)
    /// </summary>
    /// <example>"ev".BenimÇoğul() // "evlerim" (benim evlerim)</example>
    public static string BenimÇoğul(this string word)
    {
        return PluralSuffixHelper.MakePluralWithPossessive(word, Core.Suffixes.Possessive.PossessivePerson.FirstSingular);
    }

    /// <summary>
    /// Çoğul + iyelik (bizim)
    /// </summary>
    /// <example>"araba".BizimÇoğul() // "arabalarımız" (bizim arabalarımız)</example>
    public static string BizimÇoğul(this string word)
    {
        return PluralSuffixHelper.MakePluralWithPossessive(word, Core.Suffixes.Possessive.PossessivePerson.FirstPlural);
    }
}
