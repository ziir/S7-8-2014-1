using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intech.Business;

namespace Intech.Space
{
    public class Galaxy
    {
        string _name;
        ITIList<SpaceItem> _spaceItems = new ITIList<SpaceItem>();

        public Galaxy(string galaxyName)
        {
            _name = galaxyName;
        }

        public string Name 
        {
            get 
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }

        public ITIList<SpaceItem> SpaceItems 
        {
            get
            {
                return _spaceItems;
            }
        }

        public int AddSpaceItem(SpaceItem spaceItemToAdd)
        {
            _spaceItems.Add(spaceItemToAdd);
            return 1;
        }

        public int RemoveSpaceItem(SpaceItem spaceItemToRemove)
        {
            _spaceItems.Remove(spaceItemToRemove);
            return 1;
        }

        public Galaxy Nuke()
        {
            _spaceItems.ForEach("Nuke");
            Console.WriteLine("PEW PEW PEW LAZER Galaxy");
            return this;
        }
        

    }
}
