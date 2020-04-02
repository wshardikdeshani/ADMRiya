using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SQLClass;
using SQLHelper;
using SQLLogic;

namespace ADMPro.Controllers
{
    public class ADMHeaderController : Controller
    {
        // GET: ADMHeader
        public ActionResult Index()
        {
            if (GeneralClass.Role == null || GeneralClass.Role == string.Empty)
            {
                return Redirect(GeneralClass.LoginURL);
            }

            object dataReason = new ReasonMasterLogic().ReasonMaster_Get_GetAll(0, true);
            object dataStatus = new StatusMasterLogic().StatusMaster_Get_GetAll(0, true);

            if (dataReason != null)
            {
                ViewBag.ReasonList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ReasonMasterClass>>(dataReason.ToString());
            }

            if (dataStatus != null)
            {
                ViewBag.StatusList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<StatusMasterClass>>(dataStatus.ToString());
            }

            return View();
        }

        [HttpPost]
        public JsonResult Save()
        {
            string Response = string.Empty;

            if (Request.Files.Count > 0)
            {
                try
                {
                    //  Get all files from Request object 
                    HttpFileCollectionBase files = Request.Files;

                    for (int i = 0; i < files.Count; i++)
                    {
                        HttpPostedFileBase file = files[i];
                        string FileName;

                        // Checking for Internet Explorer 
                        if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                        {
                            string[] testfiles = file.FileName.Split(new char[] { '\\' });
                            FileName = testfiles[testfiles.Length - 1];
                        }
                        else
                        {
                            FileName = file.FileName;
                        }

                        string FileExtension = System.IO.Path.GetExtension(Request.Files[i].FileName);
                        string NewFileName = DateTime.Now.ToString("ddMMyyyyHHmmss") + FileExtension;
                        string SaveFilePath = System.IO.Path.Combine(Server.MapPath("~/ADMFiles/"), NewFileName);
                        file.SaveAs(SaveFilePath);

                        ADMHeaderClass obj = new ADMHeaderClass();

                        long.TryParse(Request.Form["ADMIDP"].ToString(), out long ADMIDP);
                        float.TryParse(Request.Form["ADMAmount"].ToString(), out float ADMAmount);
                        float.TryParse(Request.Form["TicketAmount"].ToString(), out float TicketAmount);
                        int.TryParse(Request.Form["ReasonIDF"].ToString(), out int ReasonIDF);
                        //DateTime.TryParse(Request.Form["IATAADMDate"].ToString(), out DateTime IATAADMDate);

                        obj.ADMIDP = ADMIDP;
                        obj.IATANumber = Request.Form["IATANumber"].ToString();
                        obj.ADMNumber = Request.Form["ADMNumber"].ToString();
                        obj.ADMAmount = ADMAmount;
                        obj.TicketID = Request.Form["TicketID"].ToString();
                        obj.OfficeID = Request.Form["OfficeID"].ToString();
                        obj.BranchID = Request.Form["BranchID"].ToString();
                        obj.TicketIssueBranchID = Request.Form["TicketIssueBranchID"].ToString();
                        obj.TicketAmount = (TicketAmount > 0 && string.IsNullOrEmpty(Request.Form["TicketID"].ToString()) ? 0 : TicketAmount);
                        obj.ReasonIDF = ReasonIDF;
                        obj.Remarks = Request.Form["Remarks"].ToString();
                        obj.StatusIDF = 1;
                        obj.UserID = GeneralClass.GetIntValue(GeneralClass.EmployeeID);
                        obj.UserName = GeneralClass.EmployeeName;
                        obj.ADMFileName = NewFileName;
                        obj.IATAADMDate = Request.Form["IATAADMDate"].ToString();

                        MEMBERS.SQLReturnValue mRes = new ADMHeaderLogic().ADMHeader_Insert_Update(obj);

                        Response = mRes.Outval.ToString();
                    }
                }
                catch (Exception ex)
                {
                    Response = "Error : " + ex.Message;
                }
            }
            else
            {
                try
                {
                    ADMHeaderClass obj = new ADMHeaderClass();

                    long.TryParse(Request.Form["ADMIDP"].ToString(), out long ADMIDP);
                    float.TryParse(Request.Form["ADMAmount"].ToString(), out float ADMAmount);
                    float.TryParse(Request.Form["TicketAmount"].ToString(), out float TicketAmount);
                    int.TryParse(Request.Form["ReasonIDF"].ToString(), out int ReasonIDF);
                    //DateTime.TryParse(Request.Form["IATAADMDate"].ToString(), out DateTime IATAADMDate);

                    //DateTime IATAADMDate = Convert.ToDateTime(Request.Form["IATAADMDate"].ToString());

                    obj.ADMIDP = ADMIDP;
                    obj.IATANumber = Request.Form["IATANumber"].ToString();
                    obj.ADMNumber = Request.Form["ADMNumber"].ToString();
                    obj.ADMAmount = ADMAmount;
                    obj.TicketID = Request.Form["TicketID"].ToString();
                    obj.OfficeID = Request.Form["OfficeID"].ToString();
                    obj.BranchID = Request.Form["BranchID"].ToString();
                    obj.TicketIssueBranchID = Request.Form["TicketIssueBranchID"].ToString();
                    obj.TicketAmount = (TicketAmount > 0 && string.IsNullOrEmpty(Request.Form["TicketID"].ToString()) ? 0 : TicketAmount);
                    obj.ReasonIDF = ReasonIDF;
                    obj.Remarks = Request.Form["Remarks"].ToString();
                    obj.StatusIDF = 1;
                    obj.UserID = GeneralClass.GetIntValue(GeneralClass.EmployeeID);
                    obj.UserName = GeneralClass.EmployeeName;
                    obj.ADMFileName = Request.Form["OldFileName"].ToString();
                    obj.IATAADMDate = Request.Form["IATAADMDate"].ToString();

                    MEMBERS.SQLReturnValue mRes = new ADMHeaderLogic().ADMHeader_Insert_Update(obj);

                    Response = mRes.Outval.ToString();
                }
                catch (Exception ee)
                {
                    Response = "Error : " + ee.Message;
                }
            }

            /*Send Email*/
            if (Request.Form["ADMIDP"].ToString() == "0" && (Response != "Ticket already added in ADM." && Response != "ADM already raised.")) // NEW ADM RAISED
            {
                string SubjectBody = string.Empty;

                if (string.IsNullOrEmpty(Request.Form["TicketID"].ToString()) && !string.IsNullOrEmpty(Request.Form["ADMNumber"].ToString()))
                {
                    SubjectBody = "New ADM Raised - AMD Number is " + Request.Form["ADMNumber"].ToString();
                }
                else if (!string.IsNullOrEmpty(Request.Form["TicketID"].ToString()))
                {
                    SubjectBody = "New ADM Raised - Ticket id is " + Request.Form["TicketID"].ToString();
                }

                DataTable dt = new BranchEmailMasterLogic().BranchEmailMaster_GetEmailByBranchID(Request.Form["BranchID"].ToString());

                if (dt.Rows.Count > 0)
                {
                    new EmailLogic().SendEmail(SubjectBody
                        , SubjectBody
                        , dt.Rows[0]["ToEmailID"].ToString()
                        , dt.Rows[0]["CCEmailID"].ToString());

                    Response = Response + " and ADM raised email send successfully.";
                }
                else
                {
                    Response = Response + " and ADM email not found.";
                }
            }

            return Json(Response, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Get_GetAll(long id)
        {
            object data = new ADMHeaderLogic().ADMHeader_Get_GetAll(id, null);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetAllPaging(int RowsPerPage, int PageNumber)
        {
            object data = new ADMHeaderLogic().ADMHeader_GetAllPaging(RowsPerPage, PageNumber);

            return Json(data, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult GeneralAction(long id, int ActionType)
        {
            MEMBERS.SQLReturnValue mRes = new ADMHeaderLogic().ADMHeader_GeneralAction(id
                , ActionType
                , GeneralClass.GetIntValue(GeneralClass.EmployeeID)
                , GeneralClass.EmployeeName);

            return Json(mRes.Outval, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Fetch ID Added
        /// </summary>
        /// <param name="TicketID"></param>
        /// <param name="IATANumber"></param>
        /// <param name="FetchID"></param>
        /// <returns></returns>
        [HttpPost] 
        public JsonResult GetTicketDetail(string TicketID, string IATANumber, int FetchID)
        {
            object data = new ADMHeaderLogic().ADM_GetTicketDetail_DSR_ERP_ByTicketID(TicketID, IATANumber, FetchID);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}