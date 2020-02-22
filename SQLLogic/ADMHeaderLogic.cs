using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLClass;
using SQLHelper;

namespace SQLLogic
{
    public class ADMHeaderLogic
    {
        public MEMBERS.SQLReturnValue ADMHeader_Insert_Update(ADMHeaderClass model)
        {
            return new SqlHelper().ExecuteProceduerWithValueSpecial("ADMHeader_Insert_Update", model);
        }

        public object ADMHeader_Get_GetAll(long ADMIDP, bool? IsActive)
        {
            return new SqlHelper().GetJsonResult("ADMHeader_Get_GetAll", new object[,] { { "ADMIDP", ADMIDP }, { "IsActive", IsActive } });
        }

        public MEMBERS.PagingResponse ADMHeader_GetAllPaging(int RowsPerPage, int PageNumber)
        {
            return new SqlHelper().Paging_GetAll_DataTable("ADMHeader_GetAllPaging", new object[,] {
                { "RowsPerPage", RowsPerPage }
                , { "PageNumber", PageNumber }
            });
        }

        public MEMBERS.PagingResponse ADMHeader_Dashboard(string BranchID, int? Role
            , int RowsPerPage, int PageNumber
            , string TicketID, string FromDate, string ToDate, int? StatusIDF, string OrderByColumnName, string OrderBy, int ReasonIDF)
        {
            return new SqlHelper().Paging_GetAll_DataTable("ADMHeader_Dashboard", new object[,] {
                { "BranchID", BranchID }
                , { "Role", Role }
                , { "RowsPerPage", RowsPerPage }
                , { "PageNumber", PageNumber }
                , { "TicketID", TicketID }
                , { "FromDate", FromDate }
                , { "ToDate", ToDate }
                , { "StatusIDF", StatusIDF }
                , { "OrderByColumnName", OrderByColumnName }
                , { "OrderBy", OrderBy }
                , { "ReasonIDF", ReasonIDF }
            });
        }

        public MEMBERS.SQLReturnValue ADMHeader_GeneralAction(long ADMIDP, int ActionType, int UserID, string UserName)
        {
            return new SqlHelper().ExecuteProceduerWithValue("ADMHeader_GeneralAction", new object[,] {
                { "ADMIDP", ADMIDP }
                , { "ActionType", ActionType }
                , { "UserID", UserID }
                , { "UserName", UserName }
            }, 3);
        }

        public object ADM_GetTicketDetail_DSR_ERP_ByTicketID(string TicketID, string IATANumber)
        {
            return new SqlHelper().GetJsonResult("ADM_GetTicketDetail_DSR_ERP_ByTicketID", new object[,] { { "TicketID", TicketID }, { "IATANumber", IATANumber } });
        }

        public MEMBERS.SQLReturnValue ADMHeader_UpdateACMDetail(long ADMIDP, string ACMNumber, float ACMAmount
            , int StatusIDF, int UserID, string UserName)
        {
            return new SqlHelper().ExecuteProceduerWithValue("ADMHeader_UpdateACMDetail", new object[,] {
                { "ADMIDP", ADMIDP }
                , { "ACMNumber", ACMNumber }
                , { "ACMAmount", ACMAmount }
                , { "StatusIDF", StatusIDF }
                , { "UserID", UserID }
                , { "UserName", UserName }
            }, 3);
        }
    }
}
