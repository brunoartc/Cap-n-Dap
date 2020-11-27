using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemController : MonoBehaviour
{
    public GameController gameController;
    
    public int itemNumber = 0;

    public void onClick(){
        gameController.appearFood(itemNumber);
    }
}
