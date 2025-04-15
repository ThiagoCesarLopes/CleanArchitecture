using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitecture.OrderManagement.Infrastructure.FeatureManager.Interfaces
{
    public interface IFeatureManager
    {
        Task<bool> IsEnabledAsync(string feature);
        IAsyncEnumerable<string> GetFeatureNamesAsync();
    }
}
