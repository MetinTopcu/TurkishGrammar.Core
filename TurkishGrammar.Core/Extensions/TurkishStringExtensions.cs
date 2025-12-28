using TurkishGrammar.Core.Suffixes.Case;
using TurkishGrammar.Core.Suffixes.Possessive;

namespace TurkishGrammar.Core.Extensions;

/// <summary>
/// String için Türkçe gramer extension metodları
/// </summary>
public static class TurkishStringExtensions
{
    /// <summary>
    /// Kelimeye iyelik eki ekler
    /// </summary>
    /// <example>
    /// "ev".WithPossessive(PossessivePerson.FirstSingular) // "evim"
    /// "masa".WithPossessive(PossessivePerson.ThirdSingular) // "masası"
    /// </example>
    public static string WithPossessive(this string word, PossessivePerson person)
    {
        return PossessiveSuffixHelper.AddPossessive(word, person);
    }

    /// <summary>
    /// Kelimeye hal eki ekler
    /// </summary>
    /// <example>
    /// "ev".WithCase(CaseType.Dative) // "eve"
    /// "masa".WithCase(CaseType.Locative) // "masada"
    /// </example>
    public static string WithCase(this string word, CaseType caseType)
    {
        return CaseSuffixHelper.AddCase(word, caseType);
    }

    /// <summary>
    /// Belirtme hali (-i, -ı, -u, -ü)
    /// </summary>
    /// <example>"ev".ToAccusative() // "evi"</example>
    public static string ToAccusative(this string word)
    {
        return CaseSuffixHelper.AddCase(word, CaseType.Accusative);
    }

    /// <summary>
    /// Yönelme hali (-e, -a)
    /// </summary>
    /// <example>"ev".ToDative() // "eve"</example>
    public static string ToDative(this string word)
    {
        return CaseSuffixHelper.AddCase(word, CaseType.Dative);
    }

    /// <summary>
    /// Bulunma hali (-de, -da, -te, -ta)
    /// </summary>
    /// <example>"ev".ToLocative() // "evde"</example>
    public static string ToLocative(this string word)
    {
        return CaseSuffixHelper.AddCase(word, CaseType.Locative);
    }

    /// <summary>
    /// Ayrılma hali (-den, -dan, -ten, -tan)
    /// </summary>
    /// <example>"ev".ToAblative() // "evden"</example>
    public static string ToAblative(this string word)
    {
        return CaseSuffixHelper.AddCase(word, CaseType.Ablative);
    }

    /// <summary>
    /// Vasıta hali (-le, -la, -ile, -yla)
    /// </summary>
    /// <example>"kalem".ToInstrumental() // "kalemle"</example>
    public static string ToInstrumental(this string word)
    {
        return CaseSuffixHelper.AddCase(word, CaseType.Instrumental);
    }

    /// <summary>
    /// Birinci tekil şahıs iyelik eki (benim)
    /// </summary>
    /// <example>"ev".ToMyPossessive() // "evim"</example>
    public static string ToMyPossessive(this string word)
    {
        return PossessiveSuffixHelper.AddPossessive(word, PossessivePerson.FirstSingular);
    }

    /// <summary>
    /// İkinci tekil şahıs iyelik eki (senin)
    /// </summary>
    /// <example>"ev".ToYourPossessive() // "evin"</example>
    public static string ToYourPossessive(this string word)
    {
        return PossessiveSuffixHelper.AddPossessive(word, PossessivePerson.SecondSingular);
    }

    /// <summary>
    /// Üçüncü tekil şahıs iyelik eki (onun)
    /// </summary>
    /// <example>"ev".ToHisPossessive() // "evi"</example>
    public static string ToHisPossessive(this string word)
    {
        return PossessiveSuffixHelper.AddPossessive(word, PossessivePerson.ThirdSingular);
    }

    /// <summary>
    /// Birinci çoğul şahıs iyelik eki (bizim)
    /// </summary>
    /// <example>"ev".ToOurPossessive() // "evimiz"</example>
    public static string ToOurPossessive(this string word)
    {
        return PossessiveSuffixHelper.AddPossessive(word, PossessivePerson.FirstPlural);
    }

    /// <summary>
    /// İkinci çoğul şahıs iyelik eki (sizin)
    /// </summary>
    /// <example>"ev".ToYourPluralPossessive() // "eviniz"</example>
    public static string ToYourPluralPossessive(this string word)
    {
        return PossessiveSuffixHelper.AddPossessive(word, PossessivePerson.SecondPlural);
    }

    /// <summary>
    /// Üçüncü çoğul şahıs iyelik eki (onların)
    /// </summary>
    /// <example>"ev".ToTheirPossessive() // "evleri"</example>
    public static string ToTheirPossessive(this string word)
    {
        return PossessiveSuffixHelper.AddPossessive(word, PossessivePerson.ThirdPlural);
    }
}
