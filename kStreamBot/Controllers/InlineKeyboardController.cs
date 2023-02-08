using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using kStreamBot.Controllers;
using kStreamBot.Configuration;
using kStreamBot.Services;
using Telegram.Bot.Types.Enums;

namespace kStreamBot.Controllers
{
        public class InlineKeyboardController
    {
        private readonly ITelegramBotClient _telegramClient;
        private readonly AppSettings _appSettings;
        private readonly IStorage _memoryStorage;

        public InlineKeyboardController(ITelegramBotClient telegramBotClient, IStorage memoryStorage, AppSettings appSettings)
        {
            _telegramClient = telegramBotClient;
            _appSettings= appSettings;
            _memoryStorage = memoryStorage;
        }
        public async Task Handle(CallbackQuery? callbackQuery, CancellationToken ct)
        {
            if (callbackQuery?.Data == null)
                return;
            _memoryStorage.GetSession(callbackQuery.From.Id).Mode = callbackQuery.Data;
            string modeTxt = callbackQuery.Data switch
            {
                "cnt" => " Подсчет символов в строке. Введите её",
                "sum" => " Подсчет суммы целых чисел. Введите их через пробелы",
                _ => String.Empty
            };
            //_appSettings.SubTaskMode = modeTxt;
            _appSettings.SubTaskMode = callbackQuery.Data;
            Console.WriteLine($"Контроллер {GetType().Name} получил сообщение {callbackQuery.From}Обнаружено нажатие на кнопку {callbackQuery.Data} [IKCH-0]");
           // Отправляем в ответ уведомление о выборе
            await _telegramClient.SendTextMessageAsync(callbackQuery.From.Id,
                $"<b>Режим бота: {modeTxt}.{Environment.NewLine}</b>" +
                $"{Environment.NewLine}Можно поменять в главном меню.", cancellationToken: ct, parseMode: ParseMode.Html);
            //switch (callbackQuery.Data) 
            //{
            //    case "sum":
            //        Console.WriteLine("надо вызвать Сервис DefineSumm ");
            //        break;
            //    case "cnt":
            //        Console.WriteLine("надо вызвать Сервис DefineCharCnt ");
            //        break;
            //    default: 
            //        Console.WriteLine("надо выбрать Сервис ??? ");
            //        break;
            //}

            //await _telegramClient.SendTextMessageAsync(callbackQuery.From.Id, $"Обнаружено нажатие на кнопку {callbackQuery.Data} [IKCH-1]", cancellationToken: ct);
            
        }
    }
}

