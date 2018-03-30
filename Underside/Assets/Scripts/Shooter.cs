using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    public GameObject lineObject;
    private AudioSource gunSound;
    public AudioClip gunClip;
    public Material lineMaterial;
    float alphaFloat = 1.0f;
    List<GameObject> reversedList = new List<GameObject>();
    private LineRenderer lineRender;
    public Material boxMaterial;

    private static int gravityLayerInt;
    private static int reversedGravityLayerInt;


    // Use this for initialization
    void Start()
    {
        gunSound = (AudioSource)GetComponent(typeof(AudioSource));
        gravityLayerInt = LayerMask.NameToLayer("normalGravity");
        reversedGravityLayerInt = LayerMask.NameToLayer("reversedGravity");
    }

    private static List<GameObject> GetObjectsInLayer(GameObject root, int layer)
    {
        var ret = new List<GameObject>();

        foreach (GameObject go in FindObjectsOfType(typeof(GameObject)) as GameObject[]) {
            if (go.layer == LayerMask.NameToLayer("reversedGravity"))
            {
                ret.Add(go.gameObject);
            }
        }

        return ret;
    }

    // Update is called once per frame
    void Update()
    {
        
        GameObject pauseMenuObject = GameObject.Find("PauseCanvas");
        pauseMenu pauseScript = pauseMenuObject.GetComponent<pauseMenu>();

        foreach (GameObject go in reversedList) {
            Rigidbody goRb = (Rigidbody)go.GetComponent(typeof(Rigidbody));
            goRb.velocity = new Vector3(0, 4.0f, 0);
        }

        if (pauseScript.gameIsPaused == false)
        {

            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit raycastHitInfo;
                if (Physics.Raycast(transform.position + (transform.forward), transform.forward, out raycastHitInfo))
                {
                    alphaFloat = 1.0f;
                    gunSound.clip = gunClip;
                    gunSound.Play();

                    lineRender = (LineRenderer)lineObject.GetComponent(typeof(LineRenderer));

                    lineRender.SetPosition(0, new Vector3(transform.position.x, transform.position.y - 1.0f, transform.position.z) + new Vector3(transform.forward.x, transform.forward.y, transform.forward.z));
                    lineRender.SetPosition(1, transform.position + transform.forward * 10);

                    lineRender.material = new Material(Shader.Find("Particles/Additive"));
                    lineRender.SetColors(Color.white, Color.white);


                    alphaFloat -= 0.05f;



                    if (raycastHitInfo.collider.gameObject.layer == gravityLayerInt || raycastHitInfo.collider.gameObject.layer == reversedGravityLayerInt)
                    {
                        GameObject theObject = raycastHitInfo.collider.gameObject;


                        if (theObject.layer == gravityLayerInt)
                        {
                            theObject.layer = reversedGravityLayerInt;

                            lineRender.material = new Material(Shader.Find("Particles/Additive"));
                            lineRender.SetColors(new Color(22.0f / 255, 140.0f / 255, 159.0f / 255), new Color(22.0f / 255, 140.0f / 255, 159.0f / 255));
                        }

                        else if (theObject.layer == reversedGravityLayerInt)
                        {
                            theObject.layer = gravityLayerInt;

                            lineRender.material = new Material(Shader.Find("Particles/Additive"));
                            lineRender.SetColors(new Color(1, 0.5f, 0), new Color(1, 0.5f, 0));
                        }


                        reversedList = GetObjectsInLayer(gameObject, reversedGravityLayerInt);
                    }

                    StartCoroutine(ExecuteAfterTime(0.1f));

                }

            }
        }

    }



    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        lineRender.SetPosition(0, new Vector3(0, 0, 0));
        lineRender.SetPosition(1, new Vector3(0, 0, 0));
    }
}