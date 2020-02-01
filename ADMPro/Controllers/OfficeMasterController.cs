using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SQLClass;
using SQLHelper;
using SQLLogic;

namespace ADMPro.Controllers
{
    public class OfficeMasterController : Controller
    {
        // GET: OfficeMaster
        public ActionResult Index()
        {
            if (GeneralClass.Role == null || GeneralClass.Role == string.Empty)
            {
                return Redirect(GeneralClass.LoginURL);
            }

            return View();
        }

        [HttpPost]
        public JsonResult Save(OfficeMasterClass model)
        {
            MEMBERS.SQLReturnValue mRes = new OfficeMasterLogic().OfficeMaster_Insert_Update(model);
            return Json(mRes.Outval, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Get_GetAll(int id)
        {
            object data = new OfficeMasterLogic().OfficeMaster_Get_GetAll(id, null);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GeneralAction(int id, int ActionType)
        {
            MEMBERS.SQLReturnValue mRes = new OfficeMasterLogic().OfficeMaster_GeneralAction(id, ActionType);
            return Json(mRes.Outval, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetAllBranch()
        {
            object data = new BranchMasterLogic().BranchMaster_Get_GetAll(0, true);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}