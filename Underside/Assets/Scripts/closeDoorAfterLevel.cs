using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closeDoorAfterLevel : MonoBehaviour {

    public GameObject exitDoor;
    private int doorDirection;
    private float doorY;
    private float currentDoorHeight;
    private AudioSource doorAudioSource;
    private bool doorClosed;

	// Use this for initialization
	void Start () {
        doorClosed = false;
        doorAudioSource = (AudioSource)exitDoor.GetComponent(typeof(AudioSource));
        doorY = 0;
        doorDirection = 0;
        currentDoorHeight = exitDoor.transform.position.y;
	}
	
	// Update is called once per frame
    void Update()
    {
        if (doorDirection == -1)
        {
            if (doorClosed == false)
        {
                if (doorY < 3.0f)
                {
                    doorY += 0.1f;
                    print("WHOOHAO");
                } else if (doorY >= 3.0f) {
                    doorClosed = true;
                    doorDirection = 0;
                    doorY = 3.0f;
                    exitDoor.transform.position = new Vector3(exitDoor.transform.position.x, currentDoorHeight - 3.0f, exitDoor.transform.position.z);
                }
                if (doorClosed == false) {
                    print("EXIT DOOR POS");
                    exitDoor.transform.position = new Vector3(exitDoor.transform.position.x, currentDoorHeight - doorY, exitDoor.transform.position.z);
                }
            }

        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (doorClosed == false) {
        doorAudioSource.Play();
        doorY = 0.0f;
        doorClosed = false;
        doorDirection = -1;
    }
        //exitDoor.transform.position = new Vector3(exitDoor.transform.position.x, exitDoor.transform.position.y + 1, exitDoor.transform.position.z);
    }
}
