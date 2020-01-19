using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLClass;
using SQLHelper;

namespace SQLLogic
{
    public class ADMFollowUpLogic
    {
        public MEMBERS.SQLReturnValue ADMFollowUp_Insert_Update(ADMFollowUpClass model)
        {
            return new SqlHelper().ExecuteProceduerWithValueSpecial("ADMFollowUp_Insert_Update", model);
        }

        public object ADMFollowUp_Get_GetAll(long ADMFollowUpIDP)
        {
            return new SqlHelper().GetJsonResult("ADMFollowUp_Get_GetAll", new object[,] { { "ADMFollowUpIDP", ADMFollowUpIDP } });
        }

        public MEMBERS.SQLReturnValue ADMFollowUp_GeneralAction(long ADMFollowUpIDP, int ActionType)
        {
            return new SqlHelper().ExecuteProceduerWithValue("ADMFollowUp_GeneralAction", new object[,] { { "ADMFollowUpIDP", ADMFollowUpIDP }, { "ActionType", ActionType } }, 3);
        }
        public object ADMFollowUp_GetAll_ByADMIDF(long ADMIDF)
        {
            return new SqlHelper().GetJsonResult("ADMFollowUp_GetAll_ByADMIDF", new object[,] { { "ADMIDF", ADMIDF } });
        }
    }
}
