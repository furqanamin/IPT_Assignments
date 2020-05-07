using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k163717_Q3
{
    class Program
    {
        //public void Adder(ICollection c)
        //{
        //    const int NumberOfElements = 1000000;
        //    Stopwatch sw = new Stopwatch();
        //    long sum = 0;
        //    sw.Start();
        //    for (int i = 0; i < NumberOfElements; i++)
        //    {
        //        sum += (int)c[i];
        //    }
        //    sw.Stop();
        //    Console.WriteLine("Time Elapsed in summing the Array: {0}ms", sw.ElapsedMilliseconds);
        //}

        static void Main(string[] args)
        {
            Random r = new Random();
            int random_value;
            const int NumberOfElements = 1000000;

            // Defininf all the different Data Structures
            int[] myArray = new int[NumberOfElements];
            ArrayList myArrayList = new ArrayList();
            List<int> myList = new List<int>();
            DynamicIntArray myDynamicArray = new DynamicIntArray();

            // Populating all the different data structures with 1M random values
            for (int i = 0; i < NumberOfElements; i++)
            {
                random_value = r.Next(0, NumberOfElements);
                myArray[i] = random_value;
                myArrayList.Add(random_value);
                myList.Add(random_value);
                myDynamicArray.Add(random_value);
            }

            //Creating StopWatch object for performance measuring
            Stopwatch sw = new Stopwatch();

            long sum = 0;

            sw.Start();
            // Sum of Array
            for (int i = 0; i < NumberOfElements; i++)
            {
                sum += myArray[i];
            }
            sw.Stop();

            Console.WriteLine("Time Elapsed in summing the Array: {0}ms", sw.ElapsedMilliseconds);


            sum = 0;
            sw.Reset();
            sw.Start();
            //Sum of ArrayList
            for (int i = 0; i < NumberOfElements; i++)
            {
                sum += (int)myArrayList[i];
            }
            sw.Stop();
            Console.WriteLine("Time Elapsed in summing the ArrayList: {0}ms", sw.ElapsedMilliseconds);

            sum = 0;
            sw.Reset();
            sw.Start();
            //Sum of List
            for (int i = 0; i < NumberOfElements; i++)
            {
                sum += myList[i];
            }
            sw.Stop();
            Console.WriteLine("Time Elapsed in summing the List: {0}ms", sw.ElapsedMilliseconds);

            sum = 0;
            sw.Reset();
            sw.Start();
            //Sum of DynamicArray
            for (int i = 0; i < NumberOfElements; i++)
            {
                sum += myDynamicArray.Get(i);
            }
            sw.Stop();
            Console.WriteLine("Time Elapsed in summing the DynamicArray: {0}ms", sw.ElapsedMilliseconds);

            //Searching on different Data Structures
            Console.WriteLine("*******************************************");

            int[] random_array = new int[5];

            for (int i = 0; i < 5; i++)
            {
                random_array[i] = r.Next(1, NumberOfElements);
            }

            //Searching in Array
            sw.Reset();
            sw.Start();
            foreach (int i in random_array)
            {
                for (int j = 0; j < NumberOfElements; j++)
                {
                    if (myArray[j] == i)
                        break;
                }
            }
            sw.Stop();
            Console.WriteLine("Time Elapsed in searching the Array: {0}ms", sw.ElapsedMilliseconds);

            //Searching in ArrayList
            sw.Reset();
            sw.Start();
            foreach(int i in random_array)
            {
                myArrayList.IndexOf(i);
            }
            sw.Stop();
            Console.WriteLine("Time Elapsed in searching the ArrayList: {0}ms", sw.ElapsedMilliseconds);


            //Searching in List
            sw.Reset();
            sw.Start();
            foreach (int i in random_array)
            {
                myList.IndexOf(i);
            }
            sw.Stop();
            Console.WriteLine("Time Elapsed in searching the List: {0}ms", sw.ElapsedMilliseconds);



            //Searching in DynamicArray
            sw.Reset();
            sw.Start();
            foreach (int i in random_array)
            {
                myDynamicArray.IndexOf(i);
            }
            sw.Stop();
            Console.WriteLine("Time Elapsed in searching the DynamicArray: {0}ms", sw.ElapsedMilliseconds);

            Console.WriteLine("Press Any key to continue");
            Console.ReadKey();
        }

    }
}
