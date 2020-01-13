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
    public class ADMHeaderController : Controller
    {
        // GET: ADMHeader
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Save(ADMHeaderClass model)
        {
            MEMBERS.SQLReturnValue mRes = new ADMHeaderLogic().ADMHeader_Insert_Update(model);
            return Json(mRes.Outval, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Get_GetAll(long id)
        {
            object data = new ADMHeaderLogic().ADMHeader_Get_GetAll(id, null);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GeneralAction(long id, int ActionType)
        {
            MEMBERS.SQLReturnValue mRes = new ADMHeaderLogic().ADMHeader_GeneralAction(id, ActionType);
            return Json(mRes.Outval, JsonRequestBehavior.AllowGet);
        }
    }
}