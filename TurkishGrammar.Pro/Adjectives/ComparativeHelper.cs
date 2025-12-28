using TurkishGrammar.Core.Suffixes.Case;

namespace TurkishGrammar.Pro.Adjectives;

/// <summary>
/// Karşılaştırma ekleri yardımcı sınıfı (Pro feature)
/// </summary>
public static class ComparativeHelper
{
    /// <summary>
    /// Sıfatı üstünlük derecesine çevirir (en + sıfat)
    /// </summary>
    /// <param name="adjective">Sıfat (örn: "güzel", "büyük")</param>
    /// <returns>Üstünlük dereceli sıfat</returns>
    /// <example>
    /// ComparativeHelper.MakeSuperlative("güzel") // "en güzel"
    /// ComparativeHelper.MakeSuperlative("büyük") // "en büyük"
    /// </example>
    public static string MakeSuperlative(string adjective)
    {
        if (string.IsNullOrWhiteSpace(adjective))
            throw new ArgumentException("Sıfat boş olamaz", nameof(adjective));

        return "en " + adjective.Trim();
    }

    /// <summary>
    /// Sıfatı karşılaştırma derecesine çevirir (daha + sıfat)
    /// </summary>
    /// <param name="adjective">Sıfat (örn: "güzel", "büyük")</param>
    /// <returns>Karşılaştırma dereceli sıfat</returns>
    /// <example>
    /// ComparativeHelper.MakeComparative("güzel") // "daha güzel"
    /// ComparativeHelper.MakeComparative("büyük") // "daha büyük"
    /// </example>
    public static string MakeComparative(string adjective)
    {
        if (string.IsNullOrWhiteSpace(adjective))
            throw new ArgumentException("Sıfat boş olamaz", nameof(adjective));

        return "daha " + adjective.Trim();
    }

    /// <summary>
    /// Karşılaştırma yapar (X'den daha + sıfat)
    /// </summary>
    /// <param name="adjective">Sıfat</param>
    /// <param name="comparedTo">Karşılaştırılan nesne</param>
    /// <returns>Karşılaştırma ifadesi</returns>
    /// <example>
    /// ComparativeHelper.CompareWith("güzel", "Ali") // "Ali'den daha güzel"
    /// ComparativeHelper.CompareWith("büyük", "ev") // "evden daha büyük"
    /// </example>
    public static string CompareWith(string adjective, string comparedTo)
    {
        if (string.IsNullOrWhiteSpace(adjective))
            throw new ArgumentException("Sıfat boş olamaz", nameof(adjective));

        if (string.IsNullOrWhiteSpace(comparedTo))
            throw new ArgumentException("Karşılaştırılan nesne boş olamaz", nameof(comparedTo));

        // Ayrılma hali ekle (-den/-dan)
        var ablativeForm = CaseSuffixHelper.AddCase(comparedTo.Trim(), CaseType.Ablative);
        return $"{ablativeForm} daha {adjective.Trim()}";
    }

    /// <summary>
    /// En az karşılaştırması (en az + sıfat)
    /// </summary>
    /// <param name="adjective">Sıfat</param>
    /// <returns>En az dereceli sıfat</returns>
    /// <example>
    /// ComparativeHelper.MakeLeastSuperlative("güzel") // "en az güzel"
    /// </example>
    public static string MakeLeastSuperlative(string adjective)
    {
        if (string.IsNullOrWhiteSpace(adjective))
            throw new ArgumentException("Sıfat boş olamaz", nameof(adjective));

        return "en az " + adjective.Trim();
    }

    /// <summary>
    /// Daha az karşılaştırması (daha az + sıfat)
    /// </summary>
    /// <param name="adjective">Sıfat</param>
    /// <returns>Daha az dereceli sıfat</returns>
    /// <example>
    /// ComparativeHelper.MakeLessComparative("güzel") // "daha az güzel"
    /// </example>
    public static string MakeLessComparative(string adjective)
    {
        if (string.IsNullOrWhiteSpace(adjective))
            throw new ArgumentException("Sıfat boş olamaz", nameof(adjective));

        return "daha az " + adjective.Trim();
    }
}
