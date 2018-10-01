using BotChat.Modules.Contracts;
using System;

namespace BotChat.Modules
{
    public class CommandModule : IModule
    {
        private readonly string triggerChar;

        public CommandModule()
        {
            triggerChar = "!command";
        }

        public string Process(string message)
        {
            throw new NotImplementedException();
        }

        public bool Trigger(string message)
        {
            return message.StartsWith(triggerChar);
        }
    }
}
