using UnityEngine;
using System.Collections;

public class MouseMove2D : MonoBehaviour
{

    public int points = 0;

    private Vector3 mousePosition;
    public float moveSpeed = 0.1f;

    private int totalHair = 120;

    public TMPro.TextMeshProUGUI win;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
        }

    }


    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.GetComponent<life>().destroyDifficult < 1)
        {
            col.gameObject.SetActive(false);
            points++;
            
            if (points >= totalHair) {
                win.SetText("You Win");
                Debug.Log($"You Win {points}");
            }
        } else
        {
            col.gameObject.GetComponent<life>().destroyDifficult--;
        }

        
        Debug.Log(col.gameObject.name + " : " + gameObject.name + " : " + Time.time);
        //spriteMove = -0.1f;
    }
}
