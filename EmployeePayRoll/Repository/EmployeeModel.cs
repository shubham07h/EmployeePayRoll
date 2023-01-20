using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayRoll.Repository
{
    internal class EmployeeModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public long Salary { get; set; }
        public DateTime Startdate { get; set; }
        public long phone { get; set; }
    }
}
