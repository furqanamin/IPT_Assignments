namespace k163717_Q1
{
    sealed class DynamicIntArray
    {
        private int Size;
        private int Capacity;
        private int[] ArrayReference;

        public int getSize()
        {
            return Size;
        }
        public DynamicIntArray(int ProvidedCapacity = 10)
        {
            Size = 0;
            this.Capacity = ProvidedCapacity;
            AllocateMemory();
        }

        private void AllocateMemory()
        {
            if (ArrayReference == null)
            {
                ArrayReference = new int[Capacity];
            }
            else
            {
                int[] NewArrayReference = new int[Capacity];
                for (int i = 0; i < Size; i++)
                {
                    NewArrayReference[i] = ArrayReference[i];
                }
                ArrayReference = NewArrayReference;
            }
        }

        public void Add(int Element)
        {
            if (Size == Capacity)
            {
                Capacity *= 2;
                AllocateMemory();
            }
            ArrayReference[Size] = Element;
            Size++;
        }

        public int Get(int IndexValue)
        {
            if (IndexValue < Size)
                return ArrayReference[IndexValue];
            return -1;
        }

        public int IndexOf(int Element)
        {
            for (int i = 0; i < Size; i++)
            {
                if (ArrayReference[i] == Element)
                    return i;
            }
            return -1;
        }



    }
}
