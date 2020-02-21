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

        [HttpGet("ProductStatisticsInTimeRange")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ReportModel> GetAllProductStatisticsInTimeRange(
            [FromQuery]DateTimeOffset dateFrom, [FromQuery]DateTimeOffset dateTo)
        {
            var report = await _reportService.GetAllProductStatisticsInTimeRange(dateFrom, dateTo);

            return _mapper.Map<ReportModel>(report);
        }

        [HttpGet("UserStatisticsInTimeRange/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ReportModel> GetUserStatisticsInTimeRange(
            int userId, [FromQuery]DateTimeOffset dateFrom, [FromQuery]DateTimeOffset dateTo)
        {
            var report = await _reportService.GetUserStatisticsInTimeRange(userId, dateFrom, dateTo);

            return _mapper.Map<ReportModel>(report);
        }

        [HttpGet("UserStatisticsAllTime/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ReportModel> GetUserStatisticsAllTime(int userId)
        {
            var report = await _reportService.GetUserStatisticsAllTime(userId);

            return _mapper.Map<ReportModel>(report);
        }

        [HttpGet("WatchStatisticsInTimeRange")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ReportModel> GetWatchStatisticsInTimeRange(
            [FromQuery]DateTimeOffset dateFrom, [FromQuery]DateTimeOffset dateTo)
        {
            var report = await _reportService.GetWatchStatisticsInTimeRange(dateFrom, dateTo);

            return _mapper.Map<ReportModel>(report);
        }

        [HttpGet("BijouterieStatisticsInTimeRange")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ReportModel> GetBijouterieStatisticsInTimeRange(
            [FromQuery]DateTimeOffset dateFrom, [FromQuery]DateTimeOffset dateTo)
        {
            var report = await _reportService.GetBijouterieStatisticsInTimeRange(dateFrom, dateTo);

            return _mapper.Map<ReportModel>(report);
        }

        [HttpGet("PreciousItemStatisticsInTimeRange")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ReportModel> GetPreciousItemStatisticsInTimeRange(
            [FromQuery]DateTimeOffset dateFrom, [FromQuery]DateTimeOffset dateTo)
        {
            var report = await _reportService.GetPreciousItemStatisticsInTimeRange(dateFrom, dateTo);

            return _mapper.Map<ReportModel>(report);
        }
    }
}
