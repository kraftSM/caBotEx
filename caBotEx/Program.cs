using System;
using System.Collections.Generic;
////using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Telegram.Bot;
using caBotCF.Controllers;
using caBotCF.Services;
using caBotCF.Configuration;

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
            AppSettings appSettings = BuildAppSettings();
            services.AddSingleton(BuildAppSettings());

            services.AddSingleton<IStorage, MemoryStorage>();

            // Подключаем контроллеры сообщений и кнопок          
            services.AddTransient<DefaultMessageController>();
            services.AddTransient<VoiceMessageController>();
            services.AddTransient<TextMessageController>();
            services.AddTransient<InlineKeyboardController>();

            // Регистрируем объект TelegramBotClient c токеном подключения
            //services.AddSingleton<ITelegramBotClient>(provider => new TelegramBotClient("5626451216:AAHQhegrbUZ7EchZWrNdzsfJrG7Jp15yYiA"));
            services.AddSingleton<ITelegramBotClient>(provider => new TelegramBotClient(appSettings.BotToken));// Регистрируем постоянно активный сервис бота
            services.AddHostedService<Bot>();
        }
        static AppSettings BuildAppSettings()
        {
            return new AppSettings()
            {
                DownloadsFolder = "C:\\Users\\evmor\\Downloads",
                BotToken = "5626451216:AAHQhegrbUZ7EchZWrNdzsfJrG7Jp15yYiA",
                AudioFileName = "audio",
                InputAudioFormat = "ogg",
            };
        }
    }

}
