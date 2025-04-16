
namespace CleanArchitecture.OrderManagement.Infrastructure.FeatureManagers.Interfaces
{
    public interface IFeatureManager
    {
        Task<bool> IsEnabledAsync(string feature);
        IAsyncEnumerable<string> GetFeatureNamesAsync();
    }
}
