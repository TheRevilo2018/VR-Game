using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MagicHandler : MonoBehaviour
{
    public bool MagicActive
    {
        get;
        protected set;
    }
    public virtual bool Creating
    {
        get;
        protected set;
    }

    public virtual void activate() { }
    public virtual void deactivate() { }
    public virtual void startCreating(ControllerManager.DeviceOption device) { }
    public virtual void stopCreating(ControllerManager.DeviceOption device) { }
    public abstract GameObject produceSpell();
}
