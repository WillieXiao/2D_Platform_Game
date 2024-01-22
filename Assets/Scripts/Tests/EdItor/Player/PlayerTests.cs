using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using VContainer;
using PlatformGame.Player.Core;

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
            builder.Build().Inject(this);
        }

        [Inject]
        private readonly PlayerModel player;

        [Test,Order(0)]
        public void When_Created_Then_InitializeProperties()
        {
            Assert.IsNotNull(player.MaxHealth);
            Assert.IsNotNull(player.MinHealth);
            Assert.IsNotNull(player.Health);
            Assert.IsNotNull(player.MoveSpeed);
            Assert.IsNotNull(player.JumpForce);
        }

        [Test, Order(1)]
        [TestCase(20, 10, 0, 100, 30)]
        [TestCase(80, 10, 0, 60, 60)]
        [TestCase(50, 10, 60, 100, 70)]
        [TestCase(0, 110, 0, 100, 100)]
        public void Given_HealthValue_When_TakeHeal_Then_IncreaseInRangeAndIsCorrectValue(float initialValue, float healingValue, float minValue, float maxValue, float targetValue)
        {
            player.SetHealthRange(minValue, maxValue);
            player.SetHealth(initialValue);
            player.IncreaseHealth(healingValue);
            Assert.AreEqual(targetValue, player.Health);

        }

        [Test, Order(2)]
        [TestCase(100,10,0,100,90)]
        [TestCase(100, 10, 0, 90,80)]
        [TestCase(50, 10, 60, 100,60)]
        [TestCase(100, 110, 0, 100, 0)]
        public void Given_HealthValue_When_TakeDamage_Then_DecreaseInRangeAndIsCorrectValue(float initialValue,float damageValue,float minValue,float maxValue,float targetValue)
        {
            player.SetHealthRange(minValue,maxValue);
            player.SetHealth(initialValue);
            player.DecreaseHealth(damageValue);
            Assert.AreEqual(targetValue, player.Health);

        }

       

    }
}
