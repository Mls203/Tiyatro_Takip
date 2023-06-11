using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tiyatro_Takip.Models;

namespace Tiyatro_Takip.Controllers
{
    public class DropDownTiyatroController : Controller
    {
            DropdownTiyatroBaglanti model = new DropdownTiyatroBaglanti();
            TiyatroEntities2 db = new TiyatroEntities2();
            public ActionResult Menu()
            {
                List<tiyatro_kategori> KategoriList = db.tiyatro_kategori.OrderBy(f => f.kategoriAdi).ToList();
                model.KategoriList = (from u in KategoriList
                                      select new SelectListItem
                                      {
                                          Text = u.kategoriAdi,
                                          Value = u.kategoriId.ToString()

                                      }
                                      ).ToList();
                return View(model);
            }

            [HttpPost]
            public JsonResult GetKonuList(int id)
            {
                List<Tiyatro_Konusu> KonuList = db.Tiyatro_Konusu.Where(f => f.kategoriId == id).OrderBy(f => f.konu).ToList();
                List<SelectListItem> itemlist = (from m in KonuList
                                                 select new SelectListItem
                                                 {
                                                     Text = m.konu,
                                                     Value = m.Id.ToString()
                                                 }).ToList();

                return Json(itemlist, JsonRequestBehavior.AllowGet);
            }

        
    }
}