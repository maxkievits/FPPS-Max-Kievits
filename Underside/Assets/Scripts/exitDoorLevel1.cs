using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exitDoorLevel1 : MonoBehaviour {


    public GameObject exitDoor;
    private int doorDirection;
    private float doorY;
    private float currentDoorHeight;
    private AudioSource doorAudioSource;

	// Use this for initialization
	void Start () {
        doorDirection = 0;
        doorAudioSource = (AudioSource)exitDoor.GetComponent(typeof(AudioSource));
        doorY = 0;
        currentDoorHeight = exitDoor.transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
        if(doorDirection == 1) {
            if (doorY < 3.0f)
            {
                doorY += 0.1f;
            }
            exitDoor.transform.position = new Vector3(exitDoor.transform.position.x, currentDoorHeight + doorY, exitDoor.transform.position.z);
        }
        else if (doorDirection == -1) {
            if (doorY > 0)
            {
                doorY -= 0.1f;
            }
            exitDoor.transform.position = new Vector3(exitDoor.transform.position.x, currentDoorHeight + doorY, exitDoor.transform.position.z);
        }


	}

	private void OnTriggerExit(Collider other)
	{
        doorAudioSource.Play();
        
        doorDirection = -1;
        //exitDoor.transform.position = new Vector3(exitDoor.transform.position.x, exitDoor.transform.position.y - 1, exitDoor.transform.position.z);
	}

	private void OnTriggerEnter(Collider other)
	{

        doorAudioSource.Play();

        doorDirection = 1;
        //exitDoor.transform.position = new Vector3(exitDoor.transform.position.x, exitDoor.transform.position.y + 1, exitDoor.transform.position.z);
	}
}
