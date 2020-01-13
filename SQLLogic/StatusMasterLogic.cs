using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLClass;
using SQLHelper;

namespace SQLLogic
{
    public class StatusMasterLogic
    {
        public MEMBERS.SQLReturnValue StatusMaster_Insert_Update(StatusMasterClass model)
        {
            return new SqlHelper().ExecuteProceduerWithValueSpecial("StatusMaster_Insert_Update", model);
        }

        public object StatusMaster_Get_GetAll(int StatusIDP, bool? IsActive)
        {
            return new SqlHelper().GetJsonResult("StatusMaster_Get_GetAll", new object[,] { { "StatusIDP", StatusIDP }, { "StatusIDP", StatusIDP } });
        }

        public MEMBERS.SQLReturnValue StatusMaster_GeneralAction(int StatusIDP, int ActionType)
        {
            return new SqlHelper().ExecuteProceduerWithValue("StatusMaster_GeneralAction", new object[,] { { "StatusIDP", StatusIDP }, { "ActionType", ActionType } }, 3);
        }
    }
}
