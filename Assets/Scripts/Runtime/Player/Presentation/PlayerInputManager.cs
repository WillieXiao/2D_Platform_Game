using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlatformGame.Player.Application;
using VContainer;

namespace PlatformGame.Player.Presentation
{
    public class PlayerInputManager : MonoBehaviour
    {
        [Inject]
        private readonly PlayerPresenter presenter;

        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            HandleMovementInput();
        }

        public void HandleMovementInput()
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            Vector2 inputVector = new Vector2 (horizontalInput, 0);
            if (inputVector == Vector2.zero)
                return;
            presenter.OnPlayerMove(inputVector);


        }

    }
}
