using System;
using System.Collections.Generic;
using UnityEngine;

public class UnfinishedSpell : MonoBehaviour
{
    public SpriteRenderer spriteRender;
    public GameObject elementAnchorType;
    public GameObject coreAnchorType;
    public GameObject socketType;

    private RuneObject bluePrint;
    private List<AnchorElement> elementAnchors = new List<AnchorElement>();
    private List<AnchorSpellSocket> coreAnchors = new List<AnchorSpellSocket>();

    private bool installed;


    public void installRuneObject(RuneObject scriptableRune)
    {
        if (!installed)
        {
            try
            {
                bluePrint = scriptableRune;
                spriteRender.sprite = bluePrint.rune;

                for (int i = 0; i < bluePrint.anchors.Count; i++)
                {
                    if (bluePrint.anchors[i].core)
                    {
                        GameObject anchor = Instantiate(coreAnchorType);
                        AnchorSpellSocket comp;

                        if (anchor.TryGetComponent(out comp))
                        {
                            anchor.transform.SetParent(transform);
                            anchor.transform.localPosition = bluePrint.anchors[i].location;
                            comp.MaxLevel = bluePrint.anchors[i].maxSpellLevel;
                            comp.MinLevel = bluePrint.anchors[i].minSpellLevel;
                            coreAnchors.Add(comp);
                        }
                    }
                    else
                    {
                        GameObject anchor = Instantiate(elementAnchorType);
                        AnchorElement comp;

                        if (anchor.TryGetComponent(out comp))
                        {
                            anchor.transform.SetParent(transform);
                            anchor.transform.localPosition = bluePrint.anchors[i].location;
                            elementAnchors.Add(comp);
                        }
                    }

                    Debug.Log("[UnfinishedSpell] - added anchor " + i + " with position " + bluePrint.anchors[i].location);
                }

                transform.LookAt(Camera.main.transform);
                installed = true;
            }
            catch(Exception e)
            {
                Debug.LogError(e);
            }
        }

    }

    private void FixedUpdate()
    {
        if (installed)
        {
            try
            {
                bool ready = true;

                foreach (AnchorSpellSocket anchor in coreAnchors)
                {
                    if (!anchor.Full)
                    {
                        ready = false;
                    }
                }
                foreach (AnchorElement anchor in elementAnchors)
                {
                    if (!anchor.Full)
                    {
                        ready = false;
                    }
                }

                if (ready)
                {
                    createSpell();
                }
            }
            catch(Exception e)
            {
                Debug.LogError(e);
            }
        }

    }

    private void createSpell()
    {
        GameObject newSpell = Instantiate(bluePrint.resultSpell);
        GameObject newSocket = Instantiate(socketType, transform.position, transform.rotation);
        SpellCore newSpellCore;
        if (newSpell.TryGetComponent(out newSpellCore))
        {
            List<ElementBaseScript> elements = new List<ElementBaseScript>();
            List<SpellCore> cores = new List<SpellCore>();

            foreach(AnchorElement anchor in elementAnchors)
            {
                elements.Add(anchor.Contains.GetComponent<ElementBaseScript>());
            }
            foreach(AnchorSpellSocket anchor in coreAnchors)
            {
                cores.Add(anchor.Contains.GetComponent<SpellOrb>().removeSpellCore());
            }

            newSpellCore.Create(elements, cores);
            newSocket.GetComponent<SpellOrb>().setSpellCore(newSpellCore, bluePrint.rune);
        }
        else
        {
            Debug.LogError("Trying to create a spell with no SpellCore");
        }
        Destroy(gameObject);
    }
}
