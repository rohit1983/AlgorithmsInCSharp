using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsInCSharp.ArrayBased
{
    public class HashTable<TKey,TValue> where TKey : IComparable
    {
        private int Size = 0;
        private int tableSize = 16;
        private TKey[] Keys;
        private TValue[] Values;

        public HashTable()
        {
            Keys = new TKey[tableSize];
            Values = new TValue[tableSize];
        }

        public HashTable(int capacity)
        {
            Keys = new TKey[capacity];
            Values = new TValue[capacity];
            tableSize = capacity;
        }

        private int GetHash(TKey key)
        {
            return (key.GetHashCode() & 0x7fffffff) % tableSize;
        }

        public TValue Get(TKey key)
        {
            int index = GetHash(key);
            for(int i=index;Keys[i] != null;i = (i+1)%tableSize)
            {
                if(key.CompareTo(Keys[i]) == 0)
                {
                    return Values[i];
                }
            }
            throw new InvalidOperationException("Key Not Found");
        }

        public bool Contains(TKey key)
        {
            for(int i = GetHash(key);Keys[i] != null;i = (i+1)%tableSize)
            {
                if(key.CompareTo(Keys[i]) == 0)
                {
                    return true;
                }
            }
            return false;
        }

        public void Put(TKey key,TValue value)
        {
            if(Size >= tableSize/2)
            {
                Resize(tableSize * 2);
            }
            int index;

            for(index= GetHash(key); Keys[index] != null;index = (index+1)%31)
            {
                if(key.CompareTo(Keys[index]) == 0)
                {
                    Values[index] = value;
                    return;
                }
            }
            Keys[index] = key;
            Values[index] = value;
            Size++;

        }

        public void Delete(TKey key)
        {
            if(!Contains(key))
            {
                throw new InvalidOperationException("Key Not Found");
            }
            int index = GetHash(key);
            while(key.CompareTo(Keys[index]) != 0)
            {
                index = (index + 1) % tableSize;
            }
            //TODO handle below for primitive types
            Keys[index] = default(TKey);
            Values[index] = default(TValue);

            index = (index + 1) % tableSize;
            while(Keys[index] != null)
            {
                var currentKey = Keys[index];
                var currentValue = Values[index];
                Keys[index] = default(TKey);
                Values[index] = default(TValue);
                Size--;
                Put(currentKey, currentValue);
                index = (index + 1) % tableSize;
            }
            Size--;     
            if(Size > 0 && Size <= tableSize/8)
            {
                Resize(tableSize / 2);
            }

        }

        private void Resize(int capacity)
        {
            HashTable<TKey, TValue> temp = new HashTable<TKey, TValue>(capacity);
            for (int i = 0;i < tableSize;i++)
            {
                if(Keys[i] != null)
                {
                    temp.Put(Keys[i], Values[i]);
                }
            }
            Keys = temp.Keys;
            Values = temp.Values;
            tableSize = temp.tableSize;
        }
    }
}
