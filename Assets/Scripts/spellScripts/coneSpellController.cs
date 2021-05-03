using UnityEngine;

public class coneSpellController : MonoBehaviour
{
    public ParticleSystem cone;

    private void Start()
    {
        release();
    }

    void press()
    {
        var coneEmission = cone.emission;
        coneEmission.enabled = true;
    }

    void release()
    {
        var coneEmission = cone.emission;
        coneEmission.enabled = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("unity - particle collision");
    }

}
