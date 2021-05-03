using System.Collections.Generic;
using UnityEngine;
using PDollarGestureRecognizer;

public class RuneDraw : MonoBehaviour
{
    public ParticleSystem particles;
    public Transform playerCenter;

    ParticleSystem.MinMaxCurve defaultSpeed;
    ParticleSystem.EmissionModule module;

    List<Point> points = new List<Point>();

    Gesture gesture;
    List<Gesture> templates;
    string path = "";
    bool castMode = false;
    Vector3 circleCenter;

    int count = 0;

    private void Awake()
    {
        path = Application.dataPath + "/Scripts/Drawing/Templates/";
        templates = GestureIO.LoadTemplates(path);
    }

    private void OnDestroy()
    {
        GestureIO.writeTemplates(templates.ToArray(), path);
    }

    void Start()
    {
        defaultSpeed = particles.emission.rateOverDistance;
        module = particles.emission;
        module.rateOverDistance = 0;
    }

    void Update()
    {
        cylinderCast();
    }

    void changeMode((bool mode, Vector3 location) tup)
    {
        castMode = tup.mode;
        circleCenter = tup.location;
    }



    void cylinderCast()
    {        
        if(castMode)
        {
            if(Input.GetMouseButtonDown(0))
            {
                module.rateOverDistance = defaultSpeed;
                Debug.Log("mousedown");
            }
            if (Input.GetMouseButtonUp(0))
            {
                gesture = new Gesture(points.ToArray(), "test" + count.ToString());
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    templates.Add(gesture);
                    count++;
                }
                else
                {
                    string gestureName = PointCloudRecognizer.Classify(gesture, templates.ToArray());
                    SendMessage("getSpell", (gestureName, particles.transform.position));
                    Debug.Log(gestureName);
                }
                points.Clear();

                module.rateOverDistance = 0;
            }

            if (Input.GetMouseButton(0))
            {
                points.Add(new Point(getAngle(particles.transform),
                    particles.transform.position.y, 0));
            }
        }
       
    }

    float getAngle(Transform particle)
    {
        return Mathf.Atan((particle.position.x - circleCenter.x) / (particle.position.z - circleCenter.z));
    }
}
