using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace backend_not_clear.DTO
{
    public class ResponseAPI<T>
    {
        public string message { get; set; }
        public bool _isIgnoreNullData;
        public object _data;

        public object Data { get; set; }
        public static JsonSerializerSettings _jsonSerializer = new JsonSerializerSettings()
        {
            NullValueHandling = NullValueHandling.Ignore,
            MissingMemberHandling = MissingMemberHandling.Ignore,
        };
        public ResponseAPI(bool isIgnoreNullData = true)
        {
            this._isIgnoreNullData = isIgnoreNullData;
        }
    }
}
