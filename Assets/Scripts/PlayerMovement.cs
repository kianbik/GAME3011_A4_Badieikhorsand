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
    public bool proccesedDataInHand;
    public GameObject spawnlocation;
    int numberOfLives = 2;
    public GameManager gameManager;
    public GameObject loseCanvas;
    public GameObject livesObj;
    [SerializeField] TextMeshProUGUI livesText;

    public AudioSource audiosrc;
    public AudioClip pickupSound;
    public AudioClip dropupSound;
    public AudioClip hitSound;
    public Proccesor proccesor;
    public LayerMask everythingMask;
    public Camera mainCam;
    // Start is called before the first frame update
    void Start()
    {
        livesObj.SetActive(true);
        livesText.text = "Number Of Lives: " + numberOfLives.ToString();
        proccesor = FindObjectOfType<Proccesor>();
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
        if (collision.gameObject.tag == "Light")
        {
            mainCam.cullingMask = everythingMask;
        }
        if (collision.gameObject.tag == "Goal")
        {
            Debug.Log("Goal");
            if (!dataInHand)
            {
                trail.SetActive(true);
                Destroy(collision.gameObject);
                dataInHand = true;
                audiosrc.clip = pickupSound;
                audiosrc.Play();
            }
        }
        if (collision.gameObject.tag == "Border")
        {
            
            ResetLife();
        }
        if (collision.gameObject.tag == "Reciever")
        {
            if (proccesedDataInHand)
            {
                if (trail != null)
                {
                    trail.SetActive(false);
                    dataInHand = false;
                    gameManager.numberOfGoals--;
                    audiosrc.clip = dropupSound;
                    audiosrc.Play();
                }

            }
        }
        if (collision.gameObject.tag == "Proccesor")
        {
            if (dataInHand)
            {
                if (trail != null)
                {
                    trail.SetActive(false);
                    dataInHand = false;
                    audiosrc.clip = dropupSound;
                    audiosrc.Play();
                    proccesor.timerStart = true;
                }

            }
            if (!dataInHand && proccesor.ready)
            {
                if (trail != null)
                {
                    trail.SetActive(true);
                    proccesedDataInHand = true;
                    audiosrc.clip = pickupSound;
                    audiosrc.Play();
                    proccesor.ResetReady();
                }

            }
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
            audiosrc.clip = hitSound;
            audiosrc.Play();
        }
        else
        {
            loseCanvas.SetActive(true);
            Destroy(this);
        }
    }
}
