using UnityEngine;
using UnityEngine.XR;

public class shootObject : MonoBehaviour
{
    public GameObject projectile;
    public float projectileForce = 50f;
    public Transform spawnPoint;
    private Element element;

    public void shoot()
    {
        GameObject lastShot;
        lastShot = Instantiate(projectile, spawnPoint.position, spawnPoint.rotation);
        lastShot.GetComponent<Rigidbody>().AddRelativeForce(-Vector3.up * projectileForce);
        lastShot.GetComponent<boltScript>().chooseElement(element);
    }

    public void setElement(Element elm)
    {
        element = elm;
    }
}
