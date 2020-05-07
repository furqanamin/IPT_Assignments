using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace k163717_Q1
{
    public partial class Form1 : Form
    {
        private Patients subReq = new Patients();
        private string lastClicked;
        public Form1()
        {
            InitializeComponent();
            label6.Text = "";
            label8.Text = "";
            label9.Text = "";
            label10.Text = "";
            lastClicked = "";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label6.Text = "";
            label8.Text = "";
            label9.Text = "";
            label10.Text = "";

            bool flag = true;

            if (!(textBox1.TextLength > 0 && System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, "^[a-zA-Z ]*$")))
            {
                label6.Text = "Please Enter a Valid Name";
                flag = false;
            }

            if (!(radioButton1.Checked || radioButton2.Checked))
            {
                label8.Text = "Please Select a Gender";
                flag = false;
            }

            if (!(textBox2.TextLength > 0 && System.Text.RegularExpressions.Regex.IsMatch(textBox2.Text, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")))
            {
                label9.Text = "Please Enter a Valid Email";
                flag = false;
            }

            short num;
            if(Int16.TryParse(textBox3.Text, out num))
            {
                if (num < 27 || num > 480)
                {
                    label10.Text = "Please Enter a Valid BPM";
                    flag = false;
                }
            }
            else
            {
                label10.Text = "Please Enter a Valid BPM";
                flag = false;
            }

            if(lastClicked == DateTime.Now.ToString("HH:mm:ss"))
            {
                MessageBox.Show("Please Wait Before Adding Another Entry");
                flag = false;
            }
            else
            {
                lastClicked = DateTime.Now.ToString("HH:mm:ss");
            }
            


            if(flag)
            {
                subReq.Patient.Add(new Patient(textBox1.Text, dateTimePicker1.Value.Date, radioButton1.Checked ? radioButton1.Text : radioButton2.Text, textBox2.Text, num, DateTime.Now));
            }

            XmlSerializer xsSubmit = new XmlSerializer(typeof(Patients));
            var xml = "";

            using (var sww = new StringWriter())
            {
                using (XmlTextWriter writer = new XmlTextWriter(sww) { Formatting = Formatting.Indented })
                {
                    xsSubmit.Serialize(writer, subReq);
                    xml = sww.ToString(); // Your XML
                    File.WriteAllText("PatientDetails" + "_" + DateTime.Now.ToString("yyyy_MM_dd") + ".xml", xml);
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

    }
}
