using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs4thcrud
{
    [Table(Name ="teacher")]
    class Teacher
    {
        private int id;
        [Column(Name ="id",IsPrimaryKey =true)]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private char grade;
        [Column(Name = "Grade")]

        public char Grade
        {
            get { return grade; }
            set { grade = value; }
        }
        private int age;
        [Column(Name = "age")]

        public int Age
        {
            get { return age; }
            set { age = value; }
        }




    }
}
