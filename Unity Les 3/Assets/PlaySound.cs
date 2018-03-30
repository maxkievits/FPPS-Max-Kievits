using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour {

    public Rigidbody rb;

    private AudioSource punchSource;
    Color blockColor = new Color();

    public Renderer blockRenderer;
    public AudioClip[] soundClips;
    private float direction;
    private float speed;

	// Use this for initialization
	void Start () {
        punchSource = (AudioSource)GetComponent(typeof(AudioSource));
        blockRenderer.material.color = blockColor;
        rb = gameObject.GetComponent<Rigidbody>();
        direction = -1;
        speed = 0.1f;

	}

    private void Update()
    {
        rb.velocity = new Vector3(0,speed,0);
        //rb.AddForce(transform.forward * -1.1f);
       
        if (Input.GetKeyDown(KeyCode.G))
        {
            
            //speed = 0.1f;
            direction *= -1;
        }
        if(direction >= 1){
            if (speed < 9.8f)
            {
                speed += 0.1f;
            }
        } else if(direction <= -1) {
            if (speed > -9.8f)
            {
                speed -= 0.1f;
            }
        }
    }

    // Update is called once per frame

    private void OnTriggerEnter(Collider other)
    {
        AudioClip randomClip = soundClips[Random.Range(0,soundClips.Length)];

        punchSource.clip = randomClip;
        punchSource.Play();

        blockColor = new Color(r: 0, g: 1, b: 0);
        blockRenderer.material.color = blockColor;
    }
    private void OnTriggerExit(Collider other)
    {
        blockColor = new Color(r: 1, g: 0, b: 0);
        blockRenderer.material.color = blockColor;

    }



}
