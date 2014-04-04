using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Intech.Business.Tests
{
    [TestFixture]
    public class StartingWithLinq
    {
        static IEnumerable<int> Numbers( int start, int count )
        {
            while( --count >= 0 ) yield return start++;
        }

        static IEnumerable<int> Sawtooth( int width )
        {
            for(;;) for( int i = 0; i < width; ++i ) yield return i;
        }

        static IEnumerable<int> RandomNumbers( int seed )
        {
            var r = new Random( seed );
            for(;;) yield return r.Next();
        }

        [Test]
        public void SimpleRanges()
        {
            CollectionAssert.AreEqual( Numbers( 0, 5 ), new[] { 0, 1, 2, 3, 4 } );

            int notTooMuch = 5454;
            foreach( var i in Sawtooth( 12 ) )
            {
                Console.WriteLine( i );
                if( --notTooMuch == 0 ) break;
            }


        }

    }
}
