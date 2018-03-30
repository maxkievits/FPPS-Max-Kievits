using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


enum DinoState {
    Idle,
    Attack
}

public class AnimationLooper : MonoBehaviour {

    public Animation animationObject;

    private DinoState state;

	// Use this for initialization
	void Start () {
        animationObject["Take 001"].wrapMode = WrapMode.Loop;
        //animationObject.playAutomatically = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlayAttack () {
        switch (state) {
            case DinoState.Idle:
                animationObject.Play();
                state = DinoState.Attack;
                break;
            case DinoState.Attack:
                animationObject.Stop();
                state = DinoState.Idle;
                break;
        }
    }
}
