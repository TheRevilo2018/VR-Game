using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Only works for spherical colliders
public class AnchorSpellSocket : AnchorSingle
{
    private int _minLevel = 0;
    private int _maxLevel = -1;

    #region Properties
    public int MinLevel
    {
        get {return _minLevel;}
        set {_minLevel = Mathf.Max(value, 0);}
    }

    public int MaxLevel
    {
        get {return _maxLevel;}
        set {_maxLevel = Mathf.Max(value, -1);}
    }

    #endregion

    protected override void Start()
    {
        base.Start();
        MinLevel = -1;
        MaxLevel = -1;
    }

    protected override bool anchorableInput(Anchorable input)
    {
        SpellOrb socket;
        if (input.TryGetComponent(out socket))
        {
            if (socket.Core != null && socket.Core.Level >= MinLevel && (MaxLevel == -1 || socket.Core.Level <= MaxLevel))
            {
                return true;
            }
        }

        return false;
    }
}

