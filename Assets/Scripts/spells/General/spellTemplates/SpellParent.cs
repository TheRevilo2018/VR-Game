using UnityEngine;

public abstract class SpellParent : MonoBehaviour
{
    [SerializeField]
    protected Usable _usable = null;
    [SerializeField]
    protected Grabbable _grabbable = null;
    [SerializeField]
    protected Anchorable _anchorable = null;

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

        //add event calls
        _grabbable.GrabEvent.AddListener(OnGrabEvent);
        _grabbable.DropEvent.AddListener(OnDropEvent);
        _usable.StartUsingEvent.AddListener(OnStartUsingEvent);
        _usable.StopUsingEvent.AddListener(OnStopUsingEvent);
    }

    public void grab(Transform parent = null)
    {
        _grabbable.grab(parent);
    }

    public void drop()
    {
        _grabbable.drop();
    }

    public void startUsing()
    {
        _usable.startUsing();
    }

    public void stopUsing()
    {
        _usable.stopUsing();
    }


    #region OnEventCall
    protected virtual void OnGrabEvent(IGrabbable grabbable)
    {
        _anchorable.tryDetach();
    }

    protected virtual void OnDropEvent(IGrabbable grabbable)
    {
        _anchorable.tryAttach();
    }

    protected virtual void OnStartUsingEvent(Usable usable)
    {    }

    protected virtual void OnStopUsingEvent(Usable usable)
    {    }
    #endregion
}
