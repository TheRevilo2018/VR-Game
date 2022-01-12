using System;
using UnityEngine;

public class SpellOrb : SpellParent
{
    public SpriteRenderer screen;
    private Transform cameraLocation;

    public SpellCore Core { get; private set; } = null;

    public void setSpellCore(SpellCore core, Sprite sprite)
    {
        try
        {
            if (Core == null)
            {
                screen.sprite = sprite;
                Core = core;
                Core.transform.parent = transform;
                Core.transform.localPosition = Vector3.zero;
                Quaternion rot = new Quaternion();
                rot.eulerAngles = Vector3.zero;
                Core.transform.localRotation = rot;
            }
            else
            {
                Debug.LogWarning("[SpellSocket] - trying to add a spell core to a full socket");
            }
        }
        catch(Exception e)
        {
            Debug.LogError(e);
        }
    }

    public SpellCore removeSpellCore()
    {
        Core.transform.parent = null;
        Destroy(gameObject, 1f);
        return Core;
    }

    protected override void Start()
    {
        cameraLocation = Camera.main.transform;
        base.Start();
    }

    public void Update()
    {
        screen.transform.LookAt(cameraLocation);
    }

    #region OnEventCall
    protected override void OnGrabEvent(IGrabbable grabbable)
    {
        base.OnGrabEvent(grabbable);
        if (Core != null)
        {
            Core.onGrab();
        }
    }

    protected override void OnDropEvent(IGrabbable grabbable)
    {
        base.OnDropEvent(grabbable);
        if (Core != null)
        {
            Core.onDrop();
        }
    }

    protected override void OnStartUsingEvent(Usable usable)
    {
        base.OnStartUsingEvent(usable);
        if (Core != null)
        {
            Core.startUsing();
        }
    }

    protected override void OnStopUsingEvent(Usable usable)
    {
        base.OnStopUsingEvent(usable);
        if (Core != null)
        {
            Core.stopUsing();
        }
    }
    #endregion
}
