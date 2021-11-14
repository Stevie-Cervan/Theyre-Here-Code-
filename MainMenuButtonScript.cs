using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtonScript : MonoBehaviour
{

    public GameObject ControlsDisplay;
    public GameObject AboutDisplay;


    // Start is called before the first frame update
    void Start()
    {
        ControlsDisplay.SetActive(false);
        AboutDisplay.SetActive(false);
    }
    public void panelExitButton(){
        ControlsDisplay.SetActive(false);
        AboutDisplay.SetActive(false);
    }

    public void controlsButtonPressed(){
        ControlsDisplay.SetActive(true);
        AboutDisplay.SetActive(false);
    }
    public void aboutButtonPressed(){
        ControlsDisplay.SetActive(false);
        AboutDisplay.SetActive(true);
    }
    public void playButton(){
        Debug.Log("Take to next screen");
        SceneManager.LoadScene(3);
    }
    public void exitGame(){
        Application.Quit();
    }
}
