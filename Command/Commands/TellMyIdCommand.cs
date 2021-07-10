using System;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;


namespace telacubot.Command
{
    public class TellMyIdCommand : Command
    {
        public override string[] Names { get; set; }
            = new string[] {"/tellmyid"};

        public override async void Execute(TelegramBotClient botClient, Message message)
        {
            await botClient.SendTextMessageAsync(
                message.Chat.Id,
                $"Your Telegram username is <b>{message.From.Username}</b>" +
                    $"\nyour chat-id is <b>{message.Chat.Id}</b>",
                parseMode: ParseMode.Html
            );

        }
    }
}
