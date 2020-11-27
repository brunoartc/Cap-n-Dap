using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class geenerateHair : MonoBehaviour
{
    public float minXhair = -1.7f;
    public float maxXhair = 0.7f;
    public float minYhair = -4f;
    public float maxYhair = -1f;

    public int totalHair = 100;


    public Sprite[] sprites;

    private List<GameObject> hairs = new List<GameObject>();

    public GameObject hair;

    public GameObject hairss;
    // Start is called before the first frame update
    void Start()
    {

        //sprites = Resources.LoadAll<Sprite>("hairss");

        totalHair = 120;//(int)Random.Range(40.0f, 110.0f);

        int currentHair = 0;

        while (currentHair < totalHair)
        {
            GameObject placedHair = Object.Instantiate(hair);

            float yValue = Random.Range(minYhair, maxYhair);

            float xValue = 0.0f;

            placedHair.transform.parent = hairss.transform;


            xValue = Random.Range(minXhair, maxXhair);

            int randomSprite = (int) Random.Range(1.0f, sprites.Length - 1);


            placedHair.gameObject.GetComponent<SpriteRenderer>().sprite = sprites[randomSprite];



            placedHair.transform.position = new Vector2(xValue, yValue);

            hairs.Add(placedHair);
            currentHair++;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
