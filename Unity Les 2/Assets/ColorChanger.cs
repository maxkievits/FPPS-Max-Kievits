using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour {

    Color blockColor = new Color();
    
    public Renderer blockRenderer;
    int colorSpeed;
    int colorCount;
    
	// Use this for initialization
	void Start () {
        blockColor.r = 0.0f;
        blockColor.g = 1.0f;
        blockColor.b = 0.0f;
		blockRenderer.material.color = blockColor;

        colorSpeed = 1;
        colorCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (colorCount >= 50)
        {
            colorSpeed *= -1;
            colorCount = 0;
        }

        blockColor.r += (colorSpeed / 50.0f);

        blockRenderer.material.color = blockColor;
        colorCount += 1;
	}
}
