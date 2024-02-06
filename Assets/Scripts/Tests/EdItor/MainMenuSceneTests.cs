using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;
using NUnit.Framework;
using VContainer.Unity;
using NSubstitute;
using PlatformGame.Application.Services;

namespace PlatformGame.Test.Editor
{
    [TestFixture]
    public class MainMenuSceneTests
    {
        [SetUp]
        public void CommonInstall()
        {
            var mockGameFlowManager = Substitute.For<GameFlowManager>();
            var container = new ContainerBuilder();
            container.RegisterInstance(mockGameFlowManager);
            //var gameFlowManager = container.Build().Resolve<GameFlowManager>();
            container.Build().Inject(this);
            // Assert
            //Assert.That(gameFlowManager != null);
        }

        [Inject] readonly GameFlowManager gameFlowManager;

        [Test]
        public void Should_InitGameFlowManager_When_IntoMainMenuScene()
        {
            Assert.That(gameFlowManager != null);

        }
    }
}
