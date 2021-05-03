using UnityEngine;

public class playerModeVR : MonoBehaviour
{
    public Transform circleLoc;
    public GameObject spellCircle;
    public PlayerBroadcast broadcaster;

    bool circleOn = false;
    Vector3 circleCenter;
    GameObject circle;

    public void Start()
    {
        circleCenter = circleLoc.position;
    }

    // Update is called once per frame
    public void Update()
    {
        if (ControllerManager.Instance.getButtonPress(ControllerManager.DeviceOption.rightController,
            ControllerManager.ButtonOption.primaryButton))
        {
            if (circleOn)
            {
                circleOn = false;
                broadcaster.BroadcastAll("changeMode", (false, circleCenter));
                circle.SendMessage("selfDestruct");
            }
            else
            {
                circleOn = true;
                circleCenter = circleLoc.position;
                circleCenter.y = circleCenter.y + 0.01f;
                Debug.Log("center y: " + circleCenter.y);
                broadcaster.BroadcastAll("changeMode", (true, circleCenter));
                circle = Instantiate(spellCircle, circleCenter, circleLoc.transform.rotation);
            }
        }
    }
}
