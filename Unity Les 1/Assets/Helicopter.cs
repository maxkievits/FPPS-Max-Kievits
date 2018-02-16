using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicopter : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(transform.position.x + 0.05f, transform.position.y, transform.position.z);
        
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + 50f, transform.eulerAngles.z);
        
        
	}
}
