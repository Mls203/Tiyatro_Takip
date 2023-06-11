using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tiyatro_Takip.Models
{
    public class DropdownTiyatroBaglanti
    {
        public int kategoriId { get; set; }
        public int Id { get; set; }
        public List<SelectListItem> KategoriList { get; set; }
        public List<SelectListItem> KonuList { get; set; }
    }
}