using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intech.Space
{
    class Planet : SpaceItem
    {
        string _name;

        public Planet(string name) : base()
        {
            _name = name;
            Console.WriteLine("New Planet");
        }

        public override SpaceItem Nuke()
        {
            Console.WriteLine("PEW PEW PEW LAZER Planet");
            return this;
        }

    }
}
