using Dane;

namespace Tests
{
    public class DataTests
    {


        [Test]
        public void DataApiTest()
        {

            AbstractDataApi dataApi = new DataApi();
            Assert.That(dataApi.Wysokosc, Is.EqualTo(400));
            Assert.That(dataApi.Szerokosc, Is.EqualTo(400));


            dataApi.IloscKulek = "3";
            Assert.That(dataApi.IloscKulek, Is.EqualTo("3"));
            dataApi.TworzKule();
            Assert.AreEqual(dataApi.Kule.Count, Convert.ToInt32(dataApi.IloscKulek));

            Assert.Pass();
        }


        [Test]
        public void KulaTest()
        {
            Kula kula = new Kula();
            kula.Srednica = 20;
            kula.X = 1;
            kula.Y = 2;


            Assert.That(kula.X, Is.EqualTo(1));
            Assert.That(kula.Y, Is.EqualTo(2));
            Assert.That(kula.Srednica, Is.EqualTo(20));




            Assert.Pass();
        }

        [Test]
        public void PudelkoTest()
        {
            Pudelko p = new Pudelko(40, 40);
            Assert.That(p.Wysokosc, Is.EqualTo(40));
            Assert.That(p.Szerokosc, Is.EqualTo(40));

            Assert.Pass();
        }

        [Test]
        public void NachodzenieTest()
        {
            DataApi dataApi = new DataApi();
            Kula kula = new Kula();
            kula.Srednica = 20;
            kula.X = 1;
            kula.Y = 1;
            dataApi.Kule.Add(kula);
            Assert.True(dataApi.JestKulaNaPozycji(1, 1, 20));
            Assert.False(dataApi.JestKulaNaPozycji(50, 50, 20));
            Assert.False(dataApi.JestKulaNaPozycji(20, 50, 20));
            Assert.False(dataApi.JestKulaNaPozycji(50, 20, 20));
            Assert.True(dataApi.JestKulaNaPozycji(21, 21, 20));
            Assert.False(dataApi.JestKulaNaPozycji(22, 22, 20));

        }


        
    }
}