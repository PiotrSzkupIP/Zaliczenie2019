using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WielkieKino.App
{
    /// <summary>
    /// Metody do napisania z wykorzystaniem LINQ (w składni zapytania, wyrażeń
    /// lambda lub mieszanej)
    /// </summary>
    public class DataProcessing
    {
        // Właściwa odpowiedź: np. "Konan Destylator" dla "Fantasy"
        public List<string> WybierzFilmyZGatunku(List<Film> filmy, string gatunek)
        {
            List<string> wynik =
                (from Film film in filmy
                 where film.Gatunek == gatunek
                 select film.Tytul).Distinct().ToList();

            return wynik;
        }

        /// <summary>
        /// Sumujemy wpływy bez względu na datę seansu
        /// </summary>
        /// <param name="bilety"></param>
        /// <returns></returns>
        public double PodajCalkowiteWplywyZBiletow(List<Bilet> bilety)
        {
            // Właściwa odpowiedź: 400

            return (from Bilet bilet in bilety
                    select bilet.Cena).Sum();
        }

        public List<Film> WybierzFilmyPokazywaneDanegoDnia(List<Seans> seanse, DateTime data)
        {
            List<Film> wynik = (from Seans seans in seanse
                                where seans.Date == data
                                select seans.Film).Distinct().ToList();
            return wynik;
        }

        /// <summary>
        /// Zwraca gatunek, z którego jest najwięcej filmów. Jeśli jest kilka takich
        /// gatunków, to zwraca dowolny z nich.
        /// </summary>
        /// <param name="filmy"></param>
        /// <returns></returns>
        public string NajpopularniejszyGatunek(List<Film> filmy)
        {
            List<string> listaGatunkow = (from Film film in filmy
                                          select film.Gatunek).Distinct().ToList();

            string gatunekWybrany = null;
            int maxLiczbaWystapienGatunku = 0;

            foreach (string gatunek in listaGatunkow)
            {
                int liczbaWystapienGatunku = 0;
                foreach (Film film in filmy)
                {
                    if (gatunek == film.Gatunek)
                    {
                        liczbaWystapienGatunku++;
                    }
                }
                if (liczbaWystapienGatunku > maxLiczbaWystapienGatunku)
                {
                    maxLiczbaWystapienGatunku = liczbaWystapienGatunku;
                    gatunekWybrany = gatunek;
                }
            }

            // Właściwa odpowiedź: Obyczajowy
            return gatunekWybrany;
        }

        public List<Sala> ZwrocSalePosortowanePoCalkowitejLiczbieMiejsc(List<Sala> sale)
        {
            // Właściwa odpowiedź: Kameralna, Bałtyk, Wisła (lub w odwrotnej kolejności)
            List<Sala> wynik1 = (from Sala sala in sale
                                 orderby (sala.LiczbaMiejscWRzedzie * sala.LiczbaRzedow)
                                 select sala).ToList();
            return wynik1;
        }

        public Sala ZwrocSaleGdzieJestNajwiecejSeansow(List<Seans> seanse, DateTime data)
        {
            // Właściwa odpowiedź dla daty 2019-01-20: sala "Wisła" 

            List<Sala> listaSal = (from Seans seans in seanse
                                       //where seans.Date == data
                                       //orderby seans.Sala
                                   select seans.Sala).Distinct().ToList();

            int najwiekszaliczbaSal = 0;
            Sala salaMax = null;
            foreach (Sala sala in listaSal)
            {
                int liczbaSal = 0;
                foreach (Seans seans in seanse)
                {
                    if (seans.Sala == sala)
                    {
                        liczbaSal++;
                    }
                }
                if (liczbaSal > najwiekszaliczbaSal)
                {
                    najwiekszaliczbaSal = liczbaSal;
                    salaMax = sala;
                }
            }

            return salaMax;
        }

        /// <summary>
        /// Uwaga: Nie wszystkie parametry przekazane do metody muszą być użyte przy
        /// implementacji. Jeśli jest kilka takich filmów, zwracamy dowolny.
        /// </summary>
        /// <param name="filmy"></param>
        /// <param name="bilety"></param>
        /// <returns></returns>
        public Film ZwrocFilmNaKtorySprzedanoNajwiecejBiletow(List<Film> filmy, List<Bilet> bilety)
        {
            List<Film> listaFilmow = (from Bilet bilet in bilety
                                      select bilet.Seans.Film).Distinct().ToList();

            int najwiekszaBiletow = 0;
            Film filmMax = null;
            foreach (Film film in listaFilmow)
            {
                int liczbaFilmow = 0;
                foreach (Bilet bilet in bilety)
                {
                    if (bilet.Seans.Film == film)
                    {
                        liczbaFilmow++;
                    }
                }
                if (liczbaFilmow > najwiekszaBiletow)
                {
                    najwiekszaBiletow = liczbaFilmow;
                    filmMax = film;
                }
            }

            return filmMax;

            // Właściwa odpowiedź: "Konan Destylator"
        }

        /// <summary>
        /// Uwaga: Nie wszystkie parametry metody muszą być wykorzystane przy
        /// implementacji. Filmy z takim samym przychodem zwracamy w dowolnej kolejności
        /// </summary>
        /// <param name="filmy"></param>
        /// <param name="bilety"></param>
        /// <returns></returns>
        public List<Film> PosortujFilmyPoDochodach(List<Film> filmy, List<Bilet> bilety)
        {
            List<Film> listaWynik = (from Bilet bilet in bilety
                                     orderby bilet.Cena
                                     select bilet.Seans.Film).ToList();


            return listaWynik;
        }
    }
}