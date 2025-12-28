using TurkishGrammar.Core.VowelHarmony;

namespace TurkishGrammar.Pro.Suffixes.Question;

/// <summary>
/// Soru ekleri oluşturma yardımcı sınıfı (Pro feature)
/// </summary>
public static class QuestionParticleHelper
{
    /// <summary>
    /// Kelimeye soru eki ekler (-mi/-mı/-mu/-mü)
    /// </summary>
    /// <param name="word">Kelime veya cümle (örn: "geldin", "evde")</param>
    /// <returns>Soru ekli ifade</returns>
    /// <example>
    /// QuestionParticleHelper.AddQuestionParticle("geldin") // "geldin mi"
    /// QuestionParticleHelper.AddQuestionParticle("evde") // "evde mi"
    /// QuestionParticleHelper.AddQuestionParticle("okuyor") // "okuyor mu"
    /// </example>
    public static string AddQuestionParticle(string word)
    {
        if (string.IsNullOrWhiteSpace(word))
            throw new ArgumentException("Kelime boş olamaz", nameof(word));

        word = word.Trim();

        // Soru eki her zaman ayrı yazılır ve sesli harf uyumuna uyar
        var vowel = VowelHarmonyHelper.GetFourWayHarmonizedVowel(word);
        return word + " m" + vowel;
    }

    /// <summary>
    /// Kelimeye olumsuz soru eki ekler (-değil mi/-değil mi)
    /// </summary>
    /// <param name="word">Kelime (örn: "öğrenci", "doktor")</param>
    /// <returns>Olumsuz soru ekli ifade</returns>
    /// <example>
    /// QuestionParticleHelper.AddNegativeQuestion("öğrenci") // "öğrenci değil mi"
    /// QuestionParticleHelper.AddNegativeQuestion("doktor") // "doktor değil mi"
    /// </example>
    public static string AddNegativeQuestion(string word)
    {
        if (string.IsNullOrWhiteSpace(word))
            throw new ArgumentException("Kelime boş olamaz", nameof(word));

        word = word.Trim();

        // "değil" kullan, ardından soru eki ekle
        var negativeForm = word + " değil";
        return AddQuestionParticle(negativeForm);
    }
}
