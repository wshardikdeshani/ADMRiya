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
        public ActionResult Index(long id)
        {
            ViewBag.ID = id;
            return View();
        }

        [HttpPost]
        public JsonResult GetAllFollowUp(long id)
        {
            object data = new ADMFollowUpLogic().ADMFollowUp_GetAll_ByADMIDF(id);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}