using UnityEngine;
using NUnit.Framework;
using VContainer;
using PlatformGame.Player.Core;
using PlatformGame.Player.Application;
using PlatformGame.Player.Presentation;
using VContainer.Unity;
using NSubstitute;


namespace PlatformGame.Test.Editor
{
    [TestFixture]
    public class PlayerTests
    {
        [SetUp]
        public void CommonInstall()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.Register<PlayerModel>(Lifetime.Scoped);
            builder.Register<PlayerPresenter>(Lifetime.Scoped);

            fakePlayer = new GameObject();
            fakePlayer.AddComponent<Rigidbody2D>();
            var playerInputManager = fakePlayer.AddComponent<PlayerInputManager>();
            var playerMovement = fakePlayer.AddComponent<PlayerMovement>();
            builder.RegisterComponent<PlayerMovement>(playerMovement).As<IPlayerMovement>();

            builder.Build().Inject(this);

        }


        GameObject fakePlayer;
        [Inject] private readonly PlayerModel playerModel;
        [Inject] private readonly PlayerPresenter playerPresenter;
        [Inject] private readonly IPlayerMovement playerMovement;

        [Test,Order(0)]
        public void When_Created_Then_InitializeProperties()
        {
            Assert.IsNotNull(playerModel);
            Assert.IsNotNull(playerPresenter);
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
        [TestCase(5,-1,-5)]
        public void When_HorizontalInput_Then_PlayerMovement(float speed,float horizontalAxisInput, float targetVectorX)
        {
            //arrange
            playerModel.SetMoveSpeed(speed);
            playerMovement.Initialize();

            //act
            playerPresenter.OnPlayerMove(new Vector2(horizontalAxisInput, 0));

            //assert
            var rigibody2D = fakePlayer.GetComponent<Rigidbody2D>();
            Assert.AreEqual(new Vector2(targetVectorX, 0), rigibody2D.velocity);

        }

    }
}
