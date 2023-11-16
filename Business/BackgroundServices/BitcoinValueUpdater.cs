using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Business.Abstract;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Business.BackgroundServices
{
    public class BitcoinValueUpdater
    {
        private readonly IBitcoinValueService _bitcoinValueService;
        private readonly HttpClient _httpClient;

        public BitcoinValueUpdater(IBitcoinValueService bitcoinValueService, HttpClient httpClient)
        {
            _bitcoinValueService = bitcoinValueService;
            _httpClient = httpClient;
        }
        public async Task RunBitcoinUpdaterWithInterval(TimeSpan interval, CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                await UpdateBitcoinValues();

                // Belirlediğiniz aralık kadar bekleyin
                await Task.Delay(interval, cancellationToken);
            }
        }
        public async Task UpdateBitcoinValues()
        {
            // CoinGecko API'den Bitcoin değerlerini çekme
            var bitcoinApiResponse = await GetBitcoinValuesFromApi();

            // API'den alınan değeri veritabanına ekleme
            await _bitcoinValueService.AddBitcoinValueAsync(bitcoinApiResponse);
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
                Console.WriteLine($"Error while getting Bitcoin values from API: {ex.Message}");
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
