using PlatformGame.Player.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformGame.Player.Application
{
    public class PlayerPresenter
    {
        private readonly PlayerModel playerModel;
        private readonly IPlayerMovement playerMovement;

        public PlayerPresenter(PlayerModel playerModel,IPlayerMovement playerMovement)
        {
            this.playerModel = playerModel;
            this.playerMovement = playerMovement;
        }

        public void OnPlayerMove(Vector2 inputVector)
        {
            Vector2 moveVector = new Vector2(inputVector.x * playerModel.MoveSpeed,0f);
            playerMovement.PlayerMove(moveVector);
        }


    }
}
