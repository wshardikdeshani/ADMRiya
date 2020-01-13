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
    public class ADMFollowUpController : Controller
    {
        // GET: ADMFollowUp
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Save(ADMFollowUpClass model)
        {
            MEMBERS.SQLReturnValue mRes = new ADMFollowUpLogic().ADMFollowUp_Insert_Update(model);
            return Json(mRes.Outval, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Get_GetAll(long id)
        {
            object data = new ADMFollowUpLogic().ADMFollowUp_Get_GetAll(id);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GeneralAction(long id, int ActionType)
        {
            MEMBERS.SQLReturnValue mRes = new ADMFollowUpLogic().ADMFollowUp_GeneralAction(id, ActionType);
            return Json(mRes.Outval, JsonRequestBehavior.AllowGet);
        }
    }
}