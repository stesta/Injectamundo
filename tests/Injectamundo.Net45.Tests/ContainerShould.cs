using System;
using NUnit.Framework;

namespace Injectamundo.Net45.Tests
{
    [TestFixture]
    public class ContainerShould
    {
        [Test]
        public void resolve_the_implementation_for_a_registered_service()
        {
            // Arrange
            var container = new Container();
            container.Register<ITypeService, AlphaService>();

            // Act
            var instance = container.GetInstance<ITypeService>();

            Assert.IsInstanceOf<AlphaService>(instance);
        }

        [Test]
        public void resolve_a_concrete_type_even_if_it_is_not_registered()
        {
            // Arrange
            var container = new Container();

            // Act
            var instance = container.GetInstance<AlphaService>();

            Assert.IsInstanceOf<AlphaService>(instance);
        }

        [Test]
        public void throw_an_error_if_a_requested_type_cannot_be_resolved()
        {
            // Arrange 
            var container = new Container();

            // Act 
            Assert.Throws<Exception>(() => 
            {
                var instance = container.GetInstance<ITypeService>();
            });
        }
    }

    public interface ITypeService
    {
        string Name { get; }
    }

    public class AlphaService : ITypeService
    {
        public string Name
        {
            get
            {
                return "AlphaService";
            }
        }
    }

    public class BravoService : ITypeService
    {
        public string Name
        {
            get
            {
                return "BravoService";
            }
        }
    }
}
