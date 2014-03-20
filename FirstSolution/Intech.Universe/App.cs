using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intech.Space
{
    class App
    {
        static void Main(string[] args)
        {
            Universe myUniverse = new Universe();

            // Galaxy
            Galaxy secondGalaxy = new Galaxy("Cigar Galaxy");
            Planet planet1 = new Planet("");
            Star star1 = new Star("");
            // Add to Galaxy
            secondGalaxy.AddSpaceItem(planet1);
            secondGalaxy.AddSpaceItem(star1);


            // Galaxy 2
            Galaxy firstGalaxy = new Galaxy("Milky Way");
            Planet firstPlanet = new Planet("Earth");
            Star firstStar = new Star("Sun");
            // Add to Galaxy
            firstGalaxy.AddSpaceItem(firstPlanet);
            firstGalaxy.AddSpaceItem(firstStar);


            // Space Item
            Planet secondPlanet = new Planet("pirouette");
            Star secondStar = new Star("cacahuete");

            // Add to Univer
            myUniverse.Add(firstGalaxy);
            myUniverse.Add(secondGalaxy);
            myUniverse.Add(secondPlanet);
            myUniverse.Add(secondStar);

            myUniverse.Destroy();

        }
    }
}
