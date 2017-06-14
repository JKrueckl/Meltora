using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockShieldController : MonoBehaviour {

    public List<GameObject> rocksInShield = new List<GameObject>();

    private float rotationSpeed = 0.05f;
    private float timeStamp;

	// Use this for initialization
	void Start ()
    {
        timeStamp = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        if (timeStamp <= Time.time)
        {
            timeStamp = Time.time + rotationSpeed;

            lock (rocksInShield)
            {
                for(int i = 0; i < rocksInShield.Count; i++)
                {
                    rocksInShield[i].transform.Rotate(Vector3.forward, 2);
                }
            }

            transform.Rotate(Vector3.back, 2);
        }
            
    }
}
