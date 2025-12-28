namespace TurkishGrammar.Core.VowelHarmony;

/// <summary>
/// Ünsüz yumuşaması kurallarını uygular
/// </summary>
public static class ConsonantSofteningHelper
{
    // Ünsüz yumuşaması haritası
    private static readonly Dictionary<char, char> _softeningMap = new()
    {
        ['p'] = 'b',
        ['ç'] = 'c',
        ['t'] = 'd',
        ['k'] = 'ğ'
    };

    /// <summary>
    /// Kelimenin son harfi yumuşaması gereken bir ünsüz mü?
    /// </summary>
    public static bool EndsWithHardenedConsonant(string word)
    {
        if (string.IsNullOrEmpty(word))
            return false;

        var lastChar = char.ToLowerInvariant(word[^1]);
        return _softeningMap.ContainsKey(lastChar);
    }

    /// <summary>
    /// Kelimeye sesli harf eklendiğinde ünsüz yumuşaması uygular
    /// Örnek: kitap -> kitab (sesli harf gelmeden önce)
    /// </summary>
    public static string ApplySoftening(string word)
    {
        if (string.IsNullOrEmpty(word))
            return word;

        var lastChar = char.ToLowerInvariant(word[^1]);

        if (_softeningMap.TryGetValue(lastChar, out var softenedChar))
        {
            // Son karakteri yumuşatılmış hali ile değiştir
            return word[..^1] + softenedChar;
        }

        return word;
    }

    /// <summary>
    /// Sesli harf eklenecekse ve kelimenin sonu sert ünsüzle bitiyorsa yumuşat
    /// </summary>
    public static string SoftenIfNeeded(string word, bool addingVowelSuffix)
    {
        if (!addingVowelSuffix)
            return word;

        return ApplySoftening(word);
    }
}
