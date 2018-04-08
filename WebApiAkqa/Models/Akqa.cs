using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;

namespace WebApiAkqa.Models
{
    [ExcludeFromCodeCoverage]
    public class Akqa
    {
        [JsonProperty(PropertyName = "userName")]
        public string UserName { get; set; }
        [JsonProperty(PropertyName = "price")]
        public string PriceinWord { get; set; }
    }
}