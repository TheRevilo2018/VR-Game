using UnityEngine;

public class SpellOrbFactory : MonoBehaviour
{
    public GameObject orbPrefab;
    public Sprite orbRune;

    public GameObject createOrb(SpellCore core)
    {
        GameObject orb = Instantiate(orbPrefab);
        SpellOrb script;

        if (!orb.TryGetComponent(out script))
        {
            throw new MissingComponentException("orbPrefab needs a spellorb script");
        }

        script.setSpellCore(core, orbRune);

        return orb;
    }
}
