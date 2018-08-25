using Newtonsoft.Json;
namespace App4.Models
{
    public class TokenResponse
    {
        [JsonProperty(PropertyName ="acces_token")]
        public string AccessToken { get; set; }

        [JsonProperty(PropertyName ="nombres")]
        public string Nombres { get; set; }

        [JsonProperty(PropertyName ="error")]
        public string Errror { get; set; }

    }
}