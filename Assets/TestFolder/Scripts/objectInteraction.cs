using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectInteraction : MonoBehaviour {

    private Vector3 spawnPosition;
	// Use this for initialization
	void Start ()
    {
        spawnPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerExit(Collider other)
    {
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        transform.position = spawnPosition;
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;

        
    }
}
