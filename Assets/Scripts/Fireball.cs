using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float Speed = 10;
    public int Damage = 1;
	
	// Update is called once per frame
	void Update ()
	{
	    transform.Translate(0, 0, Speed * Time.deltaTime);
	}

    void OnTriggerEnter(Collider other)
    {
        PlayerCharacter player = other.GetComponent<PlayerCharacter>();
        if (player != null)
        {
            player.Hurt(1);
        }

        Destroy(gameObject);
    }
}
