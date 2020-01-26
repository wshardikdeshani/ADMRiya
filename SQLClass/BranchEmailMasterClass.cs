using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLClass
{
    public class BranchEmailMasterClass
    {
        public int BranchEmailIDP { get; set; }
        public string BranchID { get; set; }
        public string ToEmailID { get; set; }
        public string CCEmailID { get; set; }
        public int UserID { get; set; }
    }
}