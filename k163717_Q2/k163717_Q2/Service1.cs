using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Timers;
using System.Xml.Linq;

namespace k163717_Q2
{
    public partial class Service1 : ServiceBase
    {
        Timer timer = new Timer();
        string read_path = ConfigurationManager.AppSettings["read_path"];
        string write_path = ConfigurationManager.AppSettings["write_path"];
        public Service1()
        {
            InitializeComponent();
        }
        
        public void OnDebug()
        {
            OnStart(null);
            //OnStop();
        }
        private void OnElapsedTime(object source, ElapsedEventArgs e)
        {
            string[] xml_files_in_dir = Directory.GetFiles(read_path, "*.xml");
            foreach (var xml_file_to_read in xml_files_in_dir)
            {
                WriteToFile(xml_file_to_read);

                var regex = new Regex(@"(\d\d\d\d_\d\d_\d\d)");
                var match = regex.Match(xml_file_to_read);
                string date_of_xml_gen = match.Groups[0].Value;

                XElement xdoc = XElement.Load(xml_file_to_read);

                //var lv1s = from lv1 in xdoc.Descendants("level1")
                //           select new
                //           {
                //               Header = lv1.Attribute("name").Value,
                //               Children = lv1.Descendants("level2")
                //           };

                //Loop through results
                //foreach (var lv1 in lv1s)
                //{
                //    result.AppendLine(lv1.Header);
                //    foreach (var lv2 in lv1.Children)
                //        result.AppendLine("     " + lv2.Attribute("name").Value);
                //}

                //foreach (var patient in xdoc.Descendants("Patient"))
                //{
                //    foreach (var attribute in patient.Attributes())
                //    {
                //        WriteToFile(attribute.Value);
                //    }
                //}

                var patients = (from ee in xdoc.Descendants("Patient").Attributes("name")
                                select ee).GroupBy(x => x.Value).Select(x => x.First().Value);

                foreach (var patient_to_process in patients)
                {
                    var patient_elements = from element in xdoc.Descendants("Patient") where element.Attribute("name").Value == patient_to_process select element;
                    var first_element_of_a_patient = patient_elements.First();

                    CreateUserDirectory(first_element_of_a_patient.Attribute("name").Value);
                    StorePatientProfile(first_element_of_a_patient.Attribute("name").Value, first_element_of_a_patient.Attribute("DOB").Value, first_element_of_a_patient.Attribute("gender").Value, first_element_of_a_patient.Attribute("email").Value);




                    //WriteToFile(patient_to_process);
                    foreach (var patient_details in patient_elements)
                    {
                        WriteToFile(patient_details.Attribute("name").Value + "  " + patient_details.Attribute("DOB").Value + "  " + patient_details.Attribute("gender").Value + "\t" + patient_details.Attribute("email").Value);


                    }
                }

            }
        }

        private void CreateUserDirectory(string value)
        {
            string new_path = write_path + "\\" + value;

            if (!Directory.Exists(new_path))
            {
                Directory.CreateDirectory(new_path);
            }
        }

        private void StorePatientProfile(string name, string DOB, string gender, string email)
        {
            string new_path = write_path + "\\" + name + "\\" + "user-profile";

            if (!Directory.Exists(new_path))
            {
                Directory.CreateDirectory(new_path);
            }

            var dob = Convert.ToDateTime(DOB);
            int age = DateTime.Now.Year - dob.Year;

            string filepath = new_path + "\\User-Profile.json"; //+ DateTime.Now.Date.ToShortDateString().Replace('/', '_') + ".txt";
            if (!File.Exists(filepath))
            {
                // Create a file to write to.   
                using (StreamWriter sw = File.CreateText(filepath))
                {
                    sw.WriteLine("{\"Name\":\"" + name +  "\",\"gender\":\"" + gender + "\",\"age\":" + Convert.ToString(age) + ",\"email\":\"" + email + "\"}");
                }
            }
        }

        protected override void OnStart(string[] args)
        {
            WriteToFile("Service is started at " + DateTime.Now);
            timer.Elapsed += new ElapsedEventHandler(OnElapsedTime);
            timer.Interval = 5000; //number in milisecinds  
            timer.Enabled = true;
        }

        protected override void OnStop()
        {
            WriteToFile("Service is stopped at " + DateTime.Now);
        }

        public void WriteToFile(string Message)
        {
            string new_path = write_path + "\\Logs";
            if (!Directory.Exists(new_path))
            {
                Directory.CreateDirectory(new_path);
            }
            string filepath = write_path + "\\Logs\\ServiceLog_" + DateTime.Now.Date.ToShortDateString().Replace('/', '_') + ".txt";
            if (!File.Exists(filepath))
            {
                // Create a file to write to.   
                using (StreamWriter sw = File.CreateText(filepath))
                {
                    sw.WriteLine(Message);
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(filepath))
                {
                    sw.WriteLine(Message);
                }
            }
        }
    }
}
