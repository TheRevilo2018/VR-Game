using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magicCircle : MonoBehaviour
{
    public ParticleSystem particles;
    public float deathDuration = 8f;

    bool destroySelf = false;
    public float currentDuration = 0f;

    // Update is called once per frame
    void Update()
    {
        if(destroySelf)
        {
            currentDuration += Time.deltaTime;

            if (currentDuration > deathDuration)
            {
                Destroy(gameObject);
            }
        }
    }

    void selfDestruct()
    {
        destroySelf = true;
        var temp = particles.emission;
        temp.enabled = false;
    }
}
