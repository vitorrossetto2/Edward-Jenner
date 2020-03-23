using System.Collections.Generic;
using Newtonsoft.Json;

namespace EdwardJenner.Cross.Models
{
    public class GoogleGeocodeResponse
    {
        [JsonProperty("results")]
        public List<GoogleGeocodeResult> Results { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }

    public class GoogleGeocodeResult
    {
        [JsonProperty("address_components")]
        public List<GoogleGeocodeAddressComponent> AddressComponents { get; set; }

        [JsonProperty("formatted_address")]
        public string FormattedAddress { get; set; }

        [JsonProperty("geometry")]
        public GoogleGeocodeGeometry GoogleGeocodeGeometry { get; set; }

        [JsonProperty("place_id")]
        public string PlaceId { get; set; }

        [JsonProperty("plus_code")]
        public GoogleGeocodePlusCode GoogleGeocodePlusCode { get; set; }

        [JsonProperty("types")]
        public List<string> Types { get; set; }
    }

    public class GoogleGeocodeAddressComponent
    {
        [JsonProperty("long_name")]
        public string LongName { get; set; }

        [JsonProperty("short_name")]
        public string ShortName { get; set; }

        [JsonProperty("types")]
        public List<string> Types { get; set; }
    }

    public class GoogleGeocodeGeometry
    {
        [JsonProperty("location")]
        public GoogleGeocodeLocation GoogleGeocodeLocation { get; set; }

        [JsonProperty("location_type")]
        public string LocationType { get; set; }

        [JsonProperty("viewport")]
        public GoogleGeocodeViewport GoogleGeocodeViewport { get; set; }
    }

    public class GoogleGeocodeLocation
    {
        [JsonProperty("lat")]
        public double Lat { get; set; }

        [JsonProperty("lng")]
        public double Lng { get; set; }
    }

    public class GoogleGeocodeViewport
    {
        [JsonProperty("northeast")]
        public GoogleGeocodeLocation Northeast { get; set; }

        [JsonProperty("southwest")]
        public GoogleGeocodeLocation Southwest { get; set; }
    }

    public class GoogleGeocodePlusCode
    {
        [JsonProperty("compound_code")]
        public string CompoundCode { get; set; }

        [JsonProperty("global_code")]
        public string GlobalCode { get; set; }
    }
}
