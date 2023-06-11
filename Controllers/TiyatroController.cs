using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Tiyatro_Takip.Models;

namespace Tiyatro_Takip.Controllers
{
    public class TiyatroController : Controller
    {
        private TiyatroEntities2 db = new TiyatroEntities2();
        
        public ActionResult TiyatroKategori(int tiyatro_konu_id)
        {

            string kategoriismi = (from k in db.Tiyatro_Konusu
                                   where k.Id == tiyatro_konu_id
                                   select k.konu).FirstOrDefault();

            ViewBag.Title = kategoriismi +" " + "listesi";
            ViewBag.Id = kategoriismi;

            List<Tiyatro> filtre = (from m in db.Tiyatro
                                  where m.tiyatro_konu == tiyatro_konu_id
                                    select m).ToList();

            return View(filtre);
        }



        public ActionResult Create()
        {
            ViewBag.tiyatroKategori = new SelectList(db.tiyatro_kategori, "kategoriId", "kategoriAdi");
            ViewBag.sahneturu = new SelectList(db.Sahne_Turu, "Id", "sahne_türü");
            ViewBag.tiyatroKonu = new SelectList(db.Tiyatro_Konusu, "Id", "konu");
            return View();
        }

        [HttpPost]
         public ActionResult Create(Tiyatro tiyatro)
        {
                db.Tiyatro.Add(tiyatro);
                db.SaveChanges();
                return RedirectToAction("TiyatroKategori", "Tiyatro", new { tiyatro_konu_id=tiyatro.tiyatro_konu});
        }

        public ActionResult Edit(int id)
        {

            List<SelectListItem> tiyatro_kategori = new List<SelectListItem>();
            tiyatro_kategori.Add(new SelectListItem { Text = "Moders", Value = "1" });
            tiyatro_kategori.Add(new SelectListItem { Text = "Geleneksel", Value = "2" });
            ViewBag.tiyatroKategori = tiyatro_kategori;

            List<SelectListItem> sahne_türü = new List<SelectListItem>();
            sahne_türü.Add(new SelectListItem { Text = "Sezonun Yenileri", Value = "1" });
            sahne_türü.Add(new SelectListItem { Text = "Sezondakiler", Value = "2" });
            ViewBag.sahnetürü = sahne_türü;


            List<SelectListItem> tiyatro_konu = new List<SelectListItem>();
            tiyatro_konu.Add(new SelectListItem { Text = "Komedi", Value = "1" });
            tiyatro_konu.Add(new SelectListItem { Text = "Trajedi", Value = "2" });
            tiyatro_konu.Add(new SelectListItem { Text = "Drama", Value = "3" });
            tiyatro_konu.Add(new SelectListItem { Text = "Kukla", Value = "4" });
            tiyatro_konu.Add(new SelectListItem { Text = "Orta Oyun", Value = "6" });
            tiyatro_konu.Add(new SelectListItem { Text = "köy Seyirleri Oyunu", Value = "7" });
            ViewBag.tiyatroKonu = tiyatro_konu;



            var edit =  db.Tiyatro.Where(t => t.Id == id).FirstOrDefault();
            return View(edit);
        }



        [HttpPost]  
        public ActionResult Edit( Tiyatro tiyatro)
        {
            db.Entry(tiyatro).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("TiyatroKategori", "Tiyatro", new { tiyatro_konu_id = tiyatro.tiyatro_konu });

        }



        //public ActionResult Delete(int? id)
        //{
          
        //    Tiyatro tiyatro = db.Tiyatro.Find(id);
        //    return View(tiyatro);
        //}
        public ActionResult Delete(int ?id)
        {
            Tiyatro tiyatro = db.Tiyatro.Find(id);
            db.Tiyatro.Remove(tiyatro);
            db.SaveChanges();
            return RedirectToAction("TiyatroKategori", "Tiyatro", new { tiyatro_konu_id = tiyatro.tiyatro_konu });

        }





        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tiyatro tiyatro = db.Tiyatro.Find(id);
            if (tiyatro == null)
            {
                return HttpNotFound();
            }
            return View(tiyatro);
        }

    }
}