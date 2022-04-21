using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    Vector3  moveVector = new Vector3 (1, 0,0);
    public GameObject trail;
    public bool dataInHand;
    public GameObject spawnlocation;
    int numberOfLives = 2;
    public GameManager gameManager;
    public GameObject loseCanvas;
    public GameObject livesObj;
    [SerializeField] TextMeshProUGUI livesText;
    // Start is called before the first frame update
    void Start()
    {
        livesObj.SetActive(true);
        livesText.text = "Number Of Lives: " + numberOfLives.ToString();
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


        transform.position = transform.position + moveVector * Time.deltaTime *movementSpeed;


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Goal")
        {
            Debug.Log("Goal");
            if (!dataInHand)
            {
                trail.SetActive(true);
                Destroy(collision.gameObject);
                dataInHand = true;
            }
        }
        if (collision.gameObject.tag == "Border")
        {
            
            ResetLife();
        }
        if (collision.gameObject.tag == "Reciever")
        {
            if (dataInHand)
            {
                if (trail != null)
                {
                    trail.SetActive(false);
                    dataInHand = false;
                    gameManager.numberOfGoals--;
                }

            }
            Debug.Log("y");
        }
    }
    void ResetLife()
    {
        if (numberOfLives > 0)
        {
            numberOfLives--;
            transform.position = spawnlocation.transform.position;
            moveVector = new Vector3(1.0f, 0, 0);
            livesText.text = "Number Of Lives: " + numberOfLives.ToString();

        }
        else
        {
            loseCanvas.SetActive(true);
            Destroy(this);
        }
    }
}
