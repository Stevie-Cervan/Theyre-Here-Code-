using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScriptsForButtons : MonoBehaviour
{

    public GameObject inGameDisplay;
    public GameObject pauseMenuDisplay;
    public GameObject gameOverDisplay;

    public GameObject UIElements_ControlScreen;
    public GameObject ControlDisplayElements;
    public Text pauseHeader;

    public GameObject player;
    public Health_And_Damage playerHealthScript;


    // Start is called before the first frame update
    void Start()
    {
        inGameDisplay.SetActive(true);
        pauseMenuDisplay.SetActive(false);
        gameOverDisplay.SetActive(false);
        ControlDisplayElements.SetActive(false);
    
        playerHealthScript = player.GetComponent<Health_And_Damage>();
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)){
            pauseGame();
        }    
    }

    public void backButton(){
        UIElements_ControlScreen.SetActive(true);
        ControlDisplayElements.SetActive(false);
    }

    //Pause Game Display
    public void pauseGame(){
        if(playerHealthScript.playerDead == false){
            inGameDisplay.SetActive(false);
            pauseMenuDisplay.SetActive(true);
            gameOverDisplay.SetActive(false);

            Time.timeScale = 0;

            //Unlock the cursor
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else{
            Debug.Log("Player is dead. Can not pause game.");
        }       
    }
    public void resumeGame(){
        inGameDisplay.SetActive(true);
        pauseMenuDisplay.SetActive(false);
        gameOverDisplay.SetActive(false);

        Time.timeScale = 1;

        //Lock The Cursor
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void controlsDisplay(){
        UIElements_ControlScreen.SetActive(false);
        ControlDisplayElements.SetActive(true);
        pauseHeader.text = "Controls";
    }
    public void exitToMainMenu(){
        SceneManager.LoadScene(1);
    }

    //Game Over Display
    public void restartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
