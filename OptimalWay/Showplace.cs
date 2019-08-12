using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimalWay
{
    public class Showplace
    {
        private string name;
        private float timeToVisit;
        private int importance;

        public Showplace(string _name, float _timeToVisit, int _importance)
        {
            Name = _name;
            TimeToVisit = _timeToVisit;
            Importance = _importance;
        }

        public string Name { get => name; set => name = value; }
        public float TimeToVisit { get => timeToVisit; set => timeToVisit = value; }
        public int Importance { get => importance; set => importance = value; }
    }
}
