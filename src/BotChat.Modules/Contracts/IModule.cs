namespace BotChat.Modules.Contracts
{
    public interface IModule
    {
        bool Trigger(string message);
        void Process(string message);
    }
}
