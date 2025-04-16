
using CleanArchitecture.OrderManagement.Infrastructure.FeatureManagers.Interfaces;

namespace CleanArchitecture.OrderManagement.Infrastructure.FeatureManagers
{
    public class FeatureManager : IFeatureManager
    {
        private readonly Dictionary<string, bool> _features;

        public FeatureManager()
        {
            _features = new Dictionary<string, bool>
                {
                    { "NewRuleTax", true } 
                };
        }

        public Task<bool> IsEnabledAsync(string feature)
        {
            if (_features.TryGetValue(feature, out var isEnabled))
            {
                return Task.FromResult(isEnabled);
            }

            return Task.FromResult(false);
        }

        public async IAsyncEnumerable<string> GetFeatureNamesAsync()
        {
            foreach (var feature in _features.Keys)
            {
                yield return feature;
                await Task.Yield(); 
            }
        }
    }
}
