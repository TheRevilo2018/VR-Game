using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchorSingleSpell : AnchorSingle
{
    protected override bool anchorableInput(Anchorable input)
    {
        SpellParent socket;
        if (input.TryGetComponent(out socket))
        {
            return true;
        }

        return false;
    }
}
