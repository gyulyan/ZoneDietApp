using ZoneDietApp.Data.Models;

namespace ZoneDietApp.Contracts
{
    public interface IStatisticService
    {
        Task<StatisticServiceModel> TotalAsync();
    }
}
