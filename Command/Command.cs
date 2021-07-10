using System.Linq;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace telacubot.Command
{
    public abstract class Command
    {
        public abstract string[] Names { set; get; }
        public abstract void Execute(TelegramBotClient outClient, Message message);

        public bool Contains(string message)
        {
            return Names.Any(message.Contains);
        }

    }
}
