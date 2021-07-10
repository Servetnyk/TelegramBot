using System;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace telacubot.Command
{
    public class StartCommand : Command
    {
        public override string[] Names { get; set; }
            = new string[] {"/start", "start"};

        public override async void Execute(TelegramBotClient botClient, Message message)
        {
            await botClient.SendTextMessageAsync(
                message.Chat.Id,
                $"Hello <i>{message.From.FirstName}</i>, we are Acumatica Ukraine team",
                parseMode: ParseMode.Html
            );
        }
    }
}
