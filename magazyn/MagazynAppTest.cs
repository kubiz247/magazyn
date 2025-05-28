using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Magazyn;

[TestClass]
public class MagazynAppTest
{
    [TestMethod]
    public void DodajProdukt()
    {
        var magazyn = new Magazyn();
        magazyn.dodajProdukt("mleko", 2);
        var produkt = magazyn.sprawdzStan("mleko");
        Assert.AreEqual(produkt, 2);
    }

    [TestMethod]
    public void DodajIstniejacy()
    {
        var magazyn = new Magazyn();
        magazyn.dodajProdukt("mleko", 3);
        magazyn.zdejmijProdukt("mleko", 1);
        magazyn.dodajProdukt("mleko", 2);
        var produkt = magazyn.sprawdzStan("mleko");
        Assert.AreEqual(produkt, 4);
    }

    [TestMethod]
    public void ZdejmijProdukt()
    {
        var magazyn = new Magazyn();
        magazyn.dodajProdukt("kiwi", 4);
        magazyn.zdejmijProdukt("kiwi", 2);
        var produkt = magazyn.sprawdzStan("kiwi");
        Assert.AreEqual(produkt, 2);
    }

    [TestMethod]
    public void ZdejmijProduktZaDuzo()
    {
        var magazyn = new Magazyn();
        magazyn.dodajProdukt("marchew", 3);
        magazyn.zdejmijProdukt("marchew", 5);
        var produkt = magazyn.sprawdzStan("marchew");
        if (produkt < 0)
        {
            Console.WriteLine("Masz niewystarczajaca ilosc produktow, nie mozesz zdjac ponad limit.");
        }
        Assert.AreEqual(produkt, 3);
    }

    [TestMethod]
    public void ZdejmijProduktBrak()
    {
        var magazyn = new Magazyn();
        magazyn.dodajProdukt("pomidor", 3);
        magazyn.zdejmijProdukt("papryka", 2);
        var produkt = magazyn.sprawdzStan("papryka");
        if (magazyn.sprawdzStan("pomidor") != produkt) 
        {
            Console.WriteLine("Nie mozesz zdjac nie istniejacego produktu");
        }
        Assert.AreEqual(produkt, 0);
    }
    
    [TestMethod]
    public void ZdejmijProduktPustaNazwa()
    {
        var magazyn = new Magazyn();
        magazyn.dodajProdukt("", -1);
        var produkt = magazyn.sprawdzStan("");
        if (magazyn.dodajProdukt("", 0))
        {
            Console.WriteLine("Nazwa nie moze byc pusta");
        }
        else if (magazyn.dodajProdukt("ogorek", -1))
        {
            Console.WriteLine("Ilosc nie moze byc ujemna");
        }
        Assert.AreEqual(produkt, 0);
    }
    
    [TestMethod]
    public void CzyIstnieje()
    {
        var magazyn = new Magazyn();
        magazyn.dodajProdukt("jablko", 2);
        var produkt = magazyn.sprawdzStan("ziemniak");
        Assert.AreEqual(produkt, 0);
    }

    [TestMethod]
    public void ZdejmijProduktDoZera()
    {
        var magazyn = new Magazyn();
        magazyn.dodajProdukt("banan", 3);
        magazyn.zdejmijProdukt("banan", 3);
        var produkt = magazyn.sprawdzStan("banan");
        Console.WriteLine("Usunales produkt z magazynu");
        Assert.AreEqual(produkt, 0);
    }
}