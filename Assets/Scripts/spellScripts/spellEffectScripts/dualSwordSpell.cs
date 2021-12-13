using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dualSwordSpell : SpellCore
{
    public ParticleSystem right;
    public ParticleSystem left;
    private Element rightElement;
    private Element leftElement;
    private ParticleSystem.EmissionModule leftEmission;
    private ParticleSystem.EmissionModule rightEmission;

    private void Start()
    {
        leftEmission = left.emission;
        rightEmission = right.emission;
        release();
    }

    public override void grab()
    {
        base.grab();
        press();
    }

    public override void drop()
    {
        base.drop();
        release();
    }


    public override void Create(List<ElementBaseScript> elements, List<SpellCore> cores)
    {
        base.Create(elements, cores);
        leftElement = elements[0].element;
        rightElement = elements[1].element;

        ParticleSystem.ColorOverLifetimeModule leftColorOver = left.colorOverLifetime;
        leftColorOver.color = leftElement.gradient;
        ParticleSystem.ColorOverLifetimeModule rightColorOver = right.colorOverLifetime;
        rightColorOver.color = rightElement.gradient;

        ParticleSystem.MainModule leftMainModule = left.main;
        leftMainModule.gravityModifier = leftElement.gravity;
        ParticleSystem.MainModule rightMainModule = right.main;
        rightMainModule.gravityModifier = rightElement.gravity;
    }

    private void press()
    {
        leftEmission.enabled = true;
        rightEmission.enabled = true;
    }

    private void release()
    {
        leftEmission.enabled = false;
        rightEmission.enabled = false;
    }

}
