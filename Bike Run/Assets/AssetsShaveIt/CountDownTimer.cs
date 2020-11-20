using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownTimer : MonoBehaviour
{
    public float currentTime = 0f;
    float startingTime = 10f;

    public TMPro.TextMeshProUGUI countDownText;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countDownText.SetText($"{ (int) currentTime}");

        if (currentTime <= 0)
        {
            currentTime = 0;
        }

        if (currentTime <= 3)
        {
            countDownText.color = Color.red;
        }
    }
}
