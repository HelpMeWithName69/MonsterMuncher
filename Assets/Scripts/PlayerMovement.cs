using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public static int Health = 100;

    float playerSpeed = 0.02f;
    
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
    public void Update()
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

        
        void OnTriggerEnter2D(Collider2D collision)
        {
            if (Health < 0)
            {
                Health--;
                Application.LoadLevel("Lose");
            }
        }
    }
}
