using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace k163717_Q1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }

    [Serializable]
    public class Patient
    {
        [XmlAttribute("name")]
        public String name;

        [XmlAttribute(DataType = "date")]
        public DateTime DOB;

        [XmlAttribute("gender")]
        public String gender;

        [XmlAttribute("email")]
        public String email;

        public int bpm;

        [XmlIgnore]
        public DateTime time;

        [XmlElement("time")]
        public string SomeDateString
        {
            get { return this.time.ToString("HH:mm:ss"); }
            set { this.time = DateTime.Parse(value); }
        }

        public int confidence;

        public Patient()
        {

        }

        public Patient(String name, DateTime DOB, String gender, String email, int bpm, DateTime time)
        {
            this.name = name;
            this.DOB = DOB;
            this.gender = gender;
            this.email = email;
            this.bpm = bpm;
            this.time = time;
            confidence = 0;
        }
    }

    public class Patients
    {
        [XmlElement]
        public List<Patient> Patient;

        public Patients()
        {
            Patient = new List<k163717_Q1.Patient>();
        }
    }

}
