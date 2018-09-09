using BotChat.Modules.Contracts;
using System.Collections.Generic;

namespace BotChat.Core
{
    public class Bot
    {
        private List<IModule> modules;
        private string messageBuffer = string.Empty;

        public Bot()
        {
            modules = new List<IModule>();
        }              

        public void ModuleLoad(IModule module)
        {
            if (modules.Contains(module) == false)
            {
                modules.Add(module);
            }
        }

        public List<IModule> ModuleList() => modules;

        public void MessageReceive(string message)
        {
            foreach (var module in modules)
            {
                if (module.Trigger(message))
                {
                    var output = module.Process(message);

                    if(string.IsNullOrEmpty(output) == false)
                    {
                        MessageBuffer(output);
                    }
                }
            }
        }

        public void MessageBuffer(string message)
        {
            messageBuffer = message;
        }

        public string MessageSend()
        {
            var output = messageBuffer;
            messageBuffer = string.Empty;

            return output;
        }
    }
}
