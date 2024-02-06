using PlatformGame.Application.Services;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

namespace PlatformGame.Presentation.UI
{
    public class PlayerInputManager : MonoBehaviour
    {
        [Inject]
        private readonly PlayerController controller;

        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            HandleMoveInput();
            HandleJumpInput();
        }

        public void HandleMoveInput()
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            Vector2 inputVector = new Vector2 (horizontalInput, 0);
            controller.OnPlayerMove(inputVector);
        }

        public void HandleJumpInput()
        {
            bool jumpInput = Input.GetKeyDown(KeyCode.Space);
            if (jumpInput == true)
            {
                controller.OnPlayerJump();
            }
           

        }

    }
}
