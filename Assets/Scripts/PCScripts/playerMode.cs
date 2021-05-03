using UnityEngine;

public class playerMode : MonoBehaviour
{
    public Transform circleLoc;
    public GameObject spellCircle;

    bool circleOn = false;
    Vector3 circleCenter;
    GameObject circle;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (circleOn)
            {
                circleOn = false;
                BroadcastMessage("changeMode", (false, circleCenter));
                circle.SendMessage("selfDestruct");
            }
            else
            {
                circleOn = true;
                circleCenter = circleLoc.position;
                BroadcastMessage("changeMode", (true, circleCenter));
                circle = Instantiate(spellCircle, circleLoc.transform.position, circleLoc.transform.rotation);
            }
        }
    }
}
