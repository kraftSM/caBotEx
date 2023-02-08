using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types.Enums;
using kStreamBot.Services;
using kStreamBot.Configuration;
using System.Runtime.Serialization.Formatters;

namespace kStreamBot.Controllers
{
    public class TextMessageController
    {
        private readonly ITelegramBotClient _telegramClient;
        private readonly AppSettings _appSettings;
        private readonly ISubTask _subTask;
        public TextMessageController(AppSettings appSettings, ITelegramBotClient telegramBotClient, ISubTask subTask)
        {
            _appSettings = appSettings;
            _telegramClient = telegramBotClient;
            _subTask = subTask;
        }

        public async Task Handle(Message message, CancellationToken ct)
        {
            string sTaskMode = _appSettings.SubTaskMode;
            string inMsg = message.Text;
            string resultMsg = inMsg;

            //if (sTaskMode == "") inMsg = "/start";
            //string.IsNullOrEmpty(sTaskMode)
            if (string.IsNullOrEmpty(sTaskMode)) inMsg = "/start";
            //switch (message.Text)
            switch (inMsg)
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
                        $"{Environment.NewLine}Или возвращает сумму целых чисел.{Environment.NewLine} выберите режим нижележащими кнопками {Environment.NewLine}", cancellationToken: ct, parseMode: ParseMode.Html, replyMarkup: new InlineKeyboardMarkup(buttons));

                    break;
                case "/stop":
                    Console.WriteLine(" Получена команда /stoр Бот завершен(?)"); 
                    CancellationTokenSource cts = new(); 
                    cts.Cancel();
                    
                    break;
                default:
                    resultMsg = _subTask.Operate(message.Text, sTaskMode);
                    //await _telegramClient.SendTextMessageAsync(message.Chat.Id, "ВЫберите действие нажатием на кнопку.[TMCH]", cancellationToken: ct);
                    _appSettings.SubTaskMode ="";
                    await _telegramClient.SendTextMessageAsync(message.Chat.Id, resultMsg+"[TMCH9]", cancellationToken: ct);
                     
                    break;
            }
        }
    }
}
