using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level2_openBox : MonoBehaviour {

    public GameObject trapDoor;
    public GameObject trapDoor2;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter(Collider other)
	{
        Rigidbody trapDoorRB = (Rigidbody)trapDoor.GetComponent(typeof(Rigidbody));
        trapDoorRB.isKinematic = false;
        trapDoorRB.useGravity = true;

        Rigidbody trapDoorRB2 = (Rigidbody)trapDoor2.GetComponent(typeof(Rigidbody));
        trapDoorRB2.isKinematic = false;
        trapDoorRB2.useGravity = true;
	}
}
