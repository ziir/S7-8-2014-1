using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intech.Business;

namespace Intech.Space
{
    public class Universe
    {
        ITIList<Galaxy> _galaxies = new ITIList<Galaxy>();
        ITIList<SpaceItem> _spaceItems = new ITIList<SpaceItem>();

        public ITIList<SpaceItem> SpaceItems
        {
            get { return _spaceItems; }
        }

        public ITIList<Galaxy> Galaxies
        {
            get { return _galaxies; }
        }

        public Universe()
        {
            Console.WriteLine("New Universe");
        }

        public void BigBang()
        {

        }

        public void Add(SpaceItem spaceItemToAdd)
        {
            _spaceItems.Add(spaceItemToAdd);
        }

        public void Add(Galaxy galaxyToAdd)
        {
            _galaxies.Add(galaxyToAdd);
        }

        public void Remove(SpaceItem spaceItemToRemove)
        {
            spaceItemToRemove.Nuke();
        }

        public void Remove(Galaxy galaxyToRemove)
        {
            _galaxies.Remove(galaxyToRemove.Nuke());
        }

        public void Destroy()
        {
            var method = "Nuke";
            _spaceItems.ForEach(method);
            _galaxies.ForEach(method);
        }

        public void show()
        {
            // use the array list to display all object
        }


    }

}
