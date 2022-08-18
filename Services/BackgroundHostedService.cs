using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using WpfMvvmDiEfSample.Models;

namespace WpfMvvmDiEfSample.Services
{
    /// <summary>
    /// Way how to implement background working service. Works with arranging DI With IHost in App class
    /// </summary>
    public class BackgroundHostedService : BackgroundService
    {
        private readonly ILogger<BackgroundHostedService> _logger;
        private readonly IRandomStringService _randomStringService;
        private readonly BackgroundValuesProvider _valuesProvider;


        public BackgroundHostedService(ILogger<BackgroundHostedService> logger, IRandomStringService randomStringService, BackgroundValuesProvider valuesProvider )
        {
            _logger = logger;
            _randomStringService = randomStringService;
            _valuesProvider = valuesProvider;

            _logger.LogInformation("Background service started...");
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    _valuesProvider.StringValue = await Payload();
                    _logger.LogInformation("New string generated in background");
                }
                catch (Exception ex)
                {
                    _logger.LogError($"There was an error: {ex.GetBaseException().Message}");
                }
            }
        }


        private async Task<string> Payload()
        {
            await Task.Delay(TimeSpan.FromSeconds(3));
            return _randomStringService.GetRandomString();
        }
    }
}
