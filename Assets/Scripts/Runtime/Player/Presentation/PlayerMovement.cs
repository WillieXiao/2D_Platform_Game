using PlatformGame.Player.Application;
using UnityEngine;

namespace PlatformGame.Player.Presentation
{
    public class PlayerMovement : MonoBehaviour,IPlayerMovement
    {
        private Rigidbody rigidbody;
      


        // Start is called before the first frame update
        void Start()
        {
            rigidbody = GetComponent<Rigidbody>();

        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public void Move(Vector2 movement)
        {
            throw new System.NotImplementedException();
        }

    }
}