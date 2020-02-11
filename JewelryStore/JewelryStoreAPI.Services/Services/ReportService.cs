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

        public async Task<ReportDto> GetAllProductStatisticsInTimeRange(DateTimeOffset dateFrom, DateTimeOffset dateTo)
        {
            var orders = await _orderRepository.GetAllInTimeRange(dateFrom, dateTo);

            return _mapper.Map<ReportDto>(orders);
        }

        public async Task<ReportWatchDto> GetWatchStatisticsInTimeRange(DateTimeOffset dateFrom, DateTimeOffset dateTo)
        {
            var orders = await _orderRepository.GetAllInTimeRange(dateFrom, dateTo);

            return _mapper.Map<ReportWatchDto>(orders);
        }

        public async Task<ReportBijouterieDto> GetBijouterieStatisticsInTimeRange(DateTimeOffset dateFrom, DateTimeOffset dateTo)
        {
            var orders = await _orderRepository.GetAllInTimeRange(dateFrom, dateTo);

            return _mapper.Map<ReportBijouterieDto>(orders);
        }

        public async Task<ReportPreciousItemDto> GetPreciousItemStatisticsInTimeRange(DateTimeOffset dateFrom, DateTimeOffset dateTo)
        {
            var orders = await _orderRepository.GetAllInTimeRange(dateFrom, dateTo);

            return _mapper.Map<ReportPreciousItemDto>(orders);
        }

        public async Task<ReportDto> GetUserStatisticsAllTime(int userId)
        {
            var orders = await _orderRepository.GetAllByUserId(userId);

            return _mapper.Map<ReportDto>(orders);
        }

        public async Task<ReportDto> GetUserStatisticsInTimeRange(int userId, DateTimeOffset dateFrom, DateTimeOffset dateTo)
        {
            var orders = await _orderRepository.GetAllByUserIdInTimeRange(userId, dateFrom, dateTo);

            return _mapper.Map<ReportDto>(orders);
        }
    }
}
