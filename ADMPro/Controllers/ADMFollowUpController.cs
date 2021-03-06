﻿using System;
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
    public class ADMFollowUpController : Controller
    {
        // GET: ADMFollowUp - 28.02.2020
        public ActionResult Index(long id)
        {
            if (GeneralClass.Role == null || GeneralClass.Role == string.Empty)
            {
                return Redirect(GeneralClass.LoginURL);
            }

            ViewBag.ID = id;

            object dataStatus = new StatusMasterLogic().StatusMaster_Get_GetAll(0, true);

            if (dataStatus != null)
            {
                ViewBag.StatusList = JsonConvert.DeserializeObject<List<StatusMasterClass>>(dataStatus.ToString());
            }

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