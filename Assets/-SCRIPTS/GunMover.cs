using System.Threading;
using UnityEngine;

public class GunMover : MonoBehaviour
{
    public float firerate;
    public GameObject spawnbullet;
    public GameObject Hero;
    public GameObject Bulletstart;
    public GameObject gunlight;
    private float angle;
    private float seconds;
    Animator gunanim;
    Animator gunlightanim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        gunanim = this.GetComponent<Animator>();
        gunlightanim = gunlight.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        seconds = seconds + 0.1f;

        if (seconds > firerate) 
        {
            gunlightanim.SetTrigger("Light");
            gunanim.SetTrigger("Fire");
            seconds = 0;
            Instantiate(spawnbullet, Bulletstart.transform.position, Bulletstart.transform.rotation);

        }
      
             

        Vector2 heroDirection = Hero.transform.position - this.transform.position;
        float angle = Mathf.Atan2(heroDirection.y, heroDirection.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));



    }
}
