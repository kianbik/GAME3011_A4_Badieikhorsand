using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proccesor : MonoBehaviour
{
    float timeLeft = 10.0f;
   public bool timerStart;
    public SpriteRenderer sprenderer;
    public bool ready;
    // Start is called before the first frame update
    void Start()
    {
        
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
    }
}
