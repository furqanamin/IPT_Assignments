using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace k163717_Q1
{
    class Program
    {
        static void CreateInputFile()
        {
            Random RandomGenerator = new Random();
            if(!File.Exists("Q1Input.txt"))
            {
                using (StreamWriter file = new StreamWriter("Q1Input.txt"))
                {
                    for (int i = 1; i <= 24; i++)
                    {
                        file.WriteLine("Z{0},{1}", i, RandomGenerator.Next(0,2));
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            //creates input file if there is no input file in the bin directory
            CreateInputFile();

            byte[] arr = new byte[24];

            using (StreamReader r = new StreamReader("Q1Input.txt"))
            {
                string line;
                while((line = r.ReadLine()) != null)
                {
                    string[] strings = line.Split(',');
                    int IndexFromFile = Convert.ToInt32(strings[0].Trim('Z'));
                    arr[IndexFromFile - 1] = Convert.ToByte(strings[1]);
                }
            }

            long m2 = GC.GetTotalMemory(true);
            Console.WriteLine("Memory occupied for storing the info: {0} Bytes", arr.Length * sizeof(byte));

            Console.WriteLine("Following is the info: ");

            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine("Z{0}, {1}", i + 1, arr[i]);
            }

            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
    }
}
