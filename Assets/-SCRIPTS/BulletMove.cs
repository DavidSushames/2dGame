using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public float bulletspeed;
    Rigidbody2D cbody;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cbody = this.gameObject.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
           if (collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        cbody.linearVelocity = transform.right * bulletspeed;
        //cbody.angularVelocity = 100f;
        //cbody.AddForce(transform.right, (ForceMode2D)ForceMode.Force);
    }
}
