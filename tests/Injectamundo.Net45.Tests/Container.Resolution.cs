﻿using System;
using NUnit.Framework;

namespace Injectamundo.Net45.Tests
{
    [TestFixture]
    public class ContainerResolution
    {
        [Test]
        public void resolve_an_implementation_for_a_registered_service()
        {
            // Arrange
            var container = new Container();
            container.Register<ITypeService, AlphaService>();

            // Act
            var instance = container.GetInstance<ITypeService>();

            Assert.IsInstanceOf<AlphaService>(instance);
        }

        [Test]
        public void make_sure_only_instance_of_each_lifestyle_type_gets_cached()
        {
            // Arrange
            var container = new Container();
            container.Register<AlphaService, AlphaService>();
            container.Register<BetaService, BetaService>();

            // Act
            var instanceAlpha = container.GetInstance<AlphaService>();
            var instanceBeta = container.GetInstance<BetaService>();

            Assert.IsTrue(container.instanceProducer.lifestyleCache.Count == 1);
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
}