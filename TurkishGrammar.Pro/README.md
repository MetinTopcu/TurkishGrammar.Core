# TurkishGrammar.Pro

Professional Turkish grammar library for .NET with advanced features.

## What's Included

### Everything from Core (Free Version)
- Vowel Harmony Rules
- Possessive Suffixes (iyelik ekleri)
- Case Suffixes (hal ekleri)
- Consonant Softening
- Fluent API

### Pro Features

#### Suffixes
- **Plural Suffixes**: -ler/-lar ekleri
- **Question Particles**: -mi/-mı/-mu/-mü soru ekleri
- **Combined Suffixes**: Çoğul + iyelik kombinasyonları

#### Adjectives
- **Comparative Forms**: daha güzel, daha büyük
- **Superlative Forms**: en güzel, en büyük
- **Comparison**: Ali'den daha güzel

#### Verb Tenses (Fiil Zamanları)
- **Present Continuous**: -iyor (geliyorum, gidiyorsun)
- **Past Tense**: -di/-dı/-du/-dü (geldim, gittin, okudu)
- **Future Tense**: -acak/-ecek (geleceğim, gideceksin)
- **Aorist Tense**: -ir/-ar (gelirim, gidersin, okur)

#### Verb Moods (Fiil Kipleri)
- **Conditional**: -se/-sa (gelsem, gidersen)
- **Optative**: -e/-a (geleyim, gidelim)
- **Imperative**: git!, gidin!, gidiniz!

## Installation

```bash
dotnet add package TurkishGrammar.Pro
```

## Pro Examples

### Plural Suffixes

```csharp
using TurkishGrammar.Pro.Extensions;

var word1 = "ev".ToPlural();      // evler (houses)
var word2 = "masa".ToPlural();    // masalar (tables)
var word3 = "kitap".ToPlural();   // kitaplar (books)
```

### Question Particles

```csharp
var q1 = "geldin".ToQuestion();           // geldin mi (did you come?)
var q2 = "evde".ToQuestion();             // evde mi (at home?)
var q3 = "öğrenci".ToNegativeQuestion();  // öğrenci değil mi (not a student?)
```

### Combined Suffixes

```csharp
// Plural + Possessive
var word1 = "ev".ToMyPluralPossessive();      // evlerim (my houses)
var word2 = "araba".ToOurPluralPossessive();  // arabalarımız (our cars)

// Using helper directly
var word3 = "kitap".ToPluralWithPossessive(PossessivePerson.FirstPlural);
// kitaplarımız (our books)
```

### Advanced Chaining

```csharp
using TurkishGrammar.Core.Extensions;
using TurkishGrammar.Pro.Extensions;

// Plural + Possessive + Case
var word = "ev"
    .ToPlural()                    // evler
    .ToMyPossessive()              // evlerim (using Core)
    .ToDative();                   // evlerime (to my houses)
```

## Pricing

**$3/month** - Full access to all Pro features and future updates

## Free Trial

Try the Core version for free to see if it fits your needs!

## License

Commercial License - License key required for production use.

## Support

For support and licensing inquiries, please contact us at support@yourcompany.com

## Complete Verb Conjugation Examples

```csharp
using TurkishGrammar.Pro.Extensions;
using TurkishGrammar.Pro.Verbs.Tense;
using TurkishGrammar.Pro.Verbs.Mood;
using TurkishGrammar.Pro.Verbs.Person;

// Şimdiki Zaman (Present Continuous)
"gel".ToPresentContinuous_I()        // geliyorum
"git".ToPresentContinuous_You()      // gidiyorsun
"oku".ToPresentContinuous_He()       // okuyor

// Geçmiş Zaman (Past Tense)
"gel".ToPastTense_I()                // geldim
"git".ToPastTense_You()              // giddin
"oku".ToPastTense_He()               // okudu

// Gelecek Zaman (Future Tense)
"gel".ToFutureTense_I()              // geleceğim
"git".ToFutureTense_You()            // gideceksin
"oku".ToFutureTense_He()             // okuyacak

// Geniş Zaman (Aorist)
"gel".ToAoristTense_I()              // gelerim
"git".ToAoristTense_You()            // gidirsin

// Emir Kipi (Imperative)
"gel".ToImperative()                 // gel!
"git".ToImperative_Plural()          // gidin!
"oku".ToImperativePolite()           // okunuz!

// Şart Kipi (Conditional)
"gel".ToConditional_I()              // gelsem
"git".ToConditional_You()            // gidersen

// İstek Kipi (Optative)
"gel".ToOptative_I()                 // geleyim
"git".ToOptative_We()                // gidelim
```

## Adjective Examples

```csharp
using TurkishGrammar.Pro.Extensions;

"güzel".ToComparative()              // daha güzel
"büyük".ToSuperlative()              // en büyük
"hızlı".CompareWith("araba")         // arabadan daha hızlı
"pahalı".ToLessComparative()         // daha az pahalı
"ucuz".ToLeastSuperlative()          // en az ucuz
```

## Future Roadmap

Planned features:
- Passive voice (edilgen çatı)
- Causative forms (ettirgen çatı)
- Reflexive forms (dönüşlü çatı)
- Reported speech
- And much more!
