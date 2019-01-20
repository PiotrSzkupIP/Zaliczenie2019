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
        [TestMethod()]
        public void CzyMoznaKupicBiletTest()
        {
            //Given
            int rzad = 8;
            int miejsce = 9;
            bool wynik = true;

            //When
            //wynik = MetodyPomocnicze.CzyMoznaKupicBilet(SkladDanych.Bilety, SkladDanych.Seanse[0], rzad, miejsce);

            //Then
            Assert.IsTrue(wynik);
        }

        [TestMethod()]
        public void CzyMoznaDodacSeansTest()
        {


            Assert.Fail();
        }

        [TestMethod()]
        public void LiczbaWolnychMiejscWSaliTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CalkowitePrzychodyZBiletowTest()
        {
            Assert.Fail();
        }
    }
}
