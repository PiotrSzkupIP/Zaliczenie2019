using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WielkieKino.App;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WielkieKino.DaneTests2
{
    [TestClass]
    public class MetodyPomocniczeTests2
    {
        //Bilety.Add(new Bilet(Seanse[0], 20.00, 5, 5))
        [TestMethod()]
         public void CzyMoznaKupicBiletTest()
        {
            //Given
            int rzad = 5;
            int miejsce = 5;
            bool wynik = false;

            //When
            wynik = MetodyPomocnicze.CzyMoznaKupicBilet(SkladDanych.Bilety, SkladDanych.Seanse[0], rzad, miejsce);

            //Then
            Assert.IsTrue(wynik);
        }

        [TestMethod()]
        public void CzyMoznaDodacSeansTest()
        {
            //Date = new DateTime(2019, 1, 20, 12, 00, 00),
            //        Film = Filmy[0],
            //        Sala = Sale[0]

            bool wynik = false;
            DateTime date = new DateTime(2019, 1, 20, 12, 00, 00);
            wynik = MetodyPomocnicze.CzyMoznaDodacSeans(
                SkladDanych.Seanse, SkladDanych.Sale[0], SkladDanych.Filmy[0],date);
            Assert.IsFalse(wynik);
        }

        [TestMethod()]
        public void LiczbaWolnychMiejscWSaliTest()
        {
            //Bilety.Add(new Bilet(Seanse[1], 22.00, 4, 5));
            int wolneMiejsceSala0 = 72;
            int wyliczoneWolneMiejsca = MetodyPomocnicze.LiczbaWolnychMiejscWSali(
                SkladDanych.Bilety, SkladDanych.Seanse[0]);
            Assert.AreEqual(wolneMiejsceSala0,wyliczoneWolneMiejsca);
        }

        [TestMethod()]
        public void CalkowitePrzychodyZBiletowTest()
        {
            double przychody = 400;
            double wyliczonePrzychody = MetodyPomocnicze.CalkowitePrzychodyZBiletow(
            SkladDanych.Bilety);
            Assert.AreEqual(przychody,wyliczonePrzychody);
        }
    }
}
