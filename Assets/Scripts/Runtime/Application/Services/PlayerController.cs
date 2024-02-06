using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;
using R3;
using PlatformGame.Domain.Entities;
using PlatformGame.Application.Interfaces;

namespace PlatformGame.Application.Services
{
    public class PlayerController
    {
        private readonly Entity playerEntity;
        private readonly IPlayerMovement playerMovement;

        public PlayerController(Entity playerModel,IPlayerMovement playerMovement)
        {
            this.playerEntity = playerModel;
            this.playerMovement = playerMovement;

        }

        public void OnPlayerMove(Vector2 inputVector)
        {
            Vector2 moveVector = new Vector2(inputVector.x * playerEntity.MoveSpeed,0f);
            if(moveVector == Vector2.zero)
            {
                playerMovement.StopMove();
            }
            else
            {
                playerMovement.SetMoveVector(moveVector);
                playerMovement.StartMove();
            }
            
        }

        public void OnPlayerJump()
        {
            playerMovement.SetJumpForce(playerEntity.JumpForce);
            playerMovement.StartJump();
        }

    }
}
