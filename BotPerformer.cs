using System;
using telacubot.Command;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;


namespace telacubot
{
    public static class BotPerformer
    {
        internal static bool _loggedIn;
        // methods

        public static async void PerformText(TelegramBotClient outClient, Message message)
        {
            Console.WriteLine($"[>>>] Message text: {message.Text}");
            if (message.Text[0] == '/')
                Activities.CallCommand(outClient, message);
            else
                await outClient.SendTextMessageAsync(message.Chat.Id,
                    $"I don't know currently how to response",
                    replyToMessageId: message.MessageId
                );
        }

        public static async void PerformContact(TelegramBotClient outClient, Message message)
        {
            Console.WriteLine($"[Data] From {message.From.FirstName} {message.From.LastName}:");
            Console.WriteLine($"[>>>>] Contact {message.Contact.FirstName} {message.Contact.LastName}");
            Console.WriteLine($"[>>>>] Phone {message.Contact.PhoneNumber}");
            await outClient.SendTextMessageAsync(message.Chat.Id,
                $"{message.From.FirstName} I've got your number {message.Contact.PhoneNumber}",
                replyMarkup: new ReplyKeyboardRemove()
            );
        }
    }
}