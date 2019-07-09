namespace Ar.UTN.QMP.Lib.Entidades.Clima
{
    public class ApiUxInfo
    {
        public Location Location { get; set; }
        public Current Current { get; set; }
    }
    public class Location
    {
        public string Name { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public string Lat { get; set; }
        public string Lon { get; set; }
        public string Tz_id { get; set; }
        public string Localtime_epoch { get; set; }
        public string Localtime { get; set; }
    }

    public class Current
    {
        public string Last_updated_epoch { get; set; }
        public string Last_updated { get; set; }
        public string Temp_c { get; set; }
        public string Temp_f { get; set; }
        public string Is_day { get; set; }
        public Condition Condition { get; set; }
        public string Wind_mph { get; set; }
        public string Wind_kph { get; set; }
        public string Wind_degree { get; set; }
        public string Wind_dir { get; set; }
        public string Pressure_mb { get; set; }
        public string Pressure_in { get; set; }
        public string Precip_mm { get; set; }
        public string Precip_in { get; set; }
        public string Humidity { get; set; }
        public string Cloud { get; set; }
        public string Feelslike_c { get; set; }
        public string Feelslike_f { get; set; }
        public string Vis_km { get; set; }
        public string Vis_miles { get; set; }
        public string Uv { get; set; }
        public string Gust_mph { get; set; }
        public string Gust_kph { get; set; }

    }

    public class Condition
    {
        public string Text { get; set; }
        public string Icon { get; set; }
        public string Code { get; set; }
    }
}
