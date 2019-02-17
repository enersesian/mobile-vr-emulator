using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controllerInteraction : MonoBehaviour
{
    private RaycastHit hit;
    private int layerMask;
    private bool hitInteractive = false, lastFrameHit = false, holdingInteractable = false;
    private GameObject lastHit;
    public float forceStrength = 600;

    // Use this for initialization
    void Start ()
    {
        layerMask = 1 << 9; // controller layer mask
        //layerMask = ~layerMask;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 10f, Color.white);
        if(!holdingInteractable)
        {
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 50f, layerMask))
            {
                if (!hitInteractive)
                {
                    lastHit = hit.collider.gameObject;
                    hit.collider.GetComponent<Outline>().enabled = true;
                    hitInteractive = true;
                }
                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) || (Application.isEditor && Input.GetMouseButtonDown(0)))
                {
                    lastHit.GetComponent<Collider>().enabled = false;
                    lastHit.GetComponent<Rigidbody>().useGravity = false;
                    lastHit.GetComponent<Rigidbody>().isKinematic = true;
                    lastHit.transform.parent = transform;
                    holdingInteractable = true;
                    lastHit.GetComponent<Outline>().enabled = false;
                    hitInteractive = false;
                }
                if (OVRInput.Get(OVRInput.Button.Up) || Input.GetKey(KeyCode.W))
                {
                    lastHit.GetComponent<Collider>().enabled = true;
                    lastHit.GetComponent<Rigidbody>().useGravity = true;
                    lastHit.GetComponent<Rigidbody>().isKinematic = false;
                    lastHit.transform.parent = null;
                    holdingInteractable = false;
                    lastHit.GetComponent<Rigidbody>().AddForce(transform.TransformDirection(Vector3.forward) * forceStrength);
                }

                if (OVRInput.Get(OVRInput.Button.Right) || Input.GetKey(KeyCode.D))
                {

                    lastHit.GetComponent<Collider>().enabled = true;
                    lastHit.GetComponent<Rigidbody>().useGravity = true;
                    lastHit.GetComponent<Rigidbody>().isKinematic = false;
                    lastHit.transform.parent = null;
                    holdingInteractable = false;
                    lastHit.GetComponent<Rigidbody>().AddForce(transform.TransformDirection(Vector3.right) * forceStrength);
                }

                if (OVRInput.Get(OVRInput.Button.Down) || Input.GetKey(KeyCode.S))
                {
                    lastHit.GetComponent<Collider>().enabled = true;
                    lastHit.GetComponent<Rigidbody>().useGravity = true;
                    lastHit.GetComponent<Rigidbody>().isKinematic = false;
                    lastHit.transform.parent = null;
                    holdingInteractable = false;
                    lastHit.GetComponent<Rigidbody>().AddForce(transform.TransformDirection(Vector3.back) * forceStrength);
                }

                if (OVRInput.Get(OVRInput.Button.Left) || Input.GetKey(KeyCode.A))
                {
                    lastHit.GetComponent<Collider>().enabled = true;
                    lastHit.GetComponent<Rigidbody>().useGravity = true;
                    lastHit.GetComponent<Rigidbody>().isKinematic = false;
                    lastHit.transform.parent = null;
                    holdingInteractable = false;
                    lastHit.GetComponent<Rigidbody>().AddForce(transform.TransformDirection(Vector3.left) * forceStrength);
                }
            }
            else
            {
                hitInteractive = false;
            }
            if (lastFrameHit && !hitInteractive)
            {
                lastHit.GetComponent<Outline>().enabled = false;
            }
            lastFrameHit = hitInteractive;
        }
        else
        {
            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) || (Application.isEditor && Input.GetMouseButtonDown(0)))
            {
                lastHit.GetComponent<Collider>().enabled = true;
                lastHit.GetComponent<Rigidbody>().useGravity = true;
                lastHit.GetComponent<Rigidbody>().isKinematic = false;
                lastHit.transform.parent = null;
                holdingInteractable = false;
                lastHit.GetComponent<Rigidbody>().AddForce(OVRInput.GetLocalControllerAcceleration(OVRInput.GetActiveController()) * 200f);
            }

            if (OVRInput.Get(OVRInput.Button.Up) || Input.GetKey(KeyCode.W))
            {
                lastHit.GetComponent<Collider>().enabled = true;
                lastHit.GetComponent<Rigidbody>().useGravity = true;
                lastHit.GetComponent<Rigidbody>().isKinematic = false;
                lastHit.transform.parent = null;
                holdingInteractable = false;
                lastHit.GetComponent<Rigidbody>().AddForce(transform.TransformDirection(Vector3.forward) * forceStrength);
            }

            if (OVRInput.Get(OVRInput.Button.Right) || Input.GetKey(KeyCode.D))
            {
                lastHit.GetComponent<Collider>().enabled = true;
                lastHit.GetComponent<Rigidbody>().useGravity = true;
                lastHit.GetComponent<Rigidbody>().isKinematic = false;
                lastHit.transform.parent = null;
                holdingInteractable = false;
                lastHit.GetComponent<Rigidbody>().AddForce(transform.TransformDirection(Vector3.right) * forceStrength);
            }

            if (OVRInput.Get(OVRInput.Button.Down) || Input.GetKey(KeyCode.S))
            {
                lastHit.GetComponent<Collider>().enabled = true;
                lastHit.GetComponent<Rigidbody>().useGravity = true;
                lastHit.GetComponent<Rigidbody>().isKinematic = false;
                lastHit.transform.parent = null;
                holdingInteractable = false;
                lastHit.GetComponent<Rigidbody>().AddForce(transform.TransformDirection(Vector3.back) * forceStrength);
            }

            if (OVRInput.Get(OVRInput.Button.Left) || Input.GetKey(KeyCode.A))
            {
                lastHit.GetComponent<Collider>().enabled = true;
                lastHit.GetComponent<Rigidbody>().useGravity = true;
                lastHit.GetComponent<Rigidbody>().isKinematic = false;
                lastHit.transform.parent = null;
                holdingInteractable = false;
                lastHit.GetComponent<Rigidbody>().AddForce(transform.TransformDirection(Vector3.left) * forceStrength);
            }
        }
        
    }
}
