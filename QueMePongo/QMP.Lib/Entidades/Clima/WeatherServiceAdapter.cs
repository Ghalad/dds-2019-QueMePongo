namespace Ar.UTN.QMP.Lib.Entidades.Clima
{
    public interface WeatherServiceAdapter
    {
        void SetCiudad(string pais, string ciudad);
        decimal ObtenerTemperatura();
        decimal ObtenerHumedad();
        decimal ObtenerPresion();
    }
}
