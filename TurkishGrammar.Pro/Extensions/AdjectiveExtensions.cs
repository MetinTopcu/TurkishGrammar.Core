using TurkishGrammar.Pro.Adjectives;

namespace TurkishGrammar.Pro.Extensions;

/// <summary>
/// Sıfat extension metodları
/// </summary>
public static class AdjectiveExtensions
{
    /// <summary>
    /// Üstünlük derecesi (en + sıfat)
    /// </summary>
    /// <example>"güzel".ToSuperlative() // "en güzel"</example>
    public static string ToSuperlative(this string adjective)
    {
        return ComparativeHelper.MakeSuperlative(adjective);
    }

    /// <summary>
    /// Karşılaştırma derecesi (daha + sıfat)
    /// </summary>
    /// <example>"güzel".ToComparative() // "daha güzel"</example>
    public static string ToComparative(this string adjective)
    {
        return ComparativeHelper.MakeComparative(adjective);
    }

    /// <summary>
    /// Karşılaştırma (X'den daha + sıfat)
    /// </summary>
    /// <example>"güzel".CompareWith("Ali") // "Ali'den daha güzel"</example>
    public static string CompareWith(this string adjective, string comparedTo)
    {
        return ComparativeHelper.CompareWith(adjective, comparedTo);
    }

    /// <summary>
    /// En az üstünlük derecesi (en az + sıfat)
    /// </summary>
    /// <example>"güzel".ToLeastSuperlative() // "en az güzel"</example>
    public static string ToLeastSuperlative(this string adjective)
    {
        return ComparativeHelper.MakeLeastSuperlative(adjective);
    }

    /// <summary>
    /// Daha az karşılaştırma (daha az + sıfat)
    /// </summary>
    /// <example>"güzel".ToLessComparative() // "daha az güzel"</example>
    public static string ToLessComparative(this string adjective)
    {
        return ComparativeHelper.MakeLessComparative(adjective);
    }
}
