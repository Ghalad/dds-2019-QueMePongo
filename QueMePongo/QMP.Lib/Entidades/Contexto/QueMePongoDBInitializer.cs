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
            listaCar.Add(new Caracteristica("TIPO", "REMERA_CUELLO_REDONDO_MANGA_CORTA"));
            listaCar.Add(new Caracteristica("TIPO", "REMERA_CUELLO_REDONDO_MANGA_LARGA"));
            listaCar.Add(new Caracteristica("TIPO", "REMERA_ESCOTE_V_MANGA_CORTA"));
            listaCar.Add(new Caracteristica("TIPO", "REMERA_ESCOTE_V_MANGA_LARGA"));
            listaCar.Add(new Caracteristica("TIPO", "SUETER"));
            listaCar.Add(new Caracteristica("TIPO", "CAMPERA"));
            listaCar.Add(new Caracteristica("TIPO", "PANTALON_LARGO"));
            listaCar.Add(new Caracteristica("TIPO", "PANTALON_CORTO"));
            listaCar.Add(new Caracteristica("TIPO", "BERMUDA"));
            listaCar.Add(new Caracteristica("TIPO", "POLLERA"));
            listaCar.Add(new Caracteristica("TIPO", "CALZA"));
            listaCar.Add(new Caracteristica("TIPO", "BUZO"));
            listaCar.Add(new Caracteristica("TIPO", "MUSCULOSA"));
            listaCar.Add(new Caracteristica("TIPO", "ZAPATILLAS"));
            listaCar.Add(new Caracteristica("TIPO", "ZAPATOS"));
            listaCar.Add(new Caracteristica("TIPO", "SANDALIAS"));

            listaCar.Add(new Caracteristica("SUPERPOSICION", "1"));
            listaCar.Add(new Caracteristica("SUPERPOSICION", "2"));
            listaCar.Add(new Caracteristica("SUPERPOSICION", "3"));
            
            listaCar.Add(new Caracteristica("ABRIGO", "1"));
            listaCar.Add(new Caracteristica("ABRIGO", "2"));
            listaCar.Add(new Caracteristica("ABRIGO", "3"));
            listaCar.Add(new Caracteristica("ABRIGO", "4"));
            listaCar.Add(new Caracteristica("ABRIGO", "5"));
            listaCar.Add(new Caracteristica("ABRIGO", "6"));
            listaCar.Add(new Caracteristica("ABRIGO", "7"));
            listaCar.Add(new Caracteristica("ABRIGO", "8"));
            listaCar.Add(new Caracteristica("ABRIGO", "9"));
            listaCar.Add(new Caracteristica("ABRIGO", "10"));
            listaCar.Add(new Caracteristica("ABRIGO", "11"));
            listaCar.Add(new Caracteristica("ABRIGO", "12"));
            listaCar.Add(new Caracteristica("ABRIGO", "13"));
            listaCar.Add(new Caracteristica("ABRIGO", "14"));
            listaCar.Add(new Caracteristica("ABRIGO", "15"));

            listaCar.Add(new Caracteristica("MATERIAL", "ALGODON"));
            listaCar.Add(new Caracteristica("MATERIAL", "SEDA"));
            listaCar.Add(new Caracteristica("MATERIAL", "POLIESTER"));
            listaCar.Add(new Caracteristica("MATERIAL", "LYCRA"));
            listaCar.Add(new Caracteristica("MATERIAL", "CUERO"));
            listaCar.Add(new Caracteristica("MATERIAL", "NYLON"));
            listaCar.Add(new Caracteristica("MATERIAL", "JEAN"));

            listaCar.Add(new Caracteristica("COLOR", "NEGRO"));
            listaCar.Add(new Caracteristica("COLOR", "BLANCO"));
            listaCar.Add(new Caracteristica("COLOR", "GRIS"));
            listaCar.Add(new Caracteristica("COLOR", "AMARILLO"));
            listaCar.Add(new Caracteristica("COLOR", "CELESTE"));
            listaCar.Add(new Caracteristica("COLOR", "VERDE"));
            listaCar.Add(new Caracteristica("COLOR", "BORDO"));

            listaCar.Add(new Caracteristica("EVENTO", "CASUAL"));
            listaCar.Add(new Caracteristica("EVENTO", "TRABAJO"));
            listaCar.Add(new Caracteristica("EVENTO", "SALIDA_AMIGOS"));
            listaCar.Add(new Caracteristica("EVENTO", "CUMPLEAÑOS"));
            listaCar.Add(new Caracteristica("EVENTO", "CASAMIENTO"));

            listaCar.Add(new Caracteristica("SUPERPOSICION", "GORRA",                             "1"));
            listaCar.Add(new Caracteristica("SUPERPOSICION", "SOMBRERO",                          "1"));
            listaCar.Add(new Caracteristica("SUPERPOSICION", "REMERA_CUELLO_REDONDO_MANGA_CORTA", "1"));
            listaCar.Add(new Caracteristica("SUPERPOSICION", "REMERA_CUELLO_REDONDO_MANGA_LARGA", "1"));
            listaCar.Add(new Caracteristica("SUPERPOSICION", "REMERA_ESCOTE_V_MANGA_CORTA",       "1"));
            listaCar.Add(new Caracteristica("SUPERPOSICION", "REMERA_ESCOTE_V_MANGA_LARGA",       "1"));
            listaCar.Add(new Caracteristica("SUPERPOSICION", "MUSCULOSA",                         "1"));
            listaCar.Add(new Caracteristica("SUPERPOSICION", "SUETER",                            "2"));
            listaCar.Add(new Caracteristica("SUPERPOSICION", "BUZO",                              "2"));
            listaCar.Add(new Caracteristica("SUPERPOSICION", "PANTALON_LARGO",                    "2"));
            listaCar.Add(new Caracteristica("SUPERPOSICION", "PANTALON_CORTO",                    "2"));
            listaCar.Add(new Caracteristica("SUPERPOSICION", "BERMUDA",                           "2"));
            listaCar.Add(new Caracteristica("SUPERPOSICION", "POLLERA",                           "2"));
            listaCar.Add(new Caracteristica("SUPERPOSICION", "CALZA",                             "2"));
            listaCar.Add(new Caracteristica("SUPERPOSICION", "ZAPATILLAS",                        "2"));
            listaCar.Add(new Caracteristica("SUPERPOSICION", "ZAPATOS",                           "2"));
            listaCar.Add(new Caracteristica("SUPERPOSICION", "SANDALIAS",                         "2"));
            listaCar.Add(new Caracteristica("SUPERPOSICION", "CAMPERA",                           "3"));

            listaCar.Add(new Caracteristica("CATEGORIATIPO", "ACCESORIO", "GORRA"));
            listaCar.Add(new Caracteristica("CATEGORIATIPO", "ACCESORIO", "SOMBRERO"));

            listaCar.Add(new Caracteristica("CATEGORIATIPO", "SUPERIOR",  "REMERA_CUELLO_REDONDO_MANGA_CORTA"));
            listaCar.Add(new Caracteristica("CATEGORIATIPO", "SUPERIOR",  "REMERA_CUELLO_REDONDO_MANGA_LARGA"));
            listaCar.Add(new Caracteristica("CATEGORIATIPO", "SUPERIOR",  "REMERA_ESCOTE_V_MANGA_CORTA"));
            listaCar.Add(new Caracteristica("CATEGORIATIPO", "SUPERIOR",  "REMERA_ESCOTE_V_MANGA_LARGA"));
            listaCar.Add(new Caracteristica("CATEGORIATIPO", "SUPERIOR",  "SUETER"));
            listaCar.Add(new Caracteristica("CATEGORIATIPO", "SUPERIOR",  "CAMPERA"));
            listaCar.Add(new Caracteristica("CATEGORIATIPO", "SUPERIOR",  "BUZO"));
            listaCar.Add(new Caracteristica("CATEGORIATIPO", "SUPERIOR",  "MUSCULOSA"));
            
            listaCar.Add(new Caracteristica("CATEGORIATIPO", "INFERIOR",  "PANTALON_LARGO"));
            listaCar.Add(new Caracteristica("CATEGORIATIPO", "INFERIOR",  "PANTALON_CORTO"));
            listaCar.Add(new Caracteristica("CATEGORIATIPO", "INFERIOR",  "BERMUDA"));
            listaCar.Add(new Caracteristica("CATEGORIATIPO", "INFERIOR",  "POLLERA"));
            listaCar.Add(new Caracteristica("CATEGORIATIPO", "INFERIOR",  "CALZA"));
            
            listaCar.Add(new Caracteristica("CATEGORIATIPO", "CALZADO",   "ZAPATILLAS"));
            listaCar.Add(new Caracteristica("CATEGORIATIPO", "CALZADO",   "ZAPATOS"));
            listaCar.Add(new Caracteristica("CATEGORIATIPO", "CALZADO",   "SANDALIAS"));

            listaCar.Add(new Caracteristica("NIVELABRIGO", "GORRA",                             "10"));
            listaCar.Add(new Caracteristica("NIVELABRIGO", "SOMBRERO",                          "25"));
            listaCar.Add(new Caracteristica("NIVELABRIGO", "REMERA_CUELLO_REDONDO_MANGA_CORTA", "20"));
            listaCar.Add(new Caracteristica("NIVELABRIGO", "REMERA_CUELLO_REDONDO_MANGA_LARGA", "70"));
            listaCar.Add(new Caracteristica("NIVELABRIGO", "REMERA_ESCOTE_V_MANGA_CORTA",       "20"));
            listaCar.Add(new Caracteristica("NIVELABRIGO", "REMERA_ESCOTE_V_MANGA_LARGA",       "70"));
            listaCar.Add(new Caracteristica("NIVELABRIGO", "SUETER",                            "40"));
            listaCar.Add(new Caracteristica("NIVELABRIGO", "CAMPERA",                           "40"));
            listaCar.Add(new Caracteristica("NIVELABRIGO", "BUZO",                              "40"));
            listaCar.Add(new Caracteristica("NIVELABRIGO", "MUSCULOSA",                         "10"));
            listaCar.Add(new Caracteristica("NIVELABRIGO", "PANTALON_LARGO",                    "70"));
            listaCar.Add(new Caracteristica("NIVELABRIGO", "PANTALON_CORTO",                    "20"));
            listaCar.Add(new Caracteristica("NIVELABRIGO", "BERMUDA",                           "20"));
            listaCar.Add(new Caracteristica("NIVELABRIGO", "POLLERA",                           "20"));
            listaCar.Add(new Caracteristica("NIVELABRIGO", "CALZA",                             "40"));
            listaCar.Add(new Caracteristica("NIVELABRIGO", "ZAPATILLAS",                        "20"));
            listaCar.Add(new Caracteristica("NIVELABRIGO", "ZAPATOS",                           "30"));
            listaCar.Add(new Caracteristica("NIVELABRIGO", "SANDALIAS",                         "5"));

            listaCar.Add(new Caracteristica("SENSIBILIDAD", "MUY_FRIOLENTO", "-2"));
            listaCar.Add(new Caracteristica("SENSIBILIDAD", "FRIOLENTO",     "-1"));
            listaCar.Add(new Caracteristica("SENSIBILIDAD", "NORMAL",        "0"));
            listaCar.Add(new Caracteristica("SENSIBILIDAD", "CALUROSO",      "1"));
            listaCar.Add(new Caracteristica("SENSIBILIDAD", "MUY_CALUROSO",  "2"));


            listaCar.Add(new Caracteristica("MATERIALPERMITIDO", "ALGODON",   "REMERA_CUELLO_REDONDO_MANGA_CORTA"));
            listaCar.Add(new Caracteristica("MATERIALPERMITIDO", "ALGODON",   "REMERA_CUELLO_REDONDO_MANGA_LARGA"));
            listaCar.Add(new Caracteristica("MATERIALPERMITIDO", "ALGODON",   "REMERA_ESCOTE_V_MANGA_CORTA"));
            listaCar.Add(new Caracteristica("MATERIALPERMITIDO", "ALGODON",   "REMERA_ESCOTE_V_MANGA_LARGA"));
            listaCar.Add(new Caracteristica("MATERIALPERMITIDO", "ALGODON",   "SUETER"));
            listaCar.Add(new Caracteristica("MATERIALPERMITIDO", "ALGODON",   "CAMPERA"));
            listaCar.Add(new Caracteristica("MATERIALPERMITIDO", "ALGODON",   "PANTALON_LARGO"));
            listaCar.Add(new Caracteristica("MATERIALPERMITIDO", "ALGODON",   "PANTALON_CORTO"));
            listaCar.Add(new Caracteristica("MATERIALPERMITIDO", "ALGODON",   "BERMUDA"));
            listaCar.Add(new Caracteristica("MATERIALPERMITIDO", "ALGODON",   "POLLERA"));
            listaCar.Add(new Caracteristica("MATERIALPERMITIDO", "ALGODON",   "CALZA"));
            listaCar.Add(new Caracteristica("MATERIALPERMITIDO", "ALGODON",   "BUZO"));
            listaCar.Add(new Caracteristica("MATERIALPERMITIDO", "ALGODON",   "MUSCULOSA"));
            listaCar.Add(new Caracteristica("MATERIALPERMITIDO", "SEDA",      "REMERA_CUELLO_REDONDO_MANGA_CORTA"));
            listaCar.Add(new Caracteristica("MATERIALPERMITIDO", "SEDA",      "REMERA_CUELLO_REDONDO_MANGA_LARGA"));
            listaCar.Add(new Caracteristica("MATERIALPERMITIDO", "SEDA",      "REMERA_ESCOTE_V_MANGA_CORTA"));
            listaCar.Add(new Caracteristica("MATERIALPERMITIDO", "SEDA",      "REMERA_ESCOTE_V_MANGA_LARGA"));
            listaCar.Add(new Caracteristica("MATERIALPERMITIDO", "SEDA",      "SUETER"));
            listaCar.Add(new Caracteristica("MATERIALPERMITIDO", "SEDA",      "CAMPERA"));
            listaCar.Add(new Caracteristica("MATERIALPERMITIDO", "SEDA",      "PANTALON_LARGO"));
            listaCar.Add(new Caracteristica("MATERIALPERMITIDO", "SEDA",      "PANTALON_CORTO"));
            listaCar.Add(new Caracteristica("MATERIALPERMITIDO", "SEDA",      "BERMUDA"));
            listaCar.Add(new Caracteristica("MATERIALPERMITIDO", "SEDA",      "POLLERA"));
            listaCar.Add(new Caracteristica("MATERIALPERMITIDO", "POLIESTER", "REMERA_CUELLO_REDONDO_MANGA_CORTA"));
            listaCar.Add(new Caracteristica("MATERIALPERMITIDO", "POLIESTER", "REMERA_CUELLO_REDONDO_MANGA_LARGA"));
            listaCar.Add(new Caracteristica("MATERIALPERMITIDO", "POLIESTER", "REMERA_ESCOTE_V_MANGA_CORTA"));
            listaCar.Add(new Caracteristica("MATERIALPERMITIDO", "POLIESTER", "REMERA_ESCOTE_V_MANGA_LARGA"));
            listaCar.Add(new Caracteristica("MATERIALPERMITIDO", "POLIESTER", "SUETER"));
            listaCar.Add(new Caracteristica("MATERIALPERMITIDO", "POLIESTER", "CAMPERA"));
            listaCar.Add(new Caracteristica("MATERIALPERMITIDO", "POLIESTER", "PANTALON_LARGO"));
            listaCar.Add(new Caracteristica("MATERIALPERMITIDO", "POLIESTER", "PANTALON_CORTO"));
            listaCar.Add(new Caracteristica("MATERIALPERMITIDO", "POLIESTER", "BERMUDA"));
            listaCar.Add(new Caracteristica("MATERIALPERMITIDO", "POLIESTER", "POLLERA"));
            listaCar.Add(new Caracteristica("MATERIALPERMITIDO", "POLIESTER", "CALZA"));
            listaCar.Add(new Caracteristica("MATERIALPERMITIDO", "POLIESTER", "BUZO"));
            listaCar.Add(new Caracteristica("MATERIALPERMITIDO", "POLIESTER", "SOMBRERO"));
            listaCar.Add(new Caracteristica("MATERIALPERMITIDO", "LYCRA",     "REMERA_CUELLO_REDONDO_MANGA_CORTA"));
            listaCar.Add(new Caracteristica("MATERIALPERMITIDO", "LYCRA",     "REMERA_CUELLO_REDONDO_MANGA_LARGA"));
            listaCar.Add(new Caracteristica("MATERIALPERMITIDO", "LYCRA",     "REMERA_ESCOTE_V_MANGA_CORTA"));
            listaCar.Add(new Caracteristica("MATERIALPERMITIDO", "LYCRA",     "REMERA_ESCOTE_V_MANGA_LARGA"));
            listaCar.Add(new Caracteristica("MATERIALPERMITIDO", "LYCRA",     "CALZA"));
            listaCar.Add(new Caracteristica("MATERIALPERMITIDO", "LYCRA",     "BUZO"));
            listaCar.Add(new Caracteristica("MATERIALPERMITIDO", "LYCRA",     "MUSCULOSA"));
            listaCar.Add(new Caracteristica("MATERIALPERMITIDO", "CUERO",     "CAMPERA"));
            listaCar.Add(new Caracteristica("MATERIALPERMITIDO", "CUERO",     "ZAPATILLAS"));
            listaCar.Add(new Caracteristica("MATERIALPERMITIDO", "CUERO",     "ZAPATOS"));
            listaCar.Add(new Caracteristica("MATERIALPERMITIDO", "CUERO",     "SANDALIAS"));
            listaCar.Add(new Caracteristica("MATERIALPERMITIDO", "CUERO",     "SOMBRERO"));
            listaCar.Add(new Caracteristica("MATERIALPERMITIDO", "JEAN",      "PANTALON_LARGO"));
            listaCar.Add(new Caracteristica("MATERIALPERMITIDO", "JEAN",      "PANTALON_CORTO"));
            listaCar.Add(new Caracteristica("MATERIALPERMITIDO", "JEAN",      "BERMUDA"));
            listaCar.Add(new Caracteristica("MATERIALPERMITIDO", "JEAN",      "POLLERA"));
            listaCar.Add(new Caracteristica("MATERIALPERMITIDO", "NYLON",     "PANTALON_LARGO"));
            listaCar.Add(new Caracteristica("MATERIALPERMITIDO", "NYLON",     "PANTALON_CORTO"));
            listaCar.Add(new Caracteristica("MATERIALPERMITIDO", "NYLON",     "CAMPERA"));
            listaCar.Add(new Caracteristica("MATERIALPERMITIDO", "NYLON",     "POLLERA"));
            listaCar.Add(new Caracteristica("MATERIALPERMITIDO", "NYLON",     "CALZA"));
            listaCar.Add(new Caracteristica("MATERIALPERMITIDO", "NYLON",     "BUZO"));
            listaCar.Add(new Caracteristica("MATERIALPERMITIDO", "NYLON",     "ZAPATILLAS"));
            listaCar.Add(new Caracteristica("MATERIALPERMITIDO", "NYLON",     "GORRA"));

            #endregion CARGA_INICIAL

            context.Caracteristicas.AddRange(listaCar);
            
            base.Seed(context);
        }
    }
}
