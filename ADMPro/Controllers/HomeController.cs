using Newtonsoft.Json;
using SQLClass;
using SQLHelper;
using SQLLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ADMPro.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
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
                ViewBag.ReasonList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ReasonMasterClass>>(dataReason.ToString());
            }

            if (Request.QueryString.Count == 4) // Branch
            {
                ViewBag.EmployeeID = Request.QueryString["eid"].ToString();
                ViewBag.EmployeeName = Request.QueryString["enm"].ToString();
                ViewBag.BranchID = Request.QueryString["bnm"].ToString();
                ViewBag.Role = Request.QueryString["role"].ToString();
            }
            else if (Request.QueryString.Count == 3) // Audit
            {
                ViewBag.EmployeeID = Request.QueryString["eid"].ToString();
                ViewBag.EmployeeName = Request.QueryString["enm"].ToString();
                ViewBag.Role = Request.QueryString["role"].ToString();
            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public JsonResult GetAllTicket(string BranchID, int? Role, int RowsPerPage, int PageNumber
            , string TicketID, string FromDate, string ToDate, int? StatusIDF)
        {
            object data = new ADMHeaderLogic().ADMHeader_Dashboard(BranchID
                , Role
                , RowsPerPage
                , PageNumber
                , TicketID
                , FromDate
                , ToDate
                , StatusIDF);

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Save(ADMFollowUpClass obj)
        {
            MEMBERS.SQLReturnValue mRes = new ADMFollowUpLogic().ADMFollowUp_Insert_Update(obj);
            return Json(mRes.Outval, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UpdateACMDetail(long ADMIDP, string ACMNumber, float ACMAmount)
        {
            MEMBERS.SQLReturnValue mRes = new ADMHeaderLogic().ADMHeader_UpdateACMDetail(ADMIDP, ACMNumber, ACMAmount);
            return Json(mRes.Outval, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetDashboardCount(string BranchID)
        {
            object data = new UtilityLogic().DashboardCount(BranchID);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}