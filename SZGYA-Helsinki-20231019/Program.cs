using System;
using SZGYA_Helsinki_20231019;

namespace SZGYAHelsinki
{
    class Program
    {
        public static void Main(string[] args)
        {
            List<Helyezes> helyezesek = new List<Helyezes>();

            using StreamReader sr = new StreamReader("../../../src/helsinki.txt");
            while (!sr.EndOfStream) 
            {
                helyezesek.Add(new Helyezes(sr.ReadLine()));
            }

            Console.WriteLine($"3.feladat: \nPontszerző helyezések száma: {helyezesek.Count}");

            var helyezesKat = helyezesek
                .GroupBy(h => h.ElertHely)
                .ToDictionary(k => k.Key, v => v.Count());
            Console.WriteLine("4.feladat:");
            Console.WriteLine($"Arany: {helyezesKat[1]}");
            Console.WriteLine($"Ezüst: {helyezesKat[2]}");
            Console.WriteLine($"Bronz: {helyezesKat[3]}");
            Console.WriteLine($"Összesen: {helyezesKat.Where(h => h.Key <= 3).Sum(h => h.Value)}");

            Console.WriteLine("5.feladat:");
            Console.WriteLine($"Olimpiai pontok száma {helyezesek.Sum(h => h.OlimpiaiPont)}");

            Console.WriteLine("6.feladat:");
            var helyezesekAgSzerint = helyezesek.GroupBy(h => h.Sportag).ToDictionary(k => k.Key, v => v.Count());
            if (helyezesekAgSzerint["torna"] > helyezesekAgSzerint["uszas"])
                Console.WriteLine("Torna sportágban szereztek több érmet.");
            else if (helyezesekAgSzerint["torna"] < helyezesekAgSzerint["uszas"])
                Console.WriteLine("Úszás sportágban szereztek több érmet.");
            else Console.WriteLine("Egyenlp volt az érmek száma");

            for (int i = 0; i < helyezesek.Count; i++)
            {
                if (helyezesek[i].Sportag == "kajakkenu") helyezesek[i].Sportag = "kajak-kenu";
            }

            using StreamWriter sw = new StreamWriter("../../../src/helsinki2.txt");
            foreach(var helyezes in helyezesek)
            {
                sw.WriteLine(helyezes);
            }

            Console.WriteLine("8.feladat:");
            var legtobbSportolo = helyezesek.MaxBy(h => h.SportolokSzama);
            Console.WriteLine($"Helyezés: {legtobbSportolo.ElertHely}");
            Console.WriteLine($"Sportág: {legtobbSportolo.Sportag}");
            Console.WriteLine($"Versenyzám: {legtobbSportolo.Versenyszam}");
            Console.WriteLine($"Sportolók száma: {legtobbSportolo.SportolokSzama}");

        }
    }
}