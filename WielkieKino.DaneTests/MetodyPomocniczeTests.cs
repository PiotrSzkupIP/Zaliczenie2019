using Microsoft.VisualStudio.TestTools.UnitTesting;
using WielkieKino.Dane;
using WielkieKino.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WielkieKino.Dane
{
    [TestClass()]
    public class MetodyPomocniczeTests
    {
        [TestMethod()]
        public void CzyMoznaKupicBiletTest()
        {
            //Given
            int rzad = 8;
            int miejsce = 9;
            bool wynik = false;

            //When
               wynik = MetodyPomocnicze.CzyMoznaKupicBilet(SkladDanych.Bilety, SkladDanych.Seanse[0], rzad, miejsce);

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