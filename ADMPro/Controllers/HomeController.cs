using Newtonsoft.Json;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using SQLClass;
using SQLHelper;
using SQLLogic;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace ADMPro.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Request.QueryString.Count == 0)
            {
                return Redirect(GeneralClass.LoginURL);
            }
            else if (Request.QueryString.Count == 4) // Branch
            {
                if (Request.QueryString.AllKeys.Contains("eid") == false
                    && Request.QueryString.AllKeys.Contains("enm") == false
                    && Request.QueryString.AllKeys.Contains("bnm") == false
                    && Request.QueryString.AllKeys.Contains("role") == false)
                {
                    return Redirect(GeneralClass.LoginURL);
                }
                else
                {
                    GeneralClass.EmployeeID = Request.QueryString["eid"].ToString();
                    GeneralClass.EmployeeName = Request.QueryString["enm"].ToString();
                    GeneralClass.BranchID = Request.QueryString["bnm"].ToString();
                    GeneralClass.Role = Request.QueryString["role"].ToString();
                }
            }
            else if (Request.QueryString.Count == 3) // Audit
            {
                if (Request.QueryString.AllKeys.Contains("eid") == false
                    && Request.QueryString.AllKeys.Contains("enm") == false
                    && Request.QueryString.AllKeys.Contains("role") == false)
                {
                    return Redirect(GeneralClass.LoginURL);
                }
                else
                {
                    GeneralClass.EmployeeID = Request.QueryString["eid"].ToString();
                    GeneralClass.EmployeeName = Request.QueryString["enm"].ToString();
                    GeneralClass.Role = Request.QueryString["role"].ToString();
                }
            }
            else
            {
                return Redirect(GeneralClass.LoginURL);
            }

            object dataStatus = new StatusMasterLogic().StatusMaster_Get_GetAll(0, true);

            if (dataStatus != null)
            {
                ViewBag.StatusList = JsonConvert.DeserializeObject<List<StatusMasterClass>>(dataStatus.ToString());
            }

            object dataBranch = new UtilityLogic().GetAllBranch();

            if (dataBranch != null)
            {
                ViewBag.BranchList = JsonConvert.DeserializeObject<List<UtilityClass>>(dataBranch.ToString());
            }

            object dataReason = new ReasonMasterLogic().ReasonMaster_Get_GetAll(0, true);

            if (dataReason != null)
            {
                ViewBag.ReasonList = JsonConvert.DeserializeObject<List<ReasonMasterClass>>(dataReason.ToString());
            }

            return View();
        }

        [HttpPost]
        public JsonResult GetAllTicket(string BranchID, int? Role, int RowsPerPage, int PageNumber
            , string TicketID, string FromDate, string ToDate, int? StatusIDF, string OrderByColumnName, string OrderBy)
        {
            MEMBERS.PagingResponse data = new ADMHeaderLogic().ADMHeader_Dashboard(BranchID
                , Role
                , RowsPerPage
                , PageNumber
                , TicketID
                , FromDate
                , ToDate
                , StatusIDF
                , OrderByColumnName
                , OrderBy);

            HttpContext.Cache["TicketResponse"] = data.Data;
            HttpContext.Cache["Role"] = Role;

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Save(ADMFollowUpClass obj)
        {
            obj.UserID = GeneralClass.GetIntValue(GeneralClass.EmployeeID);
            obj.UserName = GeneralClass.EmployeeName;

            MEMBERS.SQLReturnValue mRes = new ADMFollowUpLogic().ADMFollowUp_Insert_Update(obj);
            return Json(mRes.Outval, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UpdateACMDetail(long ADMIDP, string ACMNumber, float ACMAmount, int StatusIDF)
        {
            MEMBERS.SQLReturnValue mRes = new ADMHeaderLogic().ADMHeader_UpdateACMDetail(ADMIDP, ACMNumber, ACMAmount
                , StatusIDF, GeneralClass.GetIntValue(GeneralClass.EmployeeID), GeneralClass.EmployeeName);

            return Json(mRes.Outval, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetDashboardCount(string BranchID)
        {
            object data = new UtilityLogic().DashboardCount(BranchID);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        #region Export To Excel
        public FileResult ExportToExcel()
        {
            try
            {
                List<ADMHeaderExportClass> oList = new List<ADMHeaderExportClass>();

                object data = (object)HttpContext.Cache["TicketResponse"];
                string Role = HttpContext.Cache["Role"].ToString();

                DataTable dt = new DataTable();

                if (data != null)
                {
                    oList = JsonConvert.DeserializeObject<List<ADMHeaderExportClass>>(data.ToString());

                    dt = ToDataTable(oList);
                }

                var excelFile = GenerateExcel(dt, Role);

                string FileName = DateTime.Now.Ticks.ToString() + ".xls";

                return File(excelFile, "application/vnd.ms-excel", FileName);
            }
            catch (Exception ee)
            {
                return null;
            }
        }

        public DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            //Get all the properties by using reflection   
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names  
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {

                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }

            return dataTable;
        }

        public byte[] GenerateExcel(DataTable dt, string Role)
        {
            if (dt.Rows.Count > 0)
            {
                string SheetName = "ADM Header";

                // Declare HSSFWorkbook object for create sheet
                var workbook = new HSSFWorkbook();
                var sheet = workbook.CreateSheet(SheetName);

                // Set column name this column name use for fetch data from list
                List<string> columns = new List<string>();
                List<string> headers = new List<string>();

                columns.Add("IATANumber");
                columns.Add("ADMNumber");
                columns.Add("ADMAmount");
                columns.Add("ACMNumber");
                columns.Add("ACMAmount");
                columns.Add("TicketID");
                columns.Add("OfficeID");
                if (Role == "1")
                    columns.Add("BranchID");
                columns.Add("TicketAmount");
                columns.Add("ReasonName");
                columns.Add("StatusName");
                columns.Add("Remarks");
                columns.Add("ADMRaisedDate");

                headers.Add("IATANumber");
                headers.Add("ADMNumber");
                headers.Add("ADMAmount");
                headers.Add("ACMNumber");
                headers.Add("ACMAmount");
                headers.Add("TicketID");
                headers.Add("OfficeID");
                if (Role == "1")
                    headers.Add("BranchID");
                headers.Add("TicketAmount");
                headers.Add("ReasonName");
                headers.Add("StatusName");
                headers.Add("Remarks");
                headers.Add("ADMRaisedDate");

                var cStyle = workbook.CreateCellStyle();
                cStyle.FillForegroundColor = IndexedColors.White.Index;
                cStyle.FillBackgroundColor = IndexedColors.Green.Index;

                HSSFFont HeaderFont = (HSSFFont)workbook.CreateFont();
                HeaderFont.FontHeightInPoints = 12;
                HeaderFont.FontName = "Calibri";
                HeaderFont.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.Bold;

                HSSFFont BodyFont = (HSSFFont)workbook.CreateFont();
                BodyFont.FontHeightInPoints = 12;
                BodyFont.FontName = "Calibri";

                HSSFCellStyle HeaderStyle = (HSSFCellStyle)workbook.CreateCellStyle();
                HeaderStyle.SetFont(HeaderFont);

                HSSFCellStyle BodyStyle = (HSSFCellStyle)workbook.CreateCellStyle();
                BodyStyle.SetFont(BodyFont);

                var headerRow = sheet.CreateRow(0);

                //Below loop is create header
                for (int i = 0; i < columns.Count; i++)
                {
                    var cell = headerRow.CreateCell(i);
                    cell.SetCellValue(headers[i]);
                    cell.CellStyle = HeaderStyle;
                }

                int RowCounter = 1;

                //Below loop is fill content
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var rowIndex = i + 1;
                    var row = sheet.CreateRow(rowIndex);

                    for (int j = 0; j < columns.Count; j++)
                    {
                        var cell = row.CreateCell(j);
                        var o = dt.Rows[i][columns[j]].ToString();

                        if (columns[j] == "ADMAmount" || columns[j] == "ACMAmount" || columns[j] == "TicketAmount")
                        {
                            double.TryParse(o, out double Value);
                            cell.SetCellValue(Value);
                        }
                        else
                        {
                            cell.SetCellValue(o);
                        }

                        cell.CellStyle = BodyStyle;

                        sheet.AutoSizeColumn(j);
                    }

                    RowCounter = RowCounter + 1;
                }

                // Declare one MemoryStream variable for write file in stream
                var stream = new MemoryStream();
                workbook.Write(stream);

                return stream.ToArray();
            }

            return null;
        }
        #endregion
    }
}