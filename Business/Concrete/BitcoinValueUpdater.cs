using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Business.Abstract;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Business.Concrete
{
    public class BitcoinValueUpdater : BackgroundService
    {
        private readonly IBitcoinValueService _bitcoinValueService;
        private readonly HttpClient _httpClient;
        private readonly ILogger<BitcoinValueUpdater> _logger;

        public BitcoinValueUpdater(IBitcoinValueService bitcoinValueService, HttpClient httpClient, ILogger<BitcoinValueUpdater> logger)
        {
            _bitcoinValueService = bitcoinValueService;
            _httpClient = httpClient;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (true)
            {
                try
                {
                    if (stoppingToken.IsCancellationRequested)
                    {
                        // Uygulama kapatılmış, servisi sonlandır
                        _logger.LogInformation("BitcoinValueUpdater service is stopping.");
                        return;
                    }
                    await UpdateBitcoinValues();

                    // Belirlediğiniz aralık kadar bekleyin
                    await Task.Delay(TimeSpan.FromMinutes(10), stoppingToken);
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Error while updating Bitcoin values: {ex.Message}");
                }
            }
        }

        private async Task UpdateBitcoinValues()
        {
            // CoinGecko API'den Bitcoin değerlerini çekme
            var bitcoinApiResponse = await GetBitcoinValuesFromApi();

            // API'den alınan değeri veritabanına ekleme
            await _bitcoinValueService.AddBitcoinValueAsync(bitcoinApiResponse);

            _logger.LogInformation("Bitcoin values updated successfully.");
        }

        private async Task<decimal> GetBitcoinValuesFromApi()
        {
            try
            {
                // CoinGecko API endpoint URL
                var apiUrl = "https://api.coingecko.com/api/v3/simple/price?ids=bitcoin&vs_currencies=usd";

                // API'ye GET isteği gönderme
                var response = await _httpClient.GetStringAsync(apiUrl);

                // API yanıtını çözümleme
                var bitcoinApiResponse = JsonConvert.DeserializeObject<BitcoinApiResponse>(response);

                // Bitcoin değerini döndürme
                return bitcoinApiResponse?.Bitcoin?.Usd ?? 0;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while getting Bitcoin values from API: {ex.Message}");
                return 0;
            }
        }
    }

    public class BitcoinApiResponse
    {
        public BitcoinData Bitcoin { get; set; }
    }

    public class BitcoinData
    {
        public decimal Usd { get; set; }
    }
}
