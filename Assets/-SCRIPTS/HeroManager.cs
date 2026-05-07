using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class HeroManager : MonoBehaviour
{
    //public variables
    public GameObject Hero;
    public float movefactor;
    public SpriteRenderer HeroSprite;
    public GameObject HeroMirror;
    public float jumpforce;
    public float flyforce;
    public float forwardforce;
    public float edgeLimit;
    Color origcolour;
    public InputActionReference moveAction;
    public InputActionReference jumpAction;
    public InputActionReference sprintAction;



    //private variables

    private Rigidbody2D rb2;
    private Vector2 currentPosition;
    private Vector2 cameraPosition;

    private Animator anim;
    private bool onground = false;
    public float flashtime;



    // Start is called before the first frame update
    void Start()
    {

        HeroSprite = Hero.GetComponent<SpriteRenderer>();
        anim = Hero.GetComponent<Animator>();
        rb2 = Hero.GetComponent<Rigidbody2D>();
        origcolour = HeroSprite.material.color;
        rb2.freezeRotation = true;
        anim.speed = 0;
        anim.SetBool("Run", false);



    }
   
    void OnCollisionEnter2D(Collision2D hit)
    {
        if (hit.gameObject.tag == "Environment")
        {
            onground = true;
            Debug.Log("Hero has collided with ground");
        }
    }
   
    void OnTriggerEnter2D(Collider2D hit)
   {
        Debug.Log("Trigger in hero script");

        if (hit.gameObject.tag == "Fuel Can")
        {
            Debug.Log("Fuel Can hit"); 
            hit.gameObject.SetActive(false);
        }
        if (hit.gameObject.tag == "Laser")
        {
            Debug.Log("Laser hit");
            flashstart();
            flashstart();          
        }
        if (hit.gameObject.tag == "Vent")
        {
            int choice1 = Random.Range(0, 2);
            if (choice1 == 0)
            {
                Debug.Log("Vent hit");
                rb2.AddForce(new Vector2(forwardforce, flyforce), ForceMode2D.Impulse);
                anim.Play("Flying");
            }

        }

        if (hit.gameObject.tag == "Bullet")
        {
            Debug.Log("Bullet hit");
            flashstart();
            flashstart();

        }
        
    }

    //damage to player flash
    void flashstart()
    {
        Debug.Log("change colour");
        HeroSprite.material.color = new Color(1,0,0,1);
        Invoke("flashstop", flashtime);
    }

    void flashstop()
    {

        HeroSprite.material.color = origcolour;

    }



    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = moveAction.action.ReadValue<Vector2>();

        //store position of HeroMirror

         // Debug.Log("Camera Position");
        // Debug.Log(cameraPosition);
        // Debug.Log("Current Position");
        Vector2 currentPosition = Hero.transform.position;
               
        if(moveInput.x == 0)
        {
            anim.SetBool("Run", false);
        }
        else if (moveInput.x > 0f)
        {
            anim.ResetTrigger("Jump");
            anim.SetBool("Run", true);
            HeroSprite.flipX = false;
            anim.speed = 1;
            currentPosition = Hero.transform.position;
            currentPosition.x = currentPosition.x + movefactor * Time.deltaTime;
            Hero.transform.position = currentPosition;
            cameraPosition = HeroMirror.transform.position;
            cameraPosition.x = cameraPosition.x - edgeLimit;
           
            
        }
        else if (moveInput.x < 0f & (currentPosition.x > cameraPosition.x))
        {
            anim.ResetTrigger("Jump");
            anim.SetBool("Run", true);
            HeroSprite.flipX = true;
            anim.speed = 1;

           
            currentPosition = Hero.transform.position;
            currentPosition.x = currentPosition.x - movefactor * Time.deltaTime;
            Hero.transform.position = currentPosition;
            
       
        }
        if(moveInput.y > 0 && onground == true)
        {
            anim.SetTrigger("Jump");
            Debug.Log("Up key pressed");
            rb2.AddForce(new Vector2(forwardforce, jumpforce), ForceMode2D.Impulse);
            anim.Play("Jumping");
            onground = false;
            
        }
        
        
        
    }
}
