using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour {

    [SerializeField] GameObject destructionParticles;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            Debug.Log("Hit Wall");

            Instantiate(destructionParticles, transform.position, Quaternion.identity);

            Destroy(GetComponent<SpriteRenderer>());
            Destroy(gameObject, 0.5f);
        }       
    }
}
