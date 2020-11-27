using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void PlayGame(){
        //PlayerPrefs.DeleteAll();
        if(!PlayerPrefs.HasKey("points")){
            PlayerPrefs.SetInt("points", 0);
        }
        if(!PlayerPrefs.HasKey("lives")){
            PlayerPrefs.SetInt("lives", 5);
        }
        SceneManager.LoadScene("cenario");
    }
    public void QuitGame(){
        Application.Quit();
    }
}
