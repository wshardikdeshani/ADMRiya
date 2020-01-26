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
    public class BranchEmailMasterController : Controller
    {
        // GET: BranchEmailMaster
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Save(BranchEmailMasterClass model)
        {
            MEMBERS.SQLReturnValue mRes = new BranchEmailMasterLogic().BranchEmailMaster_Insert_Update(model);
            return Json(mRes.Outval, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Get_GetAll(int id)
        {
            object data = new BranchEmailMasterLogic().BranchEmailMaster_Get_GetAll(id, null);
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