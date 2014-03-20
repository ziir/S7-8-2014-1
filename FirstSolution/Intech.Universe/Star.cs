using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intech.Space
{
    class Star : SpaceItem
    {
        string _name;

        public Star(string name) : base()
        {
            _name = name;
            Console.WriteLine("New Star");
        }

        public override SpaceItem Nuke()
        {
            Console.WriteLine("PEW PEW PEW LAZER Star");
            return this;
        }
    }
}
