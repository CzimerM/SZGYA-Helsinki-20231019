using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZGYA_Helsinki_20231019
{
    class Helyezes
    {
        private static Dictionary<int,int> pontTabla = new Dictionary<int, int>() {
            {1, 7},
            {2, 5},
            {3, 4},
            {4, 3},
            {5, 2},
            {6, 1}
        };

        public int ElertHely { get; set; }
        public int SportolokSzama { get; set; }
        public string Sportag { get; set; }
        public string Versenyszam { get; set; }

        public int OlimpiaiPont
        {
            get
            {
                if (ElertHely > 6) return 0;
                else return Helyezes.pontTabla[ElertHely];
            }
        }

        public Helyezes(string sor)
        {
            string[] adatok = sor.Split(' ');
            this.ElertHely = int.Parse(adatok[0]);
            this.SportolokSzama = int.Parse(adatok[1]);
            this.Sportag = adatok[2];
            this.Versenyszam = adatok[3];
        }

        public override string ToString()
        {
            return $"{this.ElertHely} {this.SportolokSzama} {this.OlimpiaiPont} {this.Sportag} {this.Versenyszam}";
        }
    }
}
