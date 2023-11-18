using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System.Net.Http;
using Microsoft.Extensions.Http;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleUI
{
    internal class Program
    {
        static async Task Main()
        {
            // Servis bağlamını oluştur
            var serviceProvider = ConfigureServices();

            // BitcoinValueUpdater sınıfını al
            var bitcoinValueUpdater = serviceProvider.GetRequiredService<BitcoinValueUpdater>();

            using (var cancellationTokenSource = new CancellationTokenSource())
            {
                var cancellationToken = cancellationTokenSource.Token;

                // Bitcoin değerlerini belirli bir aralıkta güncelle
                //await bitcoinValueUpdater.RunBitcoinUpdaterWithInterval(TimeSpan.FromSeconds(10), cancellationToken);
            }
        }

        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            // IBitcoinValueService, IBitcoinValueDal, HttpClient ve diğer servisleri ekleyin
            services.AddHttpClient();
            services.AddTransient<IBitcoinValueService, BitcoinValueManager>();
            services.AddTransient<IBitcoinValueDal, EfBitcoinValueDal>();
            services.AddTransient<BitcoinValueUpdater>();  // Eklediğimiz satır

            return services.BuildServiceProvider();
        }
    }
}
