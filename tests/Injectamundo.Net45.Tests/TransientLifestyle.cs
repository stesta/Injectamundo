using System;
using NUnit.Framework;

namespace Injectamundo.Net45.Tests
{
    [TestFixture]
    public class TransientLifestyle
    {
        [Test]
        public void resolve_a_new_instance_for_transient_types_for_each_request()
        {
            // Arrange
            var container = new Container();
            container.Register<AlphaService, AlphaService>();

            // Act
            var instanceOne = container.GetInstance<AlphaService>();
            var instanceTwo = container.GetInstance<AlphaService>();

            Assert.AreNotEqual(instanceOne, instanceTwo);
        }
    }
}
