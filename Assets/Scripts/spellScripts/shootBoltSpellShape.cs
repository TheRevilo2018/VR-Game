using UnityEngine;
using UnityEngine.XR;

public class shootBoltSpellShape : MonoBehaviour
{
    public GameObject bolt;
    public float projectileForce = 50f;
    public Transform spawnPoint;

    void press()
    {
        Instantiate(bolt, spawnPoint.position, spawnPoint.rotation);
    }
}
