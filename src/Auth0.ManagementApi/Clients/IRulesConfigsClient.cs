using System.Collections.Generic;
using System.Threading.Tasks;
using Auth0.ManagementApi.Models;

namespace Auth0.ManagementApi.Clients
{
    public interface IRulesConfigsClient
    {
        /// <summary>
        ///     Gets all rules config keys.
        /// </summary>
        /// <returns>All existing <see cref="RuleConfig" />.</returns>
        Task<IList<RuleConfig>> GetAllAsync();
        
        /// <summary>
        ///     Deletes the given rules config
        /// </summary>
        /// <param name="id">The key of the rules config to delete</param>
        Task DeleteAsync(string key);
        
        /// <summary>
        ///     Sets / updates the value of a rules config key
        /// </summary>
        /// <param name="key">The key of the rules config</param>
        /// <param name="request">The <see cref="SetRuleConfigRequest" /> containing the details of the rule config to create.</param>
        /// <returns>The created / updated <see cref="RuleConfig" />.</returns>
        Task<RuleConfig> SetAsync(string key, SetRuleConfigRequest request);
    }
}