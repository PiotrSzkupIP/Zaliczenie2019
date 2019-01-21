using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WielkieKino.App
{
    /// <summary>
    /// Metody do implementacji (raczej) bez wykorzystania LINQ
    /// </summary>
    public class MetodyPomocnicze
    {
        /// <summary>
        /// Sprawdzenie czy dane miejsce w konkretnym seansie nie jest zajęte
        /// </summary>
        /// <param name="sprzedaneBilety"></param>
        /// <param name="seans"></param>
        /// <param name="rzad"></param>
        /// <param name="miejsce"></param>
        /// <returns></returns>
        /// 
        static public bool CzyMoznaKupicBilet(List<Bilet> sprzedaneBilety, Seans seans, int rzad, int miejsce)
        {
            bool CzyJestMiejsce = false;
            foreach (Bilet bilet in sprzedaneBilety)
            {
                if (bilet.Seans == seans)
                {
                    if (bilet.Miejsce == miejsce)
                    {
                        if (bilet.Rzad == rzad)
                        {
                            CzyJestMiejsce = false;
                        }
                        else
                        {
                            CzyJestMiejsce = true;
                            break; 
                        }
                    }
                }
            }

            return CzyJestMiejsce;
        }

        /// <summary>
        /// Sprawdzenie czy można projekcja filmu o zadanej godzinie nie nakłada się z już
        /// dodanymi seansami w tej sali.
        /// </summary>
        /// <param name="aktualneSeanse"></param>
        /// <param name="sala"></param>
        /// <param name="film"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        static public bool CzyMoznaDodacSeans(List<Seans> aktualneSeanse, Sala sala, Film film, DateTime data)
        {
            bool CzyMiejsce = true;

            foreach (Seans seans in aktualneSeanse)
            {
                if (seans.Date == data)
                {
                    if (seans.Film == film)
                    {
                        if (seans.Sala == sala)
                        {
                            CzyMiejsce = false;
                        }
                        else
                        {
                            CzyMiejsce = true;
                            break;
                        }
                    }
                }
            }
            // np. nie można zagrać filmu "Egzamin" w sali Kameralnej 2019-01-20 o 17:00
            // można natomiast zagrać "Egzamin" w tej sali 2019-01-20 o 14:00
            return CzyMiejsce;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sprzedaneBilety">wszystkie sprzedane bilety</param>
        /// <param name="seansDoSprawdzenia"></param>
        /// <returns></returns>
        static public int LiczbaWolnychMiejscWSali(List<Bilet> sprzedaneBilety, Seans seansDoSprawdzenia)
        {
            int LiczbaSprzedanychBiletow = 0;
            int LiczbaWolnychMiejsc = 0;

            foreach (Bilet bilet in sprzedaneBilety)
            {
                if (bilet.Seans == seansDoSprawdzenia)
                {
                    LiczbaSprzedanychBiletow += 1;
                }
            }

            LiczbaWolnychMiejsc = (seansDoSprawdzenia.Sala.LiczbaMiejscWRzedzie * seansDoSprawdzenia.Sala.LiczbaRzedow) - LiczbaSprzedanychBiletow;
            // Właściwa odpowiedź: np. na pierwszy seans z listy seansów w klasie SkladDanych są 72 miejsca
            return LiczbaWolnychMiejsc;
        }

        static public double CalkowitePrzychodyZBiletow(List<Bilet> sprzedaneBilety)
        {
            double SumaPrzychoduZBiletow = 0;

            foreach (Bilet bilet in sprzedaneBilety)
            {
                SumaPrzychoduZBiletow += bilet.Cena;
            }
            // Właściwa odpowiedź: 400.00
            return SumaPrzychoduZBiletow;
        }
    }
}
