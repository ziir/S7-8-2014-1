using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Intech.Business.Tests
{
    [TestFixture]
    public class ITIDictionaryTests
    {

        class StringInsensitive : IDicStrat<string>
        {
            public bool IsItEqual( string key1, string key2 )
            {
                return StringComparer.OrdinalIgnoreCase.Equals( key1, key2 );
            }

            public int ComputeHashCode( string key )
            {
                return StringComparer.OrdinalIgnoreCase.GetHashCode( key );
            }
        }

        [Test]
        public void OurDictionaryIsNotPerfect()
        {
            IDicStrat<string> caseInsensitiveStrat = new StringInsensitive();
            ITIDictionary<string,int> db = new ITIDictionary<string,int>( caseInsensitiveStrat );

            db.Add( "Paul", 45456 );
            Assert.That( db["Paul"] == 45456 );
            
            Assert.That( db["paul"] == 45456 );


        }


    }
}
