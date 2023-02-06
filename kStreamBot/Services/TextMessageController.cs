using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types.Enums;

namespace kStreamBot.Controllers
{
    public class TextMessageController
    {
        private readonly ITelegramBotClient _telegramClient;

        public TextMessageController(ITelegramBotClient telegramBotClient)
        {
            _telegramClient = telegramBotClient;
        }

        public async Task Handle(Message message, CancellationToken ct)
        {
            switch (message.Text)
            {
                case "/start":
                    Console.WriteLine(" Получена команда /start Бот (пере)запущен");
                    // Объект, представляющий кноки
                    var buttons = new List<InlineKeyboardButton[]>();
                    buttons.Add(new[]
                    {
                        //InlineKeyboardButton.WithCallbackData($" Русский" , $"ru"),
                        //InlineKeyboardButton.WithCallbackData($" English" , $"en"),
                        InlineKeyboardButton.WithCallbackData($" Подсчет символов" , $"cnt"),
                        InlineKeyboardButton.WithCallbackData($" Сумма чисел" , $"sum")
                    });

                    // передаем кнопки вместе с сообщением (параметр ReplyMarkup)
                    await _telegramClient.SendTextMessageAsync(message.Chat.Id, $"<b>  Этот бот учебный. Он подсчитывает сиволы в строке </b> {Environment.NewLine}" +
                        $"{Environment.NewLine}Или возвращает сумму целых чисел.{Environment.NewLine}", cancellationToken: ct, parseMode: ParseMode.Html, replyMarkup: new InlineKeyboardMarkup(buttons));

                    break;
                case "/stop":
                    Console.WriteLine(" Получена команда /stoр Бот завершен(?)"); 
                    CancellationTokenSource cts = new(); 
                    cts.Cancel();
                    
                    break;
                default:
                    await _telegramClient.SendTextMessageAsync(message.Chat.Id, "Отправьте аудио для превращения в текст.", cancellationToken: ct);
                    break;
            }
        }
    }
}
