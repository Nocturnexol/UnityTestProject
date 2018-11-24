using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(CharacterController))]
    [AddComponentMenu("Control Scripts/FPS Input")]
    public class FPSInput : MonoBehaviour
    {
        public float Speed = 6;

        public float Gravity = -9.8f;

        private CharacterController _characterController;
        // Use this for initialization
        void Start ()
        {
            _characterController = GetComponent<CharacterController>();
        }
	
        // Update is called once per frame
        void Update ()
        {
            var deltaX = Input.GetAxis("Horizontal") * Speed;
            var deltaZ = Input.GetAxis("Vertical") * Speed;
            var movement=new Vector3(deltaX,0,deltaZ);
            movement = Vector3.ClampMagnitude(movement, Speed);
            movement.y = Gravity;
            movement *= Time.deltaTime;
            movement = transform.TransformDirection(movement);
            _characterController.Move(movement);
        }
    }
}
