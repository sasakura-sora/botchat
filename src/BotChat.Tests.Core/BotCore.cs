using BotChat.Core;
using BotChat.Modules.Contracts;
using NSubstitute;
using NUnit.Framework;

namespace BotChat.Tests.Core
{
    [TestFixture]
    public class BotCore
    {
        [Test]
        public void GivenModules_WhenLoading_IsAvailable()
        {
            var bot = new Bot();

            var testModule = Substitute.For<IModule>();

            bot.ModuleLoad(testModule);

            var modules = bot.ModuleList();

            Assert.IsNotEmpty(modules);
        }

        [Test]
        public void GivenModules_WhenLoadingDuplicate_LoadsOnce()
        {
            var bot = new Bot();

            var testModule = Substitute.For<IModule>();

            bot.ModuleLoad(testModule);
            bot.ModuleLoad(testModule);

            var modules = bot.ModuleList();

            Assert.IsNotEmpty(modules);
            Assert.AreEqual(1, modules.Count);
        }
    }
}
