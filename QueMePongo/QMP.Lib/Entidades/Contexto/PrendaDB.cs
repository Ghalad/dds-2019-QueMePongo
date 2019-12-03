using Ar.UTN.QMP.Lib.Entidades.Atuendos;
using System.Collections.Generic;
using System.Linq;

namespace Ar.UTN.QMP.Lib.Entidades.Contexto
{
    public class PrendaDB
    {

        public void Crear(int guardarropaID, int categoriaID, int tipoID, int materialID, int colorPrimeroID, int colorSecundarioID, int eventoID, byte[] imagen)
        {
            PrendaBuilder pb = new PrendaBuilder();
            GestorCaracteristicas GeCa;
            Prenda prenda;
            Guardarropa guardarropa;

            GeCa = GestorCaracteristicas.GetInstance();

            if (colorSecundarioID != 0)
            {
                pb.CrearPrenda()
                    .ConCategoria(GeCa.Caracteristicas.Where(c => c.CaracteristicaId.Equals(categoriaID)).FirstOrDefault().Valor)
                    .ConTipo(GeCa.Caracteristicas.Where(c => c.CaracteristicaId.Equals(tipoID)).FirstOrDefault().Valor)
                    .ConMaterial(GeCa.Caracteristicas.Where(c => c.CaracteristicaId.Equals(materialID)).FirstOrDefault().Valor)
                    .ConColor(GeCa.Caracteristicas.Where(c => c.CaracteristicaId.Equals(colorPrimeroID)).FirstOrDefault().Valor)
                    .ConColor(GeCa.Caracteristicas.Where(c => c.CaracteristicaId.Equals(colorSecundarioID)).FirstOrDefault().Valor)
                    .ConEvento(GeCa.Caracteristicas.Where(c => c.CaracteristicaId.Equals(eventoID)).FirstOrDefault().Valor)
                    .ConImagen(imagen);
            }
            else
            {
                pb.CrearPrenda()
                    .ConCategoria(GeCa.Caracteristicas.Where(c => c.CaracteristicaId.Equals(categoriaID)).FirstOrDefault().Valor)
                    .ConTipo(GeCa.Caracteristicas.Where(c => c.CaracteristicaId.Equals(tipoID)).FirstOrDefault().Valor)
                    .ConMaterial(GeCa.Caracteristicas.Where(c => c.CaracteristicaId.Equals(materialID)).FirstOrDefault().Valor)
                    .ConColor(GeCa.Caracteristicas.Where(c => c.CaracteristicaId.Equals(colorPrimeroID)).FirstOrDefault().Valor)
                    .ConEvento(GeCa.Caracteristicas.Where(c => c.CaracteristicaId.Equals(eventoID)).FirstOrDefault().Valor)
                    .ConImagen(imagen);
            }

            using (QueMePongoDB db = new QueMePongoDB())
            {
                guardarropa = db.Guardarropas.Find(guardarropaID);
                db.Entry(guardarropa).Collection(g => g.Prendas).Load();
                prenda = pb.ObtenerPrenda();
                guardarropa.AgregarPrenda(prenda);

                db.Prendas.Attach(prenda);
                db.Entry(prenda).State = System.Data.Entity.EntityState.Added;
                foreach (Caracteristica caracteristica in prenda.Caracteristicas)
                    db.Entry(caracteristica).State = System.Data.Entity.EntityState.Unchanged;
                db.SaveChanges();
            }
        }


        public ICollection<Prenda> Listar(int guardarropaID)
        {
            using (QueMePongoDB db = new QueMePongoDB())
            {
                Guardarropa guardarropa = db.Guardarropas.Find(guardarropaID);
                db.Entry(guardarropa).Collection(g => g.Prendas).Load();
                foreach (Prenda prenda in guardarropa.Prendas)
                    db.Entry(prenda).Collection(p => p.Caracteristicas).Load();
                
                return guardarropa.Prendas;
            }
        }
    }
}
