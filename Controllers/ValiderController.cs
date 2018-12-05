using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi10.ModelLocal;
using WebApi10.Models;

namespace WebApi10.Controllers
{
    public class ValiderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetEquipmentsByPost()
        {
            using (db_inventaireContext context = new db_inventaireContext())
            {
                List<TempInvent> equipments = context.TempInvent.ToList();
                List<EquipmentConnected> equipmentsConnected = new List<EquipmentConnected>();
                foreach(TempInvent e in equipments)
                {
                    Modele modele = context.Modele.SingleOrDefault(e2 => e2.Description.Equals(e.ModelName));


                    EquipmentConnected equipment = new EquipmentConnected();
                    if (modele == null)
                    {
                        equipment.exist = false;
                    }
                    else
                    {
                        equipment.SNDetected = modele.SnDetectable;
                    }

                        equipment.ModelDetected = e.ModelDetected;
                        equipment.vendorDetected = e.VendorDetected;
                        equipment.SN = e.Sn;
                        equipment.NomPost = e.NomPost;
                        equipment.ModelName = e.ModelName;
                        equipment.VendorName = e.VendorName;
                        equipment.Type = e.Type;
                  
                    equipmentsConnected.Add(equipment);

                }

                return Json(equipmentsConnected);
            }
        }

    }
}