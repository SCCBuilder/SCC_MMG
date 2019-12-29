using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public int levelToLoad;

    private void OnTriggerStay2D(Collider2D collision)
    {
        //Debug.Log("door on trigger stay");
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            //Debug.Log("asfghj");
            GameController.gameControllerInstance.LoadLevel(levelToLoad);
        }
    }
}
