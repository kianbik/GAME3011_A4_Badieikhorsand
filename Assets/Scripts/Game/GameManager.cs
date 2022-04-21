using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    public enum Difficulty { Easy, Medium, Hard};

   public Difficulty difficultySelected;
   public bool isSelected;
    public PlayerMovement player;
    public int numberOfGoals;
    public GameObject reciever;
    public GameObject easyBoard;
    public GameObject mediumBoard;
    public GameObject hardBoard;
    public GameObject winCanvas;
    public GameObject passCanvas;
    public AudioSource audiosrc;
    public string password;
    public TMP_InputField passwordChecker;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isSelected)
        {
            if (numberOfGoals == 0)
            {
                
                player.gameObject.SetActive(false);
                easyBoard.gameObject.SetActive(false);
                mediumBoard.gameObject.SetActive(false);
                hardBoard.gameObject.SetActive(false);
                reciever.gameObject.SetActive(false);
                player.livesObj.SetActive(false);
                if(!audiosrc.isPlaying)
                audiosrc.Play();
            }
        }
        
    }
   public void GameStart()
    {
        if (difficultySelected == Difficulty.Easy)
        {
            player.movementSpeed = 1.0f;
            numberOfGoals = 1;
            easyBoard.gameObject.SetActive(true);
        }

        if (difficultySelected == Difficulty.Medium)
        {
            player.movementSpeed = 2.0f;
            numberOfGoals = 1;
            mediumBoard.gameObject.SetActive(true);
        }

        if (difficultySelected == Difficulty.Hard)
        {
            player.movementSpeed = 2.0f;
            numberOfGoals = 2;
            hardBoard.gameObject.SetActive(true);
        }
        player.gameObject.SetActive(true);
        reciever.gameObject.SetActive(true);
    }
    public void onValuechanged()
    {
        if (passwordChecker.text == password)
        {
            passCanvas.SetActive(false);
            winCanvas.SetActive(true);
        }
    }
}
