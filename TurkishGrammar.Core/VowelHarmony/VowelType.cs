namespace TurkishGrammar.Core.VowelHarmony;

/// <summary>
/// Türkçe sesli harflerin özelliklerini belirtir
/// </summary>
[Flags]
public enum VowelType
{
    /// <summary>
    /// Sesli harf değil
    /// </summary>
    None = 0,

    /// <summary>
    /// Kalın sesli (a, ı, o, u)
    /// </summary>
    Back = 1,

    /// <summary>
    /// İnce sesli (e, i, ö, ü)
    /// </summary>
    Front = 2,

    /// <summary>
    /// Düz sesli (a, e, ı, i)
    /// </summary>
    Unrounded = 4,

    /// <summary>
    /// Yuvarlak sesli (o, ö, u, ü)
    /// </summary>
    Rounded = 8
}
