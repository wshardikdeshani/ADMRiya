using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLClass;
using SQLHelper;

namespace SQLLogic
{
    public class UtilityLogic
    {
        public object DashboardCount()
        {
            return new SqlHelper().GetJsonResult("DashboardCount", new object[,] { });
        }
    }
}
