using PlatformGame.Application.Interfaces;
using UnityEngine;

namespace PlatformGame.Presentation.UI
{
    public class PlayerMovement : MonoBehaviour,IPlayerMovement
    {
        private bool canMove,canJump;
        private float currentJumpForce;
        private Vector2 currentMoveVector;

        private Rigidbody2D rigidbody;

        // Start is called before the first frame update
        void Start()
        {
            Initialize();

        }

        private void FixedUpdate()
        {
            PlayerMove();
            PlayerJump();
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public void Initialize()
        {
            rigidbody = GetComponent<Rigidbody2D>();
        }

        private void PlayerMove()
        {
            if (canMove == false)
                return;
            if (rigidbody != null)
            {
                rigidbody.velocity = new Vector2(currentMoveVector.x, rigidbody.velocity.y);
            }
        }

        private void PlayerJump()
        {
            if(canJump == true)
            {
                rigidbody?.AddForce(new Vector2(rigidbody.velocity.x, currentJumpForce * 100));
                canJump = false;
            }
            
        }

        public void SetMoveVector(Vector2 moveVector)
        {
            currentMoveVector = moveVector;
        }

        public void SetJumpForce(float jumpForce)
        {
            currentJumpForce = jumpForce;
        }

        public void StartMove()
        {
            canMove = true;
        }

        public void StartJump()
        {
            canJump = true;
        }

        public void StopMove()
        {
            canMove = false;
        }

        public void StopJump()
        {
            canJump = false;
        }
    }
}
