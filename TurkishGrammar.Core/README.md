# TurkishGrammar.Core

A powerful and easy-to-use Turkish grammar library for .NET applications.

TurkishGrammar.Core helps you correctly apply Turkish suffixes by automatically
handling vowel harmony, consonant softening, and grammatical rules.

**Tags:** turkish, grammar, nlp, suffix, dotnet

---

## Features (Core – Free)

- **Vowel Harmony Rules**  
  Automatic Turkish vowel harmony detection and application

- **Case Suffixes**  
  Accusative, dative, locative, ablative, instrumental

- **Possessive Suffixes**  
  My, your, his/her, our, your (plural), their

- **Consonant Softening**  
  Automatic handling of p→b, ç→c, t→d, k→ğ

- **Fluent API**  
  Clean, readable, and chainable extension methods

---

## Installation

```bash
dotnet add package TurkishGrammar.Core

```

## Quick Start

### English API

```
using TurkishGrammar.Core.Extensions;

// Case suffixes
"ev".ToDative();        // eve
"masa".ToLocative();    // masada
"kitap".ToAccusative(); // kitabı

// Possessive suffixes
"ev".ToMyPossessive();       // evim
"araba".ToYourPossessive();  // araban
"okul".ToHisPossessive();    // okulu

// Chaining
"ev".ToMyPossessive().ToDative(); // evime

```

### Turkish API

```
using TurkishGrammar.Core.Extensions.Tr;

// Hal ekleri
"ev".YönelmeHali();      // eve
"masa".BulunmaHali();    // masada
"kitap".BelirtmeHali();  // kitabı

// İyelik ekleri
"ev".Benim();     // evim
"araba".Senin();  // araban
"okul".Onun();    // okulu

// Zincirleme kullanım
"ev".Benim().YönelmeHali(); // evime

```

## Advanced Usage

```
using TurkishGrammar.Core.Suffixes.Case;
using TurkishGrammar.Core.Suffixes.Possessive;

// Using helpers directly
CaseSuffixHelper.AddCase("kitap", CaseType.Locative);
// kitapta

PossessiveSuffixHelper.AddPossessive("masa", PossessivePerson.FirstPlural);
// masamız

```

## Vowel Harmony

The library automatically handles Turkish vowel harmony rules:

```
"ev".ToLocative();    // evde
"masa".ToLocative();  // masada
"göl".ToLocative();   // gölde
"kol".ToLocative();   // kolda

```

## Consonant Softening

Automatic consonant softening (p→b, ç→c, t→d, k→ğ):

```
"kitap".ToAccusative(); // kitabı
"ağaç".ToAccusative();  // ağacı
```

## Need more?

TurkishGrammar.Core provides the fundamentals.

If you need advanced features such as:

Verb conjugations

Smart question suffixes

Batch processing (1000+ words)

Formal & legal text helpers

👉 Check TurkishGrammar.Pro

## License

MIT License

## Contributing

Contributions are welcome!
Feel free to open an issue or submit a Pull Request.
