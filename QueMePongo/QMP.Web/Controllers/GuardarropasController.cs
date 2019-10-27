﻿using Ar.UTN.QMP.Lib.Entidades.Atuendos;
using Ar.UTN.QMP.Lib.Entidades.Contexto;
using Ar.UTN.QMP.Lib.Entidades.Usuarios;
using Ar.UTN.QMP.Web.Models.Usuarios;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Ar.UTN.QMP.Web.Controllers
{
    public class GuardarropasController : Controller
    {
        // GET: Guardarropas
        public ActionResult Index()
        {
            GuardarropaModel g = new GuardarropaModel();
            g.UsuarioId = Int32.Parse(Session["UsrID"].ToString());
            return View(g);
        }

        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Crear(GuardarropaModel model)
        {
            try
            {
                using (QueMePongoDB db = new QueMePongoDB())
                {
                    Usuario usr = db.Usuarios.Find(Int32.Parse(Session["UsrID"].ToString()));
                    db.Entry(usr).Collection(u => u.Guardarropas).Load();

                    if (usr.Guardarropas.Count >= 2)
                        throw new Exception("Ya posee 2 guardarropas. No puede agregan nuevos guardarropas.");
                    Guardarropa g = new Guardarropa(usr.MaximoPrendas);
                    g.Nombre = model.Nombre;
                    usr.AgregarGuardarropa(g);

                    db.Guardarropas.Add(g);
                    db.SaveChanges();
                }
                ModelState.AddModelError(string.Empty, "Guardarropas creado con exito");
                return View();
            }
            catch(Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View();
            }
        }

        public ActionResult Listar()
        {
            try
            {
                using (QueMePongoDB db = new QueMePongoDB())
                {
                    Usuario usr = db.Usuarios.Find(Int32.Parse(Session["UsrID"].ToString()));
                    db.Entry(usr).Collection(u => u.Guardarropas).Load();
                    foreach (Guardarropa unGuardarropa in usr.Guardarropas)
                    {
                        db.Entry(unGuardarropa).Collection(g => g.Prendas).Load();
                    }

                    return View(usr.Guardarropas);
                }
            }
            catch(Exception ex)
            {
                return View();
            }
        }
    }
}