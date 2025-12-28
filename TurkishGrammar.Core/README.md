# TurkishGrammar.Core

A powerful and easy-to-use Turkish grammar library for .NET applications.

## Features

### Core Version (Free)

- **Vowel Harmony Rules**: Automatic Turkish vowel harmony detection and application
- **Possessive Suffixes**: Add possessive endings to words (benim, senin, onun, etc.)
- **Case Suffixes**: Apply Turkish case endings (accusative, dative, locative, ablative, instrumental)
- **Consonant Softening**: Automatic handling of Turkish consonant softening rules
- **Fluent API**: Clean and intuitive extension methods

## Installation

```bash
dotnet add package TurkishGrammar.Core
```

## Quick Start

```csharp
using TurkishGrammar.Core.Extensions;

// Case suffixes
var word1 = "ev".ToDative();        // eve (to the house)
var word2 = "masa".ToLocative();    // masada (at the table)
var word3 = "kitap".ToAccusative(); // kitabı (the book - object)

// Possessive suffixes
var word4 = "ev".ToMyPossessive();     // evim (my house)
var word5 = "araba".ToYourPossessive(); // araban (your car)
var word6 = "okul".ToHisPossessive();   // okulu (his/her school)

// Chaining
var word7 = "ev".ToMyPossessive().ToDative(); // evime (to my house)
```

## Advanced Usage

```csharp
using TurkishGrammar.Core.Suffixes.Case;
using TurkishGrammar.Core.Suffixes.Possessive;

// Using helpers directly
var word1 = CaseSuffixHelper.AddCase("kitap", CaseType.Locative);
// kitapta (in the book)

var word2 = PossessiveSuffixHelper.AddPossessive("masa", PossessivePerson.FirstPlural);
// masamız (our table)
```

## Vowel Harmony

The library automatically handles Turkish vowel harmony rules:

```csharp
"ev".ToLocative()    // evde (front vowel)
"masa".ToLocative()  // masada (back vowel)
"göl".ToLocative()   // gölde (front rounded)
"kol".ToLocative()   // kolda (back rounded)
```

## Consonant Softening

Automatic consonant softening (p→b, ç→c, t→d, k→ğ):

```csharp
"kitap".ToAccusative()  // kitabı (p→b)
"ağaç".ToAccusative()   // ağacı (ç→c)
```

## Want More Features?

Upgrade to **TurkishGrammar.Pro** for advanced features:
- Plural suffixes
- Question particles
- Verb conjugations
- Comparative and superlative forms
- And much more!

## License

MIT License

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.
