using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLClass
{
    public class ADMFollowUpClass
    {
        public long ADMFollowUpIDP { get; set; }
        public int ADMIDF { get; set; }
        public string OfficeID { get; set; }
        public string BranchID { get; set; }
        public string Remarks { get; set; }
        public int StatusIDF { get; set; }
        public string NextFollowUpDate { get; set; }
        public int UserID { get; set; }
        public string UserName { get; set; }
    }
}