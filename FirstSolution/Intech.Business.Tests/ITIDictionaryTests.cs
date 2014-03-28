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
        [Test]
        public void OurDictionaryIsNotPerfect()
        {
            ITIDictionary<string,int> db = new ITIDictionary<string,int>();

            db.Add( "Paul", 45456 );
            Assert.That( db["Paul"] == 45456 );
            
            Assert.That( db["paul"] == 45456 );


        }


    }
}
