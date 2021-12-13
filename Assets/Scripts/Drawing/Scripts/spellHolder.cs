using System.Collections.Generic;
using UnityEngine;

public class spellHolder : MonoBehaviour
{
    //TODO find a better solution for this
    //elementRunes and elements are only used to declare runeElement
    public List<Element> elements;
    public List<RuneObject> spells;
    private Dictionary<string, Element> runeElement = new Dictionary<string, Element>();
    private Dictionary<string, RuneObject> runeCore = new Dictionary<string, RuneObject>();

    public GameObject baseElement;
    public GameObject baseCore;

    private void Awake()
    {
        foreach (Element element in elements)
        {
            runeElement.Add(element.name, element);
        }
        foreach (RuneObject rune in spells)
        {
            runeCore.Add(rune.runeName, rune);
        }
        elements = null;
        spells = null;
    }

    public GameObject getSpellInstance(string runeName, Transform loc)
    {
        Element returnElement = null;
        RuneObject returnRune = null; 
        GameObject returnObject = null;

        if (runeElement.TryGetValue(runeName, out returnElement))
        {
            Debug.Log("[spellHolder] - Asked for a " + runeName + ", came with the element " + returnElement.type.ToString());
            returnObject = Instantiate(baseElement, loc.position, loc.rotation);
            returnObject.GetComponent<ElementBaseScript>().addElement(returnElement);
        }
        else if (runeCore.TryGetValue(runeName, out returnRune))
        {
            Debug.Log("[spellHolder] - Asked for a " + runeName + ", came with the spell core " + returnRune.runeName);
            returnObject = Instantiate(baseCore, loc.position, loc.rotation);
            returnObject.GetComponent<UnfinishedSpell>().installRuneObject(returnRune);
        }
        else
        {
            Debug.LogWarning("[spellHolder] rune name " + runeName + " not found");
        }


        return returnObject;
    }

}
