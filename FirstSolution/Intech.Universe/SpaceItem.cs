using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intech.Space
{
    public abstract class SpaceItem
    {
        string _id;

        public string Id
        {
            get
            {
                return _id;
            }
        }

        public SpaceItem()
        {
            _id = "izi";
        }

        public abstract SpaceItem Nuke();
    }
}
