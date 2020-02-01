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
    public class StatusMasterController : Controller
    {
        // GET: StatusMaster
        public ActionResult Index()
        {
            if (GeneralClass.Role == null || GeneralClass.Role == string.Empty)
            {
                return Redirect(GeneralClass.LoginURL);
            }

            return View();
        }

        [HttpPost]
        public JsonResult Save(StatusMasterClass model)
        {
            MEMBERS.SQLReturnValue mRes = new StatusMasterLogic().StatusMaster_Insert_Update(model);
            return Json(mRes.Outval, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Get_GetAll(int id)
        {
            object data = new StatusMasterLogic().StatusMaster_Get_GetAll(id, null);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GeneralAction(int id, int ActionType)
        {
            MEMBERS.SQLReturnValue mRes = new StatusMasterLogic().StatusMaster_GeneralAction(id, ActionType);
            return Json(mRes.Outval, JsonRequestBehavior.AllowGet);
        }
    }
}