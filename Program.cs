using System;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;


namespace telacubot
{
    class Program
    {
        private static TelegramBotClient _client;

        static void Main()
        {
            try
            {
                #region Preparation
                    _client = new TelegramBotClient(Config.token);
                #endregion

                #region StartBot
                    _client.StartReceiving();
                #endregion

                #region BotReaction
                    _client.OnMessage += OnMessageHandler;
                    Console.WriteLine("[LOG] Bot started");
                    Console.ReadKey();
                #endregion

                #region StopBot
                    _client.StopReceiving();
                #endregion
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static async void OnMessageHandler(object? sender, MessageEventArgs e)
        {
            var message = e.Message;

            Console.WriteLine($"[LOG] {message.Date} New message from: {message.From.FirstName} {message.From.LastName}");

            if (message.From.IsBot)
            {
                await _client.SendTextMessageAsync(message.Chat.Id,
                    $"I don't want to talk with other bots =^_-_^=");
                return;
            }

            switch (message.Type)
            {
                #region Type.Text
                case MessageType.Text:
                    if (message.Text == null)
                        await _client.SendTextMessageAsync(message.Chat.Id,
                            $"Text was missing",
                            replyToMessageId: message.MessageId
                        );
                    else
                        BotPerformer.PerformText(_client, message);
                    break;
                #endregion
                #region Type.Contact
                case MessageType.Contact:
                    if (string.IsNullOrEmpty(message.Contact.PhoneNumber))
                        await _client.SendTextMessageAsync(message.Chat.Id,
                            $"Phone number was missing",
                            replyToMessageId: message.MessageId
                        );
                    else
                        BotPerformer.PerformContact(_client, message);
                    break;
                #endregion

                #region Unknown
                case MessageType.Unknown:
                    await _client.SendTextMessageAsync(message.Chat.Id,
                        $"Error: Unknown type of massage",
                        replyToMessageId: message.MessageId
                    );
                    break;
                default:
                    Console.WriteLine($"[LOG]: Error {message.Type} not implemented");
                    await _client.SendTextMessageAsync(message.Chat.Id,
                        $"Sorry, {message.Type} not implemented",
                        replyToMessageId: message.MessageId
                    );
                    break;
                #endregion

            }

        }
    }

}
