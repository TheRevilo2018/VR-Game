using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class boltScript : MonoBehaviour
{
    public float speed = 10f;   // this is the projectile's speed
    public float lifespan = 3f; // this is the projectile's lifespan (in seconds)
    public int damage = 40;
    public publicEnums.ElementType type;

    private Rigidbody body;

    void Awake()
    {
        body = GetComponent<Rigidbody>();
    }


    void Start()
    {
        body.AddForce(body.transform.forward * speed);
        Destroy(gameObject, lifespan);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Magic")
        {
            //do magic things
        }
        else if(collision.gameObject.tag != "Player")
        {
            collision.gameObject.SendMessage("takeDamage", damage, SendMessageOptions.DontRequireReceiver);
            Destroy(gameObject);
        }
    }
}
