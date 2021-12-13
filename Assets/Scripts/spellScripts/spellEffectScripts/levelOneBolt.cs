using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelOneBolt : SpellCore
{
    private Element element;
    public shootObject launcher;

    public override void startUsing()
    {
        base.startUsing();
        press();
    }

    public override void Create(List<ElementBaseScript> elements, List<SpellCore> cores)
    {
        base.Create(elements, cores);
        element = elements[0].element;

        launcher.setElement(element);
    }

    private void press()
    {
        launcher.shoot();
    }
}
