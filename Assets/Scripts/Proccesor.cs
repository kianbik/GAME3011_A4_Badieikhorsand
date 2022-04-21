using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Proccesor : MonoBehaviour
{
    float timeLeft = 10.0f;
   public bool timerStart;
    public SpriteRenderer sprenderer;
    public bool ready;
    public GameObject pass;
    [SerializeField] TextMeshProUGUI passText;
    GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timerStart)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                Ready();
            }
        }
    }
    void Ready()
    {
        sprenderer.color = Color.white;
        ready = true;
    }
    public void ResetReady()
    {
        sprenderer.color = Color.red;
        timerStart = false;
        timeLeft = 10.0f;
        pass.SetActive(true);

        gm.password = (Random.Range(0, 1000).ToString());
        passText.text = "Code: " + gm.password;
    }
}
