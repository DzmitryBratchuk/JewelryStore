using AutoMapper;
using JewelryStoreAPI.Infrastructure.Interfaces.Services;
using JewelryStoreAPI.Models.Report;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace JewelryStoreAPI.Controllers
{
    [Authorize(Roles = "Accountant")]
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;
        private readonly IMapper _mapper;

        public ReportController(IReportService reportService, IMapper mapper)
        {
            _reportService = reportService;
            _mapper = mapper;
        }

        [HttpGet("GetAllProductStatisticsInTimeRange/{dateFrom}&{dateTo}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ReportModel> GetAllProductStatisticsInTimeRange(
            DateTimeOffset dateFrom, DateTimeOffset dateTo)
        {
            var report = await _reportService.GetAllProductStatisticsInTimeRange(dateFrom, dateTo);

            return _mapper.Map<ReportModel>(report);
        }

        [HttpGet("GetUserStatisticsInTimeRange/{userId}&{dateFrom}&{dateTo}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ReportModel> GetUserStatisticsInTimeRange(
            int userId, DateTimeOffset dateFrom, DateTimeOffset dateTo)
        {
            var report = await _reportService.GetUserStatisticsInTimeRange(userId, dateFrom, dateTo);

            return _mapper.Map<ReportModel>(report);
        }

        [HttpGet("GetUserStatisticsAllTime/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ReportModel> GetUserStatisticsAllTime(int userId)
        {
            var report = await _reportService.GetUserStatisticsAllTime(userId);

            return _mapper.Map<ReportModel>(report);
        }

        [HttpGet("GetWatchStatisticsInTimeRange/{dateFrom}&{dateTo}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ReportModel> GetWatchStatisticsInTimeRange(
            DateTimeOffset dateFrom, DateTimeOffset dateTo)
        {
            var report = await _reportService.GetWatchStatisticsInTimeRange(dateFrom, dateTo);

            return _mapper.Map<ReportModel>(report);
        }

        [HttpGet("GetBijouterieStatisticsInTimeRange/{dateFrom}&{dateTo}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ReportModel> GetBijouterieStatisticsInTimeRange(
            DateTimeOffset dateFrom, DateTimeOffset dateTo)
        {
            var report = await _reportService.GetBijouterieStatisticsInTimeRange(dateFrom, dateTo);

            return _mapper.Map<ReportModel>(report);
        }

        [HttpGet("GetPreciousItemStatisticsInTimeRange/{dateFrom}&{dateTo}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ReportModel> GetPreciousItemStatisticsInTimeRange(
            DateTimeOffset dateFrom, DateTimeOffset dateTo)
        {
            var report = await _reportService.GetPreciousItemStatisticsInTimeRange(dateFrom, dateTo);

            return _mapper.Map<ReportModel>(report);
        }
    }
}
