﻿using System.Collections.Generic;

namespace Ar.UTN.QMP.Lib.Entidades.Clima
{
    public class OpenWeatherInfo
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Weather> Weather { get; set; }
        public string Visibility { get; set; }
        public string dt { get; set; }
        public System Sys { get; set; }
        public Main Main { get; set; }
        public Wind Wind { get; set; }
        public Clouds Clouds { get; set; }
        public Coord Coord { get; set; }
        public string Cod { get; set; }
        public string Message { get; set; }
    }

    public class Weather
    {
        public string Id { get; set; }
        public string Main { get; set; }
        public string Description { get; set; }
    }

    public class System
    {
        public string Type { get; set; }
        public string Id { get; set; }
        public string Message { get; set; }
        public string Country { get; set; }
        public string Sunrise { get; set; }
        public string Sunset { get; set; }
    }

    public class Main
    {
        public string Temp { get; set; }
        public string Pressure { get; set; }
        public string Humidity { get; set; }
        public string Temp_min { get; set; }
        public string Temp_max { get; set; }
    }

    public class Wind
    {
        public string Speed { get; set; }
        public string Deg { get; set; }
    }

    public class Clouds
    {
        public string All { get; set; }
    }

    public class Coord
    {
        public string Lon { get; set; }
        public string Lat { get; set; }
    }
}
