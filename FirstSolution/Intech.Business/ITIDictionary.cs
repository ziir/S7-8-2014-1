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
        Bucket[] _buckets;

        class Bucket
        {
            public readonly TKey Key;
            public TValue Value;
            public Bucket Next;

            public Bucket( TKey key, TValue v, Bucket next )
            {
                Key = key;
                Value = v;
                Next = next;
            }
        }

        public ITIDictionary()
        {
            _buckets = new Bucket[11];
        }

        public int Count
        {
            get { return _count; }
        }

        public void Add( TKey key, TValue value )
        {
            AddOrReplace( key, value, true );
        }

        void AddOrReplace( TKey key, TValue value, bool add )
        {
            int h = key.GetHashCode();
            int slot = Math.Abs( h % _buckets.Length );
            Bucket b = _buckets[slot];
            if( b == null )
            {
                _buckets[slot] = new Bucket( key, value, null );
            }
            else
            {
                do
                {
                    if( EqualityComparer<TKey>.Default.Equals( b.Key, key ) )
                    {
                        if( add ) throw new InvalidOperationException( "Dans ta face." );
                        b.Value = value;
                        return;
                    }
                    b = b.Next;
                }
                while( b != null );
                ++_count;
                b = new Bucket( key, value, _buckets[slot] );
                _buckets[slot] = b;
            }
        }

        public bool TryGetValue( TKey key, out TValue value )
        {
            int h = key.GetHashCode();
            int slot = Math.Abs( h % _buckets.Length );
            Bucket b = _buckets[slot];
            while( b != null )
            {
                if( EqualityComparer<TKey>.Default.Equals( b.Key, key ) )
                {
                    value = b.Value;
                    return true;
                }
                b = b.Next;
            }
            value = default( TValue );
            return false;
        }

        /// <summary>
        /// Gets the value based on a key.
        /// If the key does not exist, an exception is thrown!!!!!!
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public TValue this[TKey key]
        {
            get 
            {
                TValue v;
                if( !TryGetValue( key, out v ) )
                {
                    throw new KeyNotFoundException();
                }
                return v; 
            }
            set
            {
                // Add or replace the value for the given key.
                AddOrReplace( key, value, false );
            }
        }

    }
}
