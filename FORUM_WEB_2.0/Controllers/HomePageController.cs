using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FORUM_WEB_2._0.Controllers
{
    public class HomePageController : Controller
    {
        // GET: HomePage
        public ActionResult HomePage()
        {
            var session = (UserLogin)Session[FORUM_WEB_2._0.Common.CommonSession.USER_LOGIN];
            if (session == null)
            {
                return RedirectToAction("Login", "Login");
            }
            var lst = new List<Models.FrameWorks.ChuDe>();
            Models.FrameWorks.FORUM_WEB_V2Entities db = new Models.FrameWorks.FORUM_WEB_V2Entities();
            lst = db.ChuDe.ToList();
            return View(lst);
        }
    }
}