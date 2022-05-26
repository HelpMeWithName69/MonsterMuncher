using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float playerSpeed = 0.02f;
    
    [SerializeField] public float playerHealth = 100f;

    private float dirX = 0f;

    float xmin;
    float xmax;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
        Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0));
        xmin = leftmost.x;
        xmax = rightmost.x;
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");

        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, 1, 0) * playerSpeed;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0, -1, 0) * playerSpeed;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-1, 0, 0) * playerSpeed;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(1, 0, 0) * playerSpeed;
        }


        if (dirX > 0f)
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }

        if (dirX < 0f)
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }


        float newX = Mathf.Clamp(transform.position.x, xmin, xmax);
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerHealth -= 50f;

        if (playerHealth <= 0)
        {
            Destroy(gameObject);
        }
    }


}
