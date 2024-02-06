using UnityEngine;
using NUnit.Framework;
using VContainer;
using VContainer.Unity;
using NSubstitute;
using PlatformGame.Domain.Entities;
using PlatformGame.Application.Services;
using PlatformGame.Application.Interfaces;

namespace PlatformGame.Test.Editor
{
    [TestFixture]
    public class PlayerTests
    {
        [SetUp]
        public void CommonInstall()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.Register<Entity>(Lifetime.Scoped);
            builder.Register<PlayerController>(Lifetime.Scoped);

            IPlayerMovement mockPlayerMovement = Substitute.For<IPlayerMovement>();

            builder.RegisterInstance<IPlayerMovement>(mockPlayerMovement);

            builder.Build().Inject(this);

        }

        [Inject] private readonly Entity playerModel;
        [Inject] private readonly PlayerController playerController;
        [Inject] private readonly IPlayerMovement playerMovement;

        [Test,Order(0)]
        public void When_Created_Then_InitializeProperties()
        {
            Assert.IsNotNull(playerModel);
            Assert.IsNotNull(playerController);
            Assert.IsNotNull(playerMovement);
        }

        [Test, Order(1)]
        [TestCase(20, 10, 0, 100, 30)]
        [TestCase(80, 10, 0, 60, 60)]
        [TestCase(50, 10, 60, 100, 70)]
        [TestCase(0, 110, 0, 100, 100)]
        public void Given_HealthValue_When_TakeHeal_Then_IncreaseInRangeAndIsCorrectValue(float initialValue, float healingValue, float minValue, float maxValue, float targetValue)
        {
            playerModel.SetHealthRange(minValue, maxValue);
            playerModel.SetHealth(initialValue);
            playerModel.IncreaseHealth(healingValue);
            Assert.AreEqual(targetValue, playerModel.Health);

        }

        [Test, Order(2)]
        [TestCase(100,10,0,100,90)]
        [TestCase(100, 10, 0, 90,80)]
        [TestCase(50, 10, 60, 100,60)]
        [TestCase(100, 110, 0, 100, 0)]
        public void Given_HealthValue_When_TakeDamage_Then_DecreaseInRangeAndIsCorrectValue(float initialValue,float damageValue,float minValue,float maxValue,float targetValue)
        {
            playerModel.SetHealthRange(minValue,maxValue);
            playerModel.SetHealth(initialValue);
            playerModel.DecreaseHealth(damageValue);
            Assert.AreEqual(targetValue, playerModel.Health);

        }

        [Test, Order(3)]
        public void When_HorizontalInputOnce_Then_PlayerMovementOnce()
        {
            //arrange
            var input = new Vector2(1, 0);

            //act
            playerController.OnPlayerMove(input);

            //assert
            playerMovement.Received(1).SetMoveVector(new Vector2(input.x * playerModel.MoveSpeed, 0f));
            playerMovement.Received(1).StartMove();

        }

        [Test, Order(4)]
        public void When_JumpInputOnce_Then_PlayerJumpOnce()
        {
            //arrange
            var input = playerModel.JumpForce;

            //act
            playerController.OnPlayerJump();

            //assert
            playerMovement.Received(1).SetJumpForce(input);
            playerMovement.Received(1).StartJump();

        }

    }
}
