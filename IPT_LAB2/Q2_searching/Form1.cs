using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace Q2_searching
{
    public partial class Form1 : Form
    {
        int length = 1000000;
        int[] randArray = new int[1000000];
        int threadsize;
        Random rand = new Random();
        List<Int64> positions = new List<Int64>();

        public Form1()
        {
            InitializeComponent();

            for (int i = 0; i < length; i++)
            {
                randArray[i] = rand.Next(0, length);
            }

            label4.Text = "";
            label5.Text = "";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private bool is_number_valid(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, "^[0-9]*$"))            
                return true;

            textBox2.Text = "Please Only Enter Numbers";
            return false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (is_number_valid(sender, e))
            {
                int length = 1000000;
                int ElementToSearch = Convert.ToInt32(textBox1.Text);
                bool flag = false;

                Stopwatch sw = new Stopwatch();
                sw.Start();
                for (int i = 0; i < length; i++)
                {
                    if (randArray[i] == ElementToSearch)
                    {
                        sw.Stop();
                        textBox2.Text = Convert.ToString(sw.Elapsed);
                        label4.Text = "at index " + Convert.ToString(i);
                        flag = true;
                    }
                }
                if (!flag)
                {
                    textBox2.Text = "Not Found";
                    label4.Text = "";
                    textBox3.Text = "Not Found";
                    label5.Text = "";
                }

                if (flag)
                {
                    int num_threads = 5;
                    ParameterizedThreadStart parameterizedThread = new ParameterizedThreadStart(threadsearching);
                    Thread[] threads = new Thread[num_threads];
                    sw.Reset();
                    sw.Start();
                    for (int i = 0; i < num_threads; i++)
                    {
                        threads[i] = new Thread(parameterizedThread);
                        object threadsearch = new ThreadSearch(i, i * threadsize, (i * threadsize) + threadsize, ElementToSearch);
                        threads[i].Start(threadsearch);
                    }
                    sw.Stop();
                    for (int i = 0; i < num_threads; i++)
                    {
                        threads[i].Join();
                    }

                    textBox3.Text = Convert.ToString(sw.Elapsed);
                    label5.Text = label4.Text;

                }

            }
        }

        public void threadsearching(object param)
        {
            ThreadSearch ts = (ThreadSearch)param;
            for (int i = ts.startIndex; i < ts.endIndex; i++)
            {
                if (randArray[i] == ts.key)
                    positions.Add(i);
            }
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }

    class ThreadSearch
    {
        public int threadIndex;
        public int startIndex;
        public int endIndex;
        public int key;

        public ThreadSearch(int threadIndex, int startIndex, int endIndex, int key)
        {
            this.threadIndex = threadIndex;
            this.startIndex = startIndex;
            this.endIndex = endIndex;
            this.key = key;
        }

        public new string ToString => threadIndex + " " + startIndex + " " + endIndex + " " + key;
    }


}
