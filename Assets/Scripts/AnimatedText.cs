using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimatedText : MonoBehaviour
{
    //Time taken for each letter to appear (The lower it is, the faster each letter appear)
    public float letterPaused;
    //Message that will displays till the end that will come out letter by letter
    public string message;
    //Text for the message to display
    public Text textComp;

    // Use this for initialization
    public void Start()
    {
        //Debug.Log("the value of letterPaused" + letterPaused);
        //Get text component
        textComp = GetComponent<Text>();
        //Message will display will be at Text
        message = textComp.text;
        //Set the text to be blank first
        textComp.text = "";
        //Call the function and expect yield to return
        StartCoroutine(TypeText());
    }

    public IEnumerator TypeText()
    {
        //Debug.Log("at TypeText in AnimatedText");

        //to add a delay to the start
        yield return new WaitForSeconds(1.0f);
        //Split each char into a char array
        foreach (char letter in message.ToCharArray())
        {
            //Add 1 letter each
            textComp.text += letter;
            yield return 0;
            yield return new WaitForSeconds(letterPaused);
        }
    }
}
