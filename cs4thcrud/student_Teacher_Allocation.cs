using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace cs4thcrud
{
    [Table (Name ="Student_teacher")]
    class student_Teacher_Allocation
    {
        private int id;
        [Column (Name ="id",IsPrimaryKey =true)]
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private int sid;
        [Column(Name ="sid")]
        public int SID
        {
            get { return sid; }
            set { sid = value; }
        }

        private int tid;
        [Column(Name = "tid")]

        public int TID
        {
            get { return tid; }
            set { tid = value; }
        }




    }
}
