using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.DataStructures
{
    class HashMap
    {
        Object[] table; // table to store data
        public HashMap(int size = 10)
        {
            table = new Object[10];
        }

        private int hash(string key)
        {
            // TODO replace with own GetHashCode() implementation
            return key.GetHashCode() % table.Length;
        }

        // Add an item to the Set. Throws ArgumentExeption if duplicate
        public void Add(string key, WithKey value)
        {
            if (KeyExists(key))
                throw new ArgumentException($"Key [{key}] already exists in HashMap");

            int hashKey = hash(key);
            if (table[hashKey] != null)
            {
                // Hash collision has occurred
                // convert table cell to list
                WithKey temp = (WithKey)table[hashKey];
                LinkedList tempList = new LinkedList();
                tempList.Insert(temp);
                tempList.Insert(value);
                table[hashKey] = tempList;
            }
            else
            {
                table[hashKey] = value;
            }
        }

        // Remove an item from the set using a keystring
        public void Remove(string key)
        {
            int hashKey = hash(key);
            if (table[hashKey] == null)
                return;
            if (table[hashKey] is LinkedList)
            {
                ((LinkedList)table[hashKey]).Delete(key);
                return;
            }
            if (((WithKey)table[hashKey]).Key == key)
                table[hashKey] = null;
        }

        // Get an item from the set using a keystring
        public WithKey GetItem(string key)
        {
            int hashKey = hash(key);
            if (table[hashKey] == null)
                throw new ArgumentException();
            if (table[hashKey] is WithKey)
            {
                WithKey temp = (WithKey)table[hashKey];
                if (temp.Key == key)
                {
                    return temp;
                }
            }
            if (table[hashKey] is LinkedList)
            {
                LinkedList tempList = (LinkedList)table[hashKey];
                return tempList.Get(key);
            }
            throw new ArgumentException();
        }

        // Does deep comparison to check if key exists in table
        public bool KeyExists(string key)
        {
            int hashKey = hash(key);
            if (table[hashKey] == null)
                return false;
            if (table[hashKey] is WithKey)
            {
                // verify key matches and not a hash collision
                WithKey temp = (WithKey)table[hashKey];
                if (temp.Key == key)
                    return true;
            }
            // check if not a chain stored at index
            if (table[hashKey] is LinkedList)
            {
                // cast object to correct type
                LinkedList list = (LinkedList)table[hashKey];
                try
                {
                    list.Get(key);
                    // key does exist
                    return true;
                } 
                catch (ArgumentException e)
                {
                    return false;
                }
            }
            return true;
        }

        // Returns the set in string form: {item1, item2, ...itemN}
        public string toString()
        {
            throw new NotImplementedException();
        }

        public int Size()
        {
            int c = 0;
            for (int i=0; i < table.Length; i++)
            {
                if (table[i] != null)
                    c++;
            }
            return c;
        }
    }
}
