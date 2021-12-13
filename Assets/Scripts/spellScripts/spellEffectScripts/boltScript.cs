using UnityEngine;

public class boltScript : MonoBehaviour
{
    public float lifespan = 3f; // this is the projectile's lifespan (in seconds)
    public int damage = 40;
    public ParticleSystem system;

    private Element element;

    void Start()
    {
        Destroy(gameObject, lifespan);
    }

    public void chooseElement(Element elm)
    {
        element = elm;
        ParticleSystem.ColorOverLifetimeModule col = system.colorOverLifetime;
        col.color = element.gradient;
    }

    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.SendMessage("takeDamage", damage, SendMessageOptions.DontRequireReceiver);
        //Destroy(gameObject);
    }
}
