using ViewModel;

namespace Tests
{
    public class Tests
    {
       

        [Test]
        public void MainViewModelTest()
        {

            MainViewModel vm = new MainViewModel();
            Assert.That(vm.Wysokosc, Is.EqualTo(400));
            Assert.That(vm.Szerokosc, Is.EqualTo(400));
            
            
            vm.IloscKulek = "3";
            Assert.That(vm.IloscKulek, Is.EqualTo("3"));
            vm.TworzKule();
            Assert.AreEqual(vm.Kule.Count, Convert.ToInt32(vm.IloscKulek));
          
            Assert.Pass();
        }

        [Test] 
        public void KulaTest() {
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
            Pudelko p = new Pudelko(40,40);
            Assert.That(p.Wysokosc, Is.EqualTo(40));
            Assert.That(p.Szereokosc, Is.EqualTo(40));

            Assert.Pass();
        }

        [Test]
        public void SprawdzNachodzenieTest()
        {
            MainViewModel vm = new MainViewModel();
            Kula kula = new Kula();
            kula.Srednica = 20;
            kula.X = 1;
            kula.Y = 1;
            vm.Kule.Add(kula);
            Assert.False(vm.SprawdzKoordynaty(1, 1, 20));
            Assert.True(vm.SprawdzKoordynaty(50, 50, 20));
            Assert.True(vm.SprawdzKoordynaty(20, 50, 20));
            Assert.True(vm.SprawdzKoordynaty(50, 20, 20));
            Assert.False(vm.SprawdzKoordynaty(21, 21, 20));
            Assert.True(vm.SprawdzKoordynaty(22, 22, 20));

        }
    }
}