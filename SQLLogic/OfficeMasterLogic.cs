using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLClass;
using SQLHelper;

namespace SQLLogic
{
    public class OfficeMasterLogic
    {
        public MEMBERS.SQLReturnValue OfficeMaster_Insert_Update(OfficeMasterClass model)
        {
            return new SqlHelper().ExecuteProceduerWithValueSpecial("OfficeMaster_Insert_Update", model);
        }

        public object OfficeMaster_Get_GetAll(int OfficeIDP, bool? IsActive)
        {
            return new SqlHelper().GetJsonResult("OfficeMaster_Get_GetAll", new object[,] { { "OfficeIDP", OfficeIDP }, { "IsActive", IsActive } });
        }

        public MEMBERS.SQLReturnValue OfficeMaster_GeneralAction(int OfficeIDP, int ActionType)
        {
            return new SqlHelper().ExecuteProceduerWithValue("OfficeMaster_GeneralAction", new object[,] { { "OfficeIDP", OfficeIDP }, { "ActionType", ActionType } }, 3);
        }
    }
}
