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
    public partial class Show : Form
    {
        public Show()
        {
            InitializeComponent();
        }
        DataContext dc = new DataContext("Data Source=DESKTOP-77FTO3H;Initial Catalog=UMS;Integrated Security=True");

        private void Show_Load(object sender, EventArgs e)
        {
            refresh();


        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();

        }
        public void refresh()
        {
            Table<student> s1 = dc.GetTable<student>();
            var s = new student();

            DataTable dt = new DataTable();
            dt.Columns.Add("Student Id", typeof(int));
            dt.Columns.Add("Student Name", typeof(string));
            var data = from k in s1
                       select k;
            foreach (var i in data)
            {
                dt.Rows.Add(i.ID, i.Name);
            }

            dataGridView1.DataSource = dt;


        }
        private void button1_Click(object sender, EventArgs e)
        {
            Table<student> s1 = dc.GetTable<student>();
            var data = from k in s1
                       where k.ID==Convert.ToInt32(textBox1.Text)
                       select k;
            foreach (var i in data)
            {
                i.Name = textBox2.Text;
            }
            dc.SubmitChanges();
            refresh();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            int del =Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());

            Table<student> s1 = dc.GetTable<student>();
            var data = from k in s1
                       where k.ID == del
                       select k;
            foreach (var i in data)
            {
                s1.DeleteOnSubmit(i);
            }
            dc.SubmitChanges();
            MessageBox.Show("Delete");
            refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Search s = new Search();
            int a = Convert.ToInt32 (textBox3.Text);
            s.search(a);
            s.Show();
        }
    }
}
