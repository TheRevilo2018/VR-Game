using System.Collections.Generic;
using UnityEngine;
using PDollarGestureRecognizer;

public class RuneDrawVR : MagicHandler
{
    public ParticleSystem rightParticles;
    public ParticleSystem leftParticles;
    private RuneDrawHand rightHand;
    private RuneDrawHand leftHand;

    public bool addingRunes;
    public int minPoints = 12;

    List<Point> points = new List<Point>();

    List<Gesture> templates;
    string path = string.Empty;
    Vector3 circleCenter;

    public GameObject runeCircle;
    private GameObject thisCircle;

    int strokeNum = 0;
    int templateAddCount = 0;

    public override bool Creating
    {
        get { return rightHand.Creating || leftHand.Creating; }
        protected set { rightHand.startCreating(); leftHand.startCreating(); }
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
        rightHand = new RuneDrawHand(rightParticles);
        leftHand = new RuneDrawHand(leftParticles);
    }

    public override void activate()
    {
        circleCenter = transform.position;
        MagicActive = true;

        Vector3 circleLoc = transform.position;
        circleLoc.y += 0.01f;
        thisCircle = Instantiate(runeCircle, circleLoc, transform.rotation);

        rightHand.activate(circleCenter);
        leftHand.activate(circleCenter);
    }

    public override void deactivate()
    {
        var temp = thisCircle.GetComponent<magicCircle>();
        if (!temp.DestroySelf)
        {
            temp.selfDestruct();
        }
    }

    public override void startCreating(ControllerManager.DeviceOption device)
    {
        if (device == ControllerManager.DeviceOption.rightController)
        {
            rightHand.startCreating(strokeNum);
        }
        else
        {
            leftHand.startCreating(strokeNum);
        }

        strokeNum++;
    }

    public override void stopCreating(ControllerManager.DeviceOption device)
    {
        if (device == ControllerManager.DeviceOption.rightController)
        {
            points.AddRange(rightHand.stopCreating());
        }
        else
        {
            points.AddRange(leftHand.stopCreating());
        }
    }

    public override GameObject produceSpell()
    {
        string gestureName = "";
        Gesture gesture = new Gesture(points.ToArray(), "test" + templateAddCount.ToString());

        if (addingRunes)
        {
            templates.Add(gesture);
            templateAddCount++;
            Debug.Log("[RuneDraw] new template added: " + templateAddCount);
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
        strokeNum = 0;

        return SpellDatabase.Instance.getSpellInstance(gestureName, leftParticles.transform);
    }




    private void FixedUpdate()
    {
        rightHand.collectPoint();
        leftHand.collectPoint();
    }
}
