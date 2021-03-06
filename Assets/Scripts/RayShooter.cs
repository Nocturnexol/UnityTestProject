﻿using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class RayShooter : MonoBehaviour
    {
        private Camera _camera;
        // Use this for initialization
        void Start ()
        {
            _camera = GetComponent<Camera>();
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        void OnGUI()
        {
            var size = 12;
            var posX = _camera.pixelWidth / 2 - size / 4;
            var posY = _camera.pixelHeight / 2 - size / 2;
            GUI.color = new Color(0, 1, 0, 0.8f);
            GUI.Label(new Rect(posX, posY, size, size), "*");
        }
	
        // Update is called once per frame
        void Update () {
            if (Input.GetMouseButtonDown(0))
            {
                var point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
                var ray = _camera.ScreenPointToRay(point);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    var hitObject = hit.transform.gameObject;
                    var target = hitObject.GetComponent<ReactiveTarget>();
                    if (target != null)
                    {
                        target.ReactToHit();
                    }
                    else
                    {
                        StartCoroutine(SphereIndicator(hit.point));
                    }
                }
            }
        }

        private IEnumerator SphereIndicator(Vector3 pos)
        {
            var sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere.transform.position = pos;

            yield return new WaitForSeconds(1);
            Destroy(sphere);
        }
    }
}
