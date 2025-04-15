using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.OrderManagement.Infrastructure.FeatureManager.Interfaces;

namespace CleanArchitecture.OrderManagement.Infrastructure.FeatureManager
{
    public class FeatureManager : IFeatureManager
    {
        private readonly Dictionary<string, bool> _features;

        public FeatureManager()
        {
            // Simulação de flags de recursos
            _features = new Dictionary<string, bool>
                {
                    { "NovaRegraImposto", true } // Exemplo de flag
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
