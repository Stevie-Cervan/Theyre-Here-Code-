using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health_And_Damage : MonoBehaviour
{
    //Movement, Look, and Jump Script reference
    public FPSMovement fpsMovementScript;
    public FPSLookAround fpsLookAroundScript;
    public FPSJump fpsJumpScript;

    public GameObject objectHolder;

    public Image fadingScreen;
    Animator screenFading;

    public bool playerDead;

    // Start is called before the first frame update
    void Start()
    {
        fpsJumpScript = GetComponent<FPSJump>();
        fpsLookAroundScript = GetComponent<FPSLookAround>();
        fpsMovementScript = GetComponent<FPSMovement>();
        screenFading = fadingScreen.GetComponent<Animator>();
        screenFading.SetBool("abduction", false);
        screenFading.SetBool("fadeScreen", false);
        playerDead = false;

    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.name == "volumetric_light_shaft"){
            fpsJumpScript.enabled = false;
            fpsLookAroundScript.enabled = false;
            fpsMovementScript.enabled = false;

            objectHolder.SetActive(false);

            screenFading.SetBool("abduction", true);
            playerDead = true;
        }    
    }

    void OnCollisionEnter(Collision other) {
        if(other.gameObject.name == "Alien(Clone)"){
            fpsJumpScript.enabled = false;
            fpsLookAroundScript.enabled = false;
            fpsMovementScript.enabled = false;

            objectHolder.SetActive(false);

            screenFading.SetBool("fadeScreen", true);

            playerDead = true;
        }
    }
}
