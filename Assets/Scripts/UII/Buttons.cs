using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Buttons : MonoBehaviour
{
    public GameObject MainMenuCanvas;
    public GameObject InstructionsCanvas;
    public GameObject CreditsCanvas;
    public GameObject DifficultyCanvas;


    public AudioClip ClickClip;
    public AudioSource audioSource;

    public GameManager gameManager;
    public void OnPlayClicked()
    {
        SceneManager.LoadScene("MainLevel");
    }

    public void OnMainMenuClicked()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void OnCreditsClicked()
    {
        CreditsCanvas.SetActive(true);
        MainMenuCanvas.SetActive(false);
        InstructionsCanvas.SetActive(false);
    }
    public void OnInstructionsClicked()
    {
        InstructionsCanvas.SetActive(true);
        MainMenuCanvas.SetActive(false);
        CreditsCanvas.SetActive(false);
    }

    public void OnBackClicked()
    {

        CreditsCanvas.SetActive(false);
        InstructionsCanvas.SetActive(false);
        MainMenuCanvas.SetActive(true);
    }

    public void OnExitClicked()
    {
        Application.Quit();
    }
    //Game scene Buttons
    public void OnEasyClicked()
    {
        gameManager.difficultySelected = GameManager.Difficulty.Easy;
        gameManager.isSelected = true;
        gameManager.GameStart();
        DifficultyCanvas.SetActive(false);
    }
    public void OnMediumClicked()
    {
        gameManager.difficultySelected = GameManager.Difficulty.Medium;
        gameManager.isSelected = true;
        gameManager.GameStart();
        DifficultyCanvas.SetActive(false);
    }
    public void OnHardClicked()
    {
        gameManager.difficultySelected = GameManager.Difficulty.Hard;
        gameManager.isSelected = true;
        gameManager.GameStart();
        DifficultyCanvas.SetActive(false);
    }


    public void ClickSound()
    {
        audioSource.PlayOneShot(ClickClip);
    }
}
