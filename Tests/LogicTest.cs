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



            Assert.AreEqual(kula.PredkoscX, kula.Predkosc);
            Assert.AreEqual(kula.PredkoscY, kula.Predkosc);
            kula.Przemieszczaj();
            Assert.AreEqual(kula.X, 1 + kula.PredkoscX);
            Assert.AreEqual(kula.X, 1 + kula.PredkoscY);
            Assert.Pass();
        }


        [Test]
        public void LogicApiTest()
        {


            LogicApi logicApi = new LogicApi();
            logicApi.TworzKule(3);
            Assert.AreEqual(logicApi.Kule.Count, 3);
            Assert.Pass();
        }


        [Test]
        public void NachodzenieTest()
        {
            LogicApi logicApi = new LogicApi();
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
            LogicApi logicApi = new LogicApi();
            
            logicApi.Kule.Add(kula);
            Assert.False(logicApi.SprawdzCzyWychodziPozaObszarX(kula));
            logicApi.ObslozKolizje(kula);
            Assert.That(kula.PredkoscX, Is.EqualTo(kula.Predkosc));
            Assert.That(kula.PredkoscY, Is.EqualTo(kula.Predkosc));

            kula.X = 381;
            Assert.True(logicApi.SprawdzCzyWychodziPozaObszarX(kula));
            kula.X = -1 - kula.PredkoscX;
            Assert.True(logicApi.SprawdzCzyWychodziPozaObszarX(kula));

            kula.Y = 381;
            Assert.True(logicApi.SprawdzCzyWychodziPozaObszarY(kula));
            kula.Y = -1 - kula.PredkoscY;
            Assert.True(logicApi.SprawdzCzyWychodziPozaObszarY(kula));

            logicApi.ObslozKolizje(kula);
            Assert.That(kula.PredkoscX, Is.EqualTo(-kula.Predkosc));
            Assert.That(kula.PredkoscY, Is.EqualTo(-kula.Predkosc));



            Assert.Pass();
        }




        [Test]
        public void LogicFactoryTest()
        {
            //AbstractLogicApi a = LogicApiFactory.CreateLogicApi();

            
            Assert.Pass();
        }
    }
}
