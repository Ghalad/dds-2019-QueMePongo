using Ar.UTN.QMP.Lib.Entidades.Atuendos;
using System.Collections.Generic;
using System.Data.Entity;

namespace Ar.UTN.QMP.Lib.Entidades.Contexto
{
    public class QueMePongoDBInitializer : DropCreateDatabaseIfModelChanges<QueMePongoDB>
    {
        protected override void Seed(QueMePongoDB context)
        {
            IList<Caracteristica> listaCar = new List<Caracteristica>();
            /*
            listaCar.Add(new Caracteristica("caracteristica", "CATEGORIA", "ACCESORIO"));
            listaCar.Add(new Caracteristica("caracteristica", "CATEGORIA", "SUPERIOR"));
            listaCar.Add(new Caracteristica("caracteristica", "CATEGORIA", "INFERIOR"));
            listaCar.Add(new Caracteristica("caracteristica", "CATEGORIA", "CALZADO"));

            listaCar.Add(new Caracteristica("caracteristica", "TIPO", "GORRA"));
            listaCar.Add(new Caracteristica("caracteristica", "TIPO", "SOMBRERO"));
            listaCar.Add(new Caracteristica("caracteristica", "TIPO", "MUSCULOSA"));
            listaCar.Add(new Caracteristica("caracteristica", "TIPO", "REMERA_MANGA_CORTA"));
            listaCar.Add(new Caracteristica("caracteristica", "TIPO", "REMERA_MANGA_LARGA"));
            listaCar.Add(new Caracteristica("caracteristica", "TIPO", "CAMISA_MANGA_CORTA"));
            listaCar.Add(new Caracteristica("caracteristica", "TIPO", "CAMISA_MANGA_LARGA"));
            listaCar.Add(new Caracteristica("caracteristica", "TIPO", "SWEATER"));
            listaCar.Add(new Caracteristica("caracteristica", "TIPO", "CAMPERA_DE_ABRIGO"));
            listaCar.Add(new Caracteristica("caracteristica", "TIPO", "CAMPERA_DE_LLUVIA"));
            listaCar.Add(new Caracteristica("caracteristica", "TIPO", "PANTALON_CORTO"));
            listaCar.Add(new Caracteristica("caracteristica", "TIPO", "PANTALON_LARGO"));
            listaCar.Add(new Caracteristica("caracteristica", "TIPO", "POLLERA"));
            listaCar.Add(new Caracteristica("caracteristica", "TIPO", "MEDIAS"));
            listaCar.Add(new Caracteristica("caracteristica", "TIPO", "ZAPATO_TACO_ALTO"));
            listaCar.Add(new Caracteristica("caracteristica", "TIPO", "ZAPATO_TACO_BAJO"));
            listaCar.Add(new Caracteristica("caracteristica", "TIPO", "ZAPATILLA_DE_CORRER"));
            listaCar.Add(new Caracteristica("caracteristica", "TIPO", "ZAPATILLA_DE_TREKING"));
            listaCar.Add(new Caracteristica("caracteristica", "TIPO", "PANCHAS"));
            listaCar.Add(new Caracteristica("caracteristica", "TIPO", "OJOTAS"));

            listaCar.Add(new Caracteristica("caracteristica", "SUPERPOSICION", "1"));
            listaCar.Add(new Caracteristica("caracteristica", "SUPERPOSICION", "2"));
            listaCar.Add(new Caracteristica("caracteristica", "SUPERPOSICION", "3"));
            listaCar.Add(new Caracteristica("caracteristica", "SUPERPOSICION", "4"));

            listaCar.Add(new Caracteristica("caracteristica", "ABRIGO", "1"));
            listaCar.Add(new Caracteristica("caracteristica", "ABRIGO", "2"));
            listaCar.Add(new Caracteristica("caracteristica", "ABRIGO", "3"));
            listaCar.Add(new Caracteristica("caracteristica", "ABRIGO", "4"));
            listaCar.Add(new Caracteristica("caracteristica", "ABRIGO", "5"));
            listaCar.Add(new Caracteristica("caracteristica", "ABRIGO", "6"));

            listaCar.Add(new Caracteristica("caracteristica", "MATERIAL", "ALGODON"));
            listaCar.Add(new Caracteristica("caracteristica", "MATERIAL", "CUERO"));
            listaCar.Add(new Caracteristica("caracteristica", "MATERIAL", "HILO"));
            listaCar.Add(new Caracteristica("caracteristica", "MATERIAL", "CORDEROY"));
            listaCar.Add(new Caracteristica("caracteristica", "MATERIAL", "JEAN"));
            listaCar.Add(new Caracteristica("caracteristica", "MATERIAL", "GOMA"));
            listaCar.Add(new Caracteristica("caracteristica", "MATERIAL", "LANA"));
            listaCar.Add(new Caracteristica("caracteristica", "MATERIAL", "POLIESTER"));

            listaCar.Add(new Caracteristica("caracteristica", "COLOR", "NEGRO"));
            listaCar.Add(new Caracteristica("caracteristica", "COLOR", "GRIS"));
            listaCar.Add(new Caracteristica("caracteristica", "COLOR", "AZUL"));
            listaCar.Add(new Caracteristica("caracteristica", "COLOR", "VERDE"));
            listaCar.Add(new Caracteristica("caracteristica", "COLOR", "VIOLETA"));
            listaCar.Add(new Caracteristica("caracteristica", "COLOR", "ROJO"));
            listaCar.Add(new Caracteristica("caracteristica", "COLOR", "NARANJA"));
            listaCar.Add(new Caracteristica("caracteristica", "COLOR", "AMARILLO"));
            listaCar.Add(new Caracteristica("caracteristica", "COLOR", "BLANCO"));

            listaCar.Add(new Caracteristica("caracteristica", "EVENTO", "TRABAJO"));
            listaCar.Add(new Caracteristica("caracteristica", "EVENTO", "SALIDA_AMIGOS"));
            listaCar.Add(new Caracteristica("caracteristica", "EVENTO", "CUMPLEAÑOS"));
            listaCar.Add(new Caracteristica("caracteristica", "EVENTO", "CASAMIENTO"));
            listaCar.Add(new Caracteristica("caracteristica", "EVENTO", "CASUAL"));

            listaCar.Add(new Caracteristica("superposicion", "GORRA", "1"));
            listaCar.Add(new Caracteristica("superposicion", "SOMBRERO", "1"));
            listaCar.Add(new Caracteristica("superposicion", "MUSCULOSA", "1"));
            listaCar.Add(new Caracteristica("superposicion", "REMERA_MANGA_CORTA", "1"));
            listaCar.Add(new Caracteristica("superposicion", "REMERA_MANGA_LARGA", "1"));
            listaCar.Add(new Caracteristica("superposicion", "CAMISA_MANGA_CORTA", "2"));
            listaCar.Add(new Caracteristica("superposicion", "CAMISA_MANGA_LARGA", "2"));
            listaCar.Add(new Caracteristica("superposicion", "SWEATER", "3"));
            listaCar.Add(new Caracteristica("superposicion", "CAMPERA_DE_ABRIGO", "4"));
            listaCar.Add(new Caracteristica("superposicion", "CAMPERA_DE_LLUVIA", "4"));
            listaCar.Add(new Caracteristica("superposicion", "PANTALON_CORTO", "2"));
            listaCar.Add(new Caracteristica("superposicion", "PANTALON_LARGO", "2"));
            listaCar.Add(new Caracteristica("superposicion", "POLLERA", "2"));
            listaCar.Add(new Caracteristica("superposicion", "MEDIAS", "1"));
            listaCar.Add(new Caracteristica("superposicion", "ZAPATO_TACO_ALTO", "2"));
            listaCar.Add(new Caracteristica("superposicion", "ZAPATO_TACO_BAJO", "2"));
            listaCar.Add(new Caracteristica("superposicion", "ZAPATILLA_DE_CORRER", "2"));
            listaCar.Add(new Caracteristica("superposicion", "ZAPATILLA_DE_TREKING", "2"));
            listaCar.Add(new Caracteristica("superposicion", "PANCHAS", "2"));
            listaCar.Add(new Caracteristica("superposicion", "OJOTAS", "2"));

            listaCar.Add(new Caracteristica("categoriatipo", "ACCESORIO", "GORRA"));
            listaCar.Add(new Caracteristica("categoriatipo", "ACCESORIO", "SOMBRERO"));
            listaCar.Add(new Caracteristica("categoriatipo", "SUPERIOR", "MUSCULOSA"));
            listaCar.Add(new Caracteristica("categoriatipo", "SUPERIOR", "REMERA_MANGA_CORTA"));
            listaCar.Add(new Caracteristica("categoriatipo", "SUPERIOR", "REMERA_MANGA_LARGA"));
            listaCar.Add(new Caracteristica("categoriatipo", "SUPERIOR", "CAMISA_MANGA_CORTA"));
            listaCar.Add(new Caracteristica("categoriatipo", "SUPERIOR", "CAMISA_MANGA_LARGA"));
            listaCar.Add(new Caracteristica("categoriatipo", "SUPERIOR", "SWEATER"));
            listaCar.Add(new Caracteristica("categoriatipo", "SUPERIOR", "CAMPERA_DE_ABRIGO"));
            listaCar.Add(new Caracteristica("categoriatipo", "SUPERIOR", "CAMPERA_DE_LLUVIA"));
            listaCar.Add(new Caracteristica("categoriatipo", "INFERIOR", "PANTALON_CORTO"));
            listaCar.Add(new Caracteristica("categoriatipo", "INFERIOR", "PANTALON_LARGO"));
            listaCar.Add(new Caracteristica("categoriatipo", "INFERIOR", "POLLERA"));
            listaCar.Add(new Caracteristica("categoriatipo", "CALZADO", "MEDIAS"));
            listaCar.Add(new Caracteristica("categoriatipo", "CALZADO", "ZAPATO_TACO_ALTO"));
            listaCar.Add(new Caracteristica("categoriatipo", "CALZADO", "ZAPATO_TACO_BAJO"));
            listaCar.Add(new Caracteristica("categoriatipo", "CALZADO", "ZAPATILLA_DE_CORRER"));
            listaCar.Add(new Caracteristica("categoriatipo", "CALZADO", "ZAPATILLA_DE_TREKING"));
            listaCar.Add(new Caracteristica("categoriatipo", "CALZADO", "PANCHAS"));
            listaCar.Add(new Caracteristica("categoriatipo", "CALZADO", "OJOTAS"));

            listaCar.Add(new Caracteristica("nivelabrigo", "GORRA", "2"));
            listaCar.Add(new Caracteristica("nivelabrigo", "SOMBRERO", "1"));
            listaCar.Add(new Caracteristica("nivelabrigo", "MUSCULOSA", "2"));
            listaCar.Add(new Caracteristica("nivelabrigo", "REMERA_MANGA_CORTA", "3"));
            listaCar.Add(new Caracteristica("nivelabrigo", "REMERA_MANGA_LARGA", "4"));
            listaCar.Add(new Caracteristica("nivelabrigo", "CAMISA_MANGA_CORTA", "3"));
            listaCar.Add(new Caracteristica("nivelabrigo", "CAMISA_MANGA_LARGA", "4"));
            listaCar.Add(new Caracteristica("nivelabrigo", "SWEATER", "5"));
            listaCar.Add(new Caracteristica("nivelabrigo", "CAMPERA_DE_ABRIGO", "6"));
            listaCar.Add(new Caracteristica("nivelabrigo", "CAMPERA_DE_LLUVIA", "4"));
            listaCar.Add(new Caracteristica("nivelabrigo", "PANTALON_CORTO", "3"));
            listaCar.Add(new Caracteristica("nivelabrigo", "PANTALON_LARGO", "4"));
            listaCar.Add(new Caracteristica("nivelabrigo", "POLLERA", "3"));
            listaCar.Add(new Caracteristica("nivelabrigo", "MEDIAS", "1"));
            listaCar.Add(new Caracteristica("nivelabrigo", "ZAPATO_TACO_ALTO", "2"));
            listaCar.Add(new Caracteristica("nivelabrigo", "ZAPATO_TACO_BAJO", "2"));
            listaCar.Add(new Caracteristica("nivelabrigo", "ZAPATILLA_DE_CORRER", "2"));
            listaCar.Add(new Caracteristica("nivelabrigo", "ZAPATILLA_DE_TREKING", "2"));
            listaCar.Add(new Caracteristica("nivelabrigo", "PANCHAS", "2"));
            listaCar.Add(new Caracteristica("nivelabrigo", "OJOTAS", "0"));

            context.Caracteristicas.AddRange(listaCar);
            */
            base.Seed(context);
        }
    }
}
