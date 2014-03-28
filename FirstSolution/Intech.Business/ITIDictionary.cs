using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intech.Business
{
    public class ITIDictionary<TKey,TValue>
    {
        int _count;

        public int Count
        {
            get { return _count; }
        }

        public void Add( TKey key, TValue value )
        {

        }

        public bool TryGetValue( TKey key, out TValue value )
        {
        }

        /// <summary>
        /// Gets the value based on a key.
        /// If the key does not exist, an exception is thrown!!!!!!
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public TValue this[TKey key]
        {
            get { return default(T); }
            set
            {
                // Add or replace the value for the given key.
            }
        }

    }
}
