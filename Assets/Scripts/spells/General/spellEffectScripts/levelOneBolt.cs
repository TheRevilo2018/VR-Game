using System.Collections.Generic;

public class levelOneBolt : SpellCore
{
    private Element element;
    public shootObject launcher;

    private void Start()
    {
        Level = 1;
    }

    public override void startUsing() 
    {
        press();
    }

    public override void Create(List<ElementBaseScript> elements, List<SpellCore> cores)
    {
        element = elements[0].element;

        launcher.setElement(element);
    }

    private void press()
    {
        launcher.shoot();
    }
}
