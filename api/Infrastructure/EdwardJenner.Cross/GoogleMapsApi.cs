using System;
using System.Collections.Generic;
using System.Net;
using EdwardJenner.Cross.Interfaces;
using EdwardJenner.Cross.Models;
using EdwardJenner.Models.Settings;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;

namespace EdwardJenner.Cross
{
    public class GoogleMapsApi : IGoogleMapsApi
    {
        private readonly RestSharpCommon _restSharp;
        private readonly string _apiKey;

        public GoogleMapsApi([FromServices]GoogleSettings googleSettings)
        {
            _restSharp = new RestSharpCommon("https://maps.googleapis.com");
            _apiKey = googleSettings.ApiKey;
        }

        public GoogleGeocodeResponse GetGeocode(string address)
        {
            var response = _restSharp.Get(new GetParams
            {
                Resource = "/maps/api/geocode/json",
                Parameters = new Dictionary<string, string>
                {
                    { "address", address },
                    { "key", _apiKey }
                },
                ParameterType = ParameterType.QueryString
            });

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<GoogleGeocodeResponse>(response.Content);
            }
            else
            {
                Console.WriteLine(response.Content);
                return new GoogleGeocodeResponse();
            }
        }
    }
}
