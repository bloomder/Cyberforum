using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawPlanet_Win
{
    public class Planet
    {
        public string Name;
        public int Radius;
        public double Alpha;
        public int Pos_X = 0;
        public int Pos_Y = 0;
        public Planet(string a, int b, double c)
        {
            Name = a;
            Radius = b;
            Alpha = c;
        }
    }
}
