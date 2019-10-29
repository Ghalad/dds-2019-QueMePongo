using Ar.UTN.QMP.Lib.Entidades.Atuendos;
using Ar.UTN.QMP.Lib.Entidades.Contexto;
using Ar.UTN.QMP.Lib.Entidades.Usuarios;
using Ar.UTN.QMP.Web.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ar.UTN.QMP.Web.Controllers
{
    public class PrendasController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Crear()
        {
            PrendaModel model = new PrendaModel();
            
            try
            {
                LoadPrendaModel(model);
                return View(model);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                LoadPrendaModel(model);
                return View();
            }
        }

        [HttpPost]
        public ActionResult Crear(PrendaModel model, HttpPostedFileBase file)
        {
            PrendaBuilder pb = new PrendaBuilder();
            GestorCaracteristicas GeCa;
            Prenda prenda;
            Guardarropa guardarropa;
            int guardarropaId, categoriaId, tipoId, materialId, colorPrimeroId, colorSecundarioId, eventoId;

            try
            {
                GeCa = GestorCaracteristicas.GetInstance();

                if (!Int32.TryParse(model.SelectedGuardarropaId, out guardarropaId) ||
                    !Int32.TryParse(model.SelectedCategoria, out categoriaId) ||
                    !Int32.TryParse(model.SelectedTipo, out tipoId) ||
                    !Int32.TryParse(model.SelectedMeterial, out materialId) ||
                    !Int32.TryParse(model.SelectedColorPrimario, out colorPrimeroId) ||
                    !Int32.TryParse(model.SelectedEvento, out eventoId))
                {
                    throw new Exception("Debe seleccionar Guardarropa, Categoria, Tipo, Material, Color Primario y Evento, obligatoriamente.");
                }

                if (Int32.TryParse(model.SelectedColorSecundario, out colorSecundarioId))
                {
                    pb.CrearPrenda()
                      .ConCategoria(GeCa.Caracteristicas.Where(c => c.CaracteristicaId.Equals(categoriaId)).FirstOrDefault().Valor)
                      .ConTipo(GeCa.Caracteristicas.Where(c => c.CaracteristicaId.Equals(tipoId)).FirstOrDefault().Valor)
                      .ConMaterial(GeCa.Caracteristicas.Where(c => c.CaracteristicaId.Equals(materialId)).FirstOrDefault().Valor)
                      .ConColor(GeCa.Caracteristicas.Where(c => c.CaracteristicaId.Equals(colorPrimeroId)).FirstOrDefault().Valor)
                      .ConColor(GeCa.Caracteristicas.Where(c => c.CaracteristicaId.Equals(colorSecundarioId)).FirstOrDefault().Valor)
                      .ConEvento(GeCa.Caracteristicas.Where(c => c.CaracteristicaId.Equals(eventoId)).FirstOrDefault().Valor);
                }
                else
                {
                    pb.CrearPrenda()
                      .ConCategoria(GeCa.Caracteristicas.Where(c => c.CaracteristicaId.Equals(categoriaId)).FirstOrDefault().Valor)
                      .ConTipo(GeCa.Caracteristicas.Where(c => c.CaracteristicaId.Equals(tipoId)).FirstOrDefault().Valor)
                      .ConMaterial(GeCa.Caracteristicas.Where(c => c.CaracteristicaId.Equals(materialId)).FirstOrDefault().Valor)
                      .ConColor(GeCa.Caracteristicas.Where(c => c.CaracteristicaId.Equals(colorPrimeroId)).FirstOrDefault().Valor)
                      .ConEvento(GeCa.Caracteristicas.Where(c => c.CaracteristicaId.Equals(eventoId)).FirstOrDefault().Valor);
                }

                if (file != null && file.ContentLength > 0)
                {
                    using (BinaryReader br = new BinaryReader(file.InputStream))
                    {
                        pb.ConImagen(br.ReadBytes(file.ContentLength));
                    }
                }
                else
                {
                    Image _im = Image.FromFile(Server.MapPath(@"~/Content/images/imgNoDisponible.png"));
                    MemoryStream ms = new MemoryStream();
                    _im.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    pb.ConImagen(ms.ToArray());
                }

                using (QueMePongoDB db = new QueMePongoDB())
                {
                    guardarropa = db.Guardarropas.Find(Int32.Parse(model.SelectedGuardarropaId));
                    db.Entry(guardarropa).Collection(g => g.Prendas).Load();
                    prenda = pb.ObtenerPrenda();
                    guardarropa.AgregarPrenda(prenda);

                    db.Prendas.Attach(prenda);
                    db.Entry(prenda).State = System.Data.Entity.EntityState.Added;
                    foreach (Caracteristica caracteristica in prenda.Caracteristicas)
                        db.Entry(caracteristica).State = System.Data.Entity.EntityState.Unchanged;
                    db.SaveChanges();
                }

                model = new PrendaModel();
                LoadPrendaModel(model);
                ModelState.AddModelError(string.Empty, "Prenda creada con exito");
                return View(model);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                LoadPrendaModel(model);
                return View(model);
            }
        }

        public ActionResult Listar()
        {
            PrendaModel model = new PrendaModel();

            try
            {
                LoadPrendaModel(model);
                return View(model);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                LoadPrendaModel(model);
                return View(model);
            }
        }

        [HttpPost]
        public ActionResult Listar(PrendaModel model)
        {
            string selectedG = model.SelectedGuardarropaId;

            Guardarropa guardarropa;
            try
            {
                using (QueMePongoDB db = new QueMePongoDB())
                {
                    guardarropa = db.Guardarropas.Find(Int32.Parse(model.SelectedGuardarropaId));
                    db.Entry(guardarropa).Collection(g => g.Prendas).Load();
                    foreach (Prenda prenda in guardarropa.Prendas)
                        db.Entry(prenda).Collection(p => p.Caracteristicas).Load();

                    LoadPrendaModel(model);

                    model.SelectedGuardarropaId = selectedG;
                    model.Prendas = guardarropa.Prendas;


                    return View(model);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                LoadPrendaModel(model);
                return View(model);
            }
        }


        private void LoadPrendaModel(PrendaModel model)
        {
            using (QueMePongoDB db = new QueMePongoDB())
            {
                GestorCaracteristicas GeCa = GestorCaracteristicas.GetInstance();
                Usuario usr = db.Usuarios.Find(Session["UsrID"]);
                db.Entry(usr).Collection(u => u.Guardarropas).Load();

                model.Guardarropas = usr.Guardarropas;

                model.Categorias = GeCa.Caracteristicas.Where(c => c.Clave.Equals("CATEGORIA")).ToList();
                model.Tipos = GeCa.Caracteristicas.Where(c => c.Clave.Equals("TIPO")).ToList();
                model.Materiales = GeCa.Caracteristicas.Where(c => c.Clave.Equals("MATERIAL")).ToList();
                model.Colores = GeCa.Caracteristicas.Where(c => c.Clave.Equals("COLOR")).ToList();
                model.Eventos = GeCa.Caracteristicas.Where(c => c.Clave.Equals("EVENTO")).ToList();
            }
        }
    }
}