using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellLoom : MonoBehaviour
{
    private static List<Vector3> nodeLocations = new List<Vector3>{
    new Vector3(1, 1, 0),
    new Vector3(-1, 1, 0),
    new Vector3(-1, -1, 0),
    new Vector3(1, -1, 0)};

    List<LoomNode> nodes = new List<LoomNode>();

    public static GameObject nodePrefab;



    // Start is called before the first frame update
    void Start()
    {
        foreach (Vector3 loc in nodeLocations)
        {
            GameObject newNode = Instantiate(nodePrefab);
            nodes.Add(newNode.GetComponent<LoomNode>());
        }

        deactivate();
    }

    void deactivate()
    {
        for (int i = 0; i < nodes.Count; i++)
        {
            nodes[i].gameObject.SetActive(false);
        }
    }

    void activate()
    {
        for (int i = 0; i < nodes.Count; i++)
        {
            nodes[i].gameObject.SetActive(true);
            nodes[i].transform.position = transform.TransformPoint(nodeLocations[i]);
            nodes[i].transform.rotation = transform.rotation;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
