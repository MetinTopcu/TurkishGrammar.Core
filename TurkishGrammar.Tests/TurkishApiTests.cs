using TurkishGrammar.Core.Extensions.Tr;
using TurkishGrammar.Pro.Extensions.Tr;

namespace TurkishGrammar.Tests;

public class TurkishApiTests
{
    [Fact]
    public void BulunmaHali_Test()
    {
        Assert.Equal("evde", "ev".BulunmaHali());
        Assert.Equal("masada", "masa".BulunmaHali());
    }

    [Fact]
    public void YönelmeHali_Test()
    {
        Assert.Equal("eve", "ev".YönelmeHali());
        Assert.Equal("masaya", "masa".YönelmeHali());
    }

    [Fact]
    public void AyrılmaHali_Test()
    {
        Assert.Equal("evden", "ev".AyrılmaHali());
        Assert.Equal("masadan", "masa".AyrılmaHali());
    }

    [Fact]
    public void BelirtmeHali_Test()
    {
        Assert.Equal("evi", "ev".BelirtmeHali());
        Assert.Equal("masayı", "masa".BelirtmeHali());
    }

    [Fact]
    public void VasıtaHali_Test()
    {
        Assert.Equal("kalemle", "kalem".VasıtaHali());
    }

    [Fact]
    public void İyelikEki_Benim_Test()
    {
        Assert.Equal("evim", "ev".Benim());
        Assert.Equal("arabam", "araba".Benim());
    }

    [Fact]
    public void İyelikEki_Senin_Test()
    {
        Assert.Equal("evin", "ev".Senin());
        Assert.Equal("araban", "araba".Senin());
    }

    [Fact]
    public void İyelikEki_Onun_Test()
    {
        Assert.Equal("evi", "ev".Onun());
        Assert.Equal("arabası", "araba".Onun());
    }

    [Fact]
    public void İyelikEki_Bizim_Test()
    {
        Assert.Equal("evimiz", "ev".Bizim());
        Assert.Equal("arabamız", "araba".Bizim());
    }

    [Fact]
    public void Çoğul_Test()
    {
        Assert.Equal("evler", "ev".Çoğul());
        Assert.Equal("masalar", "masa".Çoğul());
        Assert.Equal("kitaplar", "kitap".Çoğul());
    }

    [Fact]
    public void SoruEki_Test()
    {
        Assert.Equal("geldin mi", "geldin".SoruEki());
        Assert.Equal("evde mi", "evde".SoruEki());
    }

    [Fact]
    public void OlumsuzSoru_Test()
    {
        Assert.Equal("öğrenci değil mi", "öğrenci".OlumsuzSoru());
    }

    [Fact]
    public void BenimÇoğul_Test()
    {
        Assert.Equal("evlerim", "ev".BenimÇoğul());
        Assert.Equal("arabalarım", "araba".BenimÇoğul());
    }

    [Fact]
    public void BizimÇoğul_Test()
    {
        Assert.Equal("evlerimiz", "ev".BizimÇoğul());
        Assert.Equal("arabalarımız", "araba".BizimÇoğul());
    }

    [Fact]
    public void Zincirleme_Test()
    {
        // ev -> evim -> evime
        Assert.Equal("evime", "ev".Benim().YönelmeHali());

        // ev -> evler -> evlerim -> evlerimde
        Assert.Equal("evlerimde", "ev".Çoğul().Benim().BulunmaHali());
    }
}
