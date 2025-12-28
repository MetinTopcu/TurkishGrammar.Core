namespace TurkishGrammar.Core.VowelHarmony;

/// <summary>
/// Türkçe sesli harf uyumu kurallarını uygular
/// </summary>
public static class VowelHarmonyHelper
{
    private static readonly Dictionary<char, VowelInfo> _vowels = new()
    {
        // Kalın düz sesliler
        ['a'] = new('a', VowelType.Back | VowelType.Unrounded),
        ['ı'] = new('ı', VowelType.Back | VowelType.Unrounded),

        // Kalın yuvarlak sesliler
        ['o'] = new('o', VowelType.Back | VowelType.Rounded),
        ['u'] = new('u', VowelType.Back | VowelType.Rounded),

        // İnce düz sesliler
        ['e'] = new('e', VowelType.Front | VowelType.Unrounded),
        ['i'] = new('i', VowelType.Front | VowelType.Unrounded),

        // İnce yuvarlak sesliler
        ['ö'] = new('ö', VowelType.Front | VowelType.Rounded),
        ['ü'] = new('ü', VowelType.Front | VowelType.Rounded)
    };

    /// <summary>
    /// Verilen karakterin sesli harf olup olmadığını kontrol eder
    /// </summary>
    public static bool IsVowel(char c) => _vowels.ContainsKey(char.ToLowerInvariant(c));

    /// <summary>
    /// Verilen kelimenin son sesli harfini bulur
    /// </summary>
    public static char? GetLastVowel(string word)
    {
        if (string.IsNullOrEmpty(word))
            return null;

        for (int i = word.Length - 1; i >= 0; i--)
        {
            var c = char.ToLowerInvariant(word[i]);
            if (IsVowel(c))
                return c;
        }

        return null;
    }

    /// <summary>
    /// Verilen sesli harfin bilgisini döner
    /// </summary>
    public static VowelInfo? GetVowelInfo(char vowel)
    {
        var c = char.ToLowerInvariant(vowel);
        return _vowels.TryGetValue(c, out var info) ? info : null;
    }

    /// <summary>
    /// Kelimenin son sesli harfine göre büyük ünlü uyumuna uygun sesli harf seçer
    /// Kullanım: "ev" -> 'e', "masa" -> 'a'
    /// </summary>
    public static char GetHarmonizedVowel(string word, char frontOption = 'e', char backOption = 'a')
    {
        var lastVowel = GetLastVowel(word);
        if (lastVowel == null)
            return backOption; // Varsayılan olarak kalın

        var vowelInfo = GetVowelInfo(lastVowel.Value);
        return vowelInfo?.IsFront == true ? frontOption : backOption;
    }

    /// <summary>
    /// Küçük ünlü uyumuna göre sesli harf seçer (4'lü uyum)
    /// Kullanım: "el" -> 'i', "dal" -> 'ı', "kol" -> 'u', "göl" -> 'ü'
    /// </summary>
    public static char GetFourWayHarmonizedVowel(string word)
    {
        var lastVowel = GetLastVowel(word);
        if (lastVowel == null)
            return 'ı'; // Varsayılan

        var vowelInfo = GetVowelInfo(lastVowel.Value);
        if (vowelInfo == null)
            return 'ı';

        // Küçük ünlü uyumu kuralları
        if (vowelInfo.IsFront && vowelInfo.IsUnrounded)
            return 'i';
        if (vowelInfo.IsFront && vowelInfo.IsRounded)
            return 'ü';
        if (vowelInfo.IsBack && vowelInfo.IsUnrounded)
            return 'ı';
        if (vowelInfo.IsBack && vowelInfo.IsRounded)
            return 'u';

        return 'ı';
    }

    /// <summary>
    /// İkili ünlü uyumuna göre sesli harf seçer (e/a)
    /// </summary>
    public static char GetTwoWayHarmonizedVowel(string word)
    {
        return GetHarmonizedVowel(word, 'e', 'a');
    }
}
