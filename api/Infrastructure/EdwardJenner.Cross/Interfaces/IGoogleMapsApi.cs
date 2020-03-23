using EdwardJenner.Cross.Models;

namespace EdwardJenner.Cross.Interfaces
{
    public interface IGoogleMapsApi
    {
        GoogleGeocodeResponse GetGeocode(string address);
    }
}
