using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using devOp = ControllerManager.DeviceOption;
using butOp = ControllerManager.ButtonOption;

public class mainPlayerManager : MonoBehaviour
{
    public spellHolder holder;

    public GrabVR rightGrab;
    public GrabVR leftGrab;

    public RuneDrawVR rightDraw;
    public RuneDrawVR leftDraw;

    public GameObject runeCircle;
    private GameObject thisCircle;

    private void FixedUpdate()
    {
        checkHand(devOp.rightController, rightGrab, rightDraw);
        checkHand(devOp.leftController, leftGrab, leftDraw);

        if(ControllerManager.Instance.getFixedButtonPress(devOp.rightController, butOp.primaryButton))
        {
            toggleRuneCircle();
        }
    }

    private void checkHand(devOp hand, GrabVR grab, RuneDrawVR draw)
    {
        if (grab.Holding)
        {
            if (ControllerManager.Instance.getFixedButtonRelease(hand, butOp.gripButton))
            {
                grab.drop();
            }
            else if (ControllerManager.Instance.getFixedButtonRelease(hand, butOp.triggerButton))
            {
                grab.stopUsing();
            }
            else if (ControllerManager.Instance.getFixedButtonPress(hand, butOp.triggerButton))
            {
                grab.startUsing();
            }
        }
        else if (draw.Drawing && ControllerManager.Instance.getFixedButtonRelease(hand, butOp.triggerButton))
        {
            string result = "";
            result = draw.stopDrawing();
            holder.getSpellInstance(result, draw.transform);
        }
        else if (ControllerManager.Instance.getFixedButtonPress(hand, butOp.gripButton))
        {
            grab.grab();
        }
        else if (ControllerManager.Instance.getFixedButtonPress(hand, butOp.triggerButton) && thisCircle != null)
        {
            //change to the rune circle soon
            draw.startDrawing(thisCircle.transform.position);
        }
    }

    private void toggleRuneCircle()
    {
        if (thisCircle == null)
        {
            Vector3 circleLoc = transform.position;
            circleLoc.y += 0.01f;
            thisCircle = Instantiate(runeCircle, circleLoc, transform.rotation);
        }
        else
        {
            var temp = thisCircle.GetComponent<magicCircle>();
            if (!temp.DestroySelf)
            {
                temp.selfDestruct();
            }
        }
    }

}
