using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : MonoBehaviour
{

    public GameObject textImage;
    public Text textName;
    public bool isActive;
    //so that each sign can have its own text.
    //Note: the lines are placed on the sign object. not the text.
   
    public string lineTwo;

    public void Start()
    {
        textImage.SetActive(false);
        
    }

    public void Update()
    {
        if (isActive == true)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                Debug.Log("in sign. input gotten");
                
                textName.text = lineTwo;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            textImage.SetActive(true);
            isActive = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            textImage.SetActive(false);
            isActive = false;
        }
    }
}
