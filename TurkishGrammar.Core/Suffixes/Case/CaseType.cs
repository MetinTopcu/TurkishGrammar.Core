namespace TurkishGrammar.Core.Suffixes.Case;

/// <summary>
/// Türkçe hal ekleri türleri
/// </summary>
public enum CaseType
{
    /// <summary>
    /// Yalın hal (hiç ek almamış)
    /// Örnek: ev, masa, kitap
    /// </summary>
    Nominative,

    /// <summary>
    /// Belirtme hali (-i, -ı, -u, -ü)
    /// Örnek: ev-i, masa-yı, kitab-ı
    /// </summary>
    Accusative,

    /// <summary>
    /// Yönelme hali (-e, -a)
    /// Örnek: ev-e, masa-ya, kitab-a
    /// </summary>
    Dative,

    /// <summary>
    /// Bulunma hali (-de, -da, -te, -ta)
    /// Örnek: ev-de, masa-da, kitap-ta
    /// </summary>
    Locative,

    /// <summary>
    /// Ayrılma hali (-den, -dan, -ten, -tan)
    /// Örnek: ev-den, masa-dan, kitap-tan
    /// </summary>
    Ablative,

    /// <summary>
    /// Vasıta hali (-le, -la, -ile, -yla)
    /// Örnek: ev-le, masa-yla, kalem-le
    /// </summary>
    Instrumental
}
