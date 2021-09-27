using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web;
using System.Web.Mvc;


using PCLService.Models;

namespace PCLService.Controllers
{
    public class HomeController : Controller
    {
#if DEBUG
        private const string PASSWORD = "test";
#else
        private const string PASSWORD = "79grV2?T-4$xQ";
#endif
        private const string LASTPASSKEY = "LastPass"; // Cache key for last bad password attempt
        private const int TIMEOUT = 10; // # of seconds required after a bad password attempt

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View(new Home());
        }

        [HttpPost]
        public ActionResult Index(Home data)
        {

            // Check for last bad password attempt
            DateTime last = DataCache.Get<DateTime>(LASTPASSKEY);
            if (data.Password != PASSWORD || (last != default && DateTime.Now.Subtract(last).TotalSeconds < TIMEOUT))
            {
                DataCache.Add(LASTPASSKEY, DateTime.Now);
                return View(new Home() { ShowError = true, TimeoutValue = TIMEOUT });
            }

            data.CallLetter.SaveAs(HttpContext.Request.MapPath(@"~\PastorCallLetter.docx"));
            return View(new Home() { ShowSuccess = true });
        }

    }
}
