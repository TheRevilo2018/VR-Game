using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementBaseScript : SpellParent
{
    public Element element;
    public ParticleSystem particles;

    public void addElement(Element el)
    {
        element = el;

        var main = particles.main;
        main.gravityModifier = element.gravity;

        var colors = particles.colorOverLifetime;
        colors.color = element.gradient;
    }
}
