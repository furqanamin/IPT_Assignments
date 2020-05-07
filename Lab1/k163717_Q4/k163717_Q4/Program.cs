using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k163717_Q4
{
    class Program
    {
        static void Main(string[] args)
        {
            DynamicArray<int> x = new DynamicArray<int>();
            x.Add(100);
            int y = x.Get(0);

            DynamicArray<string> z = new DynamicArray<string>();
            z.Add("Hello");
            Console.WriteLine("{0}", z.Get(0)); 

            Console.WriteLine("Press Any key to continue");
            Console.ReadKey();

        }
    }
}
