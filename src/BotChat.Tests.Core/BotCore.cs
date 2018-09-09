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
        public void GivenModules_NoModules_CanReceive()
        {
            var bot = new Bot();

            Assert.DoesNotThrow(() => bot.MessageReceive("test"));
        }

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

        [Test]
        public void GivenModule_WhenReceiving_ChecksTrigger()
        {
            const string message = "test";
            var bot = new Bot();

            var testModule = Substitute.For<IModule>();

            bot.ModuleLoad(testModule);

            bot.MessageReceive(message);

            testModule.Received(1).Trigger(Arg.Is(message));
        }

        [Test]
        public void GivenModule_WhenTriggered_ProcessesMessage()
        {
            const string message = "test";
            var bot = new Bot();

            var testModule = Substitute.For<IModule>();

            testModule.Trigger(Arg.Is(message)).Returns(true);

            bot.ModuleLoad(testModule);

            bot.MessageReceive(message);

            testModule.Received(1).Process(Arg.Is(message));
        }
        
        [Test]
        public void GivenModule_WhenNotTriggered_IgnoresMessage()
        {
            const string message = "test";
            var bot = new Bot();

            var testModule = Substitute.For<IModule>();

            testModule.Trigger(Arg.Is(message)).Returns(false);

            bot.ModuleLoad(testModule);

            bot.MessageReceive(message);

            testModule.Received(0).Process(Arg.Any<string>());
        }

        [Test]
        public void GivenMessage_BufferMessage_SendsMessage()
        {
            const string message = "test";
            var bot = new Bot();

            bot.MessageBuffer(message);
            var result = bot.MessageSend();

            Assert.AreEqual(message, result);
        }

        [Test]
        public void GivenModule_WithOutput_HasMessage()
        {
            const string message = "test";
            var bot = new Bot();

            var testModule = Substitute.For<IModule>();

            testModule.Trigger(Arg.Is(message)).Returns(true);

            bot.ModuleLoad(testModule);

            bot.MessageReceive(message);
        }

        [Test]
        public void GivenMessage_NoBuffer_NoOutput()
        {
            var bot = new Bot();

            var result = bot.MessageSend();

            Assert.IsEmpty(result);
        }
    }
}
