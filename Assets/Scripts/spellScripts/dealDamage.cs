using UnityEngine;

public class dealDamage : MonoBehaviour
{
    public int damage = 1;
    public publicEnums.ElementType type;

    private void OnParticleCollision(GameObject other)
    {
        other.SendMessage("takeDamage", damage, SendMessageOptions.DontRequireReceiver);
    }
}
