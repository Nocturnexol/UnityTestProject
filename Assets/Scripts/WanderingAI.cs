using UnityEngine;

namespace Assets.Scripts
{
    public class WanderingAI : MonoBehaviour
    {
        public float Speed = 3;
        public float ObstacleRange = 5;

        private bool _alive;

        [SerializeField] private GameObject _fireballPrefab;
        private GameObject _fireball;
        void Start()
        {
            _alive = true;
        }

        // Update is called once per frame
        void Update()
        {
            if (_alive) transform.Translate(0, 0, Speed * Time.deltaTime);
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.SphereCast(ray, 0.75f, out hit))
            {
                var hitObject = hit.transform.gameObject;
                if (hitObject.GetComponent<PlayerCharacter>())
                {
                    if (_fireball==null)
                    {
                        _fireball = Instantiate(_fireballPrefab);
                        _fireball.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                        _fireball.transform.rotation = transform.rotation;
                    }
                }
                if (hit.distance < ObstacleRange)
                {
                    transform.Rotate(0, Random.Range(-110, 110), 0);
                }
            }
        }

        public void SetAlive(bool alive)
        {
            _alive = alive;
        }
    }
}
