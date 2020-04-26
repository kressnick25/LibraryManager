using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Text;
using System.Threading;

namespace LibraryManager.DataStructures
{
    /*
     * Represents a collection of registered members.
     */
    class List<T> : IEnumerable<T>
    {
        const int DEFAULT_SIZE = 10;

        private T[] values;
        private int actualSize;
        // size of list
        public int Length
        {
            get { return actualSize; }
        }
        public List()
        {
            values = new T[DEFAULT_SIZE];
            actualSize = 0;
        }

        public List(T[] initialValues)
        {
            values = new T[initialValues.Length + DEFAULT_SIZE];
            actualSize = initialValues.Length;
            for (int i = 0; i < actualSize; i++)
            {
                values[i] = initialValues[i];
            }
        }

        // TODO check this works
        // increase size
        private void increaseSize()
        {
            //Array.Resize<Member>(ref members, this.Length + 10);
            T[] resizedArray = new T[this.Length + 10];
            for (int i = 0; i < actualSize; i++)
            {
                resizedArray[i] = values[i];
            }
            values = resizedArray;
        }


        // returns index of provided object, or -1 if not found
        public int IndexOf(T key)
        {
            for (int i = 0; i < actualSize; i++)
            {
                if (values[i].Equals(key))
                    return i;
            }

            return -1;
        }

        public void Add(T newValue)
        {
            if (values.Length - actualSize <= 5)
            {
                this.increaseSize();
            }
            // insert at last position
            values[actualSize++] = newValue;
        }

        // get a member by name
        public T Get(int index)
        {
            if (index >= this.actualSize || index < 0)
                throw new IndexOutOfRangeException();

            return values[index];
        }

        public void Remove(int index)
        {
            if (index >= actualSize || index < 0)
                throw new IndexOutOfRangeException();

            values[index] = default(T);
            actualSize--;
        }

        public T[] ToArray()
        {
            T[] trimmed = new T[actualSize];
            for (int i = 0; i < actualSize; i++)
            {
                trimmed[i] = values[i];
            }

            return trimmed;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < actualSize; i++)
            {
                yield return values[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
