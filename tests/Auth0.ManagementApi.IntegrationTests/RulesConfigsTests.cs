using System;
using System.Threading.Tasks;
using Auth0.ManagementApi.Models;
using FluentAssertions;
using Xunit;
using Auth0.Tests.Shared;

namespace Auth0.ManagementApi.IntegrationTests
{
    public class RulesConfigsTests : TestBase
    {
        [Fact]
        public async Task Test_rules_configs_crud_sequence()
        {
            string token = await GenerateManagementApiToken();

            var apiClient = new ManagementApiClient(token, new Uri(GetVariable("AUTH0_MANAGEMENT_API_URL")));

            // Get all rules configs
            var rulesConfigsBefore = (await apiClient.RulesConfigs.GetAllAsync());

            // Add a new rule config
            var key = Guid.NewGuid().ToString();
            var value = Guid.NewGuid().ToString();
            
            var newRuleResponse = await apiClient.RulesConfigs.SetAsync(key, new SetRuleConfigRequest { Value = value });
            newRuleResponse.Should().NotBeNull();
            newRuleResponse.Key.Should().Be(key);

            // Get all the rules configs again, and check that we now have one more
            var rulesAfter = await apiClient.RulesConfigs.GetAllAsync();
            rulesAfter.Count.Should().Be(rulesConfigsBefore.Count + 1);
            rulesAfter.Should().Contain(r => r.Key == key);

            // Update the Rule
            var updateRuleConfigResponse = await apiClient.RulesConfigs.SetAsync(key, new SetRuleConfigRequest { Value = value });
            updateRuleConfigResponse.Should().NotBeNull();
            updateRuleConfigResponse.Key.Should().Be(key);

            // Delete the rule config, and ensure we get exception when trying to fetch it again
            await apiClient.RulesConfigs.DeleteAsync(key);
            var rulesConfigAfterDelete = await apiClient.RulesConfigs.GetAllAsync();
            // Back to the original count
            rulesConfigAfterDelete.Count.Should().Be(rulesConfigsBefore.Count); 
            rulesAfter.Should().NotContain(r => r.Key == key);
        }
    }
}