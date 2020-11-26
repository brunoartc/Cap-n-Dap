using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startGame : MonoBehaviour
{


    public float speed;


    private int direction;

    public GameObject nail;

    public GameObject hammerup;

    public GameObject hammerdown;

    public GameObject ohyeah;

    public GameObject nice;


    public GameObject faceGood;

    public GameObject faceBad;

    private float hammerX;

    private float movePosNailX;

    private float initialHammerX;

    private float timeDown = 0;


    private int faceStatus = 0;



    private int nailLevel;


    private float origNailY;

    private float origHammerY;



    // Start is called before the first frame update
    void Start()
    {
        direction = 1;
        movePosNailX = (int) Random.Range(-0f, +11.0f);

        nail.transform.position -= new Vector3(movePosNailX, 0, 0);
        hammerdown.transform.position -= new Vector3(movePosNailX, 0, 0);
        origNailY = nail.transform.position.y;


        origHammerY = hammerdown.transform.position.y;
        initialHammerX = hammerup.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {

        switch (faceStatus)
        {
            case 0:
                ohyeah.SetActive(false);
                nice.SetActive(false);
                faceBad.SetActive(false);
                faceGood.SetActive(true);
                break;
            case 1:
                ohyeah.SetActive(true);
                nice.SetActive(false);
                faceBad.SetActive(false);
                faceGood.SetActive(true);
                break;
            case 2:
                ohyeah.SetActive(true);
                nice.SetActive(false);
                faceBad.SetActive(false);
                faceGood.SetActive(true);
                break;
            case 3:
                ohyeah.SetActive(false);
                nice.SetActive(false);
                faceBad.SetActive(true);
                faceGood.SetActive(false);
                break;
        }


        if (timeDown < Time.timeSinceLevelLoad)
        {
            hammerup.SetActive(true);
            hammerdown.SetActive(false);
            if (hammerup.transform.position.x > initialHammerX && direction == -1)
            {
                direction *= -1;
                hammerup.transform.position = new Vector3(initialHammerX, hammerup.transform.position.y, hammerup.transform.position.z);
            } else if ( hammerup.transform.position.x < initialHammerX - 11 && direction == 1)
            {
                direction *= -1;
                hammerup.transform.position = new Vector3(initialHammerX - 11, hammerup.transform.position.y, hammerup.transform.position.z);
            }
            else
            {
                hammerup.transform.position -= new Vector3(speed * Time.deltaTime * direction, 0, 0);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            timeDown = Time.timeSinceLevelLoad + 1.0f;

            hammerdown.transform.position = new Vector2(hammerup.transform.position.x + 2.4f, hammerdown.transform.position.y);

            hammerup.SetActive(false);
            hammerdown.SetActive(true);


            float actualHammerX = Mathf.Abs(initialHammerX - hammerup.transform.position.x) - 0.5f;


            if (actualHammerX - movePosNailX > 0)
            {
                if (Mathf.Abs(actualHammerX - movePosNailX) > 0.7)
                {



                    if (Mathf.Abs(Mathf.Abs(actualHammerX) - movePosNailX) > 1.3)
                    {
                        faceStatus = 3;
                        Debug.Log("ERROU FEIO, VOCE PERDEU");
                        Debug.Log($"nail = {movePosNailX}, hammer = {actualHammerX}");

                    }
                    else
                    {
                        if (nailLevel > 0)
                        {
                            nail.transform.eulerAngles = new Vector3(
                                nail.transform.eulerAngles.x,
                                nail.transform.eulerAngles.y,
                                3
                            );
                        }
                        
                        faceStatus = 3;
                        Debug.Log("ERROU FEIO");
                        Debug.Log($"nail = {movePosNailX}, hammer = {actualHammerX}");
                    }



                }
                else
                {

                    faceStatus = (int)Random.Range(1, 2);
                    hammerdown.transform.position = new Vector2(hammerdown.transform.position.x, origHammerY - nailLevel);
                    Debug.Log("ACERTOU");
                    Debug.Log($"nail = {movePosNailX}, hammer = {initialHammerX - hammerup.transform.position.x}");
                    nailLevel++;
                    nail.transform.rotation = new Quaternion(nail.transform.rotation.x, nail.transform.rotation.y, 0, nail.transform.rotation.w);
                    nail.transform.position = new Vector2(nail.transform.position.x, origNailY - nailLevel);
                }
            } else
            {
                if (Mathf.Abs(actualHammerX - movePosNailX) > 0.5)
                {
                    if (Mathf.Abs(Mathf.Abs(actualHammerX) - movePosNailX) > 1)
                    {
                        faceStatus = 3;
                        Debug.Log("ERROU FEIO, VOCE PERDEU");
                        Debug.Log($"nail = {movePosNailX}, hammer = {actualHammerX}");

                    }
                    else
                    {
                        if (nailLevel > 0)
                        {
                            nail.transform.eulerAngles = new Vector3(
                                nail.transform.eulerAngles.x,
                                nail.transform.eulerAngles.y,
                                -15
                            );
                        }
                        faceStatus = 3;
                        Debug.Log("ERROU FEIO");
                        Debug.Log($"nail = {movePosNailX}, hammer = {actualHammerX}");
                    }



                }
                else
                {

                    faceStatus = (int)Random.Range(1, 2);
                    nailLevel++;
                    nail.transform.rotation = new Quaternion(nail.transform.rotation.x, nail.transform.rotation.y, 0, nail.transform.rotation.w);
                    hammerdown.transform.position = new Vector2(hammerdown.transform.position.x, origHammerY - nailLevel);
                    nail.transform.position = new Vector2(nail.transform.position.x, origNailY - nailLevel);
                    Debug.Log("ACERTOU");
                    Debug.Log($"nail = {movePosNailX}, hammer = {initialHammerX - hammerup.transform.position.x}");
                }
            }
            
        }

        if (nailLevel > 2)
        {
            PlayerPrefs.SetInt("points", PlayerPrefs.GetInt("points") + 1);
            SceneManager.LoadScene("cenario");
        };





    }
}
