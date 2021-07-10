using System;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace telacubot.Command
{
    public class LoginCommand : Command
    {
        public override string[] Names { get; set; }
            = new string[] {"/login", "/setlogin"};
        public override async void Execute(TelegramBotClient botClient, Message message)
        {
            await botClient.SendTextMessageAsync(
                message.Chat.Id,
                $"To login you, first I need your phone number for Telegram",
                replyToMessageId: message.MessageId,
                replyMarkup: GetKeyboardPhone()
            );
        }

        private static IReplyMarkup GetKeyboardPhone()
        {
            return new ReplyKeyboardMarkup(
                keyboard: new[]
                {
                    new []
                    {
                        new KeyboardButton("My phone number for Telegram") {RequestContact = true},
                        new KeyboardButton("Cancel")
                    }
                },
                resizeKeyboard: true,
                oneTimeKeyboard: true
            );
        }
    }
}
