using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformInputs : MonoBehaviour
{

    public float speed = 5.0f;
    public float jumpHeight = 5.0f;
    public Transform groundCheck;

    private float horizontalDirection;
    private float verticalDirection;
    private bool grounded;
    private Rigidbody2D rgdbd2d;
    private Animator anim;
    private float orgSpeed;
    private float boostSpeed;
    private bool spedUp;

    void Start()
    {
        rgdbd2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        orgSpeed = speed;
        //just to give it a value. that doesnt impact state. 
        boostSpeed = speed;
    }


    void Update()
    {
        horizontalDirection = Input.GetAxis("Horizontal");
        verticalDirection = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(horizontalDirection, 0, 0) * speed * Time.deltaTime, Camera.main.transform);

        if (horizontalDirection > 0)
        {
            Flip(true);
        }
        else if (horizontalDirection < 0)
        {
            Flip(false);
        }

        grounded = Physics2D.OverlapPoint(groundCheck.position);

        
        if (grounded && Input.GetKeyDown(KeyCode.Space))
        {
            rgdbd2d.velocity += new Vector2(rgdbd2d.velocity.x, jumpHeight);
            grounded = false;
            //Debug.Log("hoppar, grounded =" + grounded);
        }
        

        //checks for a down/s input
        if (verticalDirection < 0)
        {
            speed = 0;
            anim.SetBool("Duck", true);
            //Debug.Log("Set duck true");
        } else if (!spedUp) 
        {
            speed = orgSpeed;
            anim.SetBool("Duck", false);
            //Debug.Log("Set duck false");
        } else if (spedUp)
        {
            speed = boostSpeed;
            anim.SetBool("Duck", false);
        }
        
        
        anim.SetFloat("Speed", Mathf.Abs(horizontalDirection));
        anim.SetBool("Grounded", grounded);
    }

    public void SpeedManager(bool isSpedUp, float boost)
    {
        if (isSpedUp)
        {
            spedUp = true;
            speed = boost;
            boostSpeed = boost;
            //Debug.Log("in speedmanager. set speed to boost:" + boost);
        } else if (!isSpedUp)
        {
            Debug.Log("in speedmanager. set speed to org value" + orgSpeed);
            spedUp = false;
            speed = orgSpeed;
        }
    }

    private void Flip (bool facingRight)
    {
        Vector3 myScale = transform.localScale;

        if (facingRight == true){
            myScale.x = 1;
        } else if (facingRight ==false)
        {
            myScale.x = -1;
        }
        transform.localScale = myScale;
        
    }


}
