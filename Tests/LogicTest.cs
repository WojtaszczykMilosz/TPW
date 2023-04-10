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
            

            LogikaKuli logika = new LogikaKuli(kula);

            Assert.AreEqual(logika.PredkoscX, logika.Predkosc);
            Assert.AreEqual(logika.PredkoscY, logika.Predkosc);
            logika.Przemieszczaj();
            Assert.AreEqual(logika.X, 1 + logika.PredkoscX);
            Assert.AreEqual(logika.X, 1 + logika.PredkoscY);
            Assert.Pass();
        }


        [Test]
        public void LogicApiTest()
        {
            
            
            LogicApi logicApi = new LogicApi();
            logicApi.IloscKulek = "3";
            logicApi.ZacznijTworzycKule();
            Assert.AreEqual(logicApi.LogikaKul.Count, Convert.ToInt32(logicApi.IloscKulek));
            Assert.Pass();
        }



        [Test]
        public void KolizjeTest()
        {

            Kula kula = new Kula();
            kula.X = 1;
            kula.Y = 1; 
            kula.Srednica = 20;
            LogicApi logicApi = new LogicApi();
            LogikaKuli logika = new LogikaKuli(kula);
            logicApi.LogikaKul.Add(logika);
            Assert.False(logicApi.SprawdzCzyWychodziPozaObszarX(logika));
            logicApi.ObslozKolizje(logika);
            Assert.That(logika.PredkoscX, Is.EqualTo(logika.Predkosc));
            Assert.That(logika.PredkoscY, Is.EqualTo(logika.Predkosc));

            kula.X = 381;
            Assert.True(logicApi.SprawdzCzyWychodziPozaObszarX(logika));
            kula.X = -1 - logika.PredkoscX;
            Assert.True(logicApi.SprawdzCzyWychodziPozaObszarX(logika));

            kula.Y = 381;
            Assert.True(logicApi.SprawdzCzyWychodziPozaObszarY(logika));
            kula.Y = -1 - logika.PredkoscY;
            Assert.True(logicApi.SprawdzCzyWychodziPozaObszarY(logika));

            logicApi.ObslozKolizje(logika);
            Assert.That(logika.PredkoscX, Is.EqualTo(-logika.Predkosc));
            Assert.That(logika.PredkoscY, Is.EqualTo(-logika.Predkosc));



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
