using TurkishGrammar.Core.Suffixes.Case;
using TurkishGrammar.Core.Suffixes.Possessive;

namespace TurkishGrammar.Core.Extensions.Tr;

/// <summary>
/// String için Türkçe gramer extension metodları (Türkçe API)
/// </summary>
public static class TurkishStringTrExtensions
{
    /// <summary>
    /// Kelimeye iyelik eki ekler
    /// </summary>
    /// <example>
    /// "ev".İyelikEki(PossessivePerson.FirstSingular) // "evim"
    /// "masa".İyelikEki(PossessivePerson.ThirdSingular) // "masası"
    /// </example>
    public static string İyelikEki(this string word, PossessivePerson person)
    {
        return PossessiveSuffixHelper.AddPossessive(word, person);
    }

    /// <summary>
    /// Kelimeye hal eki ekler
    /// </summary>
    /// <example>
    /// "ev".HalEki(CaseType.Dative) // "eve"
    /// "masa".HalEki(CaseType.Locative) // "masada"
    /// </example>
    public static string HalEki(this string word, CaseType caseType)
    {
        return CaseSuffixHelper.AddCase(word, caseType);
    }

    /// <summary>
    /// Belirtme hali (-i, -ı, -u, -ü)
    /// </summary>
    /// <example>"ev".BelirtmeHali() // "evi"</example>
    public static string BelirtmeHali(this string word)
    {
        return CaseSuffixHelper.AddCase(word, CaseType.Accusative);
    }

    /// <summary>
    /// Yönelme hali (-e, -a)
    /// </summary>
    /// <example>"ev".YönelmeHali() // "eve"</example>
    public static string YönelmeHali(this string word)
    {
        return CaseSuffixHelper.AddCase(word, CaseType.Dative);
    }

    /// <summary>
    /// Bulunma hali (-de, -da, -te, -ta)
    /// </summary>
    /// <example>"ev".BulunmaHali() // "evde"</example>
    public static string BulunmaHali(this string word)
    {
        return CaseSuffixHelper.AddCase(word, CaseType.Locative);
    }

    /// <summary>
    /// Ayrılma hali (-den, -dan, -ten, -tan)
    /// </summary>
    /// <example>"ev".AyrılmaHali() // "evden"</example>
    public static string AyrılmaHali(this string word)
    {
        return CaseSuffixHelper.AddCase(word, CaseType.Ablative);
    }

    /// <summary>
    /// Vasıta hali (-le, -la, -ile, -yla)
    /// </summary>
    /// <example>"kalem".VasıtaHali() // "kalemle"</example>
    public static string VasıtaHali(this string word)
    {
        return CaseSuffixHelper.AddCase(word, CaseType.Instrumental);
    }

    /// <summary>
    /// Birinci tekil şahıs iyelik eki (benim)
    /// </summary>
    /// <example>"ev".Benim() // "evim"</example>
    public static string Benim(this string word)
    {
        return PossessiveSuffixHelper.AddPossessive(word, PossessivePerson.FirstSingular);
    }

    /// <summary>
    /// İkinci tekil şahıs iyelik eki (senin)
    /// </summary>
    /// <example>"ev".Senin() // "evin"</example>
    public static string Senin(this string word)
    {
        return PossessiveSuffixHelper.AddPossessive(word, PossessivePerson.SecondSingular);
    }

    /// <summary>
    /// Üçüncü tekil şahıs iyelik eki (onun)
    /// </summary>
    /// <example>"ev".Onun() // "evi"</example>
    public static string Onun(this string word)
    {
        return PossessiveSuffixHelper.AddPossessive(word, PossessivePerson.ThirdSingular);
    }

    /// <summary>
    /// Birinci çoğul şahıs iyelik eki (bizim)
    /// </summary>
    /// <example>"ev".Bizim() // "evimiz"</example>
    public static string Bizim(this string word)
    {
        return PossessiveSuffixHelper.AddPossessive(word, PossessivePerson.FirstPlural);
    }

    /// <summary>
    /// İkinci çoğul şahıs iyelik eki (sizin)
    /// </summary>
    /// <example>"ev".Sizin() // "eviniz"</example>
    public static string Sizin(this string word)
    {
        return PossessiveSuffixHelper.AddPossessive(word, PossessivePerson.SecondPlural);
    }

    /// <summary>
    /// Üçüncü çoğul şahıs iyelik eki (onların)
    /// </summary>
    /// <example>"ev".Onların() // "evleri"</example>
    public static string Onların(this string word)
    {
        return PossessiveSuffixHelper.AddPossessive(word, PossessivePerson.ThirdPlural);
    }
}
