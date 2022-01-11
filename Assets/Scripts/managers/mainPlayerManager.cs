using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using devOp = ControllerManager.DeviceOption;
using butOp = ControllerManager.ButtonOption;

public class mainPlayerManager : MonoBehaviour
{
    public GrabVR rightGrab;
    public GrabVR leftGrab;

    public MagicHandler magic;

    private void FixedUpdate()
    {
        checkHand(devOp.rightController, rightGrab, magic);
        checkHand(devOp.leftController, leftGrab, magic);

        if(ControllerManager.Instance.getFixedButtonPress(devOp.rightController, butOp.primaryButton))
        {
            if (magic.MagicActive)
            {
                magic.deactivate();
            }
            else
            {
                magic.activate();
            }
        }
        if(ControllerManager.Instance.getFixedButtonPress(devOp.leftController, butOp.primaryButton) && magic.MagicActive)
        {
            magic.produceSpell();
        }
    }

    private void checkHand(devOp hand, GrabVR grab, MagicHandler handler)
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
        else if (handler.Creating && ControllerManager.Instance.getFixedButtonRelease(hand, butOp.triggerButton))
        {
            handler.stopCreating(hand);
        }
        else if (ControllerManager.Instance.getFixedButtonPress(hand, butOp.gripButton))
        {
            grab.grab();
        }
        else if (ControllerManager.Instance.getFixedButtonPress(hand, butOp.triggerButton) && handler.MagicActive)
        {
            handler.startCreating(hand);
        }
    }

}
