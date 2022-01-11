using UnityEngine;

public abstract class SpellParent : MonoBehaviour
{
    [SerializeField]
    private Usable _usable = null;
    [SerializeField]
    private Grabbable _grabbable = null;
    [SerializeField]
    private Anchorable _anchorable = null;

    public Usable UsableScript { get { return _usable; }}
    public  Grabbable GrabbableScript { get { return _grabbable; } }
    public Anchorable AnchorableScript { get { return _anchorable; } }

    protected virtual void Start()
    {
        if (!gameObject.TryGetComponent(out _usable))
        {
            _usable = gameObject.AddComponent<Usable>();
        }
        if (!gameObject.TryGetComponent(out _grabbable))
        {
            _grabbable = gameObject.AddComponent<Grabbable>();
        }
        if (!gameObject.TryGetComponent(out _anchorable))
        {
            _anchorable = gameObject.AddComponent<Anchorable>();
        }
    }

    public virtual void grab(Transform parent = null)
    {
        _grabbable.grab(parent);
    }

    public virtual void drop()
    {
        _grabbable.drop();
    }

    public virtual void startUsing()
    {
        _usable.startUsing();
    }

    public virtual void stopUsing()
    {
        _usable.stopUsing();
    }

}
