using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;//non-blocking code run in background
using System.Windows.Forms;
using System.Xml.Serialization; //conversion of objects in XML

namespace XMLParsing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Person> p1 = new List<Person>();
            XmlSerializer serializer = new XmlSerializer(typeof(List<Person>));
            p1.Add(new Person() { ID = 1, Name = "Shruti" });
            p1.Add(new Person() { ID = 2, Name = "Narad" });
            using (FileStream fs = new FileStream(Environment.CurrentDirectory + "\\jacob.xml", FileMode.Create, FileAccess.Write))
            {
                serializer.Serialize(fs, p1);
                MessageBox.Show("Created");

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<Person> p1 = new List<Person>();
            XmlSerializer serializer = new XmlSerializer(typeof(List<Person>));
            
            using (FileStream fs = new FileStream(Environment.CurrentDirectory + "\\jacob.xml", FileMode.Open, FileAccess.Read))
            {
                p1 = serializer.Deserialize(fs) as List<Person>;
                MessageBox.Show("Retrieving Data");

            }
            dataGridView1.DataSource = p1;
        }
    }
}
