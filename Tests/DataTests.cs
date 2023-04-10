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



        
    }
}