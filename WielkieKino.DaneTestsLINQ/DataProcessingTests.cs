using Microsoft.VisualStudio.TestTools.UnitTesting;
using WielkieKino.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WielkieKino.App.Tests
{
    [TestClass()]
    public class DataProcessingTests
    {
        [TestMethod()]
        public void WybierzFilmyZGatunkuTest()
        {
            
            //Given
            DataProcessing dp = new DataProcessing();
            List<Film> f = SkladDanych.Filmy;

            //When
            string gatunek_oczekiwany_wynik = "Fantasy";
            string film_dane = "Konan Destylator";
            List<string> filmy = dp.WybierzFilmyZGatunku(f, film_dane);

            //Then
            Assert.Equals(gatunek_oczekiwany_wynik, filmy[0]);

          }

        [TestMethod()]
        public void NajpopularniejszyGatunekTest()
        {
            //Given
            DataProcessing dp = new DataProcessing();
            List<Film> f = SkladDanych.Filmy;

            //When
            string gatunek_dane = "Obyczajowy";
            string gatunek_wynik = dp.NajpopularniejszyGatunek(f);

            //Then
            Assert.AreSame(gatunek_dane, gatunek_wynik);

        }
        //ZwrocSaleGdzieJestNajwiecejSeansow(List<Seans> seanse, DateTime data)
        // Właściwa odpowiedź dla daty 2019-01-20: sala "Wisła" 

        [TestMethod()]
        public void ZwrocSaleGdzieJestNajwiecejSeansowTest()
        {

            DataProcessing dp = new DataProcessing();
            DateTime dataSeansu = new DateTime(2019, 1, 20, 12, 00, 00);
            List<Seans> seans = SkladDanych.Seanse;
            string nazwaSali = "Wisła";
            Sala nazwaSaliWynik = dp.ZwrocSaleGdzieJestNajwiecejSeansow(seans, dataSeansu);

            Assert.AreSame(nazwaSali, nazwaSaliWynik.Nazwa);

        }

    }
}