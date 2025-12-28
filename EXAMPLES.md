# TurkishGrammar - Kullanım Örnekleri

## Core Versiyonu (Ücretsiz)

### Temel Hal Ekleri

```csharp
using TurkishGrammar.Core.Extensions;

// Belirtme hali (-i, -ı, -u, -ü)
var kelime1 = "ev".ToAccusative();        // evi
var kelime2 = "masa".ToAccusative();      // masayı
var kelime3 = "kitap".ToAccusative();     // kitabı (ünsüz yumuşaması)

// Yönelme hali (-e, -a)
var kelime4 = "ev".ToDative();            // eve
var kelime5 = "masa".ToDative();          // masaya
var kelime6 = "okul".ToDative();          // okula

// Bulunma hali (-de, -da, -te, -ta)
var kelime7 = "ev".ToLocative();          // evde
var kelime8 = "masa".ToLocative();        // masada
var kelime9 = "kitap".ToLocative();       // kitapta (ünsüz sertleşmesi)

// Ayrılma hali (-den, -dan, -ten, -tan)
var kelime10 = "ev".ToAblative();         // evden
var kelime11 = "masa".ToAblative();       // masadan
var kelime12 = "kitap".ToAblative();      // kitaptan

// Vasıta hali (-le, -la)
var kelime13 = "kalem".ToInstrumental();  // kalemle
var kelime14 = "masa".ToInstrumental();   // masayla
```

### İyelik Ekleri

```csharp
// Birinci tekil şahıs (benim)
var kelime1 = "ev".ToMyPossessive();      // evim
var kelime2 = "araba".ToMyPossessive();   // arabam

// İkinci tekil şahıs (senin)
var kelime3 = "ev".ToYourPossessive();    // evin
var kelime4 = "araba".ToYourPossessive(); // araban

// Üçüncü tekil şahıs (onun)
var kelime5 = "ev".ToHisPossessive();     // evi
var kelime6 = "araba".ToHisPossessive();  // arabası

// Birinci çoğul şahıs (bizim)
var kelime7 = "ev".ToOurPossessive();     // evimiz
var kelime8 = "araba".ToOurPossessive();  // arabamız

// İkinci çoğul şahıs (sizin)
var kelime9 = "ev".ToYourPluralPossessive();    // eviniz
var kelime10 = "araba".ToYourPluralPossessive(); // arabanız

// Üçüncü çoğul şahıs (onların)
var kelime11 = "ev".ToTheirPossessive();    // evleri
var kelime12 = "araba".ToTheirPossessive(); // arabaları
```

### Zincirleme Kullanım

```csharp
// İyelik + Hal eki kombinasyonu
var kelime1 = "ev".ToMyPossessive().ToDative();
// evim -> evime (benim evime)

var kelime2 = "araba".ToYourPossessive().ToLocative();
// araban -> arabanda (senin arabanda)

var kelime3 = "okul".ToOurPossessive().ToAblative();
// okulumuz -> okulumuza (bizim okulumuza)
```

### Helper Sınıfları ile Kullanım

```csharp
using TurkishGrammar.Core.Suffixes.Case;
using TurkishGrammar.Core.Suffixes.Possessive;

// Hal ekleri
var kelime1 = CaseSuffixHelper.AddCase("ev", CaseType.Dative);
// eve

var kelime2 = CaseSuffixHelper.AddCase("masa", CaseType.Locative);
// masada

// İyelik ekleri
var kelime3 = PossessiveSuffixHelper.AddPossessive("ev", PossessivePerson.FirstSingular);
// evim

var kelime4 = PossessiveSuffixHelper.AddPossessive("araba", PossessivePerson.ThirdPlural);
// arabaları
```

### Sesli Harf Uyumu

```csharp
using TurkishGrammar.Core.VowelHarmony;

// Son sesli harfi bulma
var sesli1 = VowelHarmonyHelper.GetLastVowel("ev");       // e
var sesli2 = VowelHarmonyHelper.GetLastVowel("masa");     // a

// Büyük ünlü uyumu (e/a)
var uyum1 = VowelHarmonyHelper.GetTwoWayHarmonizedVowel("ev");     // e
var uyum2 = VowelHarmonyHelper.GetTwoWayHarmonizedVowel("masa");   // a

// Küçük ünlü uyumu (i/ı/u/ü)
var uyum3 = VowelHarmonyHelper.GetFourWayHarmonizedVowel("ev");    // i
var uyum4 = VowelHarmonyHelper.GetFourWayHarmonizedVowel("masa");  // ı
var uyum5 = VowelHarmonyHelper.GetFourWayHarmonizedVowel("göl");   // ü
var uyum6 = VowelHarmonyHelper.GetFourWayHarmonizedVowel("kol");   // u
```

