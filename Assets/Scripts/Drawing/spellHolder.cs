using UnityEngine;

public class spellHolder : MonoBehaviour
{
    public GameObject parentSpell;

    public GameObject ball;
    public GameObject cone;
    public GameObject bolt;

    public Element fire;

    public GameObject getSpell((string spellName, Vector3 loc) tup)
    {
        return getSpell(tup.spellName, tup.loc);
    }

    public GameObject getSpell(string spellName, Vector3 loc)
    {
        GameObject spellParent = getParentSpell(loc);
        GameObject spellShape = getSpellComponent(spellName);

        spellParent.SendMessage("changeShape", spellShape);
        spellParent.SendMessage("changeElement", fire);

        return spellParent;
    }

    private GameObject getParentSpell(Vector3 loc)
    {
        var tempSpell = Instantiate(parentSpell);

        tempSpell.transform.position = loc;
        return tempSpell;
    }

    private GameObject getSpellComponent(string name)
    {
        GameObject component = null;

        Debug.Log("unity - create " + name);

        switch (name)
        {
            case "cone":
                component = Instantiate(cone);
                break;
            case "ball":
                component = Instantiate(ball);
                break;
            case "bolt":
                component = Instantiate(bolt);
                break;
            default:
                Debug.Log("Rune not recognized");
                break;
        }

        return component;
    }

}
