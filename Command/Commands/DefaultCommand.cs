using System;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace telacubot.Command
{
    public class DefaultCommand : Command
    {
        public override string[] Names { get; set; }
            = new string[] {"/default"};

        public override async void Execute(TelegramBotClient botClient, Message message)
        {
            await botClient.SendTextMessageAsync(
                message.Chat.Id,
                message.Text,
                replyToMessageId: message.MessageId
            );

        }
    }
}
