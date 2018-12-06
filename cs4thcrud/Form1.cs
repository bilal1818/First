using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace cs4thcrud
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DataContext dc = new DataContext("Data Source=DESKTOP-77FTO3H;Initial Catalog=UMS;Integrated Security=True");


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Table<student> s1= dc.GetTable<student>();

            student s = new student();
            s.ID = Convert.ToInt32 (textBox1.Text);
            s.Name = textBox2.Text;

            s1.InsertOnSubmit(s);
            dc.SubmitChanges();

        }
    }
}
