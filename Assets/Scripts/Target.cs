using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int health = 10;
    public Collider skin;

    void Start()
    {
        skin = GetComponent<Collider>();
    }

    void Update()
    {

    }

    void takeDamage(int amount)
    {
        Debug.Log(this.ToString() + "took damage");
        health -= amount;
    }
}
