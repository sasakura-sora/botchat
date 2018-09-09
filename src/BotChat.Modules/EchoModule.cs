using BotChat.Modules.Contracts;

namespace BotChat.Modules
{
    public class EchoModule : IModule
    {
        public string Process(string message)
        {
            return $"echo: {message}";
        }

        public bool Trigger(string message)
        {
            return true;
        }
    }
}
