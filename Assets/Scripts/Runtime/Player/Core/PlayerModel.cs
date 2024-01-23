using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformGame.Player.Core
{
    public class PlayerModel
    {
        public float MaxHealth { get; private set; }
        public float MinHealth { get; private set; }
        public float Health { get; private set; }
        public float MoveSpeed { get; private set; }
        public float JumpForce { get; private set; }

        public PlayerModel()
        {
            MaxHealth = 100f;
            MinHealth = 0f;
            Health = 100f;
            MoveSpeed = 3f;
            JumpForce = 3f;
        }

        public void SetHealthRange(float minValue,float maxValue)
        {
            MaxHealth = (maxValue>minValue)?maxValue:minValue;
            MinHealth = (minValue<maxValue)?minValue:maxValue;
        }

        public void SetHealth(float value)
        {
            Health = Mathf.Abs(value);

            Health = Mathf.Clamp(Health,MinHealth,MaxHealth);

        }

        public void IncreaseHealth(float value)
        {
            Health += Mathf.Abs(value);

            Health = Mathf.Clamp(Health, MinHealth, MaxHealth);

        }

        public void DecreaseHealth(float value)
        {
            Health -= Mathf.Abs(value);

            Health = Mathf.Clamp(Health, MinHealth, MaxHealth);

        }

        public void SetMoveSpeed(float newMoveSpeed)
        {
            MoveSpeed = newMoveSpeed;
        }

        public void SetJumpForce(float newJumpForce)
        {
            JumpForce = newJumpForce;
        }


    }
}
