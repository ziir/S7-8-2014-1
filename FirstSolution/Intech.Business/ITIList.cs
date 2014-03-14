using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intech.Business
{ 
    public class ITIList<T>
    {
        T[] _array;
        int _count;

        public ITIList()
        {
            _array = new T[8];
        }

        public int Count
        {
            get { return _count; }
        }

        public void Add( T value )
        {
            if( _array.Length == _count )
            {
                var newOne = new T[ _array.Length * 2 ];
                Array.Copy( _array, newOne, _array.Length );
                _array = newOne;
            }
            _array[_count++] = value;
        }

        public T this[int i]
        {
            get 
            {
                if( i >= _count ) throw new IndexOutOfRangeException();
                return _array[i]; 
            }
            set 
            {
                if( i >= _count ) throw new IndexOutOfRangeException();
                _array[i] = value;
            }
        }

        public void RemoveAt( int i )
        {
            if( i < 0 || i >= _count ) throw new IndexOutOfRangeException();
            Array.Copy( _array, i + 1, _array, i, _count - (i+1) );
            _array[--_count] = default( T );
        }
    }
}
