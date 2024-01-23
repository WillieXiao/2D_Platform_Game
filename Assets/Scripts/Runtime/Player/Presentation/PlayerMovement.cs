using PlatformGame.Player.Application;
using UnityEngine;

namespace PlatformGame.Player.Presentation
{
    public class PlayerMovement : MonoBehaviour,IPlayerMovement
    {
        private Rigidbody2D rigidbody;
        


        // Start is called before the first frame update
        public void Start()
        {
            Initialize();

        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public void Initialize()
        {
            rigidbody = GetComponent<Rigidbody2D>();
        }

        public void PlayerMove(Vector2 moveVector)
        {
            rigidbody.velocity = moveVector;

        }

        
    }
}
