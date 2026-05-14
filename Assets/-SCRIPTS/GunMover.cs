using UnityEngine;
public class GunMover : MonoBehaviour
{
    public float firerate;
    public GameObject spawnbullet;
    public GameObject Hero;
    public GameObject Bulletstart;
    public GameObject gunlight;
    private float seconds;
    private Vector2 lastHeroPos;
    private Vector2 heroVelocity;
    private Vector2 smoothedVelocity;
    Animator gunanim;
    Animator gunlightanim;

    void Start()
    {
        gunanim = this.GetComponent<Animator>();
        gunlightanim = gunlight.GetComponent<Animator>();
        lastHeroPos = Hero.transform.position;
    }

    void Update()
    {
        // Track hero velocity manually
        heroVelocity = ((Vector2)Hero.transform.position - lastHeroPos) / Time.deltaTime;
        smoothedVelocity = Vector2.Lerp(smoothedVelocity, heroVelocity, 0.1f);
        lastHeroPos = Hero.transform.position;

        // Always increment seconds
        seconds += Time.deltaTime;

        // Asymmetric range check
        float horizontalDist = Hero.transform.position.x - this.transform.position.x;
        bool inRange = horizontalDist > -30f && horizontalDist < 10f;

        Debug.Log("horizontalDist: " + horizontalDist + " inRange: " + inRange);

        if (seconds > firerate && inRange)
        {
            gunlightanim.SetTrigger("Light");
            gunanim.SetTrigger("Fire");
            seconds = 0;
            Instantiate(spawnbullet, Bulletstart.transform.position, Bulletstart.transform.rotation);
        }

        // Aim with simple horizontal lead
        Vector2 heroPos = Hero.transform.position;
        Vector2 aimTarget = heroPos + new Vector2(smoothedVelocity.x * 0.3f, 0f);
        Vector2 heroDirection = aimTarget - (Vector2)this.transform.position;
        float angle = Mathf.Atan2(heroDirection.y, heroDirection.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}