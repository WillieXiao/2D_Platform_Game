using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformGame.Player.Application
{
    public interface IPlayerMovement
    {
        public void PlayerMove(Vector2 movement);
    }
}
