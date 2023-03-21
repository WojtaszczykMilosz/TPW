using ViewModel;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void MainViewModelTest()
        {

            MainViewModel vm = new MainViewModel();
            Assert.That(vm.Height, Is.EqualTo(400));
            Assert.That(vm.Width, Is.EqualTo(400));
            
            
            vm.IloscKulek = "3";
            Assert.That(vm.IloscKulek, Is.EqualTo("3"));
            vm.TworzKule(null);
            Assert.AreEqual(vm.Kule.Count, Convert.ToInt32(vm.IloscKulek));
          
            Assert.Pass();
        }

        [Test] 
        public void KulaTest() {
            Kula kula = new Kula();
            kula.Promien = 20;
            kula.X = 1;
            kula.Y = 2;
            kula.Vx = 3;
            kula.Vy = 4;

            Assert.That(kula.X, Is.EqualTo(1));
            Assert.That(kula.Y, Is.EqualTo(2));
            Assert.That(kula.Vx, Is.EqualTo(3));
            Assert.That(kula.Vy, Is.EqualTo(4));
            Assert.That(kula.Promien, Is.EqualTo(20));
            



            Assert.Pass();
        }

        [Test]
        public void PudelkoTest()
        {
            Pudelko p = new Pudelko(40,40);
            Assert.That(p.Height, Is.EqualTo(40));
            Assert.That(p.Width, Is.EqualTo(40));

            Assert.Pass();
        }
    }
}