using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformGame.Application.Interfaces
{
    public interface IPlayerMovement
    {
        public void Initialize();
        public void SetMoveVector(Vector2 moveVector);
        public void SetJumpForce(float jumpForce);
        public void StartMove();
        public void StopMove();
        public void StartJump();
        public void StopJump();
    }
}
