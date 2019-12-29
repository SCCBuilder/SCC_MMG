using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerBlock : MonoBehaviour
{

    private int counter = 0;
    public List<Color> colors; //list of colors, can be changed in inspector
    //remember to have the colors be at 255 transparency so that they are visible. (or at least not 0)
    SpriteRenderer renderReference;

    public float timerDuration;
    
    
    // Start is called before the first frame update
    void Start()
    {   //manages colors
        renderReference = GetComponent<SpriteRenderer>();
        renderReference.color = colors[counter];
        StartCoroutine(DelayTimer());
    }
   

    private void Update()
    {
        
        
    }

    private IEnumerator DelayTimer()
    {
        //print(Time.time);
        yield return new WaitForSeconds(timerDuration);
        //print(Time.time);
        ChangeColor();
    }

    //this is to test ChangeColor. can be commented.
    private void OnCollisionEnter2D(Collision2D other)
    {
        ChangeColor();
    }

    public void ChangeColor()
    {
        //Debug.Log("color changed");
        //if (coll.other.tag == "Wall") { //uncomment to check tag of colliding object
        if (counter < colors.Count - 1)
        {
            counter++;
        }
        else
        {
            counter = 0;
        }
        renderReference.color = colors[counter];
        //} //uncomment to check tag of colliding object
    }

}
