using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;
namespace FORUM_WEB_2._0.Controllers
{
    public class ThreadPageController : Controller
    {
        // GET: ThreadPage
        public ActionResult ThreadPage(int id, int? page)
        {
            ViewBag.id_cd = id;
            if (page == null) page = 1;
            int pageSize = 15;
            int pageNumber = (page ?? 1);
            Models.FrameWorks.FORUM_WEB_V2Entities db = new Models.FrameWorks.FORUM_WEB_V2Entities();
            var lst = new List<Models.FrameWorks.BaiDang>();
            lst = db.BaiDang.Where(x => x.ID_ChuDe == id).ToList();
            return View((lst.ToPagedList(pageNumber, pageSize)));
        }
    }
}