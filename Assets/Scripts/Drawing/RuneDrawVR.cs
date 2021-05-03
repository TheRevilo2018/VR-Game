using System.Collections.Generic;
using UnityEngine;
using PDollarGestureRecognizer;

public class RuneDrawVR : MonoBehaviour
{
    public ParticleSystem particles;
    public Transform playerCenter;
    public ControllerManager.DeviceOption hand;
    public double minPoints = 12;

    ParticleSystem.MinMaxCurve defaultSpeed;
    ParticleSystem.EmissionModule module;

    List<Point> points = new List<Point>();

    Gesture gesture;
    List<Gesture> templates;
    string path = "";
    bool castMode = false;
    bool holding = false;
    Vector3 circleCenter;

    int count = 0;

    private void Awake()
    {
        path = Application.persistentDataPath + "/Templates/";
        try
        {
            templates = GestureIO.LoadTemplates(path);
        }
        catch (System.Exception e)
        {
            Debug.LogError("unity - " + e);
        }
    }

    void Start()
    {
        defaultSpeed = particles.emission.rateOverTime;
        module = particles.emission;
        module.rateOverTime = 0;
    }

    private void Update()
    {
        if (castMode && !holding)
        {
            if (ControllerManager.Instance.getButtonPress(hand, ControllerManager.ButtonOption.triggerButton))
            {
                module.rateOverTime = defaultSpeed;
            }

            if (ControllerManager.Instance.getButtonPressing(hand, ControllerManager.ButtonOption.triggerButton))
            {
                points.Add(new Point(getAngle(particles.transform), particles.transform.position.y, 0));
            }
            else if (ControllerManager.Instance.getButtonRelease(hand, ControllerManager.ButtonOption.triggerButton))
            {
                Debug.Log("unity - pointcloud size: " + points.Count + " castMode: " + castMode);
                gesture = new Gesture(points.ToArray(), "test" + count.ToString());
                if (ControllerManager.Instance.getButtonPressing(hand, ControllerManager.ButtonOption.secondaryButton))
                {
                    templates.Add(gesture);
                    count++;
                    Debug.Log("unity - new template added: " + count);
                    try
                    {
                        GestureIO.writeTemplates(templates.ToArray(), path);
                        Debug.Log("unity - templates saved sucessfully");
                    }
                    catch (System.Exception e)
                    {
                        Debug.LogError("unity - " + e);
                    }
                }
                else if(points.Count >= minPoints)
                {
                    string gestureName = PointCloudRecognizer.Classify(gesture, templates.ToArray());
                    SendMessage("getSpell", (gestureName, particles.transform.position));
                    Debug.Log("unity - gesture: " + gestureName);
                }
                points.Clear();

                module.rateOverTime = 0;
            }
        }
    }

    void changeMode((bool mode, Vector3 location) tup)
    {
        castMode = tup.mode;
        circleCenter = tup.location;
    }

    float getAngle(Transform particle)
    {
        return Mathf.Atan((particle.position.x - circleCenter.x) / (particle.position.z - circleCenter.z));
    }

    void holdingChange(bool input)
    {
        holding = input;
    }
}
