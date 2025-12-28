# 📦 TurkishGrammar

TurkishGrammar is a .NET library for applying Turkish grammatical rules (suffixes, vowel harmony, consonant changes) to words in a deterministic and rule-based way.

It is designed for enterprise use, legal texts, form generation, and dynamic content where correctness matters.

---

## 🔓 TurkishGrammar.Core (Free)

Core provides the most common Turkish grammatical suffixes.

### Features

- **Case suffixes** (Accusative, Dative, Locative, Ablative, Instrumental)
- **Possessive suffixes** (benim, senin, onun, bizim, sizin, onların)
- **Vowel harmony** & **consonant softening**
- **Fully offline**, no dependencies

### Installation

```bash
dotnet add package TurkishGrammar.Core
```

### Usage (English API)

```csharp
using TurkishGrammar.Core.Extensions;

"ev".ToLocative();                      // evde
"masa".ToDative();                      // masaya
"ev".ToMyPossessive();                  // evim
"kitap".WithCase(CaseType.Ablative);    // kitaptan
```

### Usage (Turkish API – optional)

```csharp
using TurkishGrammar.Core.Extensions.Tr;

"ev".BulunmaHali();     // evde
"masa".YönelmeHali();   // masaya
"ev".Benim();           // evim
```

---

## 💰 TurkishGrammar.Pro (Paid)

Pro adds advanced and expressive grammar features on top of Core.

### Features

- **🚀 Batch Processing** (KILLER FEATURE!) - Process 1000+ words in parallel
- **📄 Formal & Legal Text** (KILLER FEATURE!) - Contract generation, legal clauses, official language
- **Verb tenses** & **moods** - Full conjugation support
- **Adjectives** (comparative, superlative)
- **Plural** & **question particles**
- **Optimized helpers** for large-scale text generation
- Designed for **enterprise / government / legal** usage

### Installation

```bash
dotnet add package TurkishGrammar.Pro
```

### Usage (English API)

```csharp
using TurkishGrammar.Pro.Extensions;
using TurkishGrammar.Pro.Formal;

// Batch processing - Process 1000+ words
var words = new[] { "ev", "masa", "kitap" };
words.ToLocative();              // ["evde", "masada", "kitapta"]

// Legal & Formal text
LegalTextHelper.ArticleReference(5);              // "5. madde"
ContractHelper.PaymentClause(10000m, "30 gün");   // Legal payment clause
"yap".ToFormalRequest();                          // "yapılması rica olunur"

// Verb conjugations
"gel".ToPresentContinuous_I();   // geliyorum
"git".ToFutureTense_You();       // gideceksin
"güzel".ToSuperlative();         // en güzel
"ev".ToPlural();                 // evler
```

### Usage (Turkish API – optional)

```csharp
using TurkishGrammar.Pro.Extensions.Tr;

"ev".Çoğul();           // evler
"geldin".SoruEki();     // geldin mi
```

---

## 🧠 Design Philosophy

- **Deterministic**: No guessing, no NLP, no AI
- **Explicit**: The caller always chooses which suffix to apply
- **Offline-first**: Safe for legal and enterprise systems
- **Extensible**: Core logic is shared, Turkish aliases are thin wrappers

---

## 🚀 Roadmap

- [ ] Proper noun & abbreviation support
- [ ] Numeric suffixes (3'e, 2025'te)
- [ ] Batch processing helpers
- [ ] Optional AI-powered grammar service (separate product)

---

## 📄 License

- **Core**: MIT License (Free)
- **Pro**: Commercial License - $3/month

---

## 🤝 Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

---

## 📚 Documentation

For detailed documentation and examples:
- [Core Documentation](TurkishGrammar.Core/README.md)
- [Pro Documentation](TurkishGrammar.Pro/README.md)

---

## 🌟 Examples

### Chaining (English API)

```csharp
using TurkishGrammar.Core.Extensions;
using TurkishGrammar.Pro.Extensions;

var result = "ev"
    .ToPlural()           // evler
    .ToMyPossessive()     // evlerim
    .ToDative();          // evlerime (to my houses)
```

### Chaining (Turkish API)

```csharp
using TurkishGrammar.Core.Extensions.Tr;
using TurkishGrammar.Pro.Extensions.Tr;

var sonuc = "ev"
    .Çoğul()              // evler
    .Benim()              // evlerim
    .YönelmeHali();       // evlerime
```

### Vowel Harmony

```csharp
"ev".ToLocative();      // evde (front vowel)
"masa".ToLocative();    // masada (back vowel)
"göl".ToLocative();     // gölde (front rounded)
"kol".ToLocative();     // kolda (back rounded)
```

### Consonant Softening

```csharp
"kitap".ToAccusative(); // kitabı (p→b)
"ağaç".ToAccusative();  // ağacı (ç→c)
```

---

## 💡 Use Cases

- **Legal documents**: Generate contracts with correct Turkish grammar
- **Form generation**: Dynamic forms with proper suffixes
- **E-commerce**: Product descriptions with correct case endings
- **Educational apps**: Turkish language learning tools
- **Government systems**: Official documents and forms
- **Content management**: Dynamic content with grammatical correctness

---

## 🔗 Links

- [NuGet - Core Package](https://www.nuget.org/packages/TurkishGrammar.Core)
- [NuGet - Pro Package](https://www.nuget.org/packages/TurkishGrammar.Pro)

---

