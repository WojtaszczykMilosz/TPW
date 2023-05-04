using Dane;

namespace Tests
{
    public class DataTests
    {


        [Test]
        public void DataApiTest()
        {

            AbstractDataApi dataApi = new DataApi();
            Assert.That(dataApi.Wysokosc, Is.EqualTo(500));
            Assert.That(dataApi.Szerokosc, Is.EqualTo(500));


            

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
            Assert.That(kula.Masa, Is.EqualTo(1));




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
        public void KopiaKuliTest()
        {
            Kula kula1 = new Kula();
            Kula kula2 = kula1.Kopiuj();
            Assert.That(kula1,Is.Not.EqualTo(kula2));
        }

        [Test]
        public void ZmianaWlasciwosciKuliTest()
        {
            Kula kula1 = new Kula();
            kula1.X = 2;
            kula1.Y = 3;
            kula1.PredkoscX = 5;
            kula1.PredkoscY = 7;
            Kula kula2 = new Kula();
            kula2.ZmienWlasciwosci(kula1);
            Assert.That(kula2.X,Is.EqualTo(2));
            Assert.That(kula2.Y, Is.EqualTo(3));
            Assert.That(kula2.PredkoscX, Is.EqualTo(5));
            Assert.That(kula2.PredkoscY, Is.EqualTo(7));
        }

        [Test]
        public void PrzepisanieKulTest()
        {
            AbstractDataApi dataApi = new DataApi();
            List<Kula> kulaList = new List<Kula>();
            for(int i = 0; i < 3; i++)
            {
                kulaList.Add(new Kula());
                kulaList[i].X = i;
                kulaList[i].Y = i;
            }
            dataApi.PrzepiszKule(kulaList);
            Assert.That(dataApi.Kule.Count, Is.EqualTo(3));
            for(int i = 0; i <3; i++)
            {
                Assert.That(dataApi.Kule[i].X, Is.EqualTo(i));
                Assert.That(dataApi.Kule[i].Y, Is.EqualTo(i));
            }
            kulaList.Add(new Kula());
            dataApi.PrzepiszKule(kulaList);
            Assert.That(dataApi.Kule.Count, Is.EqualTo(4));
            Assert.That(kulaList,Is.Not.EqualTo(dataApi.Kule));
        }

        [Test]
        public void ZaktualizujKuleTest()
        {
            AbstractDataApi dataApi = new DataApi();
            List<Kula> kulaList = new List<Kula>();
            for (int i = 0; i < 3; i++)
            {
                kulaList.Add(new Kula());
                kulaList[i].X = i;
                kulaList[i].Y = i;
            }
            dataApi.PrzepiszKule(kulaList);
            for (int i = 0; i < 3; i++)
            {
                
                kulaList[i].X = i + 3;
                kulaList[i].Y = i + 3;
            }
            dataApi.ZaktualizujKule(kulaList);
            for (int i = 0; i <3; i++)
            {
                Assert.That(dataApi.Kule[i].X, Is.EqualTo(i + 3));
                Assert.That(dataApi.Kule[i].Y, Is.EqualTo(i + 3));
            }
            kulaList.Add(new Kula());
            dataApi.ZaktualizujKule(kulaList);
            Assert.That(kulaList.Count,Is.Not.EqualTo(dataApi.Kule.Count));
        }
    }
}