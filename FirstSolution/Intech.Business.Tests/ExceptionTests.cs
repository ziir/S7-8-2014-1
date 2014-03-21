using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Intech.Business.Tests
{
    [TestFixture]
    public class ExceptionTests
    {
        #region Simple Scenario: Exception basics.

        bool _bHasBeenCalled;

        void A()
        {
            throw new InvalidOperationException();
        }

        void B()
        {
            _bHasBeenCalled = true;
        }

        void C()
        {
            try
            {
                A();
                B();
            }
            catch( Exception ex )
            {
                // Log
                Debug.WriteLine( ex.Message );
                throw;
            }
        }


        [Test]
        public void SimpleScenario()
        {
            bool anExceptionHasBeenCaught = false;
            _bHasBeenCalled = false;
            try
            {
                C();
            }
            //
            // This prevents compilation since other catches are 
            // more specific.
            //
            //catch( Exception ex )
            //{
            //}
            catch( ArgumentException ex )
            {
                //...
                Assert.Fail( "Never here!!" );
            }
            catch( InvalidOperationException ex )
            {
                Assert.That( ex, Is.Not.Null );
                anExceptionHasBeenCaught = true;
            }
            catch( Exception ex )
            {
                Assert.Fail( "Never here!!" );
            }
            finally
            {
                Assert.That( anExceptionHasBeenCaught, Is.True );
                Assert.That( _bHasBeenCalled, Is.False );
            }
        }

        #endregion

        [Test]
        public void SmallPerfTest()
        {
            Console.WriteLine( "Not an integer:" );
            TestPerformance( "with something" );
            Console.WriteLine( "With an integer:" );
            TestPerformance( "3712" );
        }

        private static void TestPerformance( string toParse )
        {
            Stopwatch w = new Stopwatch();

            long withException = ParseWithExceptions( w, toParse );

            w.Restart();
            for( int i = 0; i < 100; ++i )
            {
                int result;
                if( Int32.TryParse( toParse, out result ) )
                {
                    // OK
                }
            }
            w.Stop();
            long withoutException = w.ElapsedTicks;

            Console.WriteLine( "With: {0}, Without: {1}, Ratio: {2}",
                withException,
                withoutException,
                withException / withoutException );
        }

        static long ParseWithExceptions( Stopwatch w, string toParse )
        {
            w.Start();
            for( int i = 0; i < 100; ++i )
            {
                try
                {
                    int result = Int32.Parse( toParse );
                    // OK
                }
                catch { }
            }
            w.Stop();
            long withException = w.ElapsedTicks;
            return withException;
        }

        string BuildNaive( string pattern, int count )
        {
            string s = String.Empty;
            while( --count > 0 )
            {
                s += pattern;
            }
            return s;
        }

        string BuildBetter( string pattern, int count )
        {
            StringBuilder b = new StringBuilder();
            while( --count > 0 )
            {
                b.Append( pattern );
            }
            return b.ToString();
        }

        [Test]
        public void Complexity()
        {
            int testCount = 100;
            int count = 10000;
            string pattern = "Toto";

            Stopwatch w = new Stopwatch();

            long naiveTicks;
            w.Start();
            for( int i = 0; i < testCount; ++i )
            {
                BuildNaive( pattern, count );
            }
            w.Stop();
            naiveTicks = w.ElapsedTicks;

            long betterTicks;
            w.Restart();
            for( int i = 0; i < testCount; ++i )
            {
                BuildBetter( pattern, count );
            }
            w.Stop();
            betterTicks = w.ElapsedTicks;

            Console.WriteLine( "Naive: {0}, Better: {1}, Ratio: {2}",
                naiveTicks,
                betterTicks,
                naiveTicks / betterTicks );
        }

    }
}
