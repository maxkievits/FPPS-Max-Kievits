using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour {

    Color blockColor = new Color();

    public Renderer blockRenderer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame

    private void OnTriggerEnter(Collider other)
    {
        blockColor = new Color(r: 0, g: 1, b: 0);
        blockRenderer.material.color = blockColor;

    }
    private void OnTriggerExit(Collider other)
    {
        blockColor = new Color(r: 1, g: 0, b: 0);
        blockRenderer.material.color = blockColor;

    }

}
