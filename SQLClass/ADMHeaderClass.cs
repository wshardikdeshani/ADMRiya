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
        public string IATANumber { get; set; }
        public string ADMNumber { get; set; }
        public float ADMAmount { get; set; }
        public string TicketID { get; set; }
        public string OfficeID { get; set; }
        public string BranchID { get; set; }
        public string TicketIssueBranchID { get; set; }
        public float TicketAmount { get; set; }
        public int ReasonIDF { get; set; }
        public string Remarks { get; set; }
        public int StatusIDF { get; set; }
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string ADMFileName { get; set; }
    }

    public class ADMHeaderExportClass
    {
        public string TicketIDDisplay { get; set; }
        public float TicketAmount { get; set; }
        public string IATANumber { get; set; }
        public string BranchID { get; set; }
        public string OfficeID { get; set; }
        public string ADMNumber { get; set; }
        public float ADMAmount { get; set; }
        public string ReasonName { get; set; }
        public string Remarks { get; set; }
        public string StatusName { get; set; }
        public string ADMRaisedDate { get; set; }
        public string CreatedByName { get; set; } // ADM Raised By
        public string ACMNumber { get; set; }
        public float ACMAmount { get; set; }
        public float TotalDebitAmount { get; set; }
        public string LastFollowUpDate { get; set; }
        public string LastFollowUpBy { get; set; }
    }
}
