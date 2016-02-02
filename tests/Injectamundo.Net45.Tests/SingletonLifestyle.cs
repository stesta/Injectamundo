using System;
using NUnit.Framework;

namespace Injectamundo.Net45.Tests
{
    [TestFixture]
    public class SingletonLifestyle
    {
        [Test]
        public void resolve_the_same_instance_for_singleton_types_for_each_request()
        {
            // Arrange
            var container = new Container();
            container.Register<AlphaService, AlphaService>(Lifestyle.Singleton);

            // Act
            var instanceOne = container.GetInstance<AlphaService>();
            var instanceTwo = container.GetInstance<AlphaService>();

            Assert.AreEqual(instanceOne, instanceTwo);
        }
    }
}
