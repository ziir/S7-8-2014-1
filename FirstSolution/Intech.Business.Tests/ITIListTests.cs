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
            ITIList<object> list = new ITIList<object>();
            list.Add(new Object());
            Assert.That( list.Count, Is.EqualTo(1) );
            list.Remove(new Object());
            Assert.That( list.Count, Is.EqualTo(1) );


            ITIList<int> intList = new ITIList<int>();
            intList.Add(36);
            Assert.That(intList.Count, Is.EqualTo(1));
            intList.Remove(36);
            Assert.That(intList.Count, Is.EqualTo(0));

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
            Assert.That(myList[0], Is.EqualTo(itemToAdd));
            myList.RemoveUsingIndexOf(itemToAdd);
            Assert.That(myList.Count, Is.EqualTo(0));
        }

    }
}
