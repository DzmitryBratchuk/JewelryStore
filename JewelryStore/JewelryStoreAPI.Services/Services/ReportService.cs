using AutoMapper;
using JewelryStoreAPI.Infrastructure.DTO.Report;
using JewelryStoreAPI.Infrastructure.Interfaces.Repositories;
using JewelryStoreAPI.Infrastructure.Interfaces.Services;
using System;
using System.Threading.Tasks;

namespace JewelryStoreAPI.Services.Services
{
    public class ReportService : IReportService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public ReportService(
            IOrderRepository orderRepository,
            IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<ReportDto> GetAllProductStatisticsInTimeRangeAsync(DateTimeOffset dateFrom, DateTimeOffset dateTo)
        {
            var orders = await _orderRepository.GetAllInTimeRangeAsync(dateFrom, dateTo);

            return _mapper.Map<ReportDto>(orders);
        }

        public async Task<ReportWatchDto> GetWatchStatisticsInTimeRangeAsync(DateTimeOffset dateFrom, DateTimeOffset dateTo)
        {
            var orders = await _orderRepository.GetAllInTimeRangeAsync(dateFrom, dateTo);

            return _mapper.Map<ReportWatchDto>(orders);
        }

        public async Task<ReportBijouterieDto> GetBijouterieStatisticsInTimeRangeAsync(DateTimeOffset dateFrom, DateTimeOffset dateTo)
        {
            var orders = await _orderRepository.GetAllInTimeRangeAsync(dateFrom, dateTo);

            return _mapper.Map<ReportBijouterieDto>(orders);
        }

        public async Task<ReportPreciousItemDto> GetPreciousItemStatisticsInTimeRangeAsync(DateTimeOffset dateFrom, DateTimeOffset dateTo)
        {
            var orders = await _orderRepository.GetAllInTimeRangeAsync(dateFrom, dateTo);

            return _mapper.Map<ReportPreciousItemDto>(orders);
        }

        public async Task<ReportDto> GetUserStatisticsAllTimeAsync(int userId)
        {
            var orders = await _orderRepository.GetAllByUserIdAsync(userId);

            return _mapper.Map<ReportDto>(orders);
        }

        public async Task<ReportDto> GetUserStatisticsInTimeRangeAsync(int userId, DateTimeOffset dateFrom, DateTimeOffset dateTo)
        {
            var orders = await _orderRepository.GetAllByUserIdInTimeRangeAsync(userId, dateFrom, dateTo);

            return _mapper.Map<ReportDto>(orders);
        }
    }
}
