﻿using System;
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
        public int DebitToType { get; set; }
        public string DebitTo { get; set; }
        public string DebitToSubAgentName { get; set; }
        public string FU_ACMNo { get; set; }
        public float FU_ACMAmount { get; set; }
        public int FU_ACMStatusIDF { get; set; }
    }
}