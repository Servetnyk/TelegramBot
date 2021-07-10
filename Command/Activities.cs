using System;
using System.Collections.Generic;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace telacubot.Command
{
    public static class Activities
    {
        private static List<Command> _commands;

        private static List<Command> PossibleActivities()
        {
            return new()
            {
                new TellMyIdCommand(),
                new StartCommand(),
                new LoginCommand()
            };
        }

        public static void CallCommand(TelegramBotClient outClient, Message incomeMessage)
        {
            _commands = PossibleActivities();
            foreach (var comm in _commands)
            {
                if (comm.Contains(incomeMessage.Text))
                {
                    comm.Execute(outClient, incomeMessage);
                }
            }

        }

    }
}