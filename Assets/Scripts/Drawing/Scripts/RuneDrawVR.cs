using System.Collections.Generic;
using UnityEngine;
using PDollarGestureRecognizer;

public class RuneDrawVR : MonoBehaviour
{
    public ParticleSystem particles;
    public double minPoints = 12;
    public bool addingRunes;

    ParticleSystem.MinMaxCurve defaultSpeed;
    ParticleSystem.EmissionModule module;

    List<Point> points = new List<Point>();

    List<Gesture> templates;
    string path = "";
    Vector3 circleCenter;

    private bool drawing;
    int count = 0;

    public bool Drawing
    {
        get
        {
            return drawing;
        }
    }

    private void Awake()
    {
        path = Application.persistentDataPath + "/Templates/";
        try
        {
            templates = GestureIO.LoadTemplates(path);
        }
        catch (System.Exception e)
        {
            Debug.LogError("[RuneDraw] " + e);
        }
    }

    void Start()
    {
        module = particles.emission;
        defaultSpeed = module.rateOverTime;
        module.rateOverTime = 0;
    }

    public void startDrawing(Vector3 center)
    {
        circleCenter = center;
        drawing = true;
        module.rateOverTime = defaultSpeed;
    }

    public string stopDrawing()
    {
        drawing = false;
        string gestureName = "";
        Gesture gesture = new Gesture(points.ToArray(), "test" + count.ToString());

        if (addingRunes)
        {
            templates.Add(gesture);
            count++;
            Debug.Log("[RuneDraw] new template added: " + count);
            try
            {
                GestureIO.writeTemplates(templates.ToArray(), path);
                Debug.Log("[RuneDraw] templates saved sucessfully");
            }
            catch (System.Exception e)
            {
                Debug.LogError("[RuneDraw] " + e);
            }
        }
        else if (points.Count >= minPoints)
        {
            gestureName = PointCloudRecognizer.Classify(gesture, templates.ToArray());
        }

        points.Clear();
        module.rateOverTime = 0;
        return gestureName;
    }

    private void FixedUpdate()
    {
        if (drawing)
        {
            points.Add(new Point(getAngle(particles.transform), particles.transform.position.y, 0));
        }
    }

    float getAngle(Transform particle)
    {
        return Mathf.Atan((particle.position.x - circleCenter.x) / (particle.position.z - circleCenter.z));
    }
}
