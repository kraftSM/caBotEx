using System;
using System.Collections.Generic;
////using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Telegram.Bot;

namespace caBotCF
{
    public class Program
    {
        public static async Task Main()
        {
            Console.OutputEncoding = Encoding.Unicode;

            // Объект, отвечающий за постоянный жизненный цикл приложения
            var host = new HostBuilder()
                .ConfigureServices((hostContext, services) => ConfigureServices(services)) // Задаем конфигурацию
                .UseConsoleLifetime() // Позволяет поддерживать приложение активным в консоли
                .Build(); // Собираем

            Console.WriteLine("Хост создан. Запускаем Сервис ");
            // Запускаем сервис
            await host.RunAsync();
            Console.WriteLine("Сервис запущен");
            Console.WriteLine("Сервис остановлен");
        }

        static void ConfigureServices(IServiceCollection services)
        {
            // Регистрируем объект TelegramBotClient c токеном подключения
            services.AddSingleton<ITelegramBotClient>(provider => new TelegramBotClient("5626451216:AAHQhegrbUZ7EchZWrNdzsfJrG7Jp15yYiA"));
            // Регистрируем постоянно активный сервис бота
            services.AddHostedService<Bot>();
        }
    }

}
