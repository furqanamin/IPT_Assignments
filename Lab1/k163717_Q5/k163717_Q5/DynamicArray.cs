using System.Collections.Generic;
using System;
using System.Collections;

namespace k163717_Q5
{
    sealed class DynamicArray<T> : IList<T>
    {
        private int Size;
        private int Capacity;
        private T[] ArrayReference;

        public int Count => Size;

        public bool IsReadOnly => throw new NotImplementedException();

        public T this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int getSize()
        {
            return Size;
        }
        public DynamicArray(int ProvidedCapacity = 10)
        {
            Size = 0;
            this.Capacity = ProvidedCapacity;
            AllocateMemory();
        }

        private void AllocateMemory()
        {
            if (ArrayReference == null)
            {
                ArrayReference = new T[Capacity];
            }
            else
            {
                T[] NewArrayReference = new T[Capacity];
                for (int i = 0; i < Size; i++)
                {
                    NewArrayReference[i] = ArrayReference[i];
                }
                ArrayReference = NewArrayReference;
            }
        }

        public void Add(T Element)
        {
            if (Size == Capacity)
            {
                Capacity *= 2;
                AllocateMemory();
            }
            ArrayReference[Size] = Element;
            Size++;
        }

        public T Get(int IndexValue)
        {
            return ArrayReference[IndexValue];
        }

        public int IndexOf(T Element)
        {
            for (int i = 0; i < Size; i++)
            {
                if (ArrayReference[i].Equals(Element))
                    return i;
            }
            return -1;
        }

        public void Clear()
        {
            Size = 0;
        }

        public bool Contains ( T value )
        {
            for (int i = 0; i < Size; i++)
            {
                if (ArrayReference[i].Equals(value))
                    return true;
                return false;
            }
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            for (int i = 0; i < Size; i++)
            {
                array[i + arrayIndex] = ArrayReference[i];
            }
        }

        public void Insert(int index, T item)
        {
            T temp = ArrayReference[index];
            ArrayReference[index] = item;
            Add(temp);
        }

        public bool Remove(T item)
        {
            bool flag = false;
            for (int i = 0; i < Size; i++)
            {
                if (flag)
                {
                    ArrayReference[i - 1] = ArrayReference[i];
                }
                if (ArrayReference.Equals(item))
                    flag = true;
            }

            if (flag)
                Size--;

            return flag;
        }

        public void RemoveAt(int index)
        {
            for (int i = index+1 ; i < Size; i++)
            {
                ArrayReference[i - 1] = ArrayReference[i];
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        //public IEnumerator<T> GetEnumerator()
        //{

        //}

    }
}
