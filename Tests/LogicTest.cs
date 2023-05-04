using Logika;
using Dane;
namespace Testy
{
    public class LogicTest
    {
        [Test] public void LogikaKuliTest() {
            Kula kula = new Kula();
            kula.X = 1;
            kula.Y = 1;
            kula.PredkoscX = 1;
            kula.PredkoscY = 1;

            
            kula.Przemieszczaj();
            Assert.AreEqual(kula.X, 1 + kula.PredkoscX);
            Assert.AreEqual(kula.X, 1 + kula.PredkoscY);
            Assert.Pass();
        }


        [Test]
        public void LogicApiTest()
        {


            AbstractLogicApi logicApi = new LogicApi();
            logicApi.TworzKule(3);
            Assert.AreEqual(logicApi.Kule.Count, 3);
            Assert.Pass();
        }


        [Test]
        public void SprawdzPozycjeTest()
        {
            AbstractLogicApi logicApi = new LogicApi();
            Kula kula = new Kula();
            kula.Srednica = 20;
            kula.X = 1;
            kula.Y = 1;
            logicApi.Kule.Add(kula);
            Assert.True(logicApi.JestKulaNaPozycji(1, 1, 20));
            Assert.False(logicApi.JestKulaNaPozycji(50, 50, 20));
            Assert.False(logicApi.JestKulaNaPozycji(20, 50, 20));
            Assert.False(logicApi.JestKulaNaPozycji(50, 20, 20));
            Assert.True(logicApi.JestKulaNaPozycji(21, 21, 20));
            Assert.False(logicApi.JestKulaNaPozycji(22, 22, 20));




        }

        [Test]
        public void KolizjeTest()
        {

            Kula kula = new Kula();
            kula.X = 1;
            kula.Y = 1; 
            kula.Srednica = 20;
            AbstractLogicApi logicApi = new LogicApi();
            
            //logicApi.Kule.Add(kula);
            //Assert.False(logicApi.SprawdzCzyWychodziPozaObszarX(kula));
            //logicApi.ObslozKolizjeZeSciania(kula);
            

            //kula.X = 381;
            //Assert.True(logicApi.SprawdzCzyWychodziPozaObszarX(kula));
            //kula.X = -1 - kula.PredkoscX;
            //Assert.True(logicApi.SprawdzCzyWychodziPozaObszarX(kula));

            //kula.Y = 381;
            //Assert.True(logicApi.SprawdzCzyWychodziPozaObszarY(kula));
            //kula.Y = -1 - kula.PredkoscY;
            //Assert.True(logicApi.SprawdzCzyWychodziPozaObszarY(kula));

            double predkoscX = kula.PredkoscX;
            double predkoscY = kula.PredkoscY;
            logicApi.ObslozKolizjeZeSciania(kula);
            
            Assert.That(kula.PredkoscX, Is.EqualTo(-predkoscX));
            Assert.That(kula.PredkoscY, Is.EqualTo(-predkoscY));



            Assert.Pass();
        }




        [Test]
        public void LogicFactoryTest()
        {
            //AbstractLogicApi a = LogicApiFactory.CreateLogicApi();

            
            Assert.Pass();
        }

        [Test]
        public void GenerowaniePredkosciTest()
        {
            
            AbstractLogicApi kulaApi = new LogicApi();
            kulaApi.TworzKule(8);
            foreach(var kula in kulaApi.Kule)
            {
                Assert.That(kula.PredkoscY, Is.Not.EqualTo(0));
                Assert.That(kula.PredkoscX, Is.Not.EqualTo(0));
                Assert.That(kula.PredkoscY, Is.LessThan(5));
                Assert.That(kula.PredkoscX, Is.LessThan(5));
                Assert.That(kula.PredkoscY, Is.GreaterThan(-5));
                Assert.That(kula.PredkoscX, Is.GreaterThan(-5));
            }
        }

        [Test]
        public void PrzemieszczanieKulOrazCancelTest()
        {
            LogicApi kulaApi = new LogicApi();
            kulaApi.PrzemieszczajKule();
            Assert.That(kulaApi.WatkiKul.Count,Is.EqualTo(0));
            kulaApi.TworzKule(3);
            Assert.That(kulaApi.RuchKul, Is.False);
            kulaApi.PrzemieszczajKule();
            Assert.That(kulaApi.WatkiKul.Count, Is.EqualTo(3));
            foreach (var watek in kulaApi.WatkiKul)
            {
                Assert.That(watek.IsAlive, Is.True);
            }
            Assert.That(kulaApi.RuchKul, Is.True);
            kulaApi.AnulujToken();
            Thread.Sleep(1000);
            Assert.That(kulaApi.RuchKul, Is.False);
            foreach(var watek in kulaApi.WatkiKul)
            {
                Assert.That(watek.IsAlive, Is.False);
            }

        }

        [Test]
        public void InformatorTest()
        {
            var kulaApi = new LogicApi();
            kulaApi.PrzemieszczajKule();
            kulaApi.RozpocznijInformatora(1);
            Assert.That(kulaApi.Informator, Is.Null);
            kulaApi.TworzKule(3);
            kulaApi.RozpocznijInformatora(1);
            Assert.That(kulaApi.Informator, Is.Null);
            kulaApi.PrzemieszczajKule();
            kulaApi.RozpocznijInformatora(2);
            Assert.That(kulaApi.Informator.IsAlive,Is.True);
            //kulaApi.AnulujToken();
            //Thread.Sleep(20);
            //Assert.That(kulaApi.Informator.IsAlive, Is.False);
        }


        [Test]
        public void NachodzenieTest()
        {
            var kulaApi = new LogicApi();

            Kula kula1 = new Kula();
            kula1.Srednica = 20;
            kula1.X = 1;
            kula1.Y = 1;
            kula1.PredkoscX = 0;
            kula1.PredkoscY = 0;
            kulaApi.Kule.Add(kula1);

            Kula kula2 = new Kula();
            kula2.Srednica = 20;
            kula2.X = 20;
            kula2.Y = 20;
            kula2.PredkoscX = -1;
            kula2.PredkoscY = 1;
            kulaApi.Kule.Add(kula2);


            Assert.True(kulaApi.SprawdzCzyNachodziNaKule(kula1, kula2));

         
            kula2.PredkoscY = -1;
            Assert.True(kulaApi.SprawdzCzyNachodziNaKule(kula1, kula2));

            kula2.PredkoscX = 1;
            Assert.True(kulaApi.SprawdzCzyNachodziNaKule(kula1, kula2));

            kula2.PredkoscY = 1;
            Assert.False(kulaApi.SprawdzCzyNachodziNaKule(kula1, kula2));

            kula1.X = 40;
            kula1.Y = 40;

            Assert.True(kulaApi.SprawdzCzyNachodziNaKule(kula1, kula2));


            kula2.PredkoscY = -1;
            Assert.True(kulaApi.SprawdzCzyNachodziNaKule(kula1, kula2));

            kula2.PredkoscX = -1;
            Assert.False(kulaApi.SprawdzCzyNachodziNaKule(kula1, kula2));

            kula2.PredkoscY = 1;
            Assert.True(kulaApi.SprawdzCzyNachodziNaKule(kula1, kula2));

           

        }
    }
}
