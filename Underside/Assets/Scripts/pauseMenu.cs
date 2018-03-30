using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class pauseMenu : MonoBehaviour {

    public bool gameIsPaused = false;

    public GameObject pauseMenuUI;

	// Use this for initialization
	void Start () {
        //pauseMenuUI.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;


    }
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            if(gameIsPaused) {
                gameResume();
            } else {
                gamePause();
            }
        }
	}

    public void gamePause()
    {
        Time.timeScale = 0.0f;
        pauseMenuUI.SetActive(true);
        gameIsPaused = true;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        GameObject firstPersonObject = GameObject.Find("FPSController");
        FirstPersonController playerScript = firstPersonObject.GetComponent<FirstPersonController>();
        playerScript.mouseLookCustom.XSensitivity = 0.0f;
        playerScript.mouseLookCustom.YSensitivity = 0.0f;

    
    }

    public void gameResume()
    {
        Time.timeScale = 1.0f;
        pauseMenuUI.SetActive(false);
        gameIsPaused = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        GameObject firstPersonObject = GameObject.Find("FPSController");
        FirstPersonController playerScript = firstPersonObject.GetComponent<FirstPersonController>();
        playerScript.mouseLookCustom.XSensitivity = 2.0f;
        playerScript.mouseLookCustom.YSensitivity = 2.0f;
    }

    public void quitGame(){
        Application.Quit();
    }
}
