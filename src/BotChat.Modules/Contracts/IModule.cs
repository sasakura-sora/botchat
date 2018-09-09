namespace BotChat.Modules.Contracts
{
    public interface IModule
    {
        bool Trigger(string message);
        string Process(string message);
    }
}
