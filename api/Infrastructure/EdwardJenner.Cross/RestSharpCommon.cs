using System;
using System.Net;
using EdwardJenner.Cross.Interfaces.Models;
using EdwardJenner.Cross.Models;
using RestSharp;
using RestSharp.Authenticators;

namespace EdwardJenner.Cross
{
    public class RestSharpCommon
    {
        private readonly string _baseUrl;
        private readonly IAuthenticationModel _authenticationModel;

        public RestSharpCommon(string baseUrl, IAuthenticationModel authenticationModel = null)
        {
            _baseUrl = baseUrl;
            _authenticationModel = authenticationModel;
        }

        public IRestResponse Get(GetParams getParams)
        {
            if (getParams.Security)
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            }

            var client = new RestClient(getParams.Url ?? _baseUrl);

            var request = new RestRequest(getParams.Resource, Method.GET);

            if (getParams.SimpleAuthentication != null)
            {
                client.Authenticator = new HttpBasicAuthenticator(getParams.SimpleAuthentication["username"], getParams.SimpleAuthentication["password"]);
            }
            else if (getParams.UseAuthentication && _authenticationModel != null)
            {
                if (_authenticationModel is BasicAuthentication basicAuth)
                {
                    client.Authenticator = new HttpBasicAuthenticator(basicAuth.Username, basicAuth.Password);
                }
                else
                {
                    throw new NotImplementedException();
                }
            }

            if (getParams.Headers != null)
            {
                foreach (var (key, value) in getParams.Headers)
                {
                    request.AddHeader(key, value);
                }
            }

            if (getParams.Cookies != null)
            {
                foreach (var (key, value) in getParams.Cookies)
                {
                    request.AddCookie(key, value);
                }
            }

            if (getParams.Parameters != null)
            {
                foreach (var (key, value) in getParams.Parameters)
                {
                    request.AddParameter(key, value, getParams.ParameterType);
                }
            }

            var response = client.Execute(request);

            return response;
        }
    }
}
