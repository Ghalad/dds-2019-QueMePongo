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

            #region CARGA_INICIAL
            listaCar.Add(new Caracteristica("CATEGORIA", "ACCESORIO"));
            listaCar.Add(new Caracteristica("CATEGORIA", "SUPERIOR"));
            listaCar.Add(new Caracteristica("CATEGORIA", "INFERIOR"));
            listaCar.Add(new Caracteristica("CATEGORIA", "CALZADO"));

            listaCar.Add(new Caracteristica("TIPO", "GORRA"));
            listaCar.Add(new Caracteristica("TIPO", "SOMBRERO"));
            listaCar.Add(new Caracteristica("TIPO", "MUSCULOSA"));
            listaCar.Add(new Caracteristica("TIPO", "REMERA_MANGA_CORTA"));
            listaCar.Add(new Caracteristica("TIPO", "REMERA_MANGA_LARGA"));
            listaCar.Add(new Caracteristica("TIPO", "CAMISA_MANGA_CORTA"));
            listaCar.Add(new Caracteristica("TIPO", "CAMISA_MANGA_LARGA"));
            listaCar.Add(new Caracteristica("TIPO", "SWEATER"));
            listaCar.Add(new Caracteristica("TIPO", "CAMPERA_DE_ABRIGO"));
            listaCar.Add(new Caracteristica("TIPO", "CAMPERA_DE_LLUVIA"));
            listaCar.Add(new Caracteristica("TIPO", "PANTALON_CORTO"));
            listaCar.Add(new Caracteristica("TIPO", "PANTALON_LARGO"));
            listaCar.Add(new Caracteristica("TIPO", "POLLERA"));
            listaCar.Add(new Caracteristica("TIPO", "MEDIAS"));
            listaCar.Add(new Caracteristica("TIPO", "ZAPATO_TACO_ALTO"));
            listaCar.Add(new Caracteristica("TIPO", "ZAPATO_TACO_BAJO"));
            listaCar.Add(new Caracteristica("TIPO", "ZAPATILLA_DE_CORRER"));
            listaCar.Add(new Caracteristica("TIPO", "ZAPATILLA_DE_TREKING"));
            listaCar.Add(new Caracteristica("TIPO", "PANCHAS"));
            listaCar.Add(new Caracteristica("TIPO", "OJOTAS"));

            listaCar.Add(new Caracteristica("SUPERPOSICION", "1"));
            listaCar.Add(new Caracteristica("SUPERPOSICION", "2"));
            listaCar.Add(new Caracteristica("SUPERPOSICION", "3"));
            listaCar.Add(new Caracteristica("SUPERPOSICION", "4"));

            listaCar.Add(new Caracteristica("ABRIGO", "0"));
            listaCar.Add(new Caracteristica("ABRIGO", "1"));
            listaCar.Add(new Caracteristica("ABRIGO", "2"));
            listaCar.Add(new Caracteristica("ABRIGO", "3"));
            listaCar.Add(new Caracteristica("ABRIGO", "4"));
            listaCar.Add(new Caracteristica("ABRIGO", "5"));
            listaCar.Add(new Caracteristica("ABRIGO", "6"));

            listaCar.Add(new Caracteristica("MATERIAL", "ALGODON"));
            listaCar.Add(new Caracteristica("MATERIAL", "CUERO"));
            listaCar.Add(new Caracteristica("MATERIAL", "HILO"));
            listaCar.Add(new Caracteristica("MATERIAL", "CORDEROY"));
            listaCar.Add(new Caracteristica("MATERIAL", "JEAN"));
            listaCar.Add(new Caracteristica("MATERIAL", "GOMA"));
            listaCar.Add(new Caracteristica("MATERIAL", "LANA"));
            listaCar.Add(new Caracteristica("MATERIAL", "POLIESTER"));

            listaCar.Add(new Caracteristica("COLOR", "NEGRO"));
            listaCar.Add(new Caracteristica("COLOR", "GRIS"));
            listaCar.Add(new Caracteristica("COLOR", "AZUL"));
            listaCar.Add(new Caracteristica("COLOR", "VERDE"));
            listaCar.Add(new Caracteristica("COLOR", "VIOLETA"));
            listaCar.Add(new Caracteristica("COLOR", "ROJO"));
            listaCar.Add(new Caracteristica("COLOR", "NARANJA"));
            listaCar.Add(new Caracteristica("COLOR", "AMARILLO"));
            listaCar.Add(new Caracteristica("COLOR", "BLANCO"));

            listaCar.Add(new Caracteristica("EVENTO", "TRABAJO"));
            listaCar.Add(new Caracteristica("EVENTO", "SALIDA_AMIGOS"));
            listaCar.Add(new Caracteristica("EVENTO", "CUMPLEAÑOS"));
            listaCar.Add(new Caracteristica("EVENTO", "CASAMIENTO"));
            listaCar.Add(new Caracteristica("EVENTO", "CASUAL"));

            listaCar.Add(new Caracteristica("superposicion", "GORRA",                "1"));
            listaCar.Add(new Caracteristica("superposicion", "SOMBRERO",             "1"));
            listaCar.Add(new Caracteristica("superposicion", "MUSCULOSA",            "1"));
            listaCar.Add(new Caracteristica("superposicion", "REMERA_MANGA_CORTA",   "1"));
            listaCar.Add(new Caracteristica("superposicion", "REMERA_MANGA_LARGA",   "1"));
            listaCar.Add(new Caracteristica("superposicion", "CAMISA_MANGA_CORTA",   "2"));
            listaCar.Add(new Caracteristica("superposicion", "CAMISA_MANGA_LARGA",   "2"));
            listaCar.Add(new Caracteristica("superposicion", "SWEATER",              "3"));
            listaCar.Add(new Caracteristica("superposicion", "CAMPERA_DE_ABRIGO",    "4"));
            listaCar.Add(new Caracteristica("superposicion", "CAMPERA_DE_LLUVIA",    "4"));
            listaCar.Add(new Caracteristica("superposicion", "PANTALON_CORTO",       "2"));
            listaCar.Add(new Caracteristica("superposicion", "PANTALON_LARGO",       "2"));
            listaCar.Add(new Caracteristica("superposicion", "POLLERA",              "2"));
            listaCar.Add(new Caracteristica("superposicion", "MEDIAS",               "1"));
            listaCar.Add(new Caracteristica("superposicion", "ZAPATO_TACO_ALTO",     "2"));
            listaCar.Add(new Caracteristica("superposicion", "ZAPATO_TACO_BAJO",     "2"));
            listaCar.Add(new Caracteristica("superposicion", "ZAPATILLA_DE_CORRER",  "2"));
            listaCar.Add(new Caracteristica("superposicion", "ZAPATILLA_DE_TREKING", "2"));
            listaCar.Add(new Caracteristica("superposicion", "PANCHAS",              "2"));
            listaCar.Add(new Caracteristica("superposicion", "OJOTAS",               "2"));

            listaCar.Add(new Caracteristica("categoriatipo", "ACCESORIO", "GORRA"));
            listaCar.Add(new Caracteristica("categoriatipo", "ACCESORIO", "SOMBRERO"));
            listaCar.Add(new Caracteristica("categoriatipo", "SUPERIOR",  "MUSCULOSA"));
            listaCar.Add(new Caracteristica("categoriatipo", "SUPERIOR",  "REMERA_MANGA_CORTA"));
            listaCar.Add(new Caracteristica("categoriatipo", "SUPERIOR",  "REMERA_MANGA_LARGA"));
            listaCar.Add(new Caracteristica("categoriatipo", "SUPERIOR",  "CAMISA_MANGA_CORTA"));
            listaCar.Add(new Caracteristica("categoriatipo", "SUPERIOR",  "CAMISA_MANGA_LARGA"));
            listaCar.Add(new Caracteristica("categoriatipo", "SUPERIOR",  "SWEATER"));
            listaCar.Add(new Caracteristica("categoriatipo", "SUPERIOR",  "CAMPERA_DE_ABRIGO"));
            listaCar.Add(new Caracteristica("categoriatipo", "SUPERIOR",  "CAMPERA_DE_LLUVIA"));
            listaCar.Add(new Caracteristica("categoriatipo", "INFERIOR",  "PANTALON_CORTO"));
            listaCar.Add(new Caracteristica("categoriatipo", "INFERIOR",  "PANTALON_LARGO"));
            listaCar.Add(new Caracteristica("categoriatipo", "INFERIOR",  "POLLERA"));
            listaCar.Add(new Caracteristica("categoriatipo", "CALZADO",   "MEDIAS"));
            listaCar.Add(new Caracteristica("categoriatipo", "CALZADO",   "ZAPATO_TACO_ALTO"));
            listaCar.Add(new Caracteristica("categoriatipo", "CALZADO",   "ZAPATO_TACO_BAJO"));
            listaCar.Add(new Caracteristica("categoriatipo", "CALZADO",   "ZAPATILLA_DE_CORRER"));
            listaCar.Add(new Caracteristica("categoriatipo", "CALZADO",   "ZAPATILLA_DE_TREKING"));
            listaCar.Add(new Caracteristica("categoriatipo", "CALZADO",   "PANCHAS"));
            listaCar.Add(new Caracteristica("categoriatipo", "CALZADO",   "OJOTAS"));

            listaCar.Add(new Caracteristica("nivelabrigo", "GORRA",                "2"));
            listaCar.Add(new Caracteristica("nivelabrigo", "SOMBRERO",             "1"));
            listaCar.Add(new Caracteristica("nivelabrigo", "MUSCULOSA",            "0"));
            listaCar.Add(new Caracteristica("nivelabrigo", "REMERA_MANGA_CORTA",   "1"));
            listaCar.Add(new Caracteristica("nivelabrigo", "REMERA_MANGA_LARGA",   "2"));
            listaCar.Add(new Caracteristica("nivelabrigo", "CAMISA_MANGA_CORTA",   "2"));
            listaCar.Add(new Caracteristica("nivelabrigo", "CAMISA_MANGA_LARGA",   "4"));
            listaCar.Add(new Caracteristica("nivelabrigo", "SWEATER",              "5"));
            listaCar.Add(new Caracteristica("nivelabrigo", "CAMPERA_DE_ABRIGO",    "6"));
            listaCar.Add(new Caracteristica("nivelabrigo", "CAMPERA_DE_LLUVIA",    "3"));
            listaCar.Add(new Caracteristica("nivelabrigo", "PANTALON_CORTO",       "1"));
            listaCar.Add(new Caracteristica("nivelabrigo", "PANTALON_LARGO",       "2"));
            listaCar.Add(new Caracteristica("nivelabrigo", "POLLERA",              "1"));
            listaCar.Add(new Caracteristica("nivelabrigo", "MEDIAS",               "1"));
            listaCar.Add(new Caracteristica("nivelabrigo", "ZAPATO_TACO_ALTO",     "2"));
            listaCar.Add(new Caracteristica("nivelabrigo", "ZAPATO_TACO_BAJO",     "1"));
            listaCar.Add(new Caracteristica("nivelabrigo", "ZAPATILLA_DE_CORRER",  "2"));
            listaCar.Add(new Caracteristica("nivelabrigo", "ZAPATILLA_DE_TREKING", "2"));
            listaCar.Add(new Caracteristica("nivelabrigo", "PANCHAS",              "2"));
            listaCar.Add(new Caracteristica("nivelabrigo", "OJOTAS",               "0"));

            listaCar.Add(new Caracteristica("sensibilidad", "MUY FRIOLENTO", "-2"));
            listaCar.Add(new Caracteristica("sensibilidad", "FRIOLENTO", "-1"));
            listaCar.Add(new Caracteristica("sensibilidad", "NORMAL", "0"));
            listaCar.Add(new Caracteristica("sensibilidad", "CALUROSO", "1"));
            listaCar.Add(new Caracteristica("sensibilidad", "MUY CALUROSO", "2"));
            #endregion CARGA_INICIAL

            context.Caracteristicas.AddRange(listaCar);
            
            base.Seed(context);
        }
    }
}
