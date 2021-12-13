using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magicCircle : MonoBehaviour
{
    public ParticleSystem particles;
    public float deathDuration = 8f;

    private bool destroySelf = false;

    public bool DestroySelf
    {
        get
        {
            return destroySelf;
        }
    }

    public void selfDestruct()
    {
        if (!destroySelf)
        {
            var temp = particles.emission;
            temp.enabled = false;
            Destroy(gameObject, deathDuration);
            destroySelf = true;
        }
    }
}
