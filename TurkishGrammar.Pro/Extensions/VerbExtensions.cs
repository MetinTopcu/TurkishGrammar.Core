using TurkishGrammar.Pro.Verbs.Tense;
using TurkishGrammar.Pro.Verbs.Mood;
using TurkishGrammar.Pro.Verbs.Person;

namespace TurkishGrammar.Pro.Extensions;

/// <summary>
/// Fiil extension metodları
/// </summary>
public static class VerbExtensions
{
    // ============ Şimdiki Zaman (-iyor) ============

    /// <summary>Şimdiki zaman - Ben</summary>
    public static string ToPresentContinuous_I(this string verbRoot)
        => PresentContinuousTense.Conjugate(verbRoot, VerbPerson.FirstSingular);

    /// <summary>Şimdiki zaman - Sen</summary>
    public static string ToPresentContinuous_You(this string verbRoot)
        => PresentContinuousTense.Conjugate(verbRoot, VerbPerson.SecondSingular);

    /// <summary>Şimdiki zaman - O</summary>
    public static string ToPresentContinuous_He(this string verbRoot)
        => PresentContinuousTense.Conjugate(verbRoot, VerbPerson.ThirdSingular);

    /// <summary>Şimdiki zaman - Biz</summary>
    public static string ToPresentContinuous_We(this string verbRoot)
        => PresentContinuousTense.Conjugate(verbRoot, VerbPerson.FirstPlural);

    /// <summary>Şimdiki zaman - Siz</summary>
    public static string ToPresentContinuous_You_Plural(this string verbRoot)
        => PresentContinuousTense.Conjugate(verbRoot, VerbPerson.SecondPlural);

    /// <summary>Şimdiki zaman - Onlar</summary>
    public static string ToPresentContinuous_They(this string verbRoot)
        => PresentContinuousTense.Conjugate(verbRoot, VerbPerson.ThirdPlural);

    // ============ Geçmiş Zaman (-di) ============

    /// <summary>Geçmiş zaman - Ben</summary>
    public static string ToPastTense_I(this string verbRoot)
        => PastTense.Conjugate(verbRoot, VerbPerson.FirstSingular);

    /// <summary>Geçmiş zaman - Sen</summary>
    public static string ToPastTense_You(this string verbRoot)
        => PastTense.Conjugate(verbRoot, VerbPerson.SecondSingular);

    /// <summary>Geçmiş zaman - O</summary>
    public static string ToPastTense_He(this string verbRoot)
        => PastTense.Conjugate(verbRoot, VerbPerson.ThirdSingular);

    /// <summary>Geçmiş zaman - Biz</summary>
    public static string ToPastTense_We(this string verbRoot)
        => PastTense.Conjugate(verbRoot, VerbPerson.FirstPlural);

    /// <summary>Geçmiş zaman - Siz</summary>
    public static string ToPastTense_You_Plural(this string verbRoot)
        => PastTense.Conjugate(verbRoot, VerbPerson.SecondPlural);

    /// <summary>Geçmiş zaman - Onlar</summary>
    public static string ToPastTense_They(this string verbRoot)
        => PastTense.Conjugate(verbRoot, VerbPerson.ThirdPlural);

    // ============ Gelecek Zaman (-acak/-ecek) ============

    /// <summary>Gelecek zaman - Ben</summary>
    public static string ToFutureTense_I(this string verbRoot)
        => FutureTense.Conjugate(verbRoot, VerbPerson.FirstSingular);

    /// <summary>Gelecek zaman - Sen</summary>
    public static string ToFutureTense_You(this string verbRoot)
        => FutureTense.Conjugate(verbRoot, VerbPerson.SecondSingular);

    /// <summary>Gelecek zaman - O</summary>
    public static string ToFutureTense_He(this string verbRoot)
        => FutureTense.Conjugate(verbRoot, VerbPerson.ThirdSingular);

    /// <summary>Gelecek zaman - Biz</summary>
    public static string ToFutureTense_We(this string verbRoot)
        => FutureTense.Conjugate(verbRoot, VerbPerson.FirstPlural);

    /// <summary>Gelecek zaman - Siz</summary>
    public static string ToFutureTense_You_Plural(this string verbRoot)
        => FutureTense.Conjugate(verbRoot, VerbPerson.SecondPlural);

    /// <summary>Gelecek zaman - Onlar</summary>
    public static string ToFutureTense_They(this string verbRoot)
        => FutureTense.Conjugate(verbRoot, VerbPerson.ThirdPlural);

    // ============ Geniş Zaman (-ir/-ar) ============

    /// <summary>Geniş zaman - Ben</summary>
    public static string ToAoristTense_I(this string verbRoot)
        => AoristTense.Conjugate(verbRoot, VerbPerson.FirstSingular);

    /// <summary>Geniş zaman - Sen</summary>
    public static string ToAoristTense_You(this string verbRoot)
        => AoristTense.Conjugate(verbRoot, VerbPerson.SecondSingular);

    /// <summary>Geniş zaman - O</summary>
    public static string ToAoristTense_He(this string verbRoot)
        => AoristTense.Conjugate(verbRoot, VerbPerson.ThirdSingular);

    // ============ Emir Kipi ============

    /// <summary>Emir kipi - Sen (git!)</summary>
    public static string ToImperative(this string verbRoot)
        => ImperativeMood.Conjugate(verbRoot, VerbPerson.SecondSingular);

    /// <summary>Emir kipi - Siz (gidin!)</summary>
    public static string ToImperative_Plural(this string verbRoot)
        => ImperativeMood.Conjugate(verbRoot, VerbPerson.SecondPlural);

    /// <summary>Emir kipi kibarlık - (gidiniz!)</summary>
    public static string ToImperativePolite(this string verbRoot)
        => ImperativeMood.ConjugatePolite(verbRoot);

    // ============ Şart Kipi (-se/-sa) ============

    /// <summary>Şart kipi - Ben (gelsem)</summary>
    public static string ToConditional_I(this string verbRoot)
        => ConditionalMood.Conjugate(verbRoot, VerbPerson.FirstSingular);

    /// <summary>Şart kipi - Sen (gelsen)</summary>
    public static string ToConditional_You(this string verbRoot)
        => ConditionalMood.Conjugate(verbRoot, VerbPerson.SecondSingular);

    /// <summary>Şart kipi - O (gelse)</summary>
    public static string ToConditional_He(this string verbRoot)
        => ConditionalMood.Conjugate(verbRoot, VerbPerson.ThirdSingular);

    // ============ İstek Kipi (-e/-a) ============

    /// <summary>İstek kipi - Ben (geleyim)</summary>
    public static string ToOptative_I(this string verbRoot)
        => OptativeMood.Conjugate(verbRoot, VerbPerson.FirstSingular);

    /// <summary>İstek kipi - Biz (gelelim)</summary>
    public static string ToOptative_We(this string verbRoot)
        => OptativeMood.Conjugate(verbRoot, VerbPerson.FirstPlural);

    /// <summary>İstek kipi - O (gele)</summary>
    public static string ToOptative_He(this string verbRoot)
        => OptativeMood.Conjugate(verbRoot, VerbPerson.ThirdSingular);
}