## Pro Versiyonu

### Çoğul Ekleri

```csharp
using TurkishGrammar.Pro.Extensions;

var kelime1 = "ev".ToPlural();        // evler
var kelime2 = "masa".ToPlural();      // masalar
var kelime3 = "kitap".ToPlural();     // kitaplar
var kelime4 = "araba".ToPlural();     // arabalar
```

### Soru Ekleri

```csharp
var soru1 = "geldin".ToQuestion();              // geldin mi
var soru2 = "evde".ToQuestion();                // evde mi
var soru3 = "okuyor".ToQuestion();              // okuyor mu

var soru4 = "öğrenci".ToNegativeQuestion();     // öğrenci değil mi
var soru5 = "doktor".ToNegativeQuestion();      // doktor değil mi
```

### Çoğul + İyelik Kombinasyonları

```csharp
// Çoğul + iyelik (benim)
var kelime1 = "ev".ToMyPluralPossessive();        // evlerim
var kelime2 = "araba".ToMyPluralPossessive();     // arabalarım

// Çoğul + iyelik (bizim)
var kelime3 = "ev".ToOurPluralPossessive();       // evlerimiz
var kelime4 = "kitap".ToOurPluralPossessive();    // kitaplarımız
```

### Gelişmiş Zincirleme (Pro + Core)

```csharp
using TurkishGrammar.Core.Extensions;
using TurkishGrammar.Pro.Extensions;

// Çoğul + İyelik + Hal eki
var kelime1 = "ev"
    .ToPlural()           // evler
    .ToMyPossessive()     // evlerim (Core extension)
    .ToDative();          // evlerime (benim evlerime)

var kelime2 = "araba"
    .ToPlural()           // arabalar
    .ToOurPossessive()    // arabalarımız (Core extension)
    .ToLocative();        // arabalarımızda (bizim arabalarımızda)

var kelime3 = "kitap"
    .ToPlural()           // kitaplar
    .ToTheirPossessive()  // kitapları (Core extension)
    .ToAccusative();      // kitaplarını (onların kitaplarını)
```

## Gerçek Hayat Örnekleri

### Dinamik Metin Oluşturma

```csharp
using TurkishGrammar.Core.Extensions;
using TurkishGrammar.Pro.Extensions;

string userName = "Ali";
string itemName = "araba";

// "Ali'nin arabası"
var message1 = $"{userName}'nin {itemName.ToHisPossessive()}";

// "Ali'nin arabasına"
var message2 = $"{userName}'nin {itemName.ToHisPossessive().ToDative()}";

// "Ali'nin arabaları"
var message3 = $"{userName}'nin {itemName.ToPlural()}";

// "Ali'nin arabalarında"
var message4 = $"{userName}'nin {itemName.ToPlural().ToLocative()}";
```

### Veritabanı Sorgu Mesajları

```csharp
int recordCount = 5;
string tableName = "kullanıcı";

// "5 kullanıcı bulundu"
var message = $"{recordCount} {tableName} bulundu";

// "kullanıcılar tablosunda"
var tableMessage = $"{tableName.ToPlural()} {("tablo").ToLocative()}";
```

### Hata Mesajları

```csharp
string fileName = "dosya";
string folderName = "klasör";

// "Dosya bulunamadı"
var error1 = $"{fileName} bulunamadı";

// "Dosyayı kaydedemedi"
var error2 = $"{fileName.ToAccusative()} kaydedemedi";

// "Klasörde yetki yok"
var error3 = $"{folderName.ToLocative()} yetki yok";
```

## Test Etme

Kütüphanenin doğru çalıştığını test etmek için:

```csharp
using TurkishGrammar.Core.Extensions;
using Xunit;

public class MyTests
{
    [Fact]
    public void TestTurkishGrammar()
    {
        Assert.Equal("eve", "ev".ToDative());
        Assert.Equal("masada", "masa".ToLocative());
        Assert.Equal("kitabı", "kitap".ToAccusative());
        Assert.Equal("evim", "ev".ToMyPossessive());
    }
}
```
