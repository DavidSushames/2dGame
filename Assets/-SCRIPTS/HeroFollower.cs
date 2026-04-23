using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroFollower : MonoBehaviour
{

    public GameObject HeroMirror;
    public SpriteRenderer HeroSprite1;
    public float HeroYpos;

    // Start is called before the first frame update
    void Start()
    {
        HeroSprite1 = HeroMirror.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (HeroMirror.transform.position.x > this.transform.position.x & HeroSprite1.flipX == false) 
        {
            this.transform.position = new Vector2(HeroMirror.transform.position.x, HeroYpos);
        }
        if (HeroMirror.transform.position.x < this.transform.position.x & HeroSprite1.flipX == true)
        {
            this.transform.position = new Vector2(HeroMirror.transform.position.x, HeroYpos);
        }
    }
}
