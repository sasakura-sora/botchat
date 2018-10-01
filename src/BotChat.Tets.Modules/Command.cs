using BotChat.Modules;
using NUnit.Framework;
using System.Diagnostics.CodeAnalysis;

namespace BotChat.Tets.Modules
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class Command
    {
        [Test]
        public void GivenTrigger_WhenMessageIsWord_ReturnsTrue()
        {
            const string triggerMessage = "!command";

            var module = new CommandModule();

            var result = module.Trigger(triggerMessage);

            Assert.IsTrue(result);
        }

        [Test]
        public void GivenTrigger_WhenMessageStartsWithWord_ReturnsTrue()
        {
            const string triggerMessage = "!command do the thing";

            var module = new CommandModule();

            var result = module.Trigger(triggerMessage);

            Assert.IsTrue(result);
        }

        [Test]
        public void GivenTrigger_WhenMessageEmpty_ReturnsFalse()
        {
            string triggerMessage = string.Empty;

            var module = new CommandModule();

            var result = module.Trigger(triggerMessage);

            Assert.IsFalse(result);
        }

        [Test]
        public void GivenTrigger_WhenNotTrigger_ReturnsFalse()
        {
            const string triggerMessage = "this does not contain a trigger";

            var module = new CommandModule();

            var result = module.Trigger(triggerMessage);

            Assert.IsFalse(result);
        }

        [Test]
        public void GivenTrigger_WhenContainsTrigger_ReturnsFalse()
        {
            const string triggerMessage = "this contain !command";

            var module = new CommandModule();

            var result = module.Trigger(triggerMessage);

            Assert.IsFalse(result);
        }
    }
}
