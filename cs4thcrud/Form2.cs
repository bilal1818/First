using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cs4thcrud
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        DataContext dc = new DataContext("Data Source=DESKTOP-77FTO3H;Initial Catalog=UMS;Integrated Security=True");

        private void Form2_Load(object sender, EventArgs e)
        {
            //var data = from k in s1
            //           select k;
            //foreach (var d in data)
            //{
            //    comboBox1.Items.Add(d.ID);
            //}
            Table<student> s1 = dc.GetTable<student>();
            Table<student_Teacher_Allocation> st = dc.GetTable<student_Teacher_Allocation>();

            Table<Teacher> t = dc.GetTable<Teacher>();


            //////Joining two tables
            var data = from k in st
                       join i in s1
                       on k.SID equals i.ID
                       join g in t
                       on k.TID equals g.Id
                       select new { k.SID, i.Name,g.Grade,g.Age,g.Id };
            DataTable dt = new DataTable();
            dt.Columns.Add("Student ID",typeof(int));
            dt.Columns.Add("Student Name", typeof(string));
            dt.Columns.Add("Teacher Id", typeof(int));
            dt.Columns.Add("Teacher Grade", typeof(char));
            dt.Columns.Add("Teacher Age", typeof(int));
            
            foreach (var i in data)
            {
                dt.Rows.Add(i.SID,i.Name,i.Id,i.Grade,i.Age);
            }

            dataGridView1.DataSource = dt;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Table<student> s1 = dc.GetTable<student>();
            var data = from k in s1
                       where k.ID == Convert.ToInt32 (comboBox1.Text)
                       select k;
            foreach (var d in data)
            {
                textBox1.Text = d.Name;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int del = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[1].Value.ToString());

            Table<student_Teacher_Allocation> st = dc.GetTable<student_Teacher_Allocation>();

            var data = from k in st
                       where k.SID == del
                       select k;
            foreach(var d in data)
            {
                st.DeleteOnSubmit(d);
            }
            Table<student> s1 = dc.GetTable<student>();

            var dataa = from k in s1
                       where k.ID == del
                       select k;
            foreach (var d in data)
            {
                st.DeleteOnSubmit(d);
            }



        }
    }
}
