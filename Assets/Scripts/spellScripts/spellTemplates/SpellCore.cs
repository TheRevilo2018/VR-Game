using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCore : MonoBehaviour
{
    private int _level;


    #region Properties
    public int Level
    {
        get {return _level;}
        protected set 
        {
            _level = Mathf.Max(0, value);
        }
    }

    public bool Created
    {
        get;
        protected set;
    }
    #endregion

    private void Start()
    {
        Created = false;
    }

    public virtual void Create(List<ElementBaseScript> elements, List<SpellCore> cores)
    {

    }

    public virtual void grab()
    {

    }

    public virtual void drop()
    {

    }

    public virtual void startUsing()
    {

    }

    public virtual void stopUsing()
    {

    }
}
