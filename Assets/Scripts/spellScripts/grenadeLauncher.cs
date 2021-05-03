using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grenadeLauncher : MonoBehaviour
{
    public GameObject grenadeBlueprint;

    private Rigidbody grenadeBody;
    private bool pressing = false;

    private void FixedUpdate()
    {
        if (pressing)
        {
            //snap the object to the player's hand
            grenadeBody.velocity = (transform.position - grenadeBody.transform.position) / Time.fixedDeltaTime;
        }
    }

    private void press()
    {
        pressing = true;
        grenadeBody = Instantiate(grenadeBlueprint).GetComponent<Rigidbody>();
    }

    private void release()
    {
        pressing = false;
    }
}
