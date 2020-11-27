using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class life : MonoBehaviour
{

    public int destroyDifficult = 0;
    // Start is called before the first frame update
    void Start()
    {
        destroyDifficult = (int) Random.Range(1.0f, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
