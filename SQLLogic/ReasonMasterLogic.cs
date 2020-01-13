using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLClass;
using SQLHelper;

namespace SQLLogic
{
    public class ReasonMasterLogic
    {
        public MEMBERS.SQLReturnValue ReasonMaster_Insert_Update(ReasonMasterClass model)
        {
            return new SqlHelper().ExecuteProceduerWithValueSpecial("ReasonMaster_Insert_Update", model);
        }

        public object ReasonMaster_Get_GetAll(int ReasonIDP, bool? IsActive)
        {
            return new SqlHelper().GetJsonResult("ReasonMaster_Get_GetAll", new object[,] { { "ReasonIDP", ReasonIDP }, { "IsActive", IsActive } });
        }

        public MEMBERS.SQLReturnValue ReasonMaster_GeneralAction(int ReasonIDP, int ActionType)
        {
            return new SqlHelper().ExecuteProceduerWithValue("ReasonMaster_GeneralAction", new object[,] { { "ReasonIDP", ReasonIDP }, { "ActionType", ActionType } }, 3);
        }
    }
}
