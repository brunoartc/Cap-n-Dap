using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class clckScript : MonoBehaviour
{
    int totalClicks;
    bool lastButtonA;
    float currentCPS;

    public List<Sprite> manBike;

    public GameObject bg;
    public GameObject man;

    public TMPro.TextMeshProUGUI CPSText;

    public TMPro.TextMeshProUGUI TextHint;

    public float targerCPS = 12.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && !lastButtonA)
        {
            TextHint.SetText("D");
            man.GetComponent<SpriteRenderer>().sprite = manBike[1];
            totalClicks++;
            currentCPS = totalClicks / Time.timeSinceLevelLoad;
            lastButtonA = !lastButtonA;
            Debug.Log($"A {currentCPS}");
            CPSText.SetText($"{ currentCPS } / { targerCPS }");
            bg.GetComponent<BackGroundScroll>().bgSpeed = currentCPS / 8;

        }
        else if (Input.GetKeyDown(KeyCode.D) && lastButtonA)
        {
            TextHint.SetText("    A");
            man.GetComponent<SpriteRenderer>().sprite = manBike[0];
            totalClicks++;
            currentCPS = totalClicks / Time.timeSinceLevelLoad;
            Debug.Log($"D {currentCPS}");
            lastButtonA = !lastButtonA;
            CPSText.SetText($"{ currentCPS } / { targerCPS }");
            bg.GetComponent<BackGroundScroll>().bgSpeed = currentCPS / 8;

        }

        currentCPS = totalClicks / Time.timeSinceLevelLoad;
        CPSText.SetText($"{ currentCPS } / { targerCPS }"); 

        if (currentCPS * 1.20f > targerCPS)
        {
            CPSText.color = Color.yellow;
        } else if (currentCPS > targerCPS)
        {
            PlayerPrefs.SetInt("points", PlayerPrefs.GetInt("points") + 1);
            PlayerPrefs.SetInt("won_0" , 1);
            SceneManager.LoadScene("cenario");
        }

    }
}
