using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordShape : MonoBehaviour
{
    public Transform emitterLoc;
    private GameObject system;


    void setParticleSystem(GameObject systemIn)
    {
        system = systemIn;
        Quaternion angle = new Quaternion();
        angle.eulerAngles = new Vector3(-90, 0, 0);

        system.transform.parent = emitterLoc;

        system.transform.position = emitterLoc.position;
        system.transform.rotation = angle;
    }
}
