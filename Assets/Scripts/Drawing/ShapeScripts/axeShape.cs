using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class axeShape : MonoBehaviour
{
    public Transform emitterLoc;



    private GameObject element;
    private ParticleSystem system;


    void setParticleSystem(GameObject systemIn)
    {
        element = systemIn;
        Quaternion angle = new Quaternion();
        angle.eulerAngles = new Vector3(0, 210, 0);

        element.transform.parent = emitterLoc;

        element.transform.position = emitterLoc.position;
        element.transform.rotation = angle;

        modParticleSystem();
    }

    void modParticleSystem()
    {
        system = element.GetComponent<ParticleSystem>();

        var shape = system.shape;
        shape.shapeType = ParticleSystemShapeType.Circle;
        shape.arc = 80f;

        var emision = system.emission;
    }
}
