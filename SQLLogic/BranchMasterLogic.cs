using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLClass;
using SQLHelper;

namespace SQLLogic
{
    public class BranchMasterLogic
    {
        public MEMBERS.SQLReturnValue BranchMaster_Insert_Update(BranchMasterClass model)
        {
            return new SqlHelper().ExecuteProceduerWithValueSpecial("BranchMaster_Insert_Update", model);
        }

        public object BranchMaster_Get_GetAll(int BranchIDP, bool? IsActive)
        {
            return new SqlHelper().GetJsonResult("BranchMaster_Get_GetAll", new object[,] { { "BranchIDP", BranchIDP }, { "IsActive", IsActive } });
        }

        public MEMBERS.SQLReturnValue BranchMaster_GeneralAction(int BranchIDP, int ActionType)
        {
            return new SqlHelper().ExecuteProceduerWithValue("BranchMaster_GeneralAction", new object[,] { { "BranchIDP", BranchIDP }, { "ActionType", ActionType } }, 3);
        }
    }
}
