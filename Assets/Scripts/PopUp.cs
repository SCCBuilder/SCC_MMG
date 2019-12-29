using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUp : MonoBehaviour
{
    public GameObject textObjectToDisplay;

    private Animator anim;

    public void Start()
    {
        anim = GetComponent<Animator>();
    }

    public IEnumerator Test1()
    {
        Debug.Log("Test1 in PopUp reached");
        anim = GetComponent<Animator>();

        textObjectToDisplay.SetActive(false);
        //when multiple boxes. check which one should pop up.

        textObjectToDisplay.SetActive(true);

        //start animation. it spins a roattion or two.
        anim.SetBool("Appearing", true);
        //animate for some time
        yield return new WaitForSeconds(0.75f);
        //stop animating
        anim.SetBool(("Appearing"), false);

        //then start displying text.
        textObjectToDisplay.GetComponent<AnimatedText>().StartCoroutine("TypeText");

        //then the box disappears.

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
