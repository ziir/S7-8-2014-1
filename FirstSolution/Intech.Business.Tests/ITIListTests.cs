using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using NUnit.Framework;
namespace Intech.Business.Tests
{
    [TestFixture]
    public class ITIListTests
    {
        [Test]
        public void Basics()
        {
            ITIList<int> myList = new ITIList<int>();
            ITIList<string> myList2 = new ITIList<string>();
            var myList3 = new ITIList<ITIList<string>>();
        }

        [Test]
        public void BulkAddingAndRemoving()
        {
            // Arrange
            int[] bootstrappedItems = new int[] { 2, 3, 4, 99, 1054844884, 848, 784, 254, 1666666666, 47 };

            // Act
            var myBoostrappedList = new ITIList<int>(bootstrappedItems);

            // Assert
            Assert.That(myBoostrappedList.Count, Is.EqualTo(10));

            myBoostrappedList.Add(69);
            myBoostrappedList.Remove(bootstrappedItems);
            Assert.That(myBoostrappedList.Count, Is.EqualTo(1));
        }

        [Test]
        public void AddingItems()
        {
            // Arrange
            ITIList<int> myList = new ITIList<int>();
            Assert.That( myList.Count, Is.EqualTo( 0 ) );
            // Act
            myList.Add( 25 );
            // Assert
            Assert.That( myList.Count, Is.EqualTo( 1 ) );
            Assert.That( myList[0], Is.InstanceOf( typeof( int ) ) );
            Assert.That( myList[0], Is.EqualTo( 25 ) );
            myList.RemoveAt( 0 );
            Assert.That( myList.Count, Is.EqualTo( 0 ) );
        }

        [Test]
        public void RemovingItems()
        {
            // Arrange
            ITIList<string> myList = new ITIList<string>();
            Assert.That(myList.Count, Is.EqualTo(0));
            var itemToAdd = "En voiture Simone!";
            
            // Act
            myList.Add(itemToAdd);

            // Assert
            Assert.That(myList.Count, Is.EqualTo(1));
            Assert.That(myList[0], Is.InstanceOf(typeof(string)));
            Assert.That(myList[0], Is.EqualTo(itemToAdd));
            Stopwatch time = Stopwatch.StartNew();
            myList.RemoveUsingIndexOf(itemToAdd);
            time.Stop();
            Console.WriteLine(time.Elapsed);
            Assert.That(myList.Count, Is.EqualTo(0));

            myList.Add(itemToAdd);
            Assert.That(myList.Count, Is.EqualTo(1));
            System.Diagnostics.Stopwatch time2 = Stopwatch.StartNew();
            myList.Remove(itemToAdd);
            time2.Stop();
            Console.WriteLine(time2.Elapsed);
            Assert.That(myList.Count, Is.EqualTo(0));

            Assert.That(time.Elapsed, Is.LessThanOrEqualTo(time2.Elapsed));
        }

    }
}
