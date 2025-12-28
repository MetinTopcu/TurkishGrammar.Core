namespace TurkishGrammar.Core.VowelHarmony;

/// <summary>
/// Türkçe sesli harflerin bilgilerini tutar
/// </summary>
public class VowelInfo
{
    public char Vowel { get; init; }
    public VowelType Type { get; init; }

    public bool IsBack => Type.HasFlag(VowelType.Back);
    public bool IsFront => Type.HasFlag(VowelType.Front);
    public bool IsRounded => Type.HasFlag(VowelType.Rounded);
    public bool IsUnrounded => Type.HasFlag(VowelType.Unrounded);

    public VowelInfo(char vowel, VowelType type)
    {
        Vowel = vowel;
        Type = type;
    }
}
