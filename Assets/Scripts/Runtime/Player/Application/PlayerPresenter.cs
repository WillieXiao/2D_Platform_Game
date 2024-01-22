using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformGame.Player.Application
{
    public class PlayerPresenter
    {
        public IPlayerMovement playerMovement;

        public PlayerPresenter(IPlayerMovement playerMovement)
        {
            this.playerMovement = playerMovement;
        }



    }
}
