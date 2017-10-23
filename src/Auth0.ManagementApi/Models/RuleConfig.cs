using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{
    public class RuleConfig
    {
        [JsonProperty("key")]
        public string Key { get; set; }
    }
}