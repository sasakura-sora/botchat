using BotChat.Core;
using BotChat.Modules;
using System;

namespace BotChat.ConsoleHost
{
    class Program
    {
        static void Main(string[] args)
        {
            var bot = new Bot();

            bot.ModuleLoad(new EchoModule());

            while (true)
            {
                var input = Console.ReadLine();
                bot.MessageReceive(input);
                Console.WriteLine(bot.MessageSend());
            }
        }
    }
}
