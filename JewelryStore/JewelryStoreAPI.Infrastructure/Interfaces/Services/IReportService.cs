using JewelryStoreAPI.Infrastructure.DTO.Report;
using System;
using System.Threading.Tasks;

namespace JewelryStoreAPI.Infrastructure.Interfaces.Services
{
    public interface IReportService
    {
        Task<ReportDto> GetUserStatisticsAllTime(int userId);
        Task<ReportDto> GetUserStatisticsInTimeRange(int userId, DateTimeOffset dateFrom, DateTimeOffset dateTo);
        Task<ReportDto> GetAllProductStatisticsInTimeRange(DateTimeOffset dateFrom, DateTimeOffset dateTo);
        Task<ReportWatchDto> GetWatchStatisticsInTimeRange(DateTimeOffset dateFrom, DateTimeOffset dateTo);
        Task<ReportBijouterieDto> GetBijouterieStatisticsInTimeRange(DateTimeOffset dateFrom, DateTimeOffset dateTo);
        Task<ReportPreciousItemDto> GetPreciousItemStatisticsInTimeRange(DateTimeOffset dateFrom, DateTimeOffset dateTo);
    }
}
