using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLClass;
using SQLHelper;

namespace SQLLogic
{
    public class BranchEmailMasterLogic
    {
        public MEMBERS.SQLReturnValue BranchEmailMaster_Insert_Update(BranchEmailMasterClass model)
        {
            return new SqlHelper().ExecuteProceduerWithValueSpecial("BranchEmailMaster_Insert_Update", model);
        }

        public object BranchEmailMaster_Get_GetAll(int BranchEmailIDP, string BranchID, bool? IsActive)
        {
            return new SqlHelper().GetJsonResult("BranchEmailMaster_Get_GetAll", new object[,] { { "BranchEmailIDP", BranchEmailIDP }, { "BranchID", BranchID }, { "IsActive", IsActive } });
        }

        public MEMBERS.PagingResponse BranchEmailMaster_GetAll_Paging(string BranchID, int RowsPerPage, int PageNumber)
        {
            return new SqlHelper().Paging_GetAll_DataTable("BranchEmailMaster_GetAll_Paging", new object[,] {
                { "BranchID", BranchID }
                , { "RowsPerPage", RowsPerPage }
                , { "PageNumber", PageNumber }
            });
        }

        public MEMBERS.SQLReturnValue BranchEmailMaster_GeneralAction(int BranchEmailIDP, int ActionType)
        {
            return new SqlHelper().ExecuteProceduerWithValue("BranchEmailMaster_GeneralAction", new object[,] { { "BranchEmailIDP", BranchEmailIDP }, { "ActionType", ActionType } }, 3);
        }

        public DataTable BranchEmailMaster_GetEmailByBranchID(string BranchID)
        {
            return new SqlHelper().GetAll_DataTable("BranchEmailMaster_GetEmailByBranchID", new object[,] { { "BranchID", BranchID } });
        }
    }
}
