using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi10.Models;

namespace WebApi10.Controllers
{
    public class VendorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

       [HttpGet]
        public JsonResult GetAllVendors()
        {
            using (db_inventaireContext context = new db_inventaireContext())
            {
                List<Vendor> vendors = context.Vendor.ToList();

                return Json(vendors);
            }

        } 

        // GET: Vendor/GetVendor/5
        [HttpGet]
        public JsonResult GetVendor(int id)
        {
            using (db_inventaireContext context = new db_inventaireContext())
            {
                Vendor vendor = context.Vendor.FirstOrDefault(v => v.IdVendor == id);

                return Json(vendor);
            }
        }
        
    }
}