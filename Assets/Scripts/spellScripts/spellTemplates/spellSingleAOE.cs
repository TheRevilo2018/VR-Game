using UnityEngine;

public class spellSingleAOE : spellParent
{
    public ParticleSystem particles;
    private ParticleSystem.EmissionModule emission;
    private ParticleSystem.MinMaxCurve emissionRate;
    private ParticleSystem.ColorOverLifetimeModule colorMod;

    private bool beingUsed = true; //true so that when the class is declared, it can be stopped properly
    private bool ready = false;

    private Element element;

    protected void Start()
    {
        particles = GetComponent<ParticleSystem>();
        emission = particles.emission;
        emissionRate = emission.rateOverTime;

        stopUsing();
    }

    public override void startUsing()
    {
        if (!beingUsed && ready)
        {
            beingUsed = true;
            emission.rateOverTime = emissionRate;
        }
    }

    public override void stopUsing()
    {
        if (beingUsed)
        {
            beingUsed = false;
            emission.rateOverTime = 0;
        }    
    }

    public override void grab(Transform parent)
    {
        base.grab(parent);
        stopUsing();
    }

    public override void drop()
    {
        stopUsing();
    }

    public void changeElement(Element inElement)
    {
        stopUsing();
        element = inElement;

        colorMod.color = element.primaryColor;
        ready = true;
    }
}
