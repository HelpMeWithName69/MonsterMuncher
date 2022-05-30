using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartFormation : MonoBehaviour
{
    public GameObject heartPrefab;

    public bool movingright = true;

    public float width = 10;
    public float height = 5;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in transform)
        {
            GameObject heart = Instantiate(heartPrefab, child.transform.position, Quaternion.identity) as GameObject;

            heart.transform.parent = child;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (movingright)
        {
            transform.position += new Vector3(0.0025f, 0);
        }
        else
        {
            transform.position += new Vector3(-0.0025f, 0);
        }

        float rightEdgeOfFormation = transform.position.x + (0.025f * width);
        float leftEdgeOfFormation = transform.position.x - (0.025f * width);

        if (rightEdgeOfFormation > 10)
        {
            movingright = false;
        }
        if (leftEdgeOfFormation < 8)
        {
            movingright = true;
        }
    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height));
    }
}
