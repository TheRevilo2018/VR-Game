using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchorElement : AnchorSingle
{
    protected override bool anchorableInput(Anchorable input)
    {
        if (input.TryGetComponent<ElementBaseScript>(out _))
        {
            return true;
        }

        return false;
    }
}
