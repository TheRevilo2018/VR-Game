using UnityEngine;

public class spellParentOld : MonoBehaviour
{
    private GameObject shape;
    private Element element;
    bool hasShape = false;

    public MeshRenderer mat;

    void changeElement(Element newElement)
    {
        //element = newElement;
        //mat.material.color = element.primaryColor;

        /*
        if (hasShape)
        {
            shape.SendMessage("setParticleSystem", element, SendMessageOptions.DontRequireReceiver);
        }
        */
    }

    void changeShape(GameObject newShape)
    {
        hasShape = true;
        shape = newShape;

        shape.transform.parent = transform;
        shape.transform.localPosition = new Vector3(0f, 0f, 0f);
    }

    void parentPress()
    {
        BroadcastMessage("press", SendMessageOptions.DontRequireReceiver);
    }

    void parentRelease()
    {
        BroadcastMessage("release", SendMessageOptions.DontRequireReceiver);
    }
}
