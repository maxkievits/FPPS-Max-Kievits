using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour 
{

    public GameObject bulletPrefab;
    public GameObject lineObject;

	// Use this for initialization
	void Start () 
    {
	}
	
	// Update is called once per frame
	void Update () 
    {
        LineRenderer lineRender = (LineRenderer)lineObject.GetComponent(typeof(LineRenderer));

        lineRender.SetPosition(0, new Vector3(transform.position.x, transform.position.y - 0.3f, transform.position.z ) + transform.forward);
        lineRender.SetPosition(1, transform.position + transform.forward * 100);


        if(Input.GetMouseButtonDown(1))
        {
            RaycastHit raycastHitInfo;
            if (Physics.Raycast(transform.position + transform.forward, transform.forward, out raycastHitInfo)) 
            {
                if(raycastHitInfo.collider.gameObject.name == "Target") {
                    Destroy(raycastHitInfo.collider.gameObject);
                }
            }

        }


        if(Input.GetMouseButtonDown(0)) 
        {
            GameObject bulletObject = Instantiate(bulletPrefab, transform.position + transform.forward, Quaternion.identity);
            Rigidbody bulletRB = (Rigidbody)bulletObject.GetComponent(typeof(Rigidbody));
            bulletRB.AddForce(transform.forward * 100000.0f, ForceMode.Force);

        }

	}
}
