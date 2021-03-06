using System.Collections.Generic;
using UnityEngine;

public class coneSpellController : SpellCore
{
    public ParticleSystem cone;
    private Element element;
    private ParticleSystem.EmissionModule emission;

    private void Start()
    {
        Level = 1;
        emission = cone.emission;
        release();
    }

    public override void startUsing()
    {
        press();
    }

    public override void stopUsing()
    {
        release();
    }

    public override void onDrop()
    {
        release();
    }


    public override void Create(List<ElementBaseScript> elements, List<SpellCore> cores)
    {
        element = elements[0].element;

        ParticleSystem.ColorOverLifetimeModule colorOver = cone.colorOverLifetime;
        colorOver.color = element.gradient;

        ParticleSystem.MainModule mainModule = cone.main;
        mainModule.gravityModifier = element.gravity;
    }

    private void press()
    {
        emission.enabled = true;
    }

    private void release()
    {
        emission.enabled = false;
    }

}
