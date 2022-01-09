using UnityEngine;


[CreateAssetMenu(fileName = "Element", menuName = "Element")]
public class Element : ScriptableObject
{
    public publicEnums.ElementType type;
    public Gradient gradient;
    public Color primaryColor;
    public float gravity;
}
