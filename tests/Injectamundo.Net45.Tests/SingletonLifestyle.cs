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
            container.Register<AlphaService>(Lifestyle.Singleton);

            // Act
            var instanceOne = container.GetInstance<AlphaService>();
            var instanceTwo = container.GetInstance<AlphaService>();

            Assert.AreEqual(instanceOne, instanceTwo);
        }

        [Test]
        public void resolve_the_same_instance_for_singleton_types_manually_instantiated()
        {
            // Arrange
            var container = new Container();
            container.Register(() => new AlphaService(), Lifestyle.Singleton);

            // Act
            var instanceOne = container.GetInstance<AlphaService>();
            var instanceTwo = container.GetInstance<AlphaService>();

            Assert.AreEqual(instanceOne, instanceTwo);
        }

        [Test]
        public void resolve_the_same_instance_for_singleton_types_for_each_request_using_convenience_methods()
        {
            // Arrange
            var container = new Container();
            container.RegisterSingle<AlphaService>();
            container.RegisterSingle<ITypeService, BetaService>(() => new BetaService("Manual Init"));

            // Act
            var alphaOne = container.GetInstance<AlphaService>();
            var alphaTwo = container.GetInstance<AlphaService>();
            var betaOne = container.GetInstance<ITypeService>();
            var betaTwo = container.GetInstance<ITypeService>();

            Assert.AreEqual(alphaOne, alphaTwo);
            Assert.AreEqual(betaOne, betaTwo);
        }
    }
}
