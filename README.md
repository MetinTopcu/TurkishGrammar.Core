# 📦 TurkishGrammar.Core

**A .NET library for applying Turkish grammatical rules (suffixes, vowel harmony, consonant changes) in a deterministic and rule-based way.**

Designed for enterprise use, legal texts, form generation, and dynamic content where correctness matters.

**Looking for advanced features?** Check out [TurkishGrammar.Pro](https://github.com/YOUR_USERNAME/TurkishGrammar.Pro) for batch processing, formal text generation, verb conjugations, and more.

---

## ✨ Features

- **Case suffixes** (Accusative, Dative, Locative, Ablative, Instrumental)
- **Possessive suffixes** (benim, senin, onun, bizim, sizin, onların)
- **Vowel harmony** & **consonant softening**
- **Fully offline**, no dependencies

---

## 📦 Installation

```bash
dotnet add package TurkishGrammar.Core
```

---

## 🚀 Usage

### English API

```csharp
using TurkishGrammar.Core.Extensions;

"ev".ToLocative();                      // evde
"masa".ToDative();                      // masaya
"ev".ToMyPossessive();                  // evim
"kitap".WithCase(CaseType.Ablative);    // kitaptan
```

### Turkish API (optional)

```csharp
using TurkishGrammar.Core.Extensions.Tr;

"ev".BulunmaHali();     // evde
"masa".YönelmeHali();   // masaya
"ev".Benim();           // evim
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
- [ ] Additional suffix types
- [ ] Performance optimizations

---

## 📄 License

MIT License - Free and open source

---

## 🤝 Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

---

## 🌟 Examples

### Chaining (English API)

```csharp
using TurkishGrammar.Core.Extensions;

var result = "ev"
    .ToMyPossessive()     // evim
    .ToDative();          // evime (to my house)
```

### Chaining (Turkish API)

```csharp
using TurkishGrammar.Core.Extensions.Tr;

var sonuc = "ev"
    .Benim()              // evim
    .YönelmeHali();       // evime
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

- [NuGet Package](https://www.nuget.org/packages/TurkishGrammar.Core)
- [TurkishGrammar.Pro](https://github.com/YOUR_USERNAME/TurkishGrammar.Pro) - Advanced features (commercial license)

---

