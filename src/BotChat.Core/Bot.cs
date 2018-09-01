using BotChat.Modules.Contracts;
using System;
using System.Collections.Generic;

namespace BotChat.Core
{
    public class Bot
    {
        private List<IModule> modules;

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
                    module.Process(message);
                }
            }
        }
    }
}
