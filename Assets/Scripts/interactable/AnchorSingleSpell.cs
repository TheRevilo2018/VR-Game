using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchorSingleSpell : AnchorSingle
{
    protected override bool anchorableInput(Anchorable input)
    {
        if (input.TryGetComponent<SpellParent>(out _))
        {
            return true;
        }

        return false;
    }
}
