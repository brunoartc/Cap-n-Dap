using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private int element = 0;
    public static GameObject bottomBun1;
    public static GameObject tomatoes;
    public static GameObject bacon;
    public static GameObject bottomBun2;
    public static GameObject meat;
    public static GameObject cheese;
    public static GameObject ketchup;
    public static GameObject topBun;

    List<GameObject> foodList = new List<GameObject>();
    List<int> elementOrder = new List<int>() { 1,8,5,1,10,2,7,0 };

    // Start is called before the first frame update
    void Start()
    {
        makeSetUp(bottomBun1, "BottomBun");
        makeSetUp(tomatoes, "Tomato");
        makeSetUp(bacon, "Bacon");
        makeSetUp(bottomBun2, "BottomBun1");
        makeSetUp(meat, "Meat");
        makeSetUp(cheese, "Cheese");
        makeSetUp(ketchup, "Ketchup");
        makeSetUp(topBun, "TopBun");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void makeSetUp(GameObject gameObject, string tagName){
        gameObject = GameObject.FindWithTag(tagName);
        foodList.Add(gameObject);
        gameObject.SetActive(false);
    }

    public void appearFood(int itemNumber){
        if(itemNumber == elementOrder[element]){
            foodList[element].SetActive(true);
            element += 1;
        }
        else{
            Debug.Log("Você errou");
        }
        if(element == 8){
            PlayerPrefs.SetInt("points", PlayerPrefs.GetInt("points") + 1);
            PlayerPrefs.SetInt("won_1" , 1);
            SceneManager.LoadScene("cenario");
        }
    }
}
