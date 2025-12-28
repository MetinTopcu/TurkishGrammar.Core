using TurkishGrammar.Pro.Suffixes.Plural;
using TurkishGrammar.Pro.Suffixes.Question;

namespace TurkishGrammar.Pro.Extensions;

/// <summary>
/// Pro string extension metodları (advanced features)
/// </summary>
public static class TurkishStringProExtensions
{
    /// <summary>
    /// Kelimeyi çoğul yapar (-ler/-lar)
    /// </summary>
    /// <example>"ev".ToPlural() // "evler"</example>
    public static string ToPlural(this string word)
    {
        return PluralSuffixHelper.MakePlural(word);
    }

    /// <summary>
    /// Kelimeye soru eki ekler (-mi/-mı/-mu/-mü)
    /// </summary>
    /// <example>"geldin".ToQuestion() // "geldin mi"</example>
    public static string ToQuestion(this string word)
    {
        return QuestionParticleHelper.AddQuestionParticle(word);
    }

    /// <summary>
    /// Kelimeye olumsuz soru eki ekler
    /// </summary>
    /// <example>"öğrenci".ToNegativeQuestion() // "öğrenci değil mi"</example>
    public static string ToNegativeQuestion(this string word)
    {
        return QuestionParticleHelper.AddNegativeQuestion(word);
    }

    /// <summary>
    /// Çoğul + iyelik eki kombinasyonu
    /// </summary>
    /// <example>"ev".ToPluralWithPossessive(PossessivePerson.FirstSingular) // "evlerim"</example>
    public static string ToPluralWithPossessive(this string word, Core.Suffixes.Possessive.PossessivePerson person)
    {
        return PluralSuffixHelper.MakePluralWithPossessive(word, person);
    }

    /// <summary>
    /// Çoğul + iyelik (benim)
    /// </summary>
    /// <example>"ev".ToMyPluralPossessive() // "evlerim" (benim evlerim)</example>
    public static string ToMyPluralPossessive(this string word)
    {
        return PluralSuffixHelper.MakePluralWithPossessive(word, Core.Suffixes.Possessive.PossessivePerson.FirstSingular);
    }

    /// <summary>
    /// Çoğul + iyelik (bizim)
    /// </summary>
    /// <example>"araba".ToOurPluralPossessive() // "arabalarımız" (bizim arabalarımız)</example>
    public static string ToOurPluralPossessive(this string word)
    {
        return PluralSuffixHelper.MakePluralWithPossessive(word, Core.Suffixes.Possessive.PossessivePerson.FirstPlural);
    }
}
