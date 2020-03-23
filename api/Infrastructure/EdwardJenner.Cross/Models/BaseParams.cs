using System.Collections.Generic;
using RestSharp;

namespace EdwardJenner.Cross.Models
{
    public class BaseParams
    {
        public string Url { get; set; }
        public string Resource { get; set; }
        public Dictionary<string, string> Headers { get; set; }
        public Dictionary<string, string> SimpleAuthentication { get; set; }
        public Dictionary<string, string> Cookies { get; set; }
        public bool Security { get; set; } = false;
        public bool UseAuthentication { get; set; } = false;
        public bool UseCustomValidation { get; set; } = false;
    }

    public class GetParams : BaseParams
    {
        public Dictionary<string, string> Parameters { get; set; }
        public ParameterType ParameterType { get; set; } = ParameterType.UrlSegment;
    }

    public class PostParams : BaseParams
    {
        public object Body { get; set; }
        public BodyType BodyType { get; set; } = BodyType.ApplicationJson;
        public SerializerStrategy Strategy { get; set; } = SerializerStrategy.CamelCase;
    }

    public class UploadParams : BaseParams
    {
        public object Body { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public byte[] Document { get; set; }
        public BodyType BodyType { get; set; } = BodyType.ApplicationJson;
        public SerializerStrategy Strategy { get; set; } = SerializerStrategy.CamelCase;
    }

    public class PutParams : BaseParams
    {
        public object Body { get; set; }
        public BodyType BodyType { get; set; } = BodyType.ApplicationJson;
        public SerializerStrategy Strategy { get; set; } = SerializerStrategy.CamelCase;
    }

    public class DeleteParams : BaseParams
    {
        public object Body { get; set; }
        public BodyType BodyType { get; set; } = BodyType.ApplicationJson;
        public SerializerStrategy Strategy { get; set; } = SerializerStrategy.CamelCase;
    }

    public enum SerializerStrategy
    {
        SnakeJson = 0,
        CamelCase = 1,
        JsonNet = 2,
        JsonNetSkipNullProperties = 3
    }

    public enum BodyType
    {
        FormUrlEncoded = 0,
        Text = 1,
        TextPlain = 2,
        ApplicationJson = 3,
        ApplicationJavascript = 4,
        ApplicationXml = 5,
        TextXml = 6,
        TextHtml = 7
    }

    public enum AuthenticationType
    {
        None = 0,
        Basic = 1,
        Bearer = 2
    }
}
