using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using SQLClass;
using SQLHelper;
using SQLLogic;

namespace ADMPro.Controllers
{
    public class BranchEmailMasterController : Controller
    {
        // GET: BranchEmailMaster
        public ActionResult Index()
        {
            if (GeneralClass.Role == null || GeneralClass.Role == string.Empty)
            {
                return Redirect(GeneralClass.LoginURL);
            }

            object dataBranch = new UtilityLogic().GetAllBranch();

            if (dataBranch != null)
            {
                ViewBag.BranchList = JsonConvert.DeserializeObject<List<UtilityClass>>(dataBranch.ToString());
            }

            return View();
        }

        [HttpPost]
        public JsonResult Save(BranchEmailMasterClass model)
        {
            MEMBERS.SQLReturnValue mRes = new BranchEmailMasterLogic().BranchEmailMaster_Insert_Update(model);
            return Json(mRes.Outval, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Get_GetAll(int id, string BranchID)
        {
            object data = new BranchEmailMasterLogic().BranchEmailMaster_Get_GetAll(id, BranchID, null);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetAllPaging(string BranchID, int RowsPerPage, int PageNumber)
        {
            MEMBERS.PagingResponse data = new BranchEmailMasterLogic().BranchEmailMaster_GetAll_Paging(BranchID
                , RowsPerPage
                , PageNumber);

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GeneralAction(int id, int ActionType)
        {
            MEMBERS.SQLReturnValue mRes = new BranchEmailMasterLogic().BranchEmailMaster_GeneralAction(id, ActionType);
            return Json(mRes.Outval, JsonRequestBehavior.AllowGet);
        }
    }
}