using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLClass
{
    public class ADMHeaderClass
    {
        public long ADMIDP { get; set; }
        public string ICUSNumber { get; set; }
        public int ADMNumber { get; set; }
        public string TicketID { get; set; }
        public int OfficeIDF { get; set; }
        public int OfficeBranchIDF { get; set; }
        public int TicketIssueBranchID { get; set; }
        public float TicketAmount { get; set; }
        public int ReasonIDF { get; set; }
        public string Remarks { get; set; }
        public int StatusIDF { get; set; }
        public int UserID { get; set; }
    }
}
