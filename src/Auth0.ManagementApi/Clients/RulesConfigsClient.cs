using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Auth0.Core.Http;
using Auth0.ManagementApi.Models;

namespace Auth0.ManagementApi.Clients
{
    /// <summary>
    /// Contains all the methods to call the /rules-configs endpoints.
    /// </summary>
    public class RulesConfigsClient : ClientBase, IRulesConfigsClient
    {
        public RulesConfigsClient(IApiConnection connection) : base(connection)
        {
        }

        public Task<IList<RuleConfig>> GetAllAsync()
        {
            return Connection.GetAsync<IList<RuleConfig>>("rules-configs", null, null, null, null, null, null);
        }

        public Task DeleteAsync(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));
            
            return Connection.DeleteAsync<object>("rules-configs/{key}", new Dictionary<string, string>
            {
                {"key", key}
            }, null);
        }

        public Task<RuleConfig> SetAsync(string key, SetRuleConfigRequest request)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));
            
            return Connection.PutAsync<RuleConfig>("rules-configs/{key}", request, new Dictionary<string, object>
            {
                {"key", key}
            }, null, null, null, null);
        }
    }
}