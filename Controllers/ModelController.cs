using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi10.ModelLocal;
using WebApi10.Models;

namespace WebApi10.Controllers
{
    public class ModelController : Controller
    
    {

     
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetAllModels()
        {
            using (db_inventaireContext context = new db_inventaireContext())
            {
                List<Modele> models = context.Modele.OrderBy(m => m.IdTypeDev).ToList();

                return Json(models);
            }

        }


        [HttpPost]

        public JsonResult GetModels([FromBody] CritereModel model)
        {



            List<Modele> model1s = new List<Modele>();


            bool all = true;
            bool repeat = false;

            using (db_inventaireContext context = new db_inventaireContext())
            {

                if (model.IdTypeDev != 0)
                {
                    all = false;

                    model1s = context.Modele.Where(m => m.IdTypeDev == model.IdTypeDev).OrderBy(m => m.IdTypeDev).ToList();
                    if (model1s.Count() > 0)
                    {
                        repeat = true;
                    }



                }


                if (model.CodeVendor != 0)
                {
                    all = false;
                    if (repeat == false)
                    {
                        model1s = context.Modele.Where(m => m.CodeVendor == model.CodeVendor).OrderBy(m => m.IdTypeDev).ToList();
                    }
                    else
                    {
                        var req = from m1 in context.Modele.ToList()
                                  join m2 in model1s on m1.CodeModel equals m2.CodeModel
                                  where m1.CodeVendor == model.CodeVendor
                                  orderby m1.IdTypeDev
                                  select m1;
                        model1s = req.ToList();
                    }

                    if (model1s.Count() > 0)
                    {
                        repeat = true;
                    }

                }


                if ((model.SNDetectable == 1))
                {
                    all = false;

                    if (repeat == false)
                    {
                        model1s = context.Modele.Where(m => m.SnDetectable == true).OrderBy(m => m.IdTypeDev).ToList();
                    }
                    else
                    {
                        var req = from m1 in context.Modele
                                  join m2 in model1s on m1.CodeModel equals m2.CodeModel
                                  where m1.SnDetectable == true
                                  orderby m1.IdTypeDev
                                  select m1;
                        model1s = req.ToList();
                    }

                    if (model1s.Count() > 0)
                    {
                        repeat = true;
                    }


                }

                if (model.SNDetectable == 2)
                {
                    all = false;
                    if (repeat == false)
                    {
                        model1s = context.Modele.Where(m => m.SnDetectable == false).OrderBy(m => m.IdTypeDev).ToList();
                    }
                    else
                    {
                        var req = from m1 in context.Modele
                                  join m2 in model1s on m1.CodeModel equals m2.CodeModel
                                  where m1.SnDetectable == false
                                  orderby m1.IdTypeDev
                                  select m1;
                        model1s = req.ToList();
                    }

                    if (model1s.Count() > 0)
                    {
                        repeat = true;
                    }
                }


                if (model.ModelDetectable == 1)
                {

                    all = false;

                    if (repeat == false)
                    {
                        model1s = context.Modele.Where(m => m.ModelDetectable == true).OrderBy(m => m.IdTypeDev).ToList();
                    }
                    else
                    {
                        var req = from m1 in context.Modele
                                  join m2 in model1s on m1.CodeModel equals m2.CodeModel
                                  where m1.ModelDetectable == true
                                  orderby m1.IdTypeDev
                                  select m1;
                        model1s = req.ToList();
                    }

                    if (model1s.Count() > 0)
                    {
                        repeat = true;
                    }

                }


                if (model.ModelDetectable == 2)
                {
                    all = false;

                    if (repeat == false)
                    {
                        model1s = context.Modele.Where(m => m.ModelDetectable == false).OrderBy(m => m.IdTypeDev).ToList();
                    }
                    else
                    {
                        var req = from m1 in context.Modele
                                  join m2 in model1s on m1.CodeModel equals m2.CodeModel
                                  where m1.ModelDetectable == false
                                  orderby m1.IdTypeDev
                                  select m1;
                        model1s = req.ToList();
                    }

                    if (model1s.Count() > 0)
                    {
                        repeat = true;
                    }

                }



                if (!model.Description.Equals("rien"))
                {
                    all = false;

                    if (repeat == false)
                    {
                        model1s = context.Modele.Where(m => m.Description.Equals(model.Description)).OrderBy(m => m.IdTypeDev).ToList();
                    }
                    else
                    {
                        var req = from m1 in context.Modele
                                  join m2 in model1s on m1.CodeModel equals m2.CodeModel
                                  where m1.Description.Equals(model.Description)
                                  orderby m1.IdTypeDev
                                  select m1;
                        model1s = req.ToList();
                    }

                    if (model1s.Count() > 0)
                    {
                        repeat = true;
                    }

                }

                if (!model.Propriete.Equals("rien"))
                {
                    all = false;

                    if (repeat == false)
                    {
                        model1s = context.Modele.Where(m => m.Propriete.Equals(model.Propriete)).OrderBy(m => m.IdTypeDev).ToList();
                    }
                    else
                    {
                        var req = from m1 in context.Modele
                                  join m2 in model1s on m1.CodeModel equals m2.CodeModel
                                  where m1.Propriete.Equals(model.Propriete)
                                  orderby m1.IdTypeDev
                                  select m1;
                        model1s = req.ToList();
                    }

                    if (model1s.Count() > 0)
                    {
                        repeat = true;
                    }

                }


                if (all == false)
                {

                    return Json(model1s);
                }
                else
                {
                    return GetAllModels();

                }

            }


        }


        ////// Les actions suivantes pour l ajout et la modification d un model

        [HttpPost]

        public JsonResult AddModel([FromBody] Modele modele)
        {
            using (db_inventaireContext context = new db_inventaireContext())
            {
                Modele model = context.Modele.Find(modele.CodeModel);

                if (model == null)
                {
                    context.Modele.Add(modele);
                    context.SaveChanges();
                }
                else
                {
                    UpdateModel(modele);
                }
                return Json(modele);
            }

        }



        [HttpPut]
        public JsonResult UpdateModel([FromBody] Modele modele)
        {
            using (db_inventaireContext context = new db_inventaireContext())
            {

                context.Modele.Update(modele);
                context.SaveChanges();

            }
            
              return Json(modele);


        }





    }


}