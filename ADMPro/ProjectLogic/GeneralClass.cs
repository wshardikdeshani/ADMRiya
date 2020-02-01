using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ADMPro
{
    public class GeneralClass
    {
        public static string EmptyGuid = "00000000-0000-0000-0000-000000000000";

        public static string LoginURL = ConfigurationManager.AppSettings["LoginURL"];

        public static string EmployeeID
        {
            get
            {
                if (HttpContext.Current.Session["EmployeeID"] == null)
                    return string.Empty;
                return HttpContext.Current.Session["EmployeeID"].ToString();
            }
            set { HttpContext.Current.Session["EmployeeID"] = value; }
        }

        public static string EmployeeName
        {
            get
            {
                if (HttpContext.Current.Session["EmployeeName"] == null)
                    return string.Empty;
                return HttpContext.Current.Session["EmployeeName"].ToString();
            }
            set { HttpContext.Current.Session["EmployeeName"] = value; }
        }

        public static string BranchID
        {
            get
            {
                if (HttpContext.Current.Session["BranchID"] == null)
                    return string.Empty;
                return HttpContext.Current.Session["BranchID"].ToString();
            }
            set { HttpContext.Current.Session["BranchID"] = value; }
        }
        public static string Role
        {
            get
            {
                if (HttpContext.Current.Session["Role"] == null)
                    return string.Empty;
                return HttpContext.Current.Session["Role"].ToString();
            }
            set { HttpContext.Current.Session["Role"] = value; }
        }

        public static int GetIntValue(string Value)
        {
            int.TryParse(Value, out int mValue);

            return mValue;
        }
    }
}