using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogueTypeOut : MonoBehaviour
{
    public float delay = 0.07f;

    [TextArea]
    public string fullText;
    
    private string currentText = "";
    public Button continueButton;


    // Start is called before the first frame update
    void Start()
    {
        continueButton.interactable = false;
        StartCoroutine(ShowText());

    }

    IEnumerator ShowText(){
        for(int i = 0; i < fullText.Length; i++){
            currentText = fullText.Substring(0,i);
            this.GetComponent<Text>().text = currentText;
            yield return new WaitForSeconds(delay);
        }
        continueButton.interactable = true;
    }

    public void toGameScene(){
         SceneManager.LoadScene(0);
    }
}
