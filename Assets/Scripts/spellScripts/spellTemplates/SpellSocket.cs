using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellSocket : SpellParent
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
                //TODO - may need to 0 out rotaion as well
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

    public void Start()
    {
        cameraLocation = Camera.main.transform;
    }

    protected override void Awake()
    {
        base.Awake();
    }

    public void Update()
    {
        screen.transform.LookAt(cameraLocation);
    }

    public override void drop()
    {
        base.drop();
        if (Core != null)
        {
            Core.drop();
        }
    }

    public override void grab(Transform parent = null)
    {
        base.grab(parent);
        if (Core != null)
        {
            Core.grab();
        }
    }

    public override void startUsing()
    {
        base.startUsing();
        if (Core != null)
        {
            Core.startUsing();
        }
    }

    public override void stopUsing()
    {
        base.stopUsing();
        if (Core != null)
        {
            Core.stopUsing();
        }
    }
}
