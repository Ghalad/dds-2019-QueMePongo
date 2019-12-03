using Ar.UTN.QMP.Lib.Entidades.Atuendos;
using Ar.UTN.QMP.Lib.Entidades.Contexto;
using Ar.UTN.QMP.Web.Models;
using System;
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
            PrendaDB p = new PrendaDB();
            int guardarropaId, categoriaId, tipoId, materialId, colorPrimeroId, colorSecundarioId = 0, eventoId;

            try
            {
                if (!Int32.TryParse(model.SelectedGuardarropaId, out guardarropaId) ||
                    !Int32.TryParse(model.SelectedCategoria, out categoriaId) ||
                    !Int32.TryParse(model.SelectedTipo, out tipoId) ||
                    !Int32.TryParse(model.SelectedMeterial, out materialId) ||
                    !Int32.TryParse(model.SelectedColorPrimario, out colorPrimeroId) ||
                    !Int32.TryParse(model.SelectedEvento, out eventoId))
                {
                    throw new Exception("Debe seleccionar Guardarropa, Categoria, Tipo, Material, Color Primario y Evento, obligatoriamente.");
                }
                
                if (file != null && file.ContentLength > 0)
                {
                    using (BinaryReader br = new BinaryReader(file.InputStream))
                    {
                        p.Crear(guardarropaId, categoriaId, tipoId, materialId, colorPrimeroId, colorSecundarioId, eventoId, br.ReadBytes(file.ContentLength));
                    }
                }
                else
                {
                    Image _im = Image.FromFile(Server.MapPath(@"~/Content/images/imgNoDisponible.png"));
                    MemoryStream ms = new MemoryStream();
                    _im.Save(ms, System.Drawing.Imaging.ImageFormat.Png);

                    p.Crear(guardarropaId, categoriaId, tipoId, materialId, colorPrimeroId, colorSecundarioId, eventoId, ms.ToArray());
                }


                model = new PrendaModel();
                LoadPrendaModel(model);
                ModelState.AddModelError(string.Empty, "Prenda creada con exito.");
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
            PrendaDB p = new PrendaDB();
            try
            {
                LoadPrendaModel(model);

                model.SelectedGuardarropaId = model.SelectedGuardarropaId;
                model.Prendas = p.Listar(Int32.Parse(model.SelectedGuardarropaId));
                
                return View(model);
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
            GuardarropaDB g = new GuardarropaDB();
            GestorCaracteristicas GeCa = GestorCaracteristicas.GetInstance();
                
            model.Guardarropas = g.ObtenerGuardarropas(Int32.Parse(Session["UsrID"].ToString()));
            model.Categorias = GeCa.Caracteristicas.Where(c => c.Clave.Equals("CATEGORIA")).ToList();
            model.Tipos = GeCa.Caracteristicas.Where(c => c.Clave.Equals("TIPO")).ToList();
            model.Materiales = GeCa.Caracteristicas.Where(c => c.Clave.Equals("MATERIAL")).ToList();
            model.Colores = GeCa.Caracteristicas.Where(c => c.Clave.Equals("COLOR")).ToList();
            model.Eventos = GeCa.Caracteristicas.Where(c => c.Clave.Equals("EVENTO")).ToList();
        }
    }
}