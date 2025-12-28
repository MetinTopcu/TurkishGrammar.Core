namespace TurkishGrammar.Core.Suffixes.Possessive;

/// <summary>
/// İyelik eki kişi türleri
/// </summary>
public enum PossessivePerson
{
    /// <summary>
    /// Birinci tekil şahıs (benim)
    /// Örnek: ev-im, araba-m
    /// </summary>
    FirstSingular,

    /// <summary>
    /// İkinci tekil şahıs (senin)
    /// Örnek: ev-in, araba-n
    /// </summary>
    SecondSingular,

    /// <summary>
    /// Üçüncü tekil şahıs (onun)
    /// Örnek: ev-i, araba-sı
    /// </summary>
    ThirdSingular,

    /// <summary>
    /// Birinci çoğul şahıs (bizim)
    /// Örnek: ev-imiz, araba-mız
    /// </summary>
    FirstPlural,

    /// <summary>
    /// İkinci çoğul şahıs (sizin)
    /// Örnek: ev-iniz, araba-nız
    /// </summary>
    SecondPlural,

    /// <summary>
    /// Üçüncü çoğul şahıs (onların)
    /// Örnek: ev-leri, araba-ları
    /// </summary>
    ThirdPlural
}
