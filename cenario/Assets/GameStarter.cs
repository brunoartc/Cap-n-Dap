using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStarter : MonoBehaviour
{
    SpriteRenderer circleImage;
    public Sprite redCircle;
    public Sprite orangeCircle;
    public Sprite greenCircle;
    private bool isOnGame = false;
    private bool gamePlayed = false;
    public int sceneToLoad;
    private string[] scenes;
   
    void Start()
    {
        circleImage = GetComponent<SpriteRenderer>();
        scenes = new string[]{"BikeRun", "Burger", "ShaveIt","HammerIt"};
        if(PlayerPrefs.HasKey("won_" + sceneToLoad)){
            gamePlayed = true;
            circleImage.sprite = greenCircle;
        }
        
    }

    void Update() {
        if(isOnGame){
            if(Input.GetKeyDown(KeyCode.Return)){
                Debug.Log("Jogando o jogo");
                gamePlayed = true;
                isOnGame = false;
                SceneManager.LoadScene(scenes[sceneToLoad]);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "Player" && !gamePlayed){
            circleImage.sprite = orangeCircle;
            isOnGame = true;
            //circleImage.color = new Color (0, 1, 0, 1);  //Red, Green, Blue, Alpha
        }
    }
    private void OnTriggerExit2D(Collider2D collision) {
        if(collision.tag == "Player"){
            if(!gamePlayed){
                isOnGame = false;
                circleImage.sprite = redCircle;
            }
            if(gamePlayed){
                circleImage.sprite = greenCircle;
            }
            
            //circleImage.color = new Color (0, 1, 0, 1);  //Red, Green, Blue, Alpha
        }
    }
}
