using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Injectamundo.Net45.Tests
{
    [TestClass]
    public class ContainerShould
    {
        [TestMethod]
        public void resolve_the_implementation_for_a_registered_service()
        {
            // Arrange
            var container = new Container();
            container.Register<ITypeService, AlphaService>();

            // Act
            var instance = container.GetInstance<ITypeService>();

            Assert.IsInstanceOfType(instance, typeof(AlphaService));
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
