using System.Collections.Generic;
using UnityEngine;

//this a base class which would have been 
public abstract class SpellCore : MonoBehaviour
{
    #region Properties
    public int Level { get; protected set; }
    #endregion

    public virtual void Create(List<ElementBaseScript> elements, List<SpellCore> cores)
    {

    }

    public virtual void onGrab()
    {

    }

    public virtual void onDrop()
    {

    }

    public virtual void startUsing()
    {

    }

    public virtual void stopUsing()
    {

    }
}
