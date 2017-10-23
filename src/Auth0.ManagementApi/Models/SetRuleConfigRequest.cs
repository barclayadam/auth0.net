using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{
    public class SetRuleConfigRequest
    {
        [JsonProperty("value")]
        public string Value { get; set; }
    }
}