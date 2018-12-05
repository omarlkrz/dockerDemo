using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi10.Models;

namespace WebApi10.Controllers
{
    public class TypeDeviceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        // GET: TypeDevice/GetAllTypeDevice
        [HttpGet]
        public JsonResult GetAllTypeDevices()
        {
            using (db_inventaireContext context = new db_inventaireContext())
            {
                List<TypeDevice> types = context.TypeDevice.ToList();

                return Json(types);
            }


        }

        // GET: TypeDevice/ApiTypeDevice/5
        [HttpGet]
        public JsonResult GetTypeDevice(int id)
        {
            using (db_inventaireContext context = new db_inventaireContext())
            {
                TypeDevice type = context.TypeDevice.FirstOrDefault(t => t.IdTypeDev == id);
                TypeDevice device = new TypeDevice();
                device.IdTypeDev = type.IdTypeDev;
                device.Description = type.Description;

                return Json(device);
            }
        }


    }
}