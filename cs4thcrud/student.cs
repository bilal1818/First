using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace cs4thcrud
{
    [Table(Name ="student")]
    class student
    {
        int id;
        [Column(Name ="id",IsPrimaryKey =true)]
        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        private string name;
        [Column(Name ="name")]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }



    }
}
