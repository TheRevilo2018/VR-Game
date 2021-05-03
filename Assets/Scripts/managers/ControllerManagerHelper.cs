using UnityEngine;

public class ControllerManagerHelper : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ControllerManager.Instance.Update();
        ControllerManager.Instance.fixedUpdate();
    }

    // Update is called once per frame
    void Update()
    {
        ControllerManager.Instance.Update();
    }

    private void FixedUpdate()
    {
        ControllerManager.Instance.fixedUpdate();
    }
}
