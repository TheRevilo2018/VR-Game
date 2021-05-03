using UnityEngine;

public class healthScript : MonoBehaviour
{
    public int health = 100;

    public void takeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            die();
        }
    }

    public void die()
    {
        Destroy(gameObject);
    }
}
