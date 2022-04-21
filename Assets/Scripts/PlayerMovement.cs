using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    Vector3  moveVector = new Vector3 (1, 0,0);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            moveVector = new Vector3(0, 1.0f,0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveVector = new Vector3( -1.0f, 0,0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveVector = new Vector3(0, -1.0f,0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            moveVector = new Vector3(1.0f, 0,0);
        }


        transform.position = transform.position + moveVector * Time.deltaTime;


    }
}
