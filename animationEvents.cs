using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationEvents : MonoBehaviour
{

    public GameObject deathScreen;
    public GameObject inGameDisplay;
    public GameObject pauseMenuDisplay;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void openDeathScreen(){
        deathScreen.SetActive(true);
        inGameDisplay.SetActive(false);
        pauseMenuDisplay.SetActive(false);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
