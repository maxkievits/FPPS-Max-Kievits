using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour {


    private GameObject pickedObject;

    bool pickedUp = false;

	// Use this for initialization
	void Start () {	}
	
	// Update is called once per frame
	void Update () {
		
        if(Input.GetMouseButtonDown(0)) {

            if (pickedUp == false)
            {

                RaycastHit raycastHitInfo;
                int layer = LayerMask.NameToLayer("PickupLayer");
                if (Physics.Raycast(transform.position + transform.forward, transform.forward, out raycastHitInfo, 5.0f, 1 << layer))
                {

                    pickedObject = raycastHitInfo.collider.gameObject;
                    pickedUp = true;

                    ((Rigidbody)pickedObject.GetComponent(typeof(Rigidbody))).isKinematic = true;
                    ((Rigidbody)pickedObject.GetComponent(typeof(Rigidbody))).useGravity = false;

                }
            } else {
                pickedUp = false;
                ((Rigidbody)pickedObject.GetComponent(typeof(Rigidbody))).isKinematic = false;
                ((Rigidbody)pickedObject.GetComponent(typeof(Rigidbody))).useGravity = true;

            }

        }

        if (pickedObject && pickedUp == true)
        {
            pickedObject.transform.position = transform.position + (transform.forward * 2);
        }
	}
}
