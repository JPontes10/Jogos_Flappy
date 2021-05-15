using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{

    private bool isToggle = false ;
    public GameControl gm;
    

    
    public void PlayGame(){

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void QuitGame(){
        Debug.Log("QUIT!");
        Application.Quit();
    }

    public void Difficulty_toggle(){
        if(isToggle == false){
            PlayerPrefs.SetString("scrollSpeed", "True");
            isToggle = true;
            Debug.Log("True");
        }else{
            PlayerPrefs.SetString("scrollSpeed", "False");
            isToggle = false;
            Debug.Log("False");
        }
        
        //gm.scrollSpeed = -5f;
        //Debug.Log(gm.scrollSpeed);
    }
}
