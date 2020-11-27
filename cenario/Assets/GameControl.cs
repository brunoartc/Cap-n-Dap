using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    public GameObject finishMenuUI;
    public Text textFinish;
    public Text textLives;

    // Start is called before the first frame update
    void Start() {
        textLives.text = "VIDAS: " + PlayerPrefs.GetInt("lives");

        if(PlayerPrefs.GetInt("lives") <= 0){
            PlayerPrefs.DeleteAll();
            finishMenuUI.SetActive(true);
            textFinish.text = "Você perdeu";
            Time.timeScale = 0f;
            PauseMenu.GameIsPaused = true;
        }
        if(PlayerPrefs.GetInt("points")==4){
            PlayerPrefs.DeleteAll();
            finishMenuUI.SetActive(true);
            textFinish.text = "Você ganhou";
            Time.timeScale = 0f;
            PauseMenu.GameIsPaused = true;
        }
    }
}
