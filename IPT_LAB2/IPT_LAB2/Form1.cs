using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IPT_LAB2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private bool is_number_valid(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, "^[0-9.]*$"))
                if (System.Text.RegularExpressions.Regex.IsMatch(textBox2.Text, "^[0-9.]*$"))
                    return true;

            textBox3.Text = "Please Only Enter Numbers";
            return false;
        }

        private void button_clicked(object sender, EventArgs e)
        {

        }

        private void add_clicked(object sender, EventArgs e)
        {
            if (is_number_valid(sender, e))
                textBox3.Text = Convert.ToString(Convert.ToDouble(textBox1.Text) + Convert.ToDouble(textBox2.Text));
        }

        private void sub_clicked(object sender, EventArgs e)
        {
            if (is_number_valid(sender, e))
                textBox3.Text = Convert.ToString(Convert.ToDouble(textBox1.Text) - Convert.ToDouble(textBox2.Text));
        }

        private void mul_clicked(object sender, EventArgs e)
        {
            if (is_number_valid(sender, e))
                textBox3.Text = Convert.ToString(Convert.ToDouble(textBox1.Text) * Convert.ToDouble(textBox2.Text));
        }

        private void div_clicked(object sender, EventArgs e)
        {
            if (is_number_valid(sender, e))
                textBox3.Text = Convert.ToString(Convert.ToDouble(textBox1.Text) / Convert.ToDouble(textBox2.Text));
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
