using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tiyatro_Takip.Models;
using System.Linq.Dynamic.Core;

namespace Tiyatro_Takip.Controllers
{
    public class UyelerController : Controller
    {
        public ActionResult Index(string sort = "UyeAdi", string sortdir = "asc", string search = "")

        {
            int totalRecord = 0;
            var data = GetUyeler(search, sort, sortdir, out totalRecord);
            ViewBag.TotalRows = totalRecord;
            ViewBag.search = search;
            return View(data);
        }

        public List<Uyeler> GetUyeler(string search, string sort, string sortdir, out int totalRecord)

        {
           
            using (TiyatroEntities2 db = new TiyatroEntities2())
            {
                var v = (from a in db.Uyeler

                         where a.UyeAdi.Contains(search) ||
                         a.UyeSoyadi.Contains(search) ||
                         a.UyeTc.Contains(search) ||
                         a.UyeAdres.Contains(search)
                         select a
                );

                totalRecord = v.Count();
                v = v.OrderBy(sort + " " + sortdir);
                return v.ToList();
            }
        }



    }
}