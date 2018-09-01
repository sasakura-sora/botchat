using BotChat.Modules.Contracts;
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
    }
}
