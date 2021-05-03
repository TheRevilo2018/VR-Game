using UnityEngine;

public class grenadeScript : MonoBehaviour
{
    public ParticleSystem explosion;
    public ParticleSystem trail;
    public Collider grenadeCollider;
    public float duration = 8f;

    private float currentDuration = 0f;
    bool exploded = false;

    private void OnCollisionEnter(Collision collision)
    {
        explode();
    }

    void explode()
    {
        //set the particle systems
        explosion.Play();
        var em = trail.emission;
        em.enabled = false;

        //set the other stuff
        grenadeCollider.enabled = false;
        exploded = true;
    }

    private void Update()
    {
        if (exploded)
        {
            currentDuration += Time.deltaTime;
        }

        if(currentDuration > duration)
        {
            Destroy(gameObject);
        }
    }
}
