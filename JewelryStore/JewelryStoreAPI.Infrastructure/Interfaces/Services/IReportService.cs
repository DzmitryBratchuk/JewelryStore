using JewelryStoreAPI.Infrastructure.DTO.Report;
using System;
using System.Threading.Tasks;

namespace JewelryStoreAPI.Infrastructure.Interfaces.Services
{
    public interface IReportService
    {
        Task<ReportDto> GetUserStatisticsAllTimeAsync(int userId);
        Task<ReportDto> GetUserStatisticsInTimeRangeAsync(int userId, DateTimeOffset dateFrom, DateTimeOffset dateTo);
        Task<ReportDto> GetAllProductStatisticsInTimeRangeAsync(DateTimeOffset dateFrom, DateTimeOffset dateTo);
        Task<ReportWatchDto> GetWatchStatisticsInTimeRangeAsync(DateTimeOffset dateFrom, DateTimeOffset dateTo);
        Task<ReportBijouterieDto> GetBijouterieStatisticsInTimeRangeAsync(DateTimeOffset dateFrom, DateTimeOffset dateTo);
        Task<ReportPreciousItemDto> GetPreciousItemStatisticsInTimeRangeAsync(DateTimeOffset dateFrom, DateTimeOffset dateTo);
    }
}
