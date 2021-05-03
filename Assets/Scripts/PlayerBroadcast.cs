using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBroadcast : MonoBehaviour
{
    public List<GameObject> recivers = new List<GameObject>();

    public void BroadcastAll(string message, object arguments)
    {
        foreach(GameObject reciver in recivers)
        {
            reciver.BroadcastMessage(message, arguments,SendMessageOptions.DontRequireReceiver);
        }
    }
}
