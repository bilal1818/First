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
    public partial class Search : Form
    {
        public Search()
        {
            InitializeComponent();
        }
        DataContext dc = new DataContext("Data Source=DESKTOP-77FTO3H;Initial Catalog=UMS;Integrated Security=True");

        public void search(int a)
        {
            Table<student> s1 = dc.GetTable<student>();
            var s = new student();

            DataTable dt = new DataTable();
            dt.Columns.Add("Student Id", typeof(int));
            dt.Columns.Add("Student Name", typeof(string));
            var data = from k in s1
                       where k.ID==a
                       select k;
            foreach (var i in data)
            {
                dt.Rows.Add(i.ID, i.Name);
            }

            dataGridView1.DataSource = dt;


        }
        private void Search_Load(object sender, EventArgs e)
        {

        }
    }
}
