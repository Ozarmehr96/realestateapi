using Newtonsoft.Json;

namespace Ijora.RestAPI.Api.V1.Models
{
    [JsonObject]
    public class ErrorResponseModel
    {
        public ErrorResponseModel(string message)
        {
            ErrorMessage = message;
        }

        [JsonProperty(PropertyName = "error", Required = Required.DisallowNull)]
        public string ErrorMessage { get; set; }
    }
}
