using UnityEngine;

namespace Assets.Scripts
{
    public class MouseLook : MonoBehaviour {
        public enum RotationAxes
        {
            MouseXAndY,
            MouseX,
            MouseY
        }

        public RotationAxes Axes = RotationAxes.MouseXAndY;

        public float SensitivityHor = 3f;
        public float SensitivityVert = 3f;

        public float MinimumVert = -45f;
        public float MaximumVert = 45f;

        private float _rotationX = 0;
        // Use this for initialization
        void Start ()
        {
            var body = GetComponent<Rigidbody>();
            if (body!=null)
            {
                body.freezeRotation = true;
            }
        }
        // Update is called once per frame
        void Update () {
            if (Axes==RotationAxes.MouseX)
            {
                transform.Rotate(0, Input.GetAxis("Mouse X") * SensitivityHor, 0);
            }
            else if (Axes==RotationAxes.MouseY)
            {
                _rotationX -= Input.GetAxis("Mouse Y") * SensitivityVert;
                _rotationX = Mathf.Clamp(_rotationX, MinimumVert, MaximumVert);
                var rotationY = transform.localEulerAngles.y;
                transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
            }
            else
            {
                _rotationX -= Input.GetAxis("Mouse Y") * SensitivityVert;
                _rotationX = Mathf.Clamp(_rotationX, MinimumVert, MaximumVert);
                var delta = Input.GetAxis("Mouse X") * SensitivityHor;
                var rotationY = transform.localEulerAngles.y + delta;
                transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
            }
        }
    }
}
