namespace k163717_Q4
{
    sealed class DynamicArray<T>
    {
        private int Size;
        private int Capacity;
        private T[] ArrayReference;

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

    }
}
