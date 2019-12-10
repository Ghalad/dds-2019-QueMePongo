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
            Prenda prenda;
            Guardarropa guardarropa;

            GestorCaracteristicas GeCa = GestorCaracteristicas.GetInstance();

            using (QueMePongoDB db = new QueMePongoDB())
            {
                prenda = new Prenda();

                pb.CrearPrenda()
                    .ConCategoria(GeCa.Caracteristicas.Where(c => c.CaracteristicaId.Equals(categoriaID)).FirstOrDefault().Valor)
                    .ConTipo(GeCa.Caracteristicas.Where(c => c.CaracteristicaId.Equals(tipoID)).FirstOrDefault().Valor)
                    .ConMaterial(GeCa.Caracteristicas.Where(c => c.CaracteristicaId.Equals(materialID)).FirstOrDefault().Valor)
                    .ConColor(GeCa.Caracteristicas.Where(c => c.CaracteristicaId.Equals(colorPrimeroID)).FirstOrDefault().Valor)
                    .ConEvento(GeCa.Caracteristicas.Where(c => c.CaracteristicaId.Equals(eventoID)).FirstOrDefault().Valor)
                    .ConImagen(imagen);

                Caracteristica car, carAux;
                prenda.AgregarCaracteristica(db.Caracteristicas.Find(categoriaID));
                car = db.Caracteristicas.Find(tipoID);
                prenda.AgregarCaracteristica(car);
                carAux = db.Caracteristicas.Where(c2 => c2.Nombre == "SUPERPOSICION" && c2.Clave == car.Valor).FirstOrDefault();
                prenda.AgregarCaracteristica(db.Caracteristicas.Where(c => c.Nombre == "CARACTERISTICA" && c.Clave == "SUPERPOSICION" && c.Valor == carAux.Valor).FirstOrDefault());
                carAux = db.Caracteristicas.Where(c2 => c2.Nombre == "NIVELABRIGO" && c2.Clave == car.Valor).FirstOrDefault();
                prenda.AgregarCaracteristica(db.Caracteristicas.Where(c => c.Nombre == "CARACTERISTICA" && c.Clave == "ABRIGO" && c.Valor == carAux.Valor).FirstOrDefault());
                prenda.AgregarCaracteristica(db.Caracteristicas.Find(materialID));
                prenda.AgregarCaracteristica(db.Caracteristicas.Find(colorPrimeroID));
                prenda.AgregarCaracteristica(db.Caracteristicas.Find(eventoID));
                prenda.AgregarImagen(imagen);

                if (colorSecundarioID != 0)
                {
                    pb.ConColor(GeCa.Caracteristicas.Where(c => c.CaracteristicaId.Equals(colorSecundarioID)).FirstOrDefault().Valor);

                    prenda.AgregarCaracteristica(db.Caracteristicas.Find(colorSecundarioID));
                }

                guardarropa = db.Guardarropas.Find(guardarropaID);
                guardarropa.AgregarPrenda(prenda);

                db.Entry(guardarropa).State = System.Data.Entity.EntityState.Modified;
                foreach (Caracteristica caracteristica in prenda.Caracteristicas)
                {
                    db.Entry(caracteristica).State = System.Data.Entity.EntityState.Modified;
                }

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
